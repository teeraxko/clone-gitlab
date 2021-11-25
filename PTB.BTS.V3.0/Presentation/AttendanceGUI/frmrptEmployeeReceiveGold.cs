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
    public partial class frmrptEmployeeReceiveGold : ChildFormBase, IMDIChildForm
    {
        private frmMain mdiParent;
        private CompanyInfo objCompany;
        private CompanyFacade facadeCompany;
        public frmrptEmployeeReceiveGold()
        {
            InitializeComponent();
            facadeCompany = new CompanyFacade();
            this.Text = "รายชื่อพนักงานผู้มีสิทธิ์ได้รับทอง";
        }
        //		============================== Private method ==============================
        private CompanyInfo getCompany()
        {
            objCompany = new CompanyInfo("12");
            if (facadeCompany.FillCompany(ref objCompany))
            {
                return objCompany;
            }
            else
            {
                objCompany = null;
                return null;
            }
        }

        private void ReportDatabaseLogon()
        {
            try
            {
                objCompany = getCompany();
                ReportDocument rdprint1 = new ReportDocument();
                rdprint1.Load(@ApplicationProfile.REPORT_PATH + "rptEmployeeReceiveGold.rpt");

                DataSourceConnections dataSourceConnections = rdprint1.DataSourceConnections;
                IConnectionInfo iConnectionInfo = dataSourceConnections[0];
                iConnectionInfo.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

                rdprint1.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.English + "'";
                rdprint1.DataDefinition.FormulaFields["Year"].Text = "'" + Convert.ToString(dtpDate.Value.Year) + "'";

                crvPrint.ReportSource = rdprint1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
            }
        }


        #region IMDIChildFormGUI Members

        public void InitForm()
        {
            dtpDate.Value = new System.DateTime(DateTime.Today.Year, DateTime.Today.Month, 7);
            crvPrint.Hide();
            mdiParent.EnableExitCommand(true);
        }

        public void RefreshForm()
        {
            crvPrint.Show();
            this.crvPrint.DisplayToolbar = true;
            mdiParent.EnableExitCommand(true);	
        }

        public void PrintForm()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void ExitForm()
        {
            this.Close();
        }

        #endregion

        //		============================== Event ==============================

        private void frmrptEmployeeReceiveGold_Load(object sender, EventArgs e)
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
            this.crvPrint.DisplayToolbar = true;
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void frmrptEmployeeReceiveGold_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseReport(crvPrint);
        }

    }
}