using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared ;
using System.IO;
using System.Configuration;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

using Facade.PiFacade;

using Presentation.CommonGUI;

using SystemFramework.AppConfig;
using SystemFramework.AppMessage;


namespace Presentation.ContractGUI
{
	public class frmListofInCompleteServiceStaffAssign : ChildFormBase,IMDIChildForm	
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

		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvInComplete;

		#region Windows Form Designer generated code

		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			this.crvInComplete = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.SuspendLayout();
			// 
			// crvInComplete
			// 
			this.crvInComplete.ActiveViewIndex = -1;
			this.crvInComplete.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.crvInComplete.DisplayGroupTree = false;
			this.crvInComplete.Location = new System.Drawing.Point(16, 16);
			this.crvInComplete.Name = "crvInComplete";
			this.crvInComplete.ReportSource = null;
			this.crvInComplete.ShowCloseButton = false;
			this.crvInComplete.ShowGroupTreeButton = false;
			this.crvInComplete.Size = new System.Drawing.Size(656, 448);
			this.crvInComplete.TabIndex = 0;
			// 
			// frmListofInCompleteServiceStaffAssign
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(688, 486);
			this.Controls.Add(this.crvInComplete);
			this.Name = "frmListofInCompleteServiceStaffAssign";
			this.Text = "รายงานเอกสารสัญญาที่มีการจ่ายงานไม่สมบูรณ์";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmListofInCompleteServiceStaffAssign_Load);
			this.ResumeLayout(false);

		}
		#endregion

		#region - private -
		private CompanyInfo objCompany;
		private CompanyFacade facadeCompany;
		private frmMain mdiParent;
		#endregion
//		============================== Constructor ==============================
		public frmListofInCompleteServiceStaffAssign()
		{
			InitializeComponent();
			facadeCompany = new CompanyFacade();
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
				ReportDocument rdprint = new ReportDocument();
				rdprint.Load(@ApplicationProfile.REPORT_PATH + "rptInCompleteServiceStaffAssign.rpt");
				DataSourceConnections dataSourceConnections = rdprint.DataSourceConnections;
				IConnectionInfo iConnectionInfo = dataSourceConnections[0];
				iConnectionInfo.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

				rdprint.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.Thai + "'";
				crvInComplete.ReportSource = rdprint;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
			}
		}

		//		============================== Event ==============================
		#region IMDIChildForm Members

		public void InitForm()
		{
			mdiParent.EnableExitCommand(true);
		}

		public void RefreshForm()
		{
			mdiParent.EnableExitCommand(true);
		}

		public void PrintForm()
		{
		}

		public void ExitForm()
		{
			this.Hide();
		}

		#endregion
		
//		============================== Event ==============================
		private void frmListofInCompleteServiceStaffAssign_Load(object sender, System.EventArgs e)
		{
			mdiParent = (frmMain)this.MdiParent;
			
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			ReportDatabaseLogon();
			crvInComplete.RefreshReport();
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}
	}
}
