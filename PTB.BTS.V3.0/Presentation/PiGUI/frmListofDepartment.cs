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
	public class frmListofDepartment : System.Windows.Forms.Form
	{
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvDepartment;
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
			this.crvDepartment = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.SuspendLayout();
			// 
			// crvDepartment
			// 
			this.crvDepartment.ActiveViewIndex = -1;
			this.crvDepartment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.crvDepartment.DisplayGroupTree = false;
			this.crvDepartment.Location = new System.Drawing.Point(16, 16);
			this.crvDepartment.Name = "crvDepartment";
			this.crvDepartment.ReportSource = null;
			this.crvDepartment.ShowCloseButton = false;
			this.crvDepartment.ShowGroupTreeButton = false;
			this.crvDepartment.Size = new System.Drawing.Size(672, 432);
			this.crvDepartment.TabIndex = 0;
			// 
			// frmListofDepartment
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(704, 470);
			this.Controls.Add(this.crvDepartment);
			this.Name = "frmListofDepartment";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmListofDepartment_Load);
			this.ResumeLayout(false);

		}
		#endregion

		#region - private -
        private CompanyInfo objCompany;
		private CompanyFacade facadeCompany;
		#endregion

//     ====================================Constructor=====================
		public frmListofDepartment()
		{
			InitializeComponent();
			facadeCompany = new CompanyFacade();
			this.Text = "รายงานฝ่ายต้นสังกัด";
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
				ReportDocument rdDepartment = new ReportDocument();
				rdDepartment.Load(@ApplicationProfile.REPORT_PATH + "rptDepartment.rpt");

				DataSourceConnections dataSourceConnections = rdDepartment.DataSourceConnections;
				IConnectionInfo iConnectionInfo = dataSourceConnections[0];
				iConnectionInfo.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

				rdDepartment.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.Thai + "'";
				crvDepartment.ReportSource = rdDepartment;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
			}
		}

//		============================== Event ==============================
		private void frmListofDepartment_Load(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			ReportDatabaseLogon();
			crvDepartment.RefreshReport();
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}


	}
}
