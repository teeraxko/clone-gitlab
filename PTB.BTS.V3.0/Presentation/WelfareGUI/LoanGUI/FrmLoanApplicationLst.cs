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
using SystemFramework.AppConfig;
using Presentation.CommonGUI;
using ictus.PIS.PI.Entity;

namespace PTB.PIS.Welfare.WindowsApp.LoanGUI
{
    public partial class FrmLoanApplicationLst : PTB.PIS.Welfare.WindowsApp.FrmWelfareHeaderBase, IMDIChildForm
    {
        List<LoanApplication> apps;

        int currentSelectYear = DateTime.Now.Year;

        public FrmLoanApplicationLst()
            : base()
        {
            InitializeComponent();
            this.grdData.ContextMenuStrip = this.cMenu;

            isReadonly = UserProfile.IsReadOnly("miWelfare", "miWelfareLoanAppList");
            this.title = UserProfile.GetFormName("miWelfare", "miWelfareLoanAppList");
        }

        #region Public Method
        public override string FormID()
        {
            return UserProfile.GetFormID("miWelfare", "miWelfareLoanAppList");
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

        public override void FillDetail()
        {
            base.FillDetail();
            apps = LoanFacade.GetLoanApplicationByEmployee(this.emp);
            BindList();
            this.DisbleMenuBtn(apps.Count);
        } 
        #endregion

        #region Private Method
        private LoanApplication GetSelectData()
        {
            if (grdData.SelectedRows.Count > 0)
                if (grdData.SelectedRows[0] != null)
                    return (LoanApplication)grdData.SelectedRows[0].Tag;
                else
                    return null;
            else
                return null;

        }

        private void BindList()
        {
            int rowIndex = 0;
            grdData.Rows.Clear();
            foreach (LoanApplication app in this.apps)
            {
                // if (currentSelectYear == app.AppliedDate.Year) {
                grdData.RowCount++;
                grdData.Rows[rowIndex].Tag = app;
                grdData.Rows[rowIndex].Cells["colCreateDate"].Value = app.AppliedDate.ToString("dd/MM/yyyy");
                grdData.Rows[rowIndex].Cells["colPurpose"].Value = app.LoanReson.ThaiName;
                grdData.Rows[rowIndex].Cells["colStartDate"].Value = app.StartDate.ToString("dd/MM/yyyy");
                grdData.Rows[rowIndex].Cells["colEndDate"].Value = app.EndDate.ToString("dd/MM/yyyy");
                grdData.Rows[rowIndex].Cells["colPeriod"].Value = app.Period;
                grdData.Rows[rowIndex].Cells["colCapital"].Value = app.CapitalAmount.ToString("N2");
                grdData.Rows[rowIndex].Cells["colInterest"].Value = app.InterestRate.ToString("N2") + "%";
                //                    grdData.Rows[rowIndex].Cells["colPaid"].Value = (app.PaidAmount + app.OffsetAmount).ToString("N2");
                grdData.Rows[rowIndex].Cells["colPaid"].Value = app.PaidAmount.ToString("N2");
                grdData.Rows[rowIndex].Cells["colBalance"].Value = app.BalanceAmount.ToString("N2");
                grdData.Rows[rowIndex].Cells["colStatus"].Value = app.PaymentStatus;
                rowIndex++;
                // }
            }
            mdiParent.RefreshMasterCount();
            PTB.PIS.Welfare.WindowsApp.CommonGUI.Common.PaintHeaderSeq(grdData);


        }

        private void SaveDataCompleted()
        {
            FillDetail();
        }

        private bool ValidateSave()
        {
            EmployeeInfo empInfo = LoanFacade.GetEmployeeInfo(this.emp.EmployeeNo);

            if (empInfo != null && empInfo.PFToDate.HasValue && empInfo.PFToDate.Value.Date <= DateTime.Today)
            {
                Mbox.ErrorMessage("ไม่สามารถเพิ่มข้อมูลเงินกู้ได้ เนื่องจากพนักงานที่ระบุลาออกจากกองทุนสำรองเลี้ยงชีพแล้ว !");
                return false;
            }

            return true;
        } 
        #endregion

        #region Protected Method
        protected override void InsertData()
        {
            if (ValidateSave())
            {
                LoanApplication app = new LoanApplication();
                app.Employee = this.emp;
                FrmLoanApplicationEnt frm = new FrmLoanApplicationEnt(app, DataFormStatus.Insert, this.isReadonly);
                frm.SaveDataCompleted += new FrmLoanApplicationEnt.SaveDataCompleteHandler(this.SaveDataCompleted);
                frm.ShowDialog();
            }
        }

        protected override void UpdateData()
        {
            LoanApplication app = GetSelectData();
            if (app != null)
            {
                FrmLoanApplicationEnt frm = new FrmLoanApplicationEnt(app, DataFormStatus.Update, this.isReadonly);
                frm.SaveDataCompleted += new FrmLoanApplicationEnt.SaveDataCompleteHandler(this.SaveDataCompleted);
                frm.ShowDialog();
            }
        }

        protected override void DeleteData()
        {
            LoanApplication app = GetSelectData();
            if (app != null)
            {
                try
                {
                    if (Mbox.ConfirmMessage(@"คุณต้องการลบรายการนี้ใช่หรือไม่?") == DialogResult.Yes)
                    {
                        LoanFacade.UpdateLoanApplication(app, null, FacadeBase.Status.Delete);
                        SaveDataCompleted();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {

                }
            }
        }

        protected override void From_Load(object sender, EventArgs e)
        {
            base.From_Load(sender, e);
            InitForm();
            this.LockControl();
        }
        #endregion

        #region Form Event
        private void grdData_DoubleClick(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void grdData_Sorted(object sender, EventArgs e)
        {
            PTB.PIS.Welfare.WindowsApp.CommonGUI.Common.PaintHeaderSeq(grdData);

        } 
        #endregion
    }
}

