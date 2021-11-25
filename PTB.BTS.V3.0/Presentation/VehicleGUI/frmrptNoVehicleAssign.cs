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

using Entity.CommonEntity;

using Facade.PiFacade;
using Facade.VehicleFacade;

using Presentation.CommonGUI;

using SystemFramework.AppConfig;
using SystemFramework.AppMessage;
namespace Presentation.VehicleGUI
{
    public partial class frmrptNoVehicleAssign : ChildFormBase, IMDIChildForm   
    {

        #region - private -
        private CompanyInfo objCompany;
        private CompanyFacade facadeCompany;
        //private ReportVehicleFacade facadeReportVehicle;
        private frmMain mdiParent;
        #endregion

        //		============================== Constructor ==============================

        public frmrptNoVehicleAssign()
        {
            InitializeComponent();
            facadeCompany = new CompanyFacade();
            //facadeReportVehicle = new ReportVehicleFacade();
            this.Text = "รายงานรถขาย ถูกโจรกรรม และ เสียหายจนใช้การไม่ได้";
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
                string StartDay = Convert.ToString(dtpStartDate.Value.Day);
                string StartMonth = Convert.ToString(dtpStartDate.Value.Month);
                string StartYear = Convert.ToString(dtpStartDate.Value.Year);

                string EndDay = Convert.ToString(dtpEndDate.Value.Day);
                string EndMonth = Convert.ToString(dtpEndDate.Value.Month);
                string EndYear = Convert.ToString(dtpEndDate.Value.Year);

                //Age age = facadeReportVehicle.CalculateFineAge(dtpStartDate.Value,dtpEndDate.Value);

                rdprint1.Load(@ApplicationProfile.REPORT_PATH + "rptNoVehicleAssign.rpt");
                DataSourceConnections dataSourceConnections1 = rdprint1.DataSourceConnections;
                IConnectionInfo iConnectionInfo1 = dataSourceConnections1[0];
                iConnectionInfo1.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

                rdprint1.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.Thai + "'";
                rdprint1.DataDefinition.FormulaFields["Start_Date"].Text = "'" + StartDay + "'";
                rdprint1.DataDefinition.FormulaFields["Start_Month"].Text = "'" + StartMonth + "'";
                rdprint1.DataDefinition.FormulaFields["Start_Year"].Text = "'" + StartYear + "'";

                rdprint1.DataDefinition.FormulaFields["End_Date"].Text = "'" + EndDay + "'";
                rdprint1.DataDefinition.FormulaFields["End_Month"].Text = "'" + EndMonth + "'";
                rdprint1.DataDefinition.FormulaFields["End_Year"].Text = "'" + EndYear + "'";

                crvPrint.ReportSource = rdprint1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
            }
        }
        //		==============================Base Event ==============================
        public void InitForm()
        {
            dtpStartDate.Value = DateTime.Today;
            dtpEndDate.Value = DateTime.Today;
            crvPrint.Hide();
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

        //		============================== Event ==============================

        private void frmrptNoVehicleAssign_Load(object sender, EventArgs e)
        {
            mdiParent = (frmMain)this.MdiParent;
            InitForm();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            ReportDatabaseLogon();
            RefreshForm();
            mdiParent.EnableExitCommand(true);
            crvPrint.RefreshReport();
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }
    }
}