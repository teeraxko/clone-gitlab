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
using SystemFramework.AppConfig;
using Presentation.CommonGUI;

namespace PTB.PIS.Welfare.WindowsApp.ContributionGUI {
    public partial class FrmContributionEmpLst : PTB.PIS.Welfare.WindowsApp.FrmWelfareHeaderBase,IMDIChildForm {
        List<ContributionApplication> apps;
        

        public FrmContributionEmpLst():base() {
            InitializeComponent();
            this.grdData.ContextMenuStrip = this.cMenu;

            isReadonly = UserProfile.IsReadOnly("miWelfare", "miWelfareContributionEmpList");
            this.title = UserProfile.GetFormName("miWelfare", "miWelfareContributionEmpList");
        }

        protected override void From_Load(object sender, EventArgs e) {
            base.From_Load(sender, e);
            InitForm();
            this.LockControl();
        }

        public override string FormID()
        {
            return UserProfile.GetFormID("miWelfare", "miWelfareContributionEmpList");
        }

        public override int MasterCount()
        {
            return this.apps.Count;
        }

        public override void InitForm()
        {
            base.InitForm();
            mdiParent.RefreshMasterCount();
        }

        public override void RefreshForm()
        {
            base.RefreshForm();
        }

        public override void FillDetail() {
            base.FillDetail();
            BindList();
            this.DisbleMenuBtn(apps.Count);
        }

        private ContributionApplication GetSelectData() {
            if (grdData.SelectedRows.Count > 0)
                if (grdData.SelectedRows[0] != null)
                    return (ContributionApplication)grdData.SelectedRows[0].Tag;
                else
                    return null;
            else
                return null;

        }

        private void BindList() {
            apps = ContributionFacade.FillContributionApplicationByEmployee(emp);
            int rowIndex = 0;
            grdData.Rows.Clear();
            foreach (ContributionApplication app in this.apps) {
                grdData.RowCount++;
                grdData.Rows[rowIndex].Tag = app;
                grdData.Rows[rowIndex].Cells["coluDate"].Value = app.AppliedDate.ToString("dd/MM/yyyy");
                grdData.Rows[rowIndex].Cells["coluContribution"].Value = app.Contribution.ThaiDescription;
                grdData.Rows[rowIndex].Cells["coluAmount"].Value = app.AppliedAmount.ToString("N2");
                rowIndex++;
            }

            mdiParent.RefreshMasterCount();
            PTB.PIS.Welfare.WindowsApp.CommonGUI.Common.PaintHeaderSeq(grdData);
        }



        protected override void InsertData() {
            ContributionApplication app = new ContributionApplication();
            app.Employee = this.emp;
            FrmContributionApplicationEnt frm = new FrmContributionApplicationEnt(app, DataFormStatus.Insert,this.isReadonly);
            frm.SaveDataCompleted += new FrmContributionApplicationEnt.SaveDataCompleteHandler(this.SaveDataCompleted);
            frm.ShowDialog();

        }

        protected override void UpdateData() {
            ContributionApplication app = GetSelectData();
            if (app != null) {
                FrmContributionApplicationEnt frm = new FrmContributionApplicationEnt(app, DataFormStatus.Update, this.isReadonly);
                frm.SaveDataCompleted += new FrmContributionApplicationEnt.SaveDataCompleteHandler(this.SaveDataCompleted);
                frm.ShowDialog();

            }
        }

        private void SaveDataCompleted() {
            FillDetail();
        }


        protected override void DeleteData() {
            ContributionApplication app = GetSelectData();
            if (app != null) {
                try {
                    if (Mbox.ConfirmMessage(@"คุณต้องการลบรายการนี้ใช่หรือไม่?") == DialogResult.Yes) {
                        ContributionFacade.UpdateContributionApplication(app, FacadeBase.Status.Delete);
                        SaveDataCompleted();
                    }
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                } finally {

                }
            }
        }

        private void grdData_DoubleClick(object sender, EventArgs e) {
            UpdateData();
        }

        private void grdData_Sorted(object sender, EventArgs e) {
            PTB.PIS.Welfare.WindowsApp.CommonGUI.Common.PaintHeaderSeq(grdData);
        }
    }
}

