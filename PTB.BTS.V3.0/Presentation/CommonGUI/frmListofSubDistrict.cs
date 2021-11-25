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
	public class frmListofSubDistrict : FormBase
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
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvSubDistrict;
		private System.ComponentModel.Container components = null;
		private void InitializeComponent()
		{
			this.crvSubDistrict = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.SuspendLayout();
			// 
			// crvSubDistrict
			// 
			this.crvSubDistrict.ActiveViewIndex = -1;
			this.crvSubDistrict.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.crvSubDistrict.DisplayGroupTree = false;
			this.crvSubDistrict.Location = new System.Drawing.Point(8, 16);
			this.crvSubDistrict.Name = "crvSubDistrict";
			this.crvSubDistrict.ReportSource = null;
			this.crvSubDistrict.ShowCloseButton = false;
			this.crvSubDistrict.ShowGroupTreeButton = false;
			this.crvSubDistrict.Size = new System.Drawing.Size(656, 440);
			this.crvSubDistrict.TabIndex = 0;
			// 
			// frmListofSubDistrict
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(680, 478);
			this.Controls.Add(this.crvSubDistrict);
			this.Name = "frmListofSubDistrict";
			this.Text = "frmListofSubDistrict";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmListofSubDistrict_Load);
			this.ResumeLayout(false);

		}
		#endregion

		#region - private -
		private CompanyInfo objCompany;
		private CompanyFacade facadeCompany;
		#endregion
//		============================== Constructor ==============================
		public frmListofSubDistrict()
		{
			InitializeComponent();
			facadeCompany = new CompanyFacade();
			this.Text = "รายงานตำบล";

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
				ReportDocument rdSubDistrict = new ReportDocument();
				rdSubDistrict.Load(@ApplicationProfile.REPORT_PATH + "rptListofSubDistrict.rpt");
				DataSourceConnections dataSourceConnections = rdSubDistrict.DataSourceConnections;
				IConnectionInfo iConnectionInfo = dataSourceConnections[0];
				iConnectionInfo.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

				rdSubDistrict.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.Thai + "'";
				crvSubDistrict.ReportSource = rdSubDistrict;
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

		private void frmListofSubDistrict_Load(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			ReportDatabaseLogon();
			crvSubDistrict.RefreshReport();
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}
	}
}
