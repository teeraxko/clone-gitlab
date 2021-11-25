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

namespace Presentation.VehicleGUI
{
	public class frmListofRepairedVehicleByFinishDate : ChildFormBase,IMDIChildForm
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

		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvVehicle;
		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			this.crvVehicle = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.SuspendLayout();
			// 
			// crvVehicle
			// 
			this.crvVehicle.ActiveViewIndex = -1;
			this.crvVehicle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.crvVehicle.DisplayGroupTree = false;
			this.crvVehicle.Location = new System.Drawing.Point(16, 16);
			this.crvVehicle.Name = "crvVehicle";
			this.crvVehicle.ReportSource = null;
			this.crvVehicle.ShowCloseButton = false;
			this.crvVehicle.ShowGroupTreeButton = false;
			this.crvVehicle.Size = new System.Drawing.Size(1000, 496);
			this.crvVehicle.TabIndex = 14;
			// 
			// frmListofRepairedVehicleByFinishDate
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(1028, 534);
			this.Controls.Add(this.crvVehicle);
			this.Name = "frmListofRepairedVehicleByFinishDate";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmListofRepairedVehicle_Load);
			this.ResumeLayout(false);

		}
		#endregion

		#region - private -
		private CompanyInfo objCompany;
		private CompanyFacade facadeCompany;
		private frmMain mdiParent;
		#endregion

		//		============================== Constructor ==============================
		public frmListofRepairedVehicleByFinishDate() : base()
		{
			InitializeComponent();
			facadeCompany = new CompanyFacade();
			this.Text = "รายงานรถที่ซ่อมรายวัน";
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
				ReportDocument rdprint1 = new ReportDocument();

				rdprint1.Load(@ApplicationProfile.REPORT_PATH + "rptListofRepairedVehicleByFinishDate.rpt");
				DataSourceConnections dataSourceConnections1 = rdprint1.DataSourceConnections;
				IConnectionInfo iConnectionInfo1 = dataSourceConnections1[0];
				iConnectionInfo1.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

				rdprint1.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.Thai + "'";

				crvVehicle.ReportSource = rdprint1;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
			}
		}
		//		============================== Event ==============================
		public void InitForm()
		{
			crvVehicle.Show();
			mdiParent.EnableExitCommand(true);
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			ReportDatabaseLogon();
			crvVehicle.RefreshReport();
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}

		public void RefreshForm()
		{
			InitForm();
			mdiParent.EnableExitCommand(true);
		}

		public void PrintForm()
		{
		}

		public void ExitForm()
		{
			this.Hide();
		}

		//		============================== Event ==============================

		private void frmListofRepairedVehicle_Load(object sender, System.EventArgs e)
		{
			mdiParent = (frmMain)this.MdiParent;
			InitForm();
		}

	}
}
