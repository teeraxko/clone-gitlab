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
	public class frmListofBank : System.Windows.Forms.Form
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
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvBank;
		private System.ComponentModel.Container components = null;
		private void InitializeComponent()
		{
			this.crvBank = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.SuspendLayout();
			// 
			// crvBank
			// 
			this.crvBank.ActiveViewIndex = -1;
			this.crvBank.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.crvBank.DisplayGroupTree = false;
			this.crvBank.Location = new System.Drawing.Point(16, 16);
			this.crvBank.Name = "crvBank";
			this.crvBank.ReportSource = null;
			this.crvBank.ShowCloseButton = false;
			this.crvBank.ShowGroupTreeButton = false;
			this.crvBank.Size = new System.Drawing.Size(664, 456);
			this.crvBank.TabIndex = 0;
			// 
			// frmListofBank
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(696, 478);
			this.Controls.Add(this.crvBank);
			this.Name = "frmListofBank";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmListofBank_Load);
			this.ResumeLayout(false);

		}
		#endregion

		#region - private -
		private CompanyInfo objCompany;
		private CompanyFacade facadeCompany;
		#endregion
		//		============================== Constructor ==============================
		public frmListofBank()
		{
			InitializeComponent();
			facadeCompany = new CompanyFacade();
			this.Text = "รายงานธนาคาร";
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
				ReportDocument rdBank = new ReportDocument();
				rdBank.Load(ApplicationProfile.REPORT_PATH + "rptListofBank.rpt");			

				DataSourceConnections dataSourceConnections = rdBank.DataSourceConnections;
				IConnectionInfo iConnectionInfo = dataSourceConnections[0];
				iConnectionInfo.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

				objCompany = getCompany();
				rdBank.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.Thai + "'";
				crvBank.ReportSource = rdBank;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
			}
		}

		//		============================== Event ==============================
		private void frmListofBank_Load(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			ReportDatabaseLogon();
			crvBank.RefreshReport();
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}
	}
}
