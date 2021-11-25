using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using ictus.PIS.Welfare.Entity.ContributionEntities;
using PTB.PIS.Welfare.Facade;
using PTB.PIS.Welfare.WindowsApp.CommonGUI;
using Presentation.CommonGUI;
using SystemFramework.AppConfig;
using PTB.PIS.Welfare.ReportApp.GUI.MasterDataGUI;

namespace PTB.PIS.Welfare.WindowsApp.ContributionGUI {
    public partial class FrmContribution : ChildFormBase, IMDIChildForm {
        public FrmContribution() :base(){
            InitializeComponent();
            isReadonly = UserProfile.IsReadOnly("miWelfare", "miWelfareSettingContribution");
            this.title = UserProfile.GetFormName("miWelfare", "miWelfareSettingContribution");
        }
        protected override void From_Load(object sender, EventArgs e) {
            base.From_Load(sender, e);
            mdiParent = (Presentation.frmMain)this.MdiParent;
            InitForm();
        }

        private List<Contribution> contributions;

        private bool isReadonly = true;
        private Presentation.frmMain mdiParent;

        #region IMDIChildForm Members

        public void ExitForm() {
            this.Close();
        }

        public void InitForm() {
            BindData();
            mdiParent.EnableRefreshCommand(true);
            MainMenuRefreshStatus = true;

            mdiParent.EnablePrintCommand(true);
            MainMenuPrintStatus = true;

            LockReadonly();
        }

        private void LockReadonly()
        {
            btnInsert.Enabled = !this.isReadonly;
            //btnUpdate.Enabled = !this.isReadonly;
            btnDelete.Enabled = !this.isReadonly;
            insertToolStripMenuItem.Enabled = !this.isReadonly;
            deleteToolStripMenuItem.Enabled = !this.isReadonly;
                       
        }


        public void PrintForm() {
            FrmReportMasterData frmReport = new FrmReportMasterContribution();
            frmReport.MdiParent = this.MdiParent;
            frmReport.Show();
        }

        public void RefreshForm() {
            InitForm();
        }
        
        public override string FormID() {
            return UserProfile.GetFormID("miWelfare", "miWelfareSettingContribution");
        }

        public override int MasterCount()
        {
            return this.contributions.Count;
        }
        
        #endregion

        private void InsertData() {
            FrmContributionEnt frmEnt = new FrmContributionEnt(new Contribution(), DataFormStatus.Insert,this.isReadonly);
            frmEnt.SaveDataCompleted += new FrmContributionEnt.SaveDataCompleteHandler(this.SaveDataCompleted);
            frmEnt.ShowDialog();
        }

        private void UpdateData() {
            Contribution contribution = GetSelectData();
            if (contribution != null) {
                FrmContributionEnt frmEnt = new FrmContributionEnt(contribution, DataFormStatus.Update, this.isReadonly);
                frmEnt.SaveDataCompleted += new FrmContributionEnt.SaveDataCompleteHandler(this.SaveDataCompleted);
                frmEnt.ShowDialog();
            }
        }

        private void DeleteData() {
            Contribution contribution = GetSelectData();
            if (contribution != null) {
                try {
                    if (Mbox.ConfirmMessage(@"คุณต้องการลบรายการนี้ใช่หรือไม่?") == DialogResult.Yes ) {
                        ContributionFacade.UpdateContribution(contribution, ContributionFacade.Status.Delete);
                        BindData();
                    }
                } catch(Exception ex) {
                    Mbox.ErrorMessage(ex.Message);
                }

            }

        }


        private Contribution GetSelectData() {
            if (grdData.SelectedRows.Count > 0)
                if (grdData.SelectedRows[0] != null)
                    return (Contribution)grdData.SelectedRows[0].Tag;
                else
                    return null;
            else
                return null;
        }



        private void btnInsert_Click(object sender, EventArgs e) {
            InsertData();
        }


        private void btnUpdate_Click(object sender, EventArgs e) {
            UpdateData();
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            DeleteData();
        }

        private void BindData() {

            this.contributions = ContributionFacade.GetAllContributionList();
            int rowIndex = 0;
            grdData.Rows.Clear();
            foreach (Contribution contribution in this.contributions) {
                grdData.RowCount++;
                grdData.Rows[rowIndex].Tag = contribution;
                grdData.Rows[rowIndex].Cells["coluCode"].Value = contribution.Code;
                grdData.Rows[rowIndex].Cells["coluName"].Value = contribution.ThaiDescription;
                grdData.Rows[rowIndex].Cells["coluEngName"].Value = contribution.EngDescription;
                grdData.Rows[rowIndex].Cells["coluAmount"].Value = contribution.ContributionAmount;
                rowIndex++;
            }

            mdiParent.RefreshMasterCount();
            PTB.PIS.Welfare.WindowsApp.CommonGUI.Common.PaintHeaderSeq(grdData);

        }

        private void lstData_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e) {
            MessageBox.Show("Test");
        }

        private void lstData_DoubleClick(object sender, EventArgs e) {
            UpdateData();
        }


        private void SaveDataCompleted() {
            BindData();
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