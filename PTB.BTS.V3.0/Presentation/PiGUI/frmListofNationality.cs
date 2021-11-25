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
	
	public class frmListofNationality : System.Windows.Forms.Form
	{
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvNationality;
		
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
			this.crvNationality = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.SuspendLayout();
			// 
			// crvNationality
			// 
			this.crvNationality.ActiveViewIndex = -1;
			this.crvNationality.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.crvNationality.DisplayGroupTree = false;
			this.crvNationality.Location = new System.Drawing.Point(8, 8);
			this.crvNationality.Name = "crvNationality";
			this.crvNationality.ReportSource = null;
			this.crvNationality.ShowCloseButton = false;
			this.crvNationality.ShowGroupTreeButton = false;
			this.crvNationality.Size = new System.Drawing.Size(632, 424);
			this.crvNationality.TabIndex = 2;
			// 
			// frmListofNationality
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(648, 454);
			this.Controls.Add(this.crvNationality);
			this.Name = "frmListofNationality";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmListofNationality_Load);
			this.ResumeLayout(false);

		}
		#endregion

		#region - private -
        private CompanyInfo objCompany;
		private CompanyFacade facadeCompany;
		#endregion

		public frmListofNationality()
		{
			InitializeComponent();
			facadeCompany = new CompanyFacade();
			this.Text = "รายงานสัญชาติ";
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
				ReportDocument rdNationality = new ReportDocument();
				rdNationality.Load(@ApplicationProfile.REPORT_PATH + "rptListofNationality.rpt");

				DataSourceConnections dataSourceConnections = rdNationality.DataSourceConnections;
				IConnectionInfo iConnectionInfo = dataSourceConnections[0];
				iConnectionInfo.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

				rdNationality.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.Thai + "'";
				crvNationality.ReportSource = rdNationality;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
			}
		}

		//		============================== Event ==============================
		private void frmListofNationality_Load(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			ReportDatabaseLogon();
			crvNationality.RefreshReport();
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}

	}
}
