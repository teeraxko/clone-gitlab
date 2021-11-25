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
	public class frmListofReligion : System.Windows.Forms.Form
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
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvReligion;
		private System.ComponentModel.Container components = null;
		private void InitializeComponent()
		{
			this.crvReligion = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.SuspendLayout();
			// 
			// crvReligion
			// 
			this.crvReligion.ActiveViewIndex = -1;
			this.crvReligion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.crvReligion.DisplayGroupTree = false;
			this.crvReligion.Location = new System.Drawing.Point(16, 16);
			this.crvReligion.Name = "crvReligion";
			this.crvReligion.ReportSource = null;
			this.crvReligion.ShowCloseButton = false;
			this.crvReligion.ShowGroupTreeButton = false;
			this.crvReligion.Size = new System.Drawing.Size(648, 416);
			this.crvReligion.TabIndex = 0;
			// 
			// frmListofReligion
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(680, 454);
			this.Controls.Add(this.crvReligion);
			this.Name = "frmListofReligion";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmListofReligion_Load);
			this.ResumeLayout(false);

		}
		#endregion
		
		#region - private -
        private CompanyInfo objCompany;
		private CompanyFacade facadeCompany;
		#endregion

//     ====================================Constructor=====================
		public frmListofReligion()
		{
			InitializeComponent();
			facadeCompany = new CompanyFacade();
			this.Text = "รายงานศาสนา";
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
				ReportDocument rdReligion = new ReportDocument();
				rdReligion.Load(@ApplicationProfile.REPORT_PATH + "rptListofReligion.rpt");

				DataSourceConnections dataSourceConnections = rdReligion.DataSourceConnections;
				IConnectionInfo iConnectionInfo = dataSourceConnections[0];
				iConnectionInfo.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

				rdReligion.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.Thai + "'";
				crvReligion.ReportSource = rdReligion;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
			}
		}

//		============================== Event ==============================
		private void frmListofReligion_Load(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			ReportDatabaseLogon();
			crvReligion.RefreshReport();
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}



	}
}
