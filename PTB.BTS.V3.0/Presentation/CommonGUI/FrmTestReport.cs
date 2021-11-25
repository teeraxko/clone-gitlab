using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Facade.PiFacade;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

using CrystalDecisions.CrystalReports.Engine;
using SystemFramework.AppConfig;
using CrystalDecisions.Shared;
using System.Data.SqlClient;

namespace Presentation.CommonGUI {
    public partial class FrmTestReport : FormBase {
        public FrmTestReport() {
            InitializeComponent();
            facadeCompany = new CompanyFacade();
			this.Text = "รายงานจังหวัด";
        }


        #region - private -
        private CompanyInfo objCompany;
		private CompanyFacade facadeCompany;
		#endregion

        public CompanyInfo getCompany()
		{
            objCompany = new CompanyInfo("12");
            if (facadeCompany.FillCompany(ref objCompany)) {
                return objCompany;
            } else {
                return null;
            }
		}


        private void ReportDatabaseLogon() {
            try {
                objCompany = getCompany();
                ReportDocument rdProvince = new ReportDocument();
                rdProvince.Load(@ApplicationProfile.REPORT_PATH + "rptListofProvince.rpt");
                DataSourceConnections dataSourceConnections = rdProvince.DataSourceConnections;
                IConnectionInfo iConnectionInfo = dataSourceConnections[0];
                iConnectionInfo.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

                rdProvince.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.Thai + "'";
                crvProvince.ReportSource = rdProvince;
            } catch (SqlException sqlex) {
                Message(sqlex);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
            }
        }

        private void FrmTestReport_Load(object sender, EventArgs e) {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            ReportDatabaseLogon();
            crvProvince.RefreshReport();
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }
    }
}