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

namespace Presentation.VehicleGUI
{
    public partial class frmrptVehicleAccidentExcess : ChildFormBase, IMDIChildForm
    {
        #region - private -
        private CompanyInfo objCompany;
        private CompanyFacade facadeCompany;
        private frmMain mdiParent;
        #endregion

        //		============================== Constructor ==============================
        public frmrptVehicleAccidentExcess()
        {
            InitializeComponent();
            facadeCompany = new CompanyFacade();
            this.Text = "รายงานค่า Excess";
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

                rdprint1.Load(@ApplicationProfile.REPORT_PATH + "rptVehicleAccidentExcessbyGarage.rpt");
                DataSourceConnections dataSourceConnections1 = rdprint1.DataSourceConnections;
                IConnectionInfo iConnectionInfo1 = dataSourceConnections1[0];
                iConnectionInfo1.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

                rdprint1.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.Thai + "'";
                rdprint1.DataDefinition.FormulaFields["Garage"].Text = "'043'";

                crvExcessGarage.ReportSource = rdprint1;


                ReportDocument rdprint2 = new ReportDocument();

                rdprint2.Load(@ApplicationProfile.REPORT_PATH + "rptVehicleAccidentExcessbyInsurance.rpt");
                DataSourceConnections dataSourceConnections2 = rdprint2.DataSourceConnections;
                IConnectionInfo iConnectionInfo2 = dataSourceConnections2[0];
                iConnectionInfo2.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

                rdprint2.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.Thai + "'";
                rdprint2.DataDefinition.FormulaFields["Insurance"].Text = "";

                crvExcessInsurance.ReportSource = rdprint2;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
            }
        }
        //		============================== Event ==============================
        public void InitForm()
        {

            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            ReportDatabaseLogon();
            RefreshForm();
            mdiParent.EnableExitCommand(true);
            crvExcessGarage.RefreshReport();
            crvExcessInsurance.RefreshReport();
            this.crvExcessGarage.DisplayToolbar = true;
            this.crvExcessInsurance.DisplayToolbar = true;
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }

        public void RefreshForm()
        {
            mdiParent.EnableExitCommand(true);
            this.crvExcessGarage.DisplayToolbar = true;
            this.crvExcessInsurance.DisplayToolbar = true;
        }

        public void PrintForm()
        {
        }

        public void ExitForm()
        {
            this.Hide();
        }

        //		============================== Event ==============================

        private void frmrptVehicleAccidentExcess_Load(object sender, EventArgs e)
        {
            mdiParent = (frmMain)this.MdiParent;
            InitForm();
        }

    }
}