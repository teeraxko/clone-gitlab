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
	public class frmListofSpareParts : System.Windows.Forms.Form
	{
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvSpareParts;

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
			this.crvSpareParts = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.SuspendLayout();
			// 
			// crvSpareParts
			// 
			this.crvSpareParts.ActiveViewIndex = -1;
			this.crvSpareParts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.crvSpareParts.DisplayGroupTree = false;
			this.crvSpareParts.Location = new System.Drawing.Point(16, 16);
			this.crvSpareParts.Name = "crvSpareParts";
			this.crvSpareParts.ReportSource = null;
			this.crvSpareParts.ShowCloseButton = false;
			this.crvSpareParts.ShowGroupTreeButton = false;
			this.crvSpareParts.Size = new System.Drawing.Size(584, 416);
			this.crvSpareParts.TabIndex = 0;
			// 
			// frmListofSpareParts
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(608, 454);
			this.Controls.Add(this.crvSpareParts);
			this.Name = "frmListofSpareParts";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmListofSpareParts_Load);
			this.ResumeLayout(false);

		}
		#endregion
		
		#region - private -
		private CompanyInfo objCompany;
//		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvModelType;
		private CompanyFacade facadeCompany;
		#endregion

		//		============================== Constructor ==============================
		public frmListofSpareParts()
		{
			InitializeComponent();
			facadeCompany = new CompanyFacade();
			this.Text = "รายงานอะไหล่";
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
				ReportDocument rdSpareParts = new ReportDocument();
				rdSpareParts.Load(@ApplicationProfile.REPORT_PATH + "rptListofSpareParts.rpt");

				DataSourceConnections dataSourceConnections = rdSpareParts.DataSourceConnections;
				IConnectionInfo iConnectionInfo = dataSourceConnections[0];
				iConnectionInfo.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

				rdSpareParts.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.Thai + "'";
				crvSpareParts.ReportSource = rdSpareParts;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
			}
		}

		//		============================== Event ==============================
		private void frmListofSpareParts_Load(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			ReportDatabaseLogon();
			crvSpareParts.RefreshReport();
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}
	}
}
