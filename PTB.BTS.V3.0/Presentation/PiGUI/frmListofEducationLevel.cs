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
	public class frmListofEducationLevel : System.Windows.Forms.Form
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
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvEducationLavel;
		private System.ComponentModel.Container components = null;


		private void InitializeComponent()
		{
			this.crvEducationLavel = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.SuspendLayout();
			// 
			// crvEducationLavel
			// 
			this.crvEducationLavel.ActiveViewIndex = -1;
			this.crvEducationLavel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.crvEducationLavel.DisplayGroupTree = false;
			this.crvEducationLavel.Location = new System.Drawing.Point(8, 16);
			this.crvEducationLavel.Name = "crvEducationLavel";
			this.crvEducationLavel.ReportSource = null;
			this.crvEducationLavel.ShowCloseButton = false;
			this.crvEducationLavel.ShowGroupTreeButton = false;
			this.crvEducationLavel.Size = new System.Drawing.Size(680, 440);
			this.crvEducationLavel.TabIndex = 0;
			// 
			// frmListofEducationLevel
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(696, 470);
			this.Controls.Add(this.crvEducationLavel);
			this.Name = "frmListofEducationLevel";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmListofEducationLevel_Load);
			this.ResumeLayout(false);

		}
		#endregion

		#region - private -
		private CompanyInfo objCompany;
		private CompanyFacade facadeCompany;
		#endregion
		//		============================== Constructor ==============================
		public frmListofEducationLevel()
		{
			InitializeComponent();
			facadeCompany = new CompanyFacade();
			this.Text = "รายงานระดับการศึกษา";

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
				ReportDocument rdEducationLevel = new ReportDocument();
				rdEducationLevel.Load(@ApplicationProfile.REPORT_PATH + "rptListofEducationLevel.rpt");

				DataSourceConnections dataSourceConnections = rdEducationLevel.DataSourceConnections;
				IConnectionInfo iConnectionInfo = dataSourceConnections[0];
				iConnectionInfo.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

				rdEducationLevel.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.Thai + "'";
				crvEducationLavel.ReportSource = rdEducationLevel;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
			}
		}

		//		============================== Event ==============================

		private void frmListofEducationLevel_Load(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			ReportDatabaseLogon();
			crvEducationLavel.RefreshReport();
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}
	}
}
