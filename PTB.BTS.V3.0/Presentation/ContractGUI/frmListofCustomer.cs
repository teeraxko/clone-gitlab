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

using Presentation.CommonGUI;

using SystemFramework.AppConfig;

namespace Presentation.ContractGUI
{
	public class frmListofCustomer : ChildFormBase, IMDIChildForm
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
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvCustomer;
		private System.ComponentModel.Container components = null;
		private void InitializeComponent()
		{
			this.crvCustomer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.SuspendLayout();
			// 
			// crvCustomer
			// 
			this.crvCustomer.ActiveViewIndex = -1;
			this.crvCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.crvCustomer.DisplayGroupTree = false;
			this.crvCustomer.Location = new System.Drawing.Point(20, 16);
			this.crvCustomer.Name = "crvCustomer";
			this.crvCustomer.ReportSource = null;
			this.crvCustomer.ShowCloseButton = false;
			this.crvCustomer.ShowGroupTreeButton = false;
			this.crvCustomer.Size = new System.Drawing.Size(738, 330);
			this.crvCustomer.TabIndex = 0;
			// 
			// frmListofCustomer
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(778, 360);
			this.Controls.Add(this.crvCustomer);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmListofCustomer";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmListofCustomer_Load);
			this.ResumeLayout(false);

		}
		#endregion

		#region - private -
		private CompanyInfo objCompany;
		private CompanyFacade facadeCompany;
		private frmMain mdiParent;
		#endregion

//		============================== Constructor ==============================
		public frmListofCustomer()
		{
			InitializeComponent();
			facadeCompany = new CompanyFacade();
			this.Text = "รายงานลูกค้า";
		}

//		============================== Property ==============================
		private CompanyInfo getCompany()
		{
			objCompany = new CompanyInfo("12");
			if(facadeCompany.FillCompany(ref objCompany))
			{
				return objCompany;
			}
			else
			{
				objCompany = null;
				return null;
			}
		}
//		============================== Private Method ==============================
		private void ReportDatabaseLogon()
		{
			try
			{
				objCompany = getCompany();
				ReportDocument rdPrint = new ReportDocument();
				rdPrint.Load(@ApplicationProfile.REPORT_PATH + "rptCustomer.rpt");
				DataSourceConnections dataSourceConnections = rdPrint.DataSourceConnections;
				IConnectionInfo iConnectionInfo = dataSourceConnections[0];
				iConnectionInfo.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

				rdPrint.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.Thai + "'";
				crvCustomer.ReportSource = rdPrint;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
			}
		}

//		============================== Base Event ==============================
		public void InitForm()
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			ReportDatabaseLogon();
			crvCustomer.Show();
			crvCustomer.RefreshReport();
			mdiParent.EnableExitCommand(true);
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}

		public void RefreshForm()
		{
		}

		public void PrintForm()
		{
		}

		public void ExitForm()
		{
			
			this.Hide();
		}

//		============================== Event ==============================
		private void frmListofCustomer_Load(object sender, System.EventArgs e)
		{
			mdiParent = (frmMain)this.MdiParent;
			InitForm();
		}
	}
}
