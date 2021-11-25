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
	public class frmListofProvince : FormBase
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
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvProvince;
		private System.ComponentModel.Container components = null;
		private void InitializeComponent()
		{
			this.crvProvince = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.SuspendLayout();
			// 
			// crvProvince
			// 
			this.crvProvince.ActiveViewIndex = -1;
			this.crvProvince.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.crvProvince.DisplayGroupTree = false;
			this.crvProvince.Location = new System.Drawing.Point(16, 16);
			this.crvProvince.Name = "crvProvince";
			this.crvProvince.ReportSource = null;
			this.crvProvince.ShowCloseButton = false;
			this.crvProvince.ShowGroupTreeButton = false;
			this.crvProvince.Size = new System.Drawing.Size(632, 440);
			this.crvProvince.TabIndex = 0;
			// 
			// frmListofProvince
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(664, 470);
			this.Controls.Add(this.crvProvince);
			this.Name = "frmListofProvince";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmListofProvince_Load);
			this.ResumeLayout(false);

		}
		#endregion

		#region - private -
		private CompanyInfo objCompany;
		private CompanyFacade facadeCompany;
		#endregion
//		============================== Constructor ==============================
		public frmListofProvince()
		{
			InitializeComponent();
			facadeCompany = new CompanyFacade();
			this.Text = "รายงานจังหวัด";

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
				ReportDocument rdProvince = new ReportDocument();
				rdProvince.Load(@ApplicationProfile.REPORT_PATH + "rptListofProvince.rpt");
				DataSourceConnections dataSourceConnections = rdProvince.DataSourceConnections;
				IConnectionInfo iConnectionInfo = dataSourceConnections[0];
				iConnectionInfo.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

				rdProvince.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.Thai + "'";
				crvProvince.ReportSource = rdProvince;
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

		private void frmListofProvince_Load(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			ReportDatabaseLogon();
			crvProvince.RefreshReport();
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}

	}
}
