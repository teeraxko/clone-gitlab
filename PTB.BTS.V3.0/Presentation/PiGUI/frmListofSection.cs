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
	public class frmListofSection : System.Windows.Forms.Form
	{
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvSection;
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
			this.crvSection = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.SuspendLayout();
			// 
			// crvSection
			// 
			this.crvSection.ActiveViewIndex = -1;
			this.crvSection.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.crvSection.DisplayGroupTree = false;
			this.crvSection.Location = new System.Drawing.Point(16, 16);
			this.crvSection.Name = "crvSection";
			this.crvSection.ReportSource = null;
			this.crvSection.ShowCloseButton = false;
			this.crvSection.ShowGroupTreeButton = false;
			this.crvSection.Size = new System.Drawing.Size(664, 424);
			this.crvSection.TabIndex = 0;
			// 
			// frmListofSection
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(696, 462);
			this.Controls.Add(this.crvSection);
			this.Name = "frmListofSection";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmListofSection_Load);
			this.ResumeLayout(false);

		}
		#endregion

		#region - private -
		private CompanyInfo objCompany;
		private CompanyFacade facadeCompany;
		#endregion

//     ====================================Constructor=====================
		public frmListofSection()
		{
			InitializeComponent();
			facadeCompany = new CompanyFacade();
			this.Text = "รายงานส่วนงาน";
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
				ReportDocument rdSection = new ReportDocument();
				rdSection.Load(@ApplicationProfile.REPORT_PATH + "rptSection.rpt");

				DataSourceConnections dataSourceConnections = rdSection.DataSourceConnections;
				IConnectionInfo iConnectionInfo = dataSourceConnections[0];
				iConnectionInfo.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

				rdSection.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.Thai + "'";
				crvSection.ReportSource = rdSection;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
			}
		}

//		============================== Event ==============================
		private void frmListofSection_Load(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			ReportDatabaseLogon();
			crvSection.RefreshReport();
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}



	}
}
