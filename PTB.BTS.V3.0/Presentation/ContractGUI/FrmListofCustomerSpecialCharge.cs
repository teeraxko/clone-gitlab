using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;
using System.Configuration;

using ictus.Common.Entity;
using ictus.PIS.PI.Entity;

using Facade.PiFacade;

using Presentation.CommonGUI;

using SystemFramework.AppConfig;
using SystemFramework.AppMessage;

namespace Presentation.ContractGUI
{
    public partial class FrmListofCustomerSpecialCharge : ChildFormBase, IMDIChildForm  
    {
        #region - private -
        private CompanyInfo objCompany;
        private CompanyFacade facadeCompany;
        private frmMain mdiParent;
        #endregion

        //============================== Constructor ==============================
        public FrmListofCustomerSpecialCharge() : base()
        {
            InitializeComponent();
            facadeCompany = new CompanyFacade();
            this.title = UserProfile.GetFormName("miContract", "miContractDocumentCustomerSpecialCharge");
        }

        public override string FormID()
        {
            return UserProfile.GetFormID("miContract", "miContractDocumentCustomerSpecialCharge");
        }

        //============================== Property ==============================
        public CompanyInfo getCompany()
        {
            objCompany = new CompanyInfo("12");
            if (facadeCompany.FillCompany(ref objCompany))
            {
                return objCompany;
            }
            else
            {
                return null;
            }
        }

        //============================== Private Method ==============================
        private void ReportDatabaseLogon()
        {
            try
            {
                objCompany = getCompany();
                ReportDocument rdprint1 = new ReportDocument();
                string StartDate2 = Convert.ToString(dtpDate.Value.AddMonths(-1).Month);
                string StartDate3 = Convert.ToString(dtpDate.Value.AddMonths(-1).Year);

                rdprint1.Load(@ApplicationProfile.REPORT_PATH + "rptListofCustomerSpecialCharge.rpt");
                DataSourceConnections dataSourceConnections1 = rdprint1.DataSourceConnections;
                IConnectionInfo iConnectionInfo1 = dataSourceConnections1[0];
                iConnectionInfo1.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

                rdprint1.DataDefinition.FormulaFields["CompName"].Text = "'" + objCompany.AFullName.Thai + "'";
                rdprint1.DataDefinition.FormulaFields["Year"].Text = StartDate3;
                rdprint1.DataDefinition.FormulaFields["Month"].Text = StartDate2;

                crvReport1.ReportSource = rdprint1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
            }
        }

        //==============================Base Event ==============================
        public void InitForm()
        {
            dtpDate.Value = DateTime.Today;
            crvReport1.Hide();
            mdiParent.EnableExitCommand(true);
        }

        public void RefreshForm()
        {
            crvReport1.Show();
            mdiParent.EnableExitCommand(true);
        }

        public void PrintForm()
        {
        }

        public void ExitForm()
        {
            this.Hide();
        }


        //============================== Base Event ==============================
        private void cmdShow_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            ReportDatabaseLogon();
            RefreshForm();
            mdiParent.EnableExitCommand(true);
            crvReport1.RefreshReport();
            this.Cursor = Cursors.Default;
           
        }

        private void FrmListofCustomerSpecialCharge_Load(object sender, EventArgs e)
        {
            mdiParent = (frmMain)this.MdiParent;
            InitForm();
        }
    }
}