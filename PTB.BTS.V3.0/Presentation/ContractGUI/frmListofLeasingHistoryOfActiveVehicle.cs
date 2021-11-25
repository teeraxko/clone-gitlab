using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared ;
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
	public class frmListofLeasingHistoryOfActiveVehicle : System.Windows.Forms.Form
	{
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvHistory;
		private System.ComponentModel.Container components = null;

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
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.crvHistory = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.SuspendLayout();
			// 
			// crvHistory
			// 
			this.crvHistory.ActiveViewIndex = -1;
			this.crvHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.crvHistory.DisplayGroupTree = false;
			this.crvHistory.Location = new System.Drawing.Point(24, 16);
			this.crvHistory.Name = "crvHistory";
			this.crvHistory.ReportSource = null;
			this.crvHistory.ShowCloseButton = false;
			this.crvHistory.ShowGroupTreeButton = false;
			this.crvHistory.Size = new System.Drawing.Size(974, 718);
			this.crvHistory.TabIndex = 0;
			// 
			// frmListofLeasingHistoryOfActiveVehicle
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(1030, 748);
			this.Controls.Add(this.crvHistory);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmListofLeasingHistoryOfActiveVehicle";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmListofLeasingHistoryOfActiveVehicle_Load);
			this.ResumeLayout(false);

		}
		#endregion

		#region - private -
		private CompanyInfo objCompany;
		private CompanyFacade facadeCompany;
		#endregion


//		============================== Constructor ==============================
		public frmListofLeasingHistoryOfActiveVehicle()
		{
			InitializeComponent();
			facadeCompany = new CompanyFacade();
			this.Text = "รายงานประวัติการเช่ารถ(เฉพาะรถยนต์ปัจจุบัน)";
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

				rdprint.Load(@ApplicationProfile.REPORT_PATH + "rptLeasingHistoryOfActiveVehicle.rpt");

				DataSourceConnections dataSourceConnections = rdprint.DataSourceConnections;
				IConnectionInfo iConnectionInfo = dataSourceConnections[0];
				iConnectionInfo.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

				rdprint.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.Thai + "'";

				crvHistory.ReportSource = rdprint;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
			}
		}
	
//		============================== Event ==============================
		private void frmListofLeasingHistoryOfActiveVehicle_Load(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			ReportDatabaseLogon();
			crvHistory.RefreshReport();
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}



	}
}
