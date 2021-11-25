using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;
using System.Configuration;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

using Facade.PiFacade;

using Presentation.CommonGUI;

using SystemFramework.AppConfig;
using SystemFramework.AppMessage;

namespace PTB.BTS.BTS2BizPacPresentation.ConnectBizPac
{
    public partial class FrmrptExcessExpense : ChildFormBase, IMDIChildForm
    {
        #region - private -
        private CompanyInfo objCompany;
        private CompanyFacade facadeCompany;
        private Presentation.frmMain mdiParent;
        public string fileName = string.Empty;
        #endregion

        ////		============================== Constructor ==============================
        public FrmrptExcessExpense() : base()
        {
            InitializeComponent();
            facadeCompany = new CompanyFacade();
            this.Text = "Excess Expense";
        }

       ////		============================== Property ==============================
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
        ////		============================== Private Method ==============================
        private void ReportDatabaseLogon()
        {
            try
            {
                objCompany = getCompany();

                ReportDocument rdprint1 = new ReportDocument();
                rdprint1.Load(@ApplicationProfile.REPORT_PATH + "rptExcessExpense.rpt");
                DataSourceConnections dataSourceConnections1 = rdprint1.DataSourceConnections;
                IConnectionInfo iConnectionInfo1 = dataSourceConnections1[0];
                iConnectionInfo1.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

                rdprint1.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.English + "'";
                rdprint1.DataDefinition.FormulaFields["BPFileName"].Text = "'" + fileName + "'";

                crvPrint.ReportSource = rdprint1;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
            }
        }
        ////		============================== Event ==============================

        public void InitForm()
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            ReportDatabaseLogon();
            crvPrint.Show();
            crvPrint.RefreshReport();
            this.Cursor = System.Windows.Forms.Cursors.Default;
            mdiParent.EnableExitCommand(true);
        }

        public void RefreshForm()
        {
            crvPrint.Show();
            mdiParent.EnableExitCommand(true);
        }

        public void PrintForm()
        {

        }

        public void ExitForm()
        {
            this.Hide();
        }

        //============================== Event ==============================
        private void FrmrptExcessExpense_Load(object sender, EventArgs e)
        {
            mdiParent = (Presentation.frmMain)this.MdiParent;
            InitForm();
        }

        private void FrmrptExcessExpense_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseReport(crvPrint);
        }
    }
}