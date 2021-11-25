using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using ictus.PIS.Welfare.Entity.LoanEntities;
using PTB.PIS.Welfare.Facade;
using PTB.PIS.Welfare.WindowsApp.CommonGUI;
using Presentation.CommonGUI;
using SystemFramework.AppConfig;
using PTB.PIS.Welfare.ReportApp.GUI.MasterDataGUI;

namespace PTB.PIS.Welfare.WindowsApp.LoanGUI {
    public partial class FrmLoanResonLst : ChildFormBase, IMDIChildForm
    {
        private List<LoanReson> items;
        private bool isReadonly = true;
        private Presentation.frmMain mdiParent;

        public FrmLoanResonLst() :base(){
            InitializeComponent();

            isReadonly = UserProfile.IsReadOnly("miWelfare", "miWelfareSettingLoanReasonList");
            this.Text = UserProfile.GetFormName("miWelfare", "miWelfareSettingLoanReasonList");
        }
        
        protected override void From_Load(object sender, EventArgs e) {
            base.From_Load(sender, e);
            mdiParent = (Presentation.frmMain)this.MdiParent;
            InitForm();
        }

        private void LockReadonly() {
            btnInsert.Enabled = !this.isReadonly;
            //btnUpdate.Enabled = !this.isReadonly;
            btnDelete.Enabled = !this.isReadonly;
            insertToolStripMenuItem.Enabled = !this.isReadonly;
            deleteToolStripMenuItem.Enabled = !this.isReadonly;

        }
        #region IMDIChildFormGUI Members

        public void ExitForm()
        {
            this.Close();
        }

        public void InitForm()
        {
            BindData();

            mdiParent.EnableRefreshCommand(true);
            MainMenuRefreshStatus = true; ;

            mdiParent.EnablePrintCommand(true);
            MainMenuPrintStatus = true;
            LockReadonly();
        }

        public void PrintForm()
        {
            FrmReportMasterData frmReport = new FrmReportMasterLoanReson();
            frmReport.MdiParent = this.MdiParent;
            frmReport.Show();
        }

        public void RefreshForm()
        {
            InitForm();
        }

        public override string FormID()
        {
            return UserProfile.GetFormID("miWelfare", "miWelfareSettingLoanReasonList");
        }

        public override int MasterCount()
        {
            return this.items.Count;
        }

        #endregion

        private void BindData() {
            this.items = LoanFacade.GetAllLoanReson();
            int rowIndex = 0;
            grdData.Rows.Clear();
            foreach (LoanReson item in this.items) {
                grdData.RowCount++;
                grdData.Rows[rowIndex].Tag = item;
                grdData.Rows[rowIndex].Cells["coluCode"].Value = item.Code;
                grdData.Rows[rowIndex].Cells["coluThaiName"].Value = item.ThaiName;
                grdData.Rows[rowIndex].Cells["coluEngName"].Value = item.EngName;
                rowIndex++;
            }

            mdiParent.RefreshMasterCount();
            PTB.PIS.Welfare.WindowsApp.CommonGUI.Common.PaintHeaderSeq(grdData);

        }

        private LoanReson GetSelectData() {
            if (grdData.SelectedRows.Count > 0)
                if (grdData.SelectedRows[0] != null)
                    return (LoanReson)grdData.SelectedRows[0].Tag;
                else
                    return null;
            else
                return null;

        }

        private void InsertData() {
            FrmLoanResonEnt frmEnt = new FrmLoanResonEnt(new LoanReson(), DataFormStatus.Insert,this.isReadonly);
            frmEnt.SaveDataCompleted += new FrmLoanResonEnt.SaveDataCompleteHandler(this.SaveDataCompleted);
            frmEnt.ShowDialog();
        }

        private void UpdateData() {
            LoanReson item = GetSelectData();
            if (item != null) {
                FrmLoanResonEnt frmEnt = new FrmLoanResonEnt(item, DataFormStatus.Update, this.isReadonly);
                frmEnt.SaveDataCompleted += new FrmLoanResonEnt.SaveDataCompleteHandler(this.SaveDataCompleted);
                frmEnt.ShowDialog();
            }
        }

        private void DeleteData() {
            LoanReson item = GetSelectData();
            if (item != null) {
                try {
                    if (Mbox.ConfirmMessage(@"คุณต้องการลบรายการนี้ใช่หรือไม่?") == DialogResult.Yes) {
                        LoanFacade.UpdateLoanReson(item, FacadeBase.Status.Delete);
                        BindData();
                    }
                } catch (Exception ex) {
                    Mbox.ErrorMessage(ex.Message);
                }

            }

        }

        private void SaveDataCompleted() { BindData(); }

        

        private void btnInsert_Click(object sender, EventArgs e) {
            InsertData();
        }

        private void btnUpdate_Click(object sender, EventArgs e) {
            UpdateData();
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            DeleteData();
        }

        private void grdData_DoubleClick(object sender, EventArgs e) {
            UpdateData();
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

        private void grdData_Sorted(object sender, EventArgs e) {
            PTB.PIS.Welfare.WindowsApp.CommonGUI.Common.PaintHeaderSeq(grdData);
        }
    }
}