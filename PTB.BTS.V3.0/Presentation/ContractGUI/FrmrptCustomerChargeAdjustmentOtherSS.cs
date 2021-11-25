using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

using Facade.PiFacade;
using Facade.ContractFacade;

using Presentation.CommonGUI;
using Presentation.PiGUI;
using Presentation.ContractGUI.ContractChargeRateGUI;

using SystemFramework.AppConfig;
using SystemFramework.AppMessage;
using SystemFramework.AppException;

namespace Presentation.ContractGUI
{
    public partial class FrmrptCustomerChargeAdjustmentOtherSS : ChildFormBase, IMDIChildForm  
    {
        #region - private -
        private CompanyFacade facadeCompany;
        private Presentation.frmMain mdiParent;
        #endregion

        private DateTime selectedDate;
        public DateTime SelectedDate
        {
            set
            {
                selectedDate = value;
            }
        }

        //======================================================================
        public FrmrptCustomerChargeAdjustmentOtherSS()
            : base()
        {
            InitializeComponent();
            facadeCompany = new CompanyFacade();
            this.Text = "รายงานเงินขาดเกินสำหรับเรียกเก็บเงินลูกค้า";
        }

        //======================================================================
        private CompanyInfo getCompany()
        {
            CompanyInfo objCompany = new CompanyInfo("12");
            if (facadeCompany.FillCompany(ref objCompany))
            {
                return objCompany;
            }
            else
            {
                return null;
            }
        }

        //======================================================================

        private void ReportDatabaseLogon()
        {
            try
            {
                string companyName = this.getCompany().AFullName.Thai;
                string StartDate1 = Convert.ToString(selectedDate.Month);
                string StartDate2 = Convert.ToString(selectedDate.Year);


                ReportDocument rdprint1 = new ReportDocument();
                rdprint1.Load(@ApplicationProfile.REPORT_PATH + "rptCustomerChargeAdjustmentOtherSS.rpt");
                DataSourceConnections dataSourceConnections1 = rdprint1.DataSourceConnections;
                IConnectionInfo iConnectionInfo1 = dataSourceConnections1[0];
                iConnectionInfo1.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);
                rdprint1.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + companyName + "'";
                rdprint1.DataDefinition.FormulaFields["Month"].Text = StartDate1;
                rdprint1.DataDefinition.FormulaFields["Year"].Text = StartDate2;
                crvPrint.ReportSource = rdprint1;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
            }
        }

        //======================================================================
     
        public void InitForm()
        {
        }

        public void RefreshForm()
        {

        }

        public void PrintForm()
        {
        }

        public void ExitForm()
        {
            this.Hide();
        }

        //======================================================================


        private void FrmrptCustomerChargeAdjustmentOtherSS_Load(object sender, EventArgs e)
        {
            mdiParent = (Presentation.frmMain)this.MdiParent;
            InitForm();
            ReportDatabaseLogon();
            crvPrint.RefreshReport();
        }

        private void FrmrptCustomerChargeAdjustmentOtherSS_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseReport(crvPrint);
        }
    }
}