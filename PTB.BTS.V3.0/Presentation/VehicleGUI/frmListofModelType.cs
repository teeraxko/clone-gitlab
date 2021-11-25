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
	public class frmListofModelType : System.Windows.Forms.Form
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
			this.crvModelType = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.SuspendLayout();
			// 
			// crvModelType
			// 
			this.crvModelType.ActiveViewIndex = -1;
			this.crvModelType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.crvModelType.DisplayGroupTree = false;
			this.crvModelType.Location = new System.Drawing.Point(8, 16);
			this.crvModelType.Name = "crvModelType";
			this.crvModelType.ReportSource = null;
			this.crvModelType.ShowCloseButton = false;
			this.crvModelType.ShowGroupTreeButton = false;
			this.crvModelType.Size = new System.Drawing.Size(672, 440);
			this.crvModelType.TabIndex = 0;
			// 
			// frmListofModelType
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(696, 478);
			this.Controls.Add(this.crvModelType);
			this.Name = "frmListofModelType";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmListofModelType_Load);
			this.ResumeLayout(false);

		}
		#endregion

		#region - private -
		private CompanyInfo objCompany;
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvModelType;
		private CompanyFacade facadeCompany;
		#endregion
		//		============================== Constructor ==============================
		public frmListofModelType()
		{
			InitializeComponent();
			facadeCompany = new CompanyFacade();
			this.Text = "รายงานประเภทรถ";
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
				ReportDocument rdModelType = new ReportDocument();
				rdModelType.Load(@ApplicationProfile.REPORT_PATH + "rptListofModelType.rpt");

				DataSourceConnections dataSourceConnections = rdModelType.DataSourceConnections;
				IConnectionInfo iConnectionInfo = dataSourceConnections[0];
				iConnectionInfo.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

				rdModelType.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.Thai + "'";
				crvModelType.ReportSource = rdModelType;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
			}
		}

		//		============================== Event ==============================

		private void frmListofModelType_Load(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			ReportDatabaseLogon();
			crvModelType.RefreshReport();
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}
	}
}
