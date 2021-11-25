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
	public class frmListofOccupation : System.Windows.Forms.Form
	{
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvOccupation;
		
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
			this.crvOccupation = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.SuspendLayout();
			// 
			// crvOccupation
			// 
			this.crvOccupation.ActiveViewIndex = -1;
			this.crvOccupation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.crvOccupation.DisplayGroupTree = false;
			this.crvOccupation.Location = new System.Drawing.Point(8, 8);
			this.crvOccupation.Name = "crvOccupation";
			this.crvOccupation.ReportSource = null;
			this.crvOccupation.ShowCloseButton = false;
			this.crvOccupation.ShowGroupTreeButton = false;
			this.crvOccupation.Size = new System.Drawing.Size(680, 440);
			this.crvOccupation.TabIndex = 1;
			// 
			// frmListofOccupation
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(720, 454);
			this.Controls.Add(this.crvOccupation);
			this.Name = "frmListofOccupation";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmListofOccupation_Load);
			this.ResumeLayout(false);

		}
		#endregion
	
		#region - private -
		private CompanyInfo objCompany;
		private CompanyFacade facadeCompany;
		#endregion

		public frmListofOccupation()
		{		
			InitializeComponent();
			facadeCompany = new CompanyFacade();
			this.Text = "รายงานอาชีพ";
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
				ReportDocument rdOccupation = new ReportDocument();
				rdOccupation.Load(@ApplicationProfile.REPORT_PATH + "rptListofOccupation.rpt");

				DataSourceConnections dataSourceConnections = rdOccupation.DataSourceConnections;
				IConnectionInfo iConnectionInfo = dataSourceConnections[0];
				iConnectionInfo.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

				rdOccupation.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.Thai + "'";
				crvOccupation.ReportSource = rdOccupation;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
			}
		}

		//		============================== Event ==============================
		private void frmListofOccupation_Load(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			ReportDatabaseLogon();
			crvOccupation.RefreshReport();
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}
	}
}
