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

	public class frmListofMajor : FormBase
	{
		
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
			this.crvMajor = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.SuspendLayout();
			// 
			// crvMajor
			// 
			this.crvMajor.ActiveViewIndex = -1;
			this.crvMajor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.crvMajor.DisplayGroupTree = false;
			this.crvMajor.Location = new System.Drawing.Point(8, 16);
			this.crvMajor.Name = "crvMajor";
			this.crvMajor.ReportSource = null;
			this.crvMajor.ShowCloseButton = false;
			this.crvMajor.ShowGroupTreeButton = false;
			this.crvMajor.Size = new System.Drawing.Size(664, 448);
			this.crvMajor.TabIndex = 1;
			// 
			// frmListofMajor
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(680, 502);
			this.Controls.Add(this.crvMajor);
			this.Name = "frmListofMajor";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmListofMajor_Load);
			this.ResumeLayout(false);

		}
		#endregion


		#region - private -
		private CompanyInfo objCompany;
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvMajor;
		private CompanyFacade facadeCompany;
		#endregion
		//		============================== Constructor ==============================
		public frmListofMajor()
		{
			InitializeComponent();
			facadeCompany = new CompanyFacade();
			this.Text = "รายงานวิชาเอก";

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
				ReportDocument rdMajor = new ReportDocument();
				rdMajor.Load(@ApplicationProfile.REPORT_PATH + "rptListofMajor.rpt");
				DataSourceConnections dataSourceConnections = rdMajor.DataSourceConnections;
				IConnectionInfo iConnectionInfo = dataSourceConnections[0];
				iConnectionInfo.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

				rdMajor.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.Thai + "'";
				crvMajor.ReportSource = rdMajor;
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
		private void frmListofMajor_Load(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			ReportDatabaseLogon();
			crvMajor.RefreshReport();
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}
	}
}
