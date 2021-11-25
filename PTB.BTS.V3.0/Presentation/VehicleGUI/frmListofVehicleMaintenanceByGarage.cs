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
	public class frmListofVehicleMaintenanceByGarage : ChildFormBase,IMDIChildForm
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

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.TabPage tabPage4;
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvSummaryCheque;
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvSummaryCash;
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvDetailCheque;
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvDetailCash;
		private System.Windows.Forms.DateTimePicker dtpStartDate;
		private System.Windows.Forms.DateTimePicker dtpEndDate;
		private System.Windows.Forms.Button cmdShow;
		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
			this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cmdShow = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.crvSummaryCheque = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.crvSummaryCash = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.crvDetailCheque = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.crvDetailCash = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.groupBox1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.SuspendLayout();
			// 
			// dtpStartDate
			// 
			this.dtpStartDate.CustomFormat = "dd/MM/yyyy";
			this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpStartDate.Location = new System.Drawing.Point(112, 24);
			this.dtpStartDate.Name = "dtpStartDate";
			this.dtpStartDate.Size = new System.Drawing.Size(88, 20);
			this.dtpStartDate.TabIndex = 0;
			// 
			// dtpEndDate
			// 
			this.dtpEndDate.CustomFormat = "dd/MM/yyyy";
			this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpEndDate.Location = new System.Drawing.Point(240, 24);
			this.dtpEndDate.Name = "dtpEndDate";
			this.dtpEndDate.Size = new System.Drawing.Size(96, 20);
			this.dtpEndDate.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "ค่าซ่อมตั้งแต่วันที่";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.cmdShow);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.dtpStartDate);
			this.groupBox1.Controls.Add(this.dtpEndDate);
			this.groupBox1.Location = new System.Drawing.Point(8, 16);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(952, 56);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			// 
			// cmdShow
			// 
			this.cmdShow.Location = new System.Drawing.Point(376, 19);
			this.cmdShow.Name = "cmdShow";
			this.cmdShow.TabIndex = 4;
			this.cmdShow.Text = "ดูรายงาน";
			this.cmdShow.Click += new System.EventHandler(this.cmdShow_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(208, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(16, 11);
			this.label2.TabIndex = 3;
			this.label2.Text = "ถึง";
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Controls.Add(this.tabPage4);
			this.tabControl1.Location = new System.Drawing.Point(16, 88);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(944, 600);
			this.tabControl1.TabIndex = 4;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.crvSummaryCheque);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(936, 574);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "ค่าซ่อมของศูนย์ซ่อมต่าง ๆ (เครดิต)";
			// 
			// crvSummaryCheque
			// 
			this.crvSummaryCheque.ActiveViewIndex = -1;
			this.crvSummaryCheque.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.crvSummaryCheque.DisplayGroupTree = false;
			this.crvSummaryCheque.DisplayToolbar = false;
			this.crvSummaryCheque.Location = new System.Drawing.Point(16, 11);
			this.crvSummaryCheque.Name = "crvSummaryCheque";
			this.crvSummaryCheque.ReportSource = null;
			this.crvSummaryCheque.ShowCloseButton = false;
			this.crvSummaryCheque.ShowGroupTreeButton = false;
			this.crvSummaryCheque.Size = new System.Drawing.Size(904, 440);
			this.crvSummaryCheque.TabIndex = 0;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.crvSummaryCash);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(936, 574);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "ค่าซ่อมของศูนย์ซ่อมต่าง ๆ (เงินสด)";
			// 
			// crvSummaryCash
			// 
			this.crvSummaryCash.ActiveViewIndex = -1;
			this.crvSummaryCash.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.crvSummaryCash.DisplayGroupTree = false;
			this.crvSummaryCash.DisplayToolbar = false;
			this.crvSummaryCash.Location = new System.Drawing.Point(16, 16);
			this.crvSummaryCash.Name = "crvSummaryCash";
			this.crvSummaryCash.ReportSource = null;
			this.crvSummaryCash.ShowCloseButton = false;
			this.crvSummaryCash.ShowGroupTreeButton = false;
			this.crvSummaryCash.Size = new System.Drawing.Size(904, 445);
			this.crvSummaryCash.TabIndex = 1;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.crvDetailCheque);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(936, 574);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "ค่าซ่อมแยกตามศูนย์ซ่อม (เครดิต)";
			// 
			// crvDetailCheque
			// 
			this.crvDetailCheque.ActiveViewIndex = -1;
			this.crvDetailCheque.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.crvDetailCheque.DisplayGroupTree = false;
			this.crvDetailCheque.DisplayToolbar = false;
			this.crvDetailCheque.Location = new System.Drawing.Point(16, 16);
			this.crvDetailCheque.Name = "crvDetailCheque";
			this.crvDetailCheque.ReportSource = null;
			this.crvDetailCheque.ShowCloseButton = false;
			this.crvDetailCheque.ShowGroupTreeButton = false;
			this.crvDetailCheque.Size = new System.Drawing.Size(904, 440);
			this.crvDetailCheque.TabIndex = 1;
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.crvDetailCash);
			this.tabPage4.Location = new System.Drawing.Point(4, 22);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Size = new System.Drawing.Size(936, 574);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "ค่าซ่อมแยกตามศูนย์ซ่อม (เงินสด)";
			// 
			// crvDetailCash
			// 
			this.crvDetailCash.ActiveViewIndex = -1;
			this.crvDetailCash.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.crvDetailCash.DisplayGroupTree = false;
			this.crvDetailCash.DisplayToolbar = false;
			this.crvDetailCash.Location = new System.Drawing.Point(16, 11);
			this.crvDetailCash.Name = "crvDetailCash";
			this.crvDetailCash.ReportSource = null;
			this.crvDetailCash.ShowCloseButton = false;
			this.crvDetailCash.ShowGroupTreeButton = false;
			this.crvDetailCash.Size = new System.Drawing.Size(912, 453);
			this.crvDetailCash.TabIndex = 1;
			// 
			// frmListofVehicleMaintenanceByGarage
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(984, 582);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.groupBox1);
			this.Name = "frmListofVehicleMaintenanceByGarage";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmrptVehicleMaintenanceByGarage_Load);
			this.groupBox1.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.tabPage4.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region - private -
		private CompanyInfo objCompany;
		private CompanyFacade facadeCompany;
		private frmMain mdiParent;
		#endregion

