using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using System.Data.SqlClient;
using CrystalDecisions.Shared;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

using Facade.PiFacade;
using SystemFramework.AppConfig;

namespace Presentation.CommonGUI
{
	public class frmListofStreet : FormBase
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

		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvStreet;

		#region Windows Form Designer generated code

		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			this.crvStreet = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.SuspendLayout();
			// 
			// crvStreet
			// 
			this.crvStreet.ActiveViewIndex = -1;
			this.crvStreet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.crvStreet.DisplayGroupTree = false;
			this.crvStreet.Location = new System.Drawing.Point(16, 16);
			this.crvStreet.Name = "crvStreet";
			this.crvStreet.ReportSource = null;
			this.crvStreet.ShowCloseButton = false;
			this.crvStreet.ShowGroupTreeButton = false;
			this.crvStreet.Size = new System.Drawing.Size(656, 448);
			this.crvStreet.TabIndex = 0;
			// 
			// frmListofStreet
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(688, 478);
			this.Controls.Add(this.crvStreet);
			this.Name = "frmListofStreet";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmListofStreet_Load);
			this.ResumeLayout(false);

		}
		#endregion

		#region - private -
		private CompanyInfo objCompany;
		private CompanyFacade facadeCompany;
		#endregion
//		============================== Constructor ==============================
		public frmListofStreet()
		{
			InitializeComponent();
			facadeCompany = new CompanyFacade();
			this.Text = "รายงานถนน";

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
				ReportDocument rdStreet = new ReportDocument();
				rdStreet.Load(@ApplicationProfile.REPORT_PATH + "rptListofStreet.rpt");
				DataSourceConnections dataSourceConnections = rdStreet.DataSourceConnections;
				IConnectionInfo iConnectionInfo = dataSourceConnections[0];
				iConnectionInfo.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

				rdStreet.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.Thai + "'";
				crvStreet.ReportSource = rdStreet;
			}
			catch(SqlException sqlex)
			{
				Message(sqlex);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
			}
		}

//		============================== Event ==============================
		private void frmListofStreet_Load(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			ReportDatabaseLogon();
			crvStreet.RefreshReport();
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}
	}
}
