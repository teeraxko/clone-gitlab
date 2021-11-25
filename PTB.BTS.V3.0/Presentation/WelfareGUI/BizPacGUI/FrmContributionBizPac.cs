using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ictus.PIS.Welfare.Entity.ContributionEntities;
using PTB.PIS.Welfare.BizPac;
using PTB.PIS.Welfare.ReportApp.GUI.ConnectBizPacGUI;
using PTB.PIS.Welfare.WindowsApp.CommonGUI;
using PTB.PIS.Welfare.BizPac.BizPacEntities;
using SystemFramework.AppConfig;

namespace PTB.PIS.Welfare.WindowsApp.BizPacGUI
{
    public partial class FrmContributionBizPac : FrmConnectBizBase
    {
        private List<ContributionApplication> apps;

        public FrmContributionBizPac()
            : base()
        {
            InitializeComponent();
            this.reportFileName = "rptConnectBizPacGLContribution.rpt";
            this.mainTableName = "Employee_Contribution";
            isReadonly = UserProfile.IsReadOnly("miBizPacConnect", "miBizPacConnectContribution");
            this.Text = UserProfile.GetFormName("miBizPacConnect", "miBizPacConnectContribution");

            // Kriangkrai A. 11/3/2019
            ////Find last day - 1 of current date 
            //DateTime paymentDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month) - 1);

            DateTime paymentDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            //If payment date is holiday then payment date will change to previous.
            dtpPaymentDate.Value = MedicalAidBizPacFacade.RetriveDate(paymentDate);

        }
        public override string FormID()
        {
            return UserProfile.GetFormID("miBizPacConnect", "miBizPacConnectContribution");
        }

        public override int MasterCount()
        {
            return this.apps.Count;
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

        protected override void RetiveData()
        {
            this.apps = ContributionBizPacFacade.FillNoBizPacByFromDateToDAte(dtpDateFrom.Value.Date, dtpDateTo.Value.Date);
            this.apps.RemoveAll(i => i.Contribution.Code == "04");
            this.apps.RemoveAll(i => i.Contribution.Code == "05");
            this.apps.RemoveAll(i => i.Contribution.Code == "06");
            this.apps.RemoveAll(i => i.Contribution.Code == "07");

            this.itemCount = this.apps.Count;
        }

        protected override void PaintData()
        {
            if (this.apps != null)
            {
                int rowIndex = 0;
                grdData.Rows.Clear();
                foreach (ContributionApplication app in this.apps)
                {
                    grdData.RowCount++;
                    grdData.Rows[rowIndex].Tag = app;
                    grdData.Rows[rowIndex].Cells["colChk"].Value = true;
                    grdData.Rows[rowIndex].Cells["coluDate"].Value = app.AppliedDate.ToString("dd/MM/yyyy");
                    grdData.Rows[rowIndex].Cells["colEmployee"].Value = string.Format("{0} {1}", app.Employee.EmployeeNo, app.Employee.EmployeeName);
                    grdData.Rows[rowIndex].Cells["coluContribution"].Value = app.Contribution.ThaiDescription;
                    grdData.Rows[rowIndex].Cells["coluAmount"].Value = app.AppliedAmount.ToString("N2");
                    rowIndex++;
                }
            }

        }

        protected override void Submit()
        {
            try
            {
                List<ContributionApplication> apps = this.GetSelectData();
                if (apps.Count > 0)
                {
                    //ConnectBizPacResult connectBizPacResult = ContributionBizPacFacade.Update(apps);
                    DateTime paymentDate = dtpPaymentDate.Value.Date;
                    ConnectBizPacResult connectBizPacResult = ContributionBizPacFacade.Update(apps,paymentDate);
                    this.csvFileName = connectBizPacResult.FileName;
                    this.ListOfRefNo = connectBizPacResult.ListOfRefNo;
                }

            }
            catch (Exception ex)
            {
                Mbox.ErrorMessage(ex.Message);
            }
        }



        protected override void Cancel()
        {

        }


        private List<ContributionApplication> GetSelectData()
        {
            List<ContributionApplication> result = new List<ContributionApplication>();
            foreach (DataGridViewRow row in grdData.Rows)
            {
                if ((bool)row.Cells["colChk"].Value)
                {
                    result.Add((ContributionApplication)row.Tag);
                }
            }
            return result;
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
                    ContributionApplication app = (ContributionApplication)row.Tag;
                    this.selectItemCount++;
                    this.itemsAmount += app.AppliedAmount;
                }
            }
        }


    }
}