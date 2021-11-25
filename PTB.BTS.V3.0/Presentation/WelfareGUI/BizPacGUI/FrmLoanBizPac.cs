using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ictus.PIS.Welfare.Entity.LoanEntities;
using PTB.PIS.Welfare.BizPac;
using PTB.PIS.Welfare.ReportApp.GUI.ConnectBBLGUI;
using PTB.PIS.Welfare.BBL;
using PTB.PIS.Welfare.ReportApp.GUI.ConnectBizPacGUI;
using PTB.PIS.Welfare.ReportApp.GUI.LoanGUI;
using PTB.PIS.Welfare.BizPac.BizPacEntities;
using SystemFramework.AppConfig;

namespace PTB.PIS.Welfare.WindowsApp.BizPacGUI
{
    public partial class FrmLoanBizPac : PTB.PIS.Welfare.WindowsApp.BizPacGUI.FrmConnectBizBase
    {

        private List<LoanApplication> apps;

        // private FrmReportBBLLoan frmReportBBLLoan;

        public FrmLoanBizPac()
            : base()
        {
            InitializeComponent();
            this.reportFileName = "rptConnectBizPacGLLoan.rpt";
            this.mainTableName = "Employee_Loan_Head";
            this.dtpPaymentDate.Value = DateTime.Now.Date;
            isReadonly = UserProfile.IsReadOnly("miBizPacConnect", "miBizPacConnectLoan");
            this.Text = UserProfile.GetFormName("miBizPacConnect", "miBizPacConnectLoan");
        }
        public override string FormID()
        {
            return UserProfile.GetFormID("miBizPacConnect", "miBizPacConnectLoan");
        }

        public override int MasterCount()
        {
            return this.apps.Count;
        }

        protected override void RetiveData()
        {
            this.apps = LoanBizPacFacade.FillNoBizPacByFromDateToDAte(dtpDateFrom.Value.Date, dtpDateTo.Value.Date);
            this.itemCount = this.apps.Count;
        }
        protected override void PaintData()
        {
            if (this.apps != null)
            {
                int rowIndex = 0;
                grdData.Rows.Clear();
                foreach (LoanApplication app in this.apps)
                {
                    grdData.RowCount++;
                    grdData.Rows[rowIndex].Tag = app;
                    grdData.Rows[rowIndex].Cells["colChk"].Value = true;
                    grdData.Rows[rowIndex].Cells["colEmp"].Value = string.Format("{0} {1}", app.Employee.EmployeeNo, app.Employee.EmployeeName);
                    grdData.Rows[rowIndex].Cells["colCreateDate"].Value = app.AppliedDate.ToString("dd/MM/yyyy");
                    grdData.Rows[rowIndex].Cells["colPurpose"].Value = app.LoanReson.ThaiName;
                    grdData.Rows[rowIndex].Cells["colStartDate"].Value = app.StartDate.ToString("dd/MM/yyyy");
                    grdData.Rows[rowIndex].Cells["colEndDate"].Value = app.EndDate.ToString("dd/MM/yyyy");
                    grdData.Rows[rowIndex].Cells["colPeriod"].Value = app.Period;
                    grdData.Rows[rowIndex].Cells["colCapital"].Value = app.CapitalAmount.ToString("N2");
                    grdData.Rows[rowIndex].Cells["colInterest"].Value = app.InterestRate.ToString("N2") + "%";
                    //grdData.Rows[rowIndex].Cells["colPaid"].Value = app.PaidAmount.ToString("N2");
                    grdData.Rows[rowIndex].Cells["colBalance"].Value = app.BalanceAmount.ToString("N2");
                    rowIndex++;
                }

            }
        }
        protected override void SelectAll()
        {
            foreach (DataGridViewRow row in grdData.Rows)
            {
                row.Cells["colChk"].Value = true;
            }
        }
        protected override void DeselectAll()
        {
            foreach (DataGridViewRow row in grdData.Rows)
            {
                row.Cells["colChk"].Value = false;
            }
        }
        protected override void Submit()
        {
            try
            {
                List<LoanApplication> apps = this.GetSelectData();

                if (apps.Count > 0)
                {
                    ConnectBizPacResult connectBizPacResult = LoanBizPacFacade.Update(apps, dtpPaymentDate.Value.Date);
                    this.csvFileName = connectBizPacResult.FileName;
                    this.ListOfRefNo = connectBizPacResult.ListOfRefNo;
                    ConnectBBL();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        private void ConnectBBL()
        {
            try
            {
                List<LoanApplication> apps = this.GetSelectData();
                BBLFacadeLoan.GenDataBBL(dtpPaymentDate.Value.Date, apps);
                //frmReportBBLLoan = new FrmReportBBLLoan(dtpPaymentDate.Value.Date);
                //frmReportBBLLoan.MdiParent = this.MdiParent;
                //frmReportBBLLoan.Show();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        protected override void Cancel() { }

        private List<LoanApplication> GetSelectData()
        {
            List<LoanApplication> result = new List<LoanApplication>();
            foreach (DataGridViewRow row in grdData.Rows)
            {
                if ((bool)row.Cells["colChk"].Value)
                {
                    result.Add((LoanApplication)row.Tag);
                }
            }
            return result;
        }

        protected override void SetReport()
        {
            if (this.ListOfRefNo.Count > 0)
            {
                FrmReportLoanConnect frmReport = new FrmReportLoanConnect();
                frmReport.MdiParent = this.MdiParent;
                frmReport.PaymentDate = this.dtpPaymentDate.Value.Date;
                frmReport.ReportFileName = this.reportFileName;
                frmReport.MainTableName = this.mainTableName;
                frmReport.ListOfRefNo = this.ListOfRefNo;
                frmReport.ConnectFileName = this.csvFileName;
                frmReport.LoadDate();
                frmReport.Show();
            }

        }

        protected override void GetSelectItemDetail()
        {
            base.GetSelectItemDetail();
            this.selectItemCount = 0;
            this.itemsAmount = 0M;
            foreach (DataGridViewRow row in this.grdData.Rows)
            {
                if ((bool)row.Cells["colChk"].Value)
                {
                    LoanApplication app = (LoanApplication)row.Tag;
                    this.selectItemCount++;
                    this.itemsAmount += app.CapitalAmount;
                }
            }
        }
    }
}

