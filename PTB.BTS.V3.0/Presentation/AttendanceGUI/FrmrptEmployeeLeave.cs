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

using Entity.ContractEntities;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

using Facade.ContractFacade;
using Facade.PiFacade;
using Facade.AttendanceFacade;

using Presentation.CommonGUI;

using SystemFramework.AppConfig;
using SystemFramework.AppMessage;
using SystemFramework.AppException;

namespace Presentation.AttendanceGUI
{
    public partial class FrmrptEmployeeLeave : ChildFormBase,IMDIChildForm  
    {

        #region - private -
        private CompanyInfo objCompany;
        private CompanyFacade facadeCompany;
        private frmMain mdiParent;

        #endregion
        //		============================== Constructor ==============================
        public FrmrptEmployeeLeave()
        {
            InitializeComponent();
            facadeCompany = new CompanyFacade();
            this.Text = "รายงานบันทึกการลาประจำปี";
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
                //				forYear
                objCompany = getCompany();
                ReportDocument rdprint = new ReportDocument();
                string Year = Convert.ToString(dtpYear.Value.Year);
                string Emp_No = txtEmpNo.Text;


                rdprint.Load(@ApplicationProfile.REPORT_PATH + "rptEmployeeLeave.rpt");

                DataSourceConnections dataSourceConnections = rdprint.DataSourceConnections;
                IConnectionInfo iConnectionInfo = dataSourceConnections[0];
                iConnectionInfo.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

                rdprint.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.Thai + "'";
                rdprint.DataDefinition.FormulaFields["Year"].Text = "'" + Year + "'";
                rdprint.DataDefinition.FormulaFields["Emp_No"].Text = "'" + Emp_No + "'";

                crvPrint.ReportSource = rdprint;
            }
            catch (SqlException sqlex)
            {
                Message(sqlex);
            }
            catch (AppExceptionBase ex)
            {
                Message(ex);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
            }
        }
        //		==============================Base Event ==============================

        public void InitForm()
        {
            dtpYear.Value = DateTime.Today;
            crvPrint.Hide();
            mdiParent.EnableExitCommand(true);
            txtEmpNo.Text = string.Empty;
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
        private void FrmrptEmployeeLeave_Load(object sender, EventArgs e)
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

        private void FrmrptEmployeeLeave_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseReport(crvPrint);
        }
    }
}