using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

using Facade.PiFacade;

using SystemFramework.AppConfig;

namespace Presentation.VehicleGUI
{
	public class frmListofBrand : System.Windows.Forms.Form
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

		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvBrand;

		#region Windows Form Designer generated code

		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			this.crvBrand = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.SuspendLayout();
			// 
			// crvBrand
			// 
			this.crvBrand.ActiveViewIndex = -1;
			this.crvBrand.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.crvBrand.DisplayGroupTree = false;
			this.crvBrand.Location = new System.Drawing.Point(16, 16);
			this.crvBrand.Name = "crvBrand";
			this.crvBrand.ReportSource = null;
			this.crvBrand.ShowCloseButton = false;
			this.crvBrand.ShowGroupTreeButton = false;
			this.crvBrand.Size = new System.Drawing.Size(664, 448);
			this.crvBrand.TabIndex = 0;
			// 
			// frmListofBrand
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(696, 478);
			this.Controls.Add(this.crvBrand);
			this.Name = "frmListofBrand";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmListofBrand_Load);
			this.ResumeLayout(false);

		}
		#endregion

		#region - private -
		private CompanyInfo objCompany;
		private CompanyFacade facadeCompany;
		#endregion
//		============================== Constructor ==============================
		public frmListofBrand()
		{
			InitializeComponent();
			facadeCompany = new CompanyFacade();
			this.Text = "รายงานยี่ห้อรถ";

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
				ReportDocument rdBrand = new ReportDocument();
				rdBrand.Load(@ApplicationProfile.REPORT_PATH + "rptListofBrand.rpt");
				rdBrand.SetDatabaseLogon(ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD, ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME);
				rdBrand.DataDefinition.FormulaFields[0].Text = "'" + objCompany.AFullName.Thai + "'";
				crvBrand.ReportSource = rdBrand;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
			}
		}

//		============================== Event ==============================
		private void frmListofBrand_Load(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			ReportDatabaseLogon();
			crvBrand.RefreshReport();
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}
	}
}