//		============================== Constructor ==============================
		public frmListofVehicleMaintenanceByGarage()
		{
			InitializeComponent();
			facadeCompany = new CompanyFacade();
			this.Text = "รายงานค่าซ่อมของศูนย์ซ่อมต่างๆ";
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
				string StartDate1 = Convert.ToString(dtpStartDate.Value.Day);
				string StartDate2 = Convert.ToString(dtpStartDate.Value.Month);
				string StartDate3 = Convert.ToString(dtpStartDate.Value.Year);

				string EndDate1 = Convert.ToString(dtpEndDate.Value.Day);
				string EndDate2 = Convert.ToString(dtpEndDate.Value.Month);
				string EndDate3 = Convert.ToString(dtpEndDate.Value.Year);
				//1111
				ReportDocument rdprint1 = new ReportDocument();
				rdprint1.Load(@ApplicationProfile.REPORT_PATH + "rptVehicleMaintenanceByGarageSummary_Credit.rpt");

				DataSourceConnections dataSourceConnections1 = rdprint1.DataSourceConnections;
				IConnectionInfo iConnectionInfo1 = dataSourceConnections1[0];
				iConnectionInfo1.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

				rdprint1.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.Thai + "'";
				rdprint1.DataDefinition.FormulaFields["StartDay"].Text = StartDate1;
				rdprint1.DataDefinition.FormulaFields["StartMonth"].Text = StartDate2;
				rdprint1.DataDefinition.FormulaFields["StartYear"].Text = StartDate3;
				
				rdprint1.DataDefinition.FormulaFields["EndDay"].Text = EndDate1;
				rdprint1.DataDefinition.FormulaFields["EndMonth"].Text = EndDate2;
				rdprint1.DataDefinition.FormulaFields["Endyear"].Text = EndDate3;

				crvSummaryCheque.ReportSource = rdprint1;

				//2222
				ReportDocument rdprint2 = new ReportDocument();
				rdprint2.Load(@ApplicationProfile.REPORT_PATH + "rptVehicleMaintenanceByGarageSummary_Cash.rpt");

				DataSourceConnections dataSourceConnections2 = rdprint2.DataSourceConnections;
				IConnectionInfo iConnectionInfo2 = dataSourceConnections2[0];
				iConnectionInfo2.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

				rdprint2.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.Thai + "'";
				rdprint2.DataDefinition.FormulaFields["StartDay"].Text = StartDate1;
				rdprint2.DataDefinition.FormulaFields["StartMonth"].Text = StartDate2;
				rdprint2.DataDefinition.FormulaFields["StartYear"].Text = StartDate3;
				
				rdprint2.DataDefinition.FormulaFields["EndDay"].Text = EndDate1;
				rdprint2.DataDefinition.FormulaFields["EndMonth"].Text = EndDate2;
				rdprint2.DataDefinition.FormulaFields["Endyear"].Text = EndDate3;

				crvSummaryCash.ReportSource = rdprint2;

				//3333
				ReportDocument rdprint3 = new ReportDocument();
				rdprint3.Load(@ApplicationProfile.REPORT_PATH + "rptVehicleMaintenanceByGarageDetail_Credit.rpt");

				DataSourceConnections dataSourceConnections3 = rdprint3.DataSourceConnections;
				IConnectionInfo iConnectionInfo3 = dataSourceConnections3[0];
				iConnectionInfo3.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

				rdprint3.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.Thai + "'";
				rdprint3.DataDefinition.FormulaFields["StartDay"].Text = StartDate1;
				rdprint3.DataDefinition.FormulaFields["StartMonth"].Text = StartDate2;
				rdprint3.DataDefinition.FormulaFields["StartYear"].Text = StartDate3;
				
				rdprint3.DataDefinition.FormulaFields["EndDay"].Text = EndDate1;
				rdprint3.DataDefinition.FormulaFields["EndMonth"].Text = EndDate2;
				rdprint3.DataDefinition.FormulaFields["Endyear"].Text = EndDate3;

				crvDetailCheque.ReportSource = rdprint3;

				//4444
				ReportDocument rdprint4 = new ReportDocument();
				rdprint4.Load(@ApplicationProfile.REPORT_PATH + "rptVehicleMaintenanceByGarageDetail_Cash.rpt");

				DataSourceConnections dataSourceConnections4 = rdprint4.DataSourceConnections;
				IConnectionInfo iConnectionInfo4 = dataSourceConnections4[0];
				iConnectionInfo4.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

				rdprint4.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.Thai + "'";
				rdprint4.DataDefinition.FormulaFields["StartDay"].Text = StartDate1;
				rdprint4.DataDefinition.FormulaFields["StartMonth"].Text = StartDate2;
				rdprint4.DataDefinition.FormulaFields["StartYear"].Text = StartDate3;
				
				rdprint4.DataDefinition.FormulaFields["EndDay"].Text = EndDate1;
				rdprint4.DataDefinition.FormulaFields["EndMonth"].Text = EndDate2;
				rdprint4.DataDefinition.FormulaFields["Endyear"].Text = EndDate3;

				crvDetailCash.ReportSource = rdprint4;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
			}
		}
		//		============================== Event ==============================

		public void InitForm()
		{
			if(DateTime.Today.Month == 1)
			{
				dtpStartDate.Value = new DateTime(DateTime.Today.AddYears(-1).Year, DateTime.Today.AddMonths(-1).Month, 1);
				dtpEndDate.Value = new DateTime(DateTime.Today.AddYears(-1).Year, DateTime.Today.AddMonths(-1).Month, 1);
			}
			else
			{
				dtpStartDate.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
				dtpEndDate.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
			}
			tabControl1.Hide();
			dtpStartDate.Focus();
			mdiParent.EnableExitCommand(true);		
		}

		public void RefreshForm()
		{
			tabControl1.Show();
			this.crvSummaryCheque.DisplayToolbar = true;
			this.crvSummaryCash.DisplayToolbar = true;
			this.crvDetailCash.DisplayToolbar = true;
			this.crvDetailCheque.DisplayToolbar = true;
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
		private void frmrptVehicleMaintenanceByGarage_Load(object sender, System.EventArgs e)
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
			crvDetailCash.RefreshReport();
			crvDetailCheque.RefreshReport();
			crvSummaryCash.RefreshReport();
			crvSummaryCheque.RefreshReport();
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}

	}
}
