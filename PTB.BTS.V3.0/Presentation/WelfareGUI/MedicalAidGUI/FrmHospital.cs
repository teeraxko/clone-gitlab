using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ictus.PIS.Welfare.Entity.MedicalAidEntities;
using PTB.PIS.Welfare.Facade;
using ictus.PIS.Welfare.Entity.CommonEntities;
using PTB.PIS.Welfare.WindowsApp.CommonGUI;
using Presentation.CommonGUI;
using SystemFramework.AppConfig;
using PTB.PIS.Welfare.ReportApp.GUI.MasterDataGUI;

namespace PTB.PIS.Welfare.WindowsApp.MedicalAidGUI {
    public partial class FrmHospital : ChildFormBase, IMDIChildForm
    {
        #region Private Variable
        private bool isReadonly = true;
        private Presentation.frmMain mdiParent;
        private const string DUMMY = "99"; 
        #endregion

        #region Constructor
        public FrmHospital()
            : base()
        {
            InitializeComponent();
            isReadonly = UserProfile.IsReadOnly("miWelfare", "miWelfareSettingHospital");
            this.title = UserProfile.GetFormName("miWelfare", "miWelfareSettingHospital");
        } 
        #endregion

        private List<Hospital> hospitals;

        #region IMDIChildForm Members

        public void ExitForm() {
            this.Close();
        }

        private void LockReadonly() {
            btnInsert.Enabled = !this.isReadonly;
            //btnUpdate.Enabled = !this.isReadonly;
            btnDelete.Enabled = !this.isReadonly;
            insertToolStripMenuItem.Enabled = !this.isReadonly;
            deleteToolStripMenuItem.Enabled = !this.isReadonly;

        }


        public void InitForm(){
            BindData();
            mdiParent.EnableRefreshCommand(true);
            MainMenuRefreshStatus = true;
            
            mdiParent.EnablePrintCommand(true);
            MainMenuPrintStatus = true;
            LockReadonly();

        }

        public void PrintForm() 
        {
            FrmReportMasterData frmReport = new FrmReportMasterHospital();
            frmReport.MdiParent = this.MdiParent;
            frmReport.Show();
        }

        public void RefreshForm(){
            InitForm();
        }

        public override string FormID()
        {
            return UserProfile.GetFormID("miWelfare", "miWelfareSettingHospital");
        }

        public override int MasterCount()
        {
            return this.hospitals.Count;
        }
        #endregion

        private void BindData() {
            this.hospitals = MedicalAidFacade.GetListOfContractHospital();
            int rowIndex = 0;
            grdData.Rows.Clear();
            foreach (Hospital hospital in this.hospitals) {
                grdData.RowCount++;
                grdData.Rows[rowIndex].Tag = hospital;
                grdData.Rows[rowIndex].Cells["coluCode"].Value = hospital.Code;
                grdData.Rows[rowIndex].Cells["coluThaiName"].Value = hospital.ThaiName;
                grdData.Rows[rowIndex].Cells["coluEngName"].Value = hospital.EngName;
                rowIndex++;
            }

            mdiParent.RefreshMasterCount();
            PTB.PIS.Welfare.WindowsApp.CommonGUI.Common.PaintHeaderSeq(grdData);
        }

        private void InsertData() {
            FrmHospitalEnt frmEnt = new FrmHospitalEnt(new Hospital(), DataFormStatus.Insert,this.isReadonly);
            frmEnt.SaveDataCompleted += new FrmHospitalEnt.SaveDataCompleteHandler(this.SaveDataCompleted);
            frmEnt.ShowDialog();
        }

        private void UpdateData() {
            Hospital hospital = GetSelectData();
            if (hospital != null) {
                FrmHospitalEnt frmEnt = new FrmHospitalEnt(hospital, DataFormStatus.Update,this.isReadonly);
                frmEnt.SaveDataCompleted += new FrmHospitalEnt.SaveDataCompleteHandler(this.SaveDataCompleted);
                frmEnt.ShowDialog();
            }
        }

        private void DeleteData()
        {
            if (ValidateDelete())
            {
                Hospital hospital = GetSelectData();

                if (hospital != null)
                {
                    try
                    {
                        if (Mbox.ConfirmMessage(@"คุณต้องการลบรายการนี้ใช่หรือไม่?") == DialogResult.Yes)
                        {
                            MedicalAidFacade.UpdateHospital(hospital, ContributionFacade.Status.Delete);
                            BindData();
                        }
                    }
                    catch (Exception ex)
                    {
                        Mbox.ErrorMessage(ex.Message);
                    }
                }
            }
        }

        private Hospital GetSelectData() {
            if (grdData.SelectedRows.Count > 0)
                if (grdData.SelectedRows[0] != null)
                    return (Hospital)grdData.SelectedRows[0].Tag;
                else
                    return null;
            else
                return null;
        }

        private bool ValidateDelete()
        {
            if (grdData.CurrentRow.Tag != null)
            {
                if (((Hospital)grdData.CurrentRow.Tag).Code.Trim() == DUMMY)
                {
                    Mbox.ErrorMessage("ไม่สามารถลบข้อมูลนี้ได้ เนื่องจากเป็นรหัสของระบบ");
                    return false;
                }
            }

            return true;
        }

        private void btnInsert_Click(object sender, EventArgs e) {
            InsertData();
        }

        protected override void From_Load(object sender, EventArgs e) {
            base.From_Load(sender, e);
            mdiParent = (Presentation.frmMain)this.MdiParent;
            InitForm();
        }

        private void btnUpdate_Click(object sender, EventArgs e) {
            UpdateData();
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            DeleteData();
        }

        private void lstData_DoubleClick(object sender, EventArgs e) {
            UpdateData();
        }

        private void SaveDataCompleted() {
            BindData();
        }

        private void insertToolStripMenuItem_Click(object sender, EventArgs e) {
            InsertData();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e) {
            UpdateData();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e) {
            DeleteData();
        }

        private void grdData_DoubleClick(object sender, EventArgs e) {
            UpdateData();
        }

        private void grdData_Sorted(object sender, EventArgs e) {
            PTB.PIS.Welfare.WindowsApp.CommonGUI.Common.PaintHeaderSeq(grdData);
        }        
    }
}