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
	public class frmrptExpiredVehicleContractWithDriver :ChildFormBase,IMDIChildForm
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
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button cmdShow;
		private System.Windows.Forms.DateTimePicker dtpDate;
		private System.Windows.Forms.Label label;
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvReport1;
		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cmdShow = new System.Windows.Forms.Button();
			this.dtpDate = new System.Windows.Forms.DateTimePicker();
			this.label = new System.Windows.Forms.Label();
			this.crvReport1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.cmdShow);
			this.groupBox1.Controls.Add(this.dtpDate);
			this.groupBox1.Controls.Add(this.label);
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(656, 64);
			this.groupBox1.TabIndex = 15;
			this.groupBox1.TabStop = false;
			// 
			// cmdShow
			// 
			this.cmdShow.Location = new System.Drawing.Point(216, 24);
			this.cmdShow.Name = "cmdShow";
			this.cmdShow.TabIndex = 7;
			this.cmdShow.Text = "ดูข้อมูล";
			this.cmdShow.Click += new System.EventHandler(this.cmdShow_Click);
			// 
			// dtpDate
			// 
			this.dtpDate.CustomFormat = "MM/yyyy";
			this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpDate.Location = new System.Drawing.Point(72, 24);
			this.dtpDate.Name = "dtpDate";
			this.dtpDate.Size = new System.Drawing.Size(88, 20);
			this.dtpDate.TabIndex = 6;
			// 
			// label
			// 
			this.label.AutoSize = true;
			this.label.Location = new System.Drawing.Point(24, 24);
			this.label.Name = "label";
			this.label.Size = new System.Drawing.Size(36, 16);
			this.label.TabIndex = 5;
			this.label.Text = "เดือน/ปี";
			// 
			// crvReport1
			// 
			this.crvReport1.ActiveViewIndex = -1;
			this.crvReport1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.crvReport1.DisplayGroupTree = false;
			this.crvReport1.Location = new System.Drawing.Point(16, 80);
			this.crvReport1.Name = "crvReport1";
			this.crvReport1.ReportSource = null;
			this.crvReport1.ShowCloseButton = false;
			this.crvReport1.ShowGroupTreeButton = false;
			this.crvReport1.Size = new System.Drawing.Size(648, 440);
			this.crvReport1.TabIndex = 18;
			// 
			// frmrptExpiredVehicleContractWithDriver
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(680, 526);
			this.Controls.Add(this.crvReport1);
			this.Controls.Add(this.groupBox1);
			this.Name = "frmrptExpiredVehicleContractWithDriver";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmrptExpiredVehicleContractWithDriver_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region - private -
		private CompanyInfo objCompany;
		private CompanyFacade facadeCompany;
		private frmMain mdiParent;
		#endregion
		//		============================== Constructor ==============================

		public frmrptExpiredVehicleContractWithDriver()
		{
			InitializeComponent();
			facadeCompany = new CompanyFacade();
			this.Text = "รายงานรถหมดสัญญา";
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
				//				string StartDate1 = Convert.ToString(dtpDate.Value.Day);
				string StartDate2 = Convert.ToString(dtpDate.Value.Month);
				string StartDate3 = Convert.ToString(dtpDate.Value.Year);

				rdprint1.Load(@ApplicationProfile.REPORT_PATH + "rptExpiredVehicleContractWithDriver.rpt");
				DataSourceConnections dataSourceConnections1 = rdprint1.DataSourceConnections;
				IConnectionInfo iConnectionInfo1 = dataSourceConnections1[0];
				iConnectionInfo1.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

				rdprint1.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.Thai + "'";
				rdprint1.DataDefinition.FormulaFields["Year"].Text = StartDate3;
				rdprint1.DataDefinition.FormulaFields["Month"].Text = StartDate2;

				crvReport1.ReportSource = rdprint1;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
			}
		}

		//		==============================Base Event ==============================

		public void InitForm()
		{
			dtpDate.Value = DateTime.Today;
			crvReport1.Hide();
			mdiParent.EnableExitCommand(true);		
		}

		public void RefreshForm()
		{
			crvReport1.Show();
			mdiParent.EnableExitCommand(true);
		}

		public void PrintForm()
		{
		}

		public void ExitForm()
		{
			this.Hide();
		}


		//		==============================Base Event ==============================



		private void frmrptExpiredVehicleContractWithDriver_Load(object sender, System.EventArgs e)
		{
			mdiParent = (frmMain)this.MdiParent;
			InitForm();
		}

		private void cmdShow_Click(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			ReportDatabaseLogon();
			RefreshForm();
			mdiParent.EnableExitCommand(true);
			crvReport1.RefreshReport();
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}
	}
}
