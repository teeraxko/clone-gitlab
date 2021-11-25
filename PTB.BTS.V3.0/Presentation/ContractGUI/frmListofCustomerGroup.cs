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

namespace Presentation.ContractGUI
{
	public class frmListofCustomerGroup : System.Windows.Forms.Form
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

		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvCustomerGroup;

		#region Windows Form Designer generated code

		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			this.crvCustomerGroup = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.SuspendLayout();
			// 
			// crvCustomerGroup
			// 
			this.crvCustomerGroup.ActiveViewIndex = -1;
			this.crvCustomerGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.crvCustomerGroup.DisplayGroupTree = false;
			this.crvCustomerGroup.Location = new System.Drawing.Point(16, 16);
			this.crvCustomerGroup.Name = "crvCustomerGroup";
			this.crvCustomerGroup.ReportSource = null;
			this.crvCustomerGroup.ShowCloseButton = false;
			this.crvCustomerGroup.ShowGroupTreeButton = false;
			this.crvCustomerGroup.Size = new System.Drawing.Size(664, 440);
			this.crvCustomerGroup.TabIndex = 0;
			// 
			// frmListofCustomerGroup
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(696, 478);
			this.Controls.Add(this.crvCustomerGroup);
			this.Name = "frmListofCustomerGroup";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmListofCustomerGroup_Load);
			this.ResumeLayout(false);

		}
		#endregion

		#region - private -
		private CompanyInfo objCompany;
		private CompanyFacade facadeCompany;
		#endregion
		//		============================== Constructor ==============================
		public frmListofCustomerGroup()
		{
			InitializeComponent();
			facadeCompany = new CompanyFacade();
			this.Text = "รายงานกลุ่มลูกค้า";

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
				ReportDocument rdCustomerGroup = new ReportDocument();
				rdCustomerGroup.Load(@ApplicationProfile.REPORT_PATH + "rptListofCustomerGroup.rpt");
				DataSourceConnections dataSourceConnections = rdCustomerGroup.DataSourceConnections;
				IConnectionInfo iConnectionInfo = dataSourceConnections[0];
				iConnectionInfo.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

				rdCustomerGroup.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.Thai + "'";
				crvCustomerGroup.ReportSource = rdCustomerGroup;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
			}
		}

		//		============================== Event ==============================

		private void frmListofCustomerGroup_Load(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			ReportDatabaseLogon();
			crvCustomerGroup.RefreshReport();
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}
	}
}
