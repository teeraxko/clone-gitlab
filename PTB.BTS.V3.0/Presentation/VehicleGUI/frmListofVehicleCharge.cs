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
	public class frmListofVehicleCharge : ChildFormBase,IMDIChildForm
	{
        //This class not use : woranai 16/3/2007
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
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker dtpDate;
		private System.Windows.Forms.Button btnShow;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tbpSummary;
		private System.Windows.Forms.TabPage tbpDetail;
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvSummary;
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvDetail;
		private System.Windows.Forms.TabPage tbpTIS;
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvTIS;
		private System.Windows.Forms.TabPage tbpBSTL;
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvBSTL;
		private System.Windows.Forms.TabPage tbpIMCT;
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvIMCT;
		private System.ComponentModel.Container components = null;


		private void InitializeComponent()
		{
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnShow = new System.Windows.Forms.Button();
			this.dtpDate = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tbpSummary = new System.Windows.Forms.TabPage();
			this.crvSummary = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.tbpDetail = new System.Windows.Forms.TabPage();
			this.crvDetail = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.tbpTIS = new System.Windows.Forms.TabPage();
			this.crvTIS = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.tbpBSTL = new System.Windows.Forms.TabPage();
			this.crvBSTL = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.tbpIMCT = new System.Windows.Forms.TabPage();
			this.crvIMCT = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.groupBox1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tbpSummary.SuspendLayout();
			this.tbpDetail.SuspendLayout();
			this.tbpTIS.SuspendLayout();
			this.tbpBSTL.SuspendLayout();
			this.tbpIMCT.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnShow);
			this.groupBox1.Controls.Add(this.dtpDate);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(1008, 56);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			// 
			// btnShow
			// 
			this.btnShow.Location = new System.Drawing.Point(480, 24);
			this.btnShow.Name = "btnShow";
			this.btnShow.TabIndex = 2;
			this.btnShow.Text = "ดูข้อมูล";
			this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
			// 
			// dtpDate
			// 
			this.dtpDate.CustomFormat = "MM/yyyy";
			this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpDate.Location = new System.Drawing.Point(360, 24);
			this.dtpDate.Name = "dtpDate";
			this.dtpDate.Size = new System.Drawing.Size(80, 20);
			this.dtpDate.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(240, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(81, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "ค่าเช่ารถของเดือน";
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tbpSummary);
			this.tabControl1.Controls.Add(this.tbpDetail);
			this.tabControl1.Controls.Add(this.tbpTIS);
			this.tabControl1.Controls.Add(this.tbpBSTL);
			this.tabControl1.Controls.Add(this.tbpIMCT);
			this.tabControl1.Location = new System.Drawing.Point(8, 72);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(1000, 672);
			this.tabControl1.TabIndex = 1;
			// 
			// tbpSummary
			// 
			this.tbpSummary.Controls.Add(this.crvSummary);
			this.tbpSummary.Location = new System.Drawing.Point(4, 22);
			this.tbpSummary.Name = "tbpSummary";
			this.tbpSummary.Size = new System.Drawing.Size(992, 646);
			this.tbpSummary.TabIndex = 0;
			this.tbpSummary.Text = "สรุป";
			// 
			// crvSummary
			// 
			this.crvSummary.ActiveViewIndex = -1;
			this.crvSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.crvSummary.DisplayGroupTree = false;
			this.crvSummary.DisplayToolbar = false;
			this.crvSummary.Location = new System.Drawing.Point(16, 16);
			this.crvSummary.Name = "crvSummary";
			this.crvSummary.ReportSource = null;
			this.crvSummary.ShowCloseButton = false;
			this.crvSummary.ShowGroupTreeButton = false;
			this.crvSummary.Size = new System.Drawing.Size(960, 616);
			this.crvSummary.TabIndex = 0;
			// 
			// tbpDetail
			// 
			this.tbpDetail.Controls.Add(this.crvDetail);
			this.tbpDetail.Location = new System.Drawing.Point(4, 22);
			this.tbpDetail.Name = "tbpDetail";
			this.tbpDetail.Size = new System.Drawing.Size(992, 646);
			this.tbpDetail.TabIndex = 1;
			this.tbpDetail.Text = "รายละเอียด";
			// 
			// crvDetail
			// 
			this.crvDetail.ActiveViewIndex = -1;
			this.crvDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.crvDetail.DisplayGroupTree = false;
			this.crvDetail.DisplayToolbar = false;
			this.crvDetail.Location = new System.Drawing.Point(16, 16);
			this.crvDetail.Name = "crvDetail";
			this.crvDetail.ReportSource = null;
			this.crvDetail.ShowCloseButton = false;
			this.crvDetail.ShowGroupTreeButton = false;
			this.crvDetail.Size = new System.Drawing.Size(960, 616);
			this.crvDetail.TabIndex = 1;
			// 
			// tbpTIS
			// 
			this.tbpTIS.Controls.Add(this.crvTIS);
			this.tbpTIS.Location = new System.Drawing.Point(4, 22);
			this.tbpTIS.Name = "tbpTIS";
			this.tbpTIS.Size = new System.Drawing.Size(992, 646);
			this.tbpTIS.TabIndex = 2;
			this.tbpTIS.Text = "รายละเอียด(TIS)";
			// 
			// crvTIS
			// 
			this.crvTIS.ActiveViewIndex = -1;
			this.crvTIS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.crvTIS.DisplayGroupTree = false;
			this.crvTIS.DisplayToolbar = false;
			this.crvTIS.Location = new System.Drawing.Point(16, 16);
			this.crvTIS.Name = "crvTIS";
			this.crvTIS.ReportSource = null;
			this.crvTIS.ShowCloseButton = false;
			this.crvTIS.ShowGroupTreeButton = false;
			this.crvTIS.Size = new System.Drawing.Size(976, 616);
			this.crvTIS.TabIndex = 0;
			// 
			// tbpBSTL
			// 
			this.tbpBSTL.Controls.Add(this.crvBSTL);
			this.tbpBSTL.Location = new System.Drawing.Point(4, 22);
			this.tbpBSTL.Name = "tbpBSTL";
			this.tbpBSTL.Size = new System.Drawing.Size(992, 646);
			this.tbpBSTL.TabIndex = 3;
			this.tbpBSTL.Text = "รายละเอียด(BSTL)";
			// 
			// crvBSTL
			// 
			this.crvBSTL.ActiveViewIndex = -1;
			this.crvBSTL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.crvBSTL.DisplayGroupTree = false;
			this.crvBSTL.DisplayToolbar = false;
			this.crvBSTL.Location = new System.Drawing.Point(16, 16);
			this.crvBSTL.Name = "crvBSTL";
			this.crvBSTL.ReportSource = null;
			this.crvBSTL.ShowCloseButton = false;
			this.crvBSTL.ShowGroupTreeButton = false;
			this.crvBSTL.Size = new System.Drawing.Size(976, 616);
			this.crvBSTL.TabIndex = 1;
			// 
			// tbpIMCT
			// 
			this.tbpIMCT.Controls.Add(this.crvIMCT);
			this.tbpIMCT.Location = new System.Drawing.Point(4, 22);
			this.tbpIMCT.Name = "tbpIMCT";
			this.tbpIMCT.Size = new System.Drawing.Size(992, 646);
			this.tbpIMCT.TabIndex = 4;
			this.tbpIMCT.Text = "รายละเอียด(IMCT)";
			// 
			// crvIMCT
			// 
			this.crvIMCT.ActiveViewIndex = -1;
			this.crvIMCT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.crvIMCT.DisplayGroupTree = false;
			this.crvIMCT.DisplayToolbar = false;
			this.crvIMCT.Location = new System.Drawing.Point(8, 15);
			this.crvIMCT.Name = "crvIMCT";
			this.crvIMCT.ReportSource = null;
			this.crvIMCT.ShowCloseButton = false;
			this.crvIMCT.ShowGroupTreeButton = false;
			this.crvIMCT.Size = new System.Drawing.Size(976, 616);
			this.crvIMCT.TabIndex = 2;
			// 
			// frmListofVehicleCharge
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(1028, 746);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.groupBox1);
			this.Name = "frmListofVehicleCharge";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmListofVehicleChargeSummary_Load);
			this.groupBox1.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tbpSummary.ResumeLayout(false);
			this.tbpDetail.ResumeLayout(false);
			this.tbpTIS.ResumeLayout(false);
			this.tbpBSTL.ResumeLayout(false);
			this.tbpIMCT.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region - private -
		private CompanyInfo objCompany;
		private CompanyFacade facadeCompany;
		private frmMain mdiParent;
		#endregion

		//		============================== Constructor ==============================
		public frmListofVehicleCharge()
		{
			InitializeComponent();
			facadeCompany = new CompanyFacade();
			this.Text = "รายงานแสดงค่าเช่ารถรายเดือน";

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
				//crvSummary
				ReportDocument rdprint1 = new ReportDocument();
				string Month = Convert.ToString(dtpDate.Value.Month);
				string Year  = Convert.ToString(dtpDate.Value.Year);

				rdprint1.Load(@ApplicationProfile.REPORT_PATH + "rptVehicleChargeSummary.rpt");
				DataSourceConnections dataSourceConnections1 = rdprint1.DataSourceConnections;
				IConnectionInfo iConnectionInfo1 = dataSourceConnections1[0];
				iConnectionInfo1.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

				rdprint1.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.Thai + "'";
				rdprint1.DataDefinition.FormulaFields["Month"].Text = Month;
				rdprint1.DataDefinition.FormulaFields["Year"].Text = Year;
			
				crvSummary.ReportSource = rdprint1;


				//crvDetail
				ReportDocument rdprint2 = new ReportDocument();

				rdprint2.Load(@ApplicationProfile.REPORT_PATH + "rptVehicleChargeDetail.rpt");
				DataSourceConnections dataSourceConnections2 = rdprint2.DataSourceConnections;
				IConnectionInfo iConnectionInfo2 = dataSourceConnections2[0];
				iConnectionInfo2.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

				rdprint2.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.Thai + "'";
				rdprint2.DataDefinition.FormulaFields["Month"].Text = Month;
				rdprint2.DataDefinition.FormulaFields["Year"].Text = Year;
				
				crvDetail.ReportSource = rdprint2;

				//crvTIS

				ReportDocument rdprint3 = new ReportDocument();

				rdprint3.Load(@ApplicationProfile.REPORT_PATH + "rptVehicleChargeDetailTISOnly.rpt");
				DataSourceConnections dataSourceConnections3 = rdprint3.DataSourceConnections;
				IConnectionInfo iConnectionInfo3 = dataSourceConnections3[0];
				iConnectionInfo3.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

				rdprint3.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.Thai + "'";
				rdprint3.DataDefinition.FormulaFields["Month"].Text = Month;
				rdprint3.DataDefinition.FormulaFields["Year"].Text = Year;

				crvTIS.ReportSource = rdprint3;

				//crvBSTL

				ReportDocument rdprint4 = new ReportDocument();

				rdprint4.Load(@ApplicationProfile.REPORT_PATH + "rptVehicleChargeDetailBSTLOnly.rpt");
				DataSourceConnections dataSourceConnections4 = rdprint4.DataSourceConnections;
				IConnectionInfo iConnectionInfo4 = dataSourceConnections4[0];
				iConnectionInfo4.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

				rdprint4.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.Thai + "'";
				rdprint4.DataDefinition.FormulaFields["Month"].Text = Month;
				rdprint4.DataDefinition.FormulaFields["Year"].Text = Year;

				crvBSTL.ReportSource = rdprint4;

				//crvIMCT

				ReportDocument rdprint5 = new ReportDocument();

				rdprint5.Load(@ApplicationProfile.REPORT_PATH + "rptVehicleChargeDetailIMCTOnly.rpt");
				DataSourceConnections dataSourceConnections5 = rdprint5.DataSourceConnections;
				IConnectionInfo iConnectionInfo5 = dataSourceConnections5[0];
				iConnectionInfo5.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

				rdprint5.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.Thai + "'";
				rdprint5.DataDefinition.FormulaFields["Month"].Text = Month;
				rdprint5.DataDefinition.FormulaFields["Year"].Text = Year;

				crvIMCT.ReportSource = rdprint5;


			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
			}
		}
		//		==============================Base Event ==============================
		public void InitForm()
		{
			if(DateTime.Today.Month == 1)
			{
				dtpDate.Value = new DateTime(DateTime.Today.AddYears(-1).Year, DateTime.Today.AddMonths(-1).Month, 1);

			}
			else
			{
				dtpDate.Value = new DateTime(DateTime.Today.Year, DateTime.Today.AddMonths(-1).Month, 1);
			}
			tabControl1.Hide();
			mdiParent.EnableExitCommand(true);
		}

		public void RefreshForm()
		{
			tabControl1.Show();
			mdiParent.EnableExitCommand(true);
			this.crvDetail.DisplayToolbar = true;
			this.crvSummary.DisplayToolbar = true;
			this.crvTIS.DisplayToolbar = true;
			this.crvBSTL.DisplayToolbar = true;
			this.crvIMCT.DisplayToolbar = true;
		}

		public void PrintForm()
		{
		}

		public void ExitForm()
		{
			this.Hide();
		}

		//		============================== Event ==============================

		private void frmListofVehicleChargeSummary_Load(object sender, System.EventArgs e)
		{
			mdiParent = (frmMain)this.MdiParent;
			InitForm();
		}

		private void btnShow_Click(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			ReportDatabaseLogon();
			RefreshForm();
			mdiParent.EnableExitCommand(true);
			crvSummary.RefreshReport();
			crvDetail.RefreshReport();
			crvTIS.RefreshReport();
			crvBSTL.RefreshReport();
			crvIMCT.RefreshReport();
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}


	}
}
