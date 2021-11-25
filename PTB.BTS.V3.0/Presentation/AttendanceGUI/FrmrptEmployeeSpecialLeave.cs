using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using CrystalDecisions.Shared;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

using Facade.PiFacade;

using Presentation.CommonGUI;

using SystemFramework.AppConfig;

namespace Presentation.AttendanceGUI
{
    public partial class FrmrptEmployeeSpecialLeave : ChildFormBase,IMDIChildForm
    {
        #region Private Variable
        private CompanyInfo objCompany;
        private CompanyFacade facadeCompany;
        private frmMain mdiParent; 
        #endregion

        #region Constructor
        public FrmrptEmployeeSpecialLeave()
        {
            InitializeComponent();
            facadeCompany = new CompanyFacade();
            this.Text = "รายงานการลากิจพิเศษ รายเดือน";
        }
        #endregion

        #region Private Method
        private CompanyInfo getCompany()
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

        private void ReportDatabaseLogon()
        {
            try
            {
                objCompany = getCompany();
                ReportDocument rdprint1 = new ReportDocument();
                rdprint1.Load(@ApplicationProfile.REPORT_PATH + "rptEmployeeSpecialLeave.rpt");

                DataSourceConnections dataSourceConnections = rdprint1.DataSourceConnections;
                IConnectionInfo iConnectionInfo = dataSourceConnections[0];
                iConnectionInfo.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

                rdprint1.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.Thai + "'";
                rdprint1.DataDefinition.FormulaFields["FilterMonth"].Text = string.Format("CDate ({0}, {1}, {2})", dtpForMonth.Value.Year.ToString(), dtpForMonth.Value.Month.ToString(), dtpForMonth.Value.Day.ToString());

                crvPrint.ReportSource = rdprint1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
            }
        } 
        #endregion

        #region Public Method
        public void InitForm()
        {
            dtpForMonth.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
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
            this.Close();
        } 
        #endregion

        #region Form Event
        private void FrmrptEmployeeSpecialLeave_Load(object sender, EventArgs e)
        {
            mdiParent = (frmMain)this.MdiParent;
            InitForm();
        }

        private void cmdShow_Click(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            ReportDatabaseLogon();
            RefreshForm();
            mdiParent.EnableExitCommand(true);
            crvPrint.RefreshReport();
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void FrmrptEmployeeSpecialLeave_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseReport(crvPrint);
        } 
        #endregion
    }
}
