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

using SystemFramework.AppConfig;

namespace Presentation.VehicleGUI
{
	public class frmListofCompulsoryInsurancebyPlate : System.Windows.Forms.Form
	{


		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvReport;
		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			this.crvReport = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.SuspendLayout();
			// 
			// crvReport
			// 
			this.crvReport.ActiveViewIndex = -1;
			this.crvReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.crvReport.DisplayGroupTree = false;
			this.crvReport.Location = new System.Drawing.Point(12, 16);
			this.crvReport.Name = "crvReport";
			this.crvReport.ReportSource = null;
			this.crvReport.ShowCloseButton = false;
			this.crvReport.ShowGroupTreeButton = false;
			this.crvReport.Size = new System.Drawing.Size(656, 456);
			this.crvReport.TabIndex = 2;
			// 
			// frmListofCompulsoryInsurancebyPlate
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(680, 494);
			this.Controls.Add(this.crvReport);
			this.Name = "frmListofCompulsoryInsurancebyPlate";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmListofCompulsoryInsurancebyPlate_Load);
			this.ResumeLayout(false);

		}
		#endregion

		#region - private -
		private CompanyInfo objCompany;
		private CompanyFacade facadeCompany;
		#endregion

		//		============================== Constructor ==============================

		public frmListofCompulsoryInsurancebyPlate()
		{
			InitializeComponent();
			facadeCompany = new CompanyFacade();
			this.Text = "รายงาน ข้อมูลพรบ. ตามป้ายทะเบียน";
		}
		//		============================== Property ==============================
        public CompanyInfo getCompany()
		{
            objCompany = new CompanyInfo("12");
			if(facadeCompany.FillCompany(ref objCompany))
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
				ReportDocument rdprint = new ReportDocument();

				rdprint.Load(@ApplicationProfile.REPORT_PATH + "rptCompulsoryInsurancebyPlate.rpt");

				DataSourceConnections dataSourceConnections = rdprint.DataSourceConnections;
				IConnectionInfo iConnectionInfo = dataSourceConnections[0];
				iConnectionInfo.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

				rdprint.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.Thai + "'";

				crvReport.ReportSource = rdprint;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
			}
		}

		//		============================== Event ==============================


		private void frmListofCompulsoryInsurancebyPlate_Load(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			ReportDatabaseLogon();
			crvReport.RefreshReport();
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}

	}
}
