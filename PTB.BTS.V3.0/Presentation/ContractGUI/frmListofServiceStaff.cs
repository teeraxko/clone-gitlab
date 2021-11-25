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

namespace Presentation.ContractGUI
{
    public partial class frmListofServiceStaff : Form
    {

        #region - private -
        private CompanyInfo objCompany;
        private CompanyFacade facadeCompany;
        #endregion

        //		============================== Constructor ==============================

        public frmListofServiceStaff()
        {
            InitializeComponent();
            facadeCompany = new CompanyFacade();
            this.Text = "รายงานประเภทพนักงาน (Service Staff)";
        }
        //		============================== Property ==============================
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
        //		============================== Private Method ==============================
        private void ReportDatabaseLogon()
        {
            try
            {
                objCompany = getCompany();
                ReportDocument rdprint1 = new ReportDocument();

                rdprint1.Load(@ApplicationProfile.REPORT_PATH + "rptListofServiceStaffType.rpt");
                DataSourceConnections dataSourceConnections1 = rdprint1.DataSourceConnections;
                IConnectionInfo iConnectionInfo1 = dataSourceConnections1[0];
                iConnectionInfo1.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

                rdprint1.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.Thai + "'";


                crvPrint.ReportSource = rdprint1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
            }
        }

        //		==============================Event ==============================
        private void frmListofServiceStaff_Load(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            ReportDatabaseLogon();
            crvPrint.RefreshReport();
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }
    }
}