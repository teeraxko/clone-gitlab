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
	public class frmListofColor : System.Windows.Forms.Form
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

		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvColor;

		#region Windows Form Designer generated code

		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			this.crvColor = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.SuspendLayout();
			// 
			// crvColor
			// 
			this.crvColor.ActiveViewIndex = -1;
			this.crvColor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.crvColor.DisplayGroupTree = false;
			this.crvColor.Location = new System.Drawing.Point(16, 16);
			this.crvColor.Name = "crvColor";
			this.crvColor.ReportSource = null;
			this.crvColor.ShowCloseButton = false;
			this.crvColor.ShowGroupTreeButton = false;
			this.crvColor.Size = new System.Drawing.Size(656, 440);
			this.crvColor.TabIndex = 0;
			// 
			// frmListofColor
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(696, 478);
			this.Controls.Add(this.crvColor);
			this.Name = "frmListofColor";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmListofColor_Load);
			this.ResumeLayout(false);

		}
		#endregion

		#region - private -
		private CompanyInfo objCompanyInfo;
		private CompanyFacade facadeCompany;
		#endregion
//		============================== Constructor ==============================
		public frmListofColor()
		{
			InitializeComponent();
			facadeCompany = new CompanyFacade();
			this.Text = "รายงานสีรถ";
		}
//		============================== Property ==============================
        public CompanyInfo getCompany()
		{
            objCompanyInfo = new CompanyInfo("12");
			if(facadeCompany.FillCompany(ref objCompanyInfo))
			{
				return objCompanyInfo;
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
				objCompanyInfo = getCompany();
				ReportDocument rdColor = new ReportDocument();
				rdColor.Load(@ApplicationProfile.REPORT_PATH + "rptListofColor.rpt");

				DataSourceConnections dataSourceConnections = rdColor.DataSourceConnections;
				IConnectionInfo iConnectionInfo = dataSourceConnections[0];
				iConnectionInfo.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

				rdColor.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompanyInfo.AFullName.Thai + "'";
				crvColor.ReportSource = rdColor;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
			}
		}

//		============================== Event ==============================
		private void frmListofColor_Load(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			ReportDatabaseLogon();
			crvColor.RefreshReport();
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}
	}
}
