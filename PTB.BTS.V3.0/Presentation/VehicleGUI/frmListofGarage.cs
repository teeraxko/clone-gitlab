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
	public class frmListofGarage : System.Windows.Forms.Form
	{
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvGarage;
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
			this.crvGarage = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.SuspendLayout();
			// 
			// crvGarage
			// 
			this.crvGarage.ActiveViewIndex = -1;
			this.crvGarage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.crvGarage.DisplayGroupTree = false;
			this.crvGarage.Location = new System.Drawing.Point(16, 16);
			this.crvGarage.Name = "crvGarage";
			this.crvGarage.ReportSource = null;
			this.crvGarage.ShowCloseButton = false;
			this.crvGarage.ShowGroupTreeButton = false;
			this.crvGarage.Size = new System.Drawing.Size(672, 432);
			this.crvGarage.TabIndex = 0;
			// 
			// frmListofGarage
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(704, 470);
			this.Controls.Add(this.crvGarage);
			this.Name = "frmListofGarage";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmListofGarage_Load);
			this.ResumeLayout(false);

		}
		#endregion

		#region - private -
		private CompanyInfo objCompany;
		private CompanyFacade facadeCompany;
		#endregion

//		============================== Constructor ==============================
		public frmListofGarage()
		{
			InitializeComponent();
			facadeCompany = new CompanyFacade();
			this.Text = "รายงานศูนย์บริการ";
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
				ReportDocument rdGarage = new ReportDocument();
				rdGarage.Load(@ApplicationProfile.REPORT_PATH + "rptListofGarage.rpt");

				DataSourceConnections dataSourceConnections = rdGarage.DataSourceConnections;
				IConnectionInfo iConnectionInfo = dataSourceConnections[0];
				iConnectionInfo.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

				rdGarage.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.Thai + "'";
				crvGarage.ReportSource = rdGarage;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
			}
		}

//		============================== Event ==============================
		private void frmListofGarage_Load(object sender, System.EventArgs e)
		{
			try
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				ReportDatabaseLogon();
				crvGarage.RefreshReport();
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Report refresh error", MessageBoxButtons.OK);
			}
		}
	}
}
