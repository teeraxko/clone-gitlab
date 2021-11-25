using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ictus.PIS.Welfare.Entity.MedicalAidEntities;
using PTB.PIS.Welfare.BizPac;
using PTB.PIS.Welfare.WindowsApp.CommonGUI;
using PTB.PIS.Welfare.BizPac.BizPacEntities;
using SystemFramework.AppConfig;

namespace PTB.PIS.Welfare.WindowsApp.BizPacGUI
{
    public partial class FrmMedicalAidNoAttBizPac : PTB.PIS.Welfare.WindowsApp.BizPacGUI.FrmConnectBizBase
    {
        private List<MedicalAidApplication> apps;

        public FrmMedicalAidNoAttBizPac()
            : base()
        {
            InitializeComponent();
            this.reportFileName = "rptConnectBizPacGLMedicalAid.rpt";
            this.mainTableName = "Employee_Medical_Aid";
            isReadonly = UserProfile.IsReadOnly("miBizPacConnect", "miBizPacConnectMedicalAidNoAtt");
            this.Text = UserProfile.GetFormName("miBizPacConnect", "miBizPacConnectMedicalAidNoAtt");

            // Kriangkrai A. 11/3/2019
            ////Find last day - 1 of current date 
            //DateTime paymentDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month) - 1);

            DateTime paymentDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            //If payment date is holiday then payment date will change to previous.
            dtpPaymentDate.Value = MedicalAidBizPacFacade.RetriveDate(paymentDate);
        }
        public override string FormID()
        {
            return UserProfile.GetFormID("miBizPacConnect", "miBizPacConnectMedicalAidNoAtt");
        }

        public override int MasterCount()
        {
            return this.apps.Count;
        }

        protected override void RetiveData()
        {
            this.apps = MedicalAidBizPacFacade.FillNoBizPacByFromDateToDateNoAtt(dtpDateFrom.Value.Date, dtpDateTo.Value.Date);
            this.itemCount = this.apps.Count;
        }

        protected override void PaintData()
        {
            if (this.apps != null)
            {
                int rowIndex = 0;
                grdData.Rows.Clear();
                foreach (MedicalAidApplication app in this.apps)
                {
                    grdData.RowCount++;
                    grdData.Rows[rowIndex].Tag = app;
                    grdData.Rows[rowIndex].Cells["colChk"].Value = true;
                    grdData.Rows[rowIndex].Cells["colEmp"].Value = string.Format("{0} {1}", app.AEmployee.EmployeeNo, app.AEmployee.EmployeeName);
                    grdData.Rows[rowIndex].Cells["colCreateDate"].Value = app.CreateDate.ToString("dd/MM/yyyy");
                    grdData.Rows[rowIndex].Cells["colType"].Value = app.ApplicationType.ThaiName;
                    grdData.Rows[rowIndex].Cells["colFor"].Value = app.ApplicationFor.ThaiName;
                    grdData.Rows[rowIndex].Cells["colDisease"].Value = app.ADisease.Name;
                    // display hospital name
                    if (app.AHospital.Code == "ZZZZZZ")
                    {
                        grdData.Rows[rowIndex].Cells["colHospital"].Value = app.NoContractHospitalName;
                    }
                    else
                    {
                        grdData.Rows[rowIndex].Cells["colHospital"].Value = app.AHospital.ThaiName;
                    }
                    grdData.Rows[rowIndex].Cells["colAdmitDate"].Value = app.AdmitDate.ToString("dd/MM/yyyy");
                    grdData.Rows[rowIndex].Cells["colActualAmount"].Value = app.ActualAmount.ToString("N2");
                    grdData.Rows[rowIndex].Cells["colAppliedAmount"].Value = app.AppliedAmount.ToString("N2");
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
                List<MedicalAidApplication> apps = this.GetSelectData();
                if (apps.Count > 0)
                {
                    // Kriangkrai A.
                    ConnectBizPacResult connectBizPacResult = MedicalAidBizPacFacade.Update(apps, dtpPaymentDate.Value.Date);
                    this.csvFileName = connectBizPacResult.FileName;
                    this.ListOfRefNo = connectBizPacResult.ListOfRefNo;
                }

            }
            catch (Exception ex)
            {
                Mbox.ErrorMessage(ex.Message);
            }
        }
        protected override void Cancel() { }

        private List<MedicalAidApplication> GetSelectData()
        {
            List<MedicalAidApplication> result = new List<MedicalAidApplication>();
            foreach (DataGridViewRow row in grdData.Rows)
            {
                if ((bool)row.Cells["colChk"].Value)
                {
                    result.Add((MedicalAidApplication)row.Tag);
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
                    MedicalAidApplication app = (MedicalAidApplication)row.Tag;
                    this.selectItemCount++;
                    this.itemsAmount += app.AppliedAmount;
                }
            }
        }

    }
}

