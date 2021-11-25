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
	public class frmListofInstitute : FormBase
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

		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvInstitute;

		#region Windows Form Designer generated code

		private System.ComponentModel.Container components = null;
		private void InitializeComponent()
		{
			this.crvInstitute = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.SuspendLayout();
			// 
			// crvInstitute
			// 
			this.crvInstitute.ActiveViewIndex = -1;
			this.crvInstitute.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.crvInstitute.DisplayGroupTree = false;
			this.crvInstitute.Location = new System.Drawing.Point(8, 16);
			this.crvInstitute.Name = "crvInstitute";
			this.crvInstitute.ReportSource = null;
			this.crvInstitute.ShowCloseButton = false;
			this.crvInstitute.ShowGroupTreeButton = false;
			this.crvInstitute.Size = new System.Drawing.Size(664, 448);
			this.crvInstitute.TabIndex = 0;
			// 
			// frmListofInstitute
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(688, 478);
			this.Controls.Add(this.crvInstitute);
			this.Name = "frmListofInstitute";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmListofInstitute_Load);
			this.ResumeLayout(false);

		}
		#endregion

		#region - private -
		private CompanyInfo objCompany;
		private CompanyFacade facadeCompany;
		#endregion
		//		============================== Constructor ==============================
		public frmListofInstitute()
		{
			InitializeComponent();
			facadeCompany = new CompanyFacade();
			this.Text = "��§ҹʶҺѹ";

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
				ReportDocument rdInstitute = new ReportDocument();
				rdInstitute.Load(@ApplicationProfile.REPORT_PATH + "rptListofInstitute.rpt");
				DataSourceConnections dataSourceConnections = rdInstitute.DataSourceConnections;
				IConnectionInfo iConnectionInfo = dataSourceConnections[0];
				iConnectionInfo.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

				rdInstitute.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.Thai + "'";
				crvInstitute.ReportSource = rdInstitute;
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


		private void frmListofInstitute_Load(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			ReportDatabaseLogon();
			crvInstitute.RefreshReport();
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}
	}
}
