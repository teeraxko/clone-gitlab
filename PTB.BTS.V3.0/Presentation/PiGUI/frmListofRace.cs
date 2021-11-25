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

namespace Presentation.PiGUI
{
	public class frmListofRace : System.Windows.Forms.Form
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
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvRace;
		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			this.crvRace = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.SuspendLayout();
			// 
			// crvRace
			// 
			this.crvRace.ActiveViewIndex = -1;
			this.crvRace.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.crvRace.DisplayGroupTree = false;
			this.crvRace.Location = new System.Drawing.Point(8, 8);
			this.crvRace.Name = "crvRace";
			this.crvRace.ReportSource = null;
			this.crvRace.ShowCloseButton = false;
			this.crvRace.ShowGroupTreeButton = false;
			this.crvRace.Size = new System.Drawing.Size(656, 472);
			this.crvRace.TabIndex = 0;
			// 
			// frmListofRace
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(680, 494);
			this.Controls.Add(this.crvRace);
			this.Name = "frmListofRace";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmListofRace_Load);
			this.ResumeLayout(false);

		}
		#endregion
		private CompanyInfo objCompany;
		private CompanyFacade facadeCompany;
//		============================== Constructor ==============================
		public frmListofRace()
		{
			InitializeComponent();
			facadeCompany = new CompanyFacade();
			this.Text = "รายงานเชื้อชาติ";
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
				ReportDocument rdRace = new ReportDocument();
				rdRace.Load(@ApplicationProfile.REPORT_PATH + "rptListofRace.rpt");

				DataSourceConnections dataSourceConnections = rdRace.DataSourceConnections;
				IConnectionInfo iConnectionInfo = dataSourceConnections[0];
				iConnectionInfo.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

				rdRace.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.Thai + "'";
				crvRace.ReportSource = rdRace;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
			}
		}

//		============================== Event ==============================
		private void frmListofRace_Load(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			ReportDatabaseLogon();
			crvRace.RefreshReport();
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}


	}
}
