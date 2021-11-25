using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using SystemFramework.AppConfig;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

using ictus.Common.Entity;
using ictus.PIS.PI.Entity;

using Facade.PiFacade;
using Presentation.CommonGUI;

namespace Presentation.PiGUI
{
	/// <summary>
	/// Summary description for FrmListOfPictureEmployee.
	/// </summary>
	public class FrmListOfPictureEmployee : ChildFormBase,IMDIChildForm
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvReport3;
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvReport1;
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvReport2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private CompanyInfo objCompany;
		private CompanyFacade facadeCompany;
		private System.Windows.Forms.Button btnShow;
		private System.Windows.Forms.DateTimePicker dtpToDate;
		private System.Windows.Forms.DateTimePicker dtpFromDate;
        private TabPage tabPage4;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvReport4;
		private frmMain mdiParent;

		public FrmListOfPictureEmployee()
		{
			InitializeComponent();
			facadeCompany = new CompanyFacade();
			this.Text = "รายงาน รายชื่อพนักงานพร้อมรูปถ่าย";
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnShow = new System.Windows.Forms.Button();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.crvReport1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.crvReport2 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.crvReport3 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.crvReport4 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnShow);
            this.groupBox1.Controls.Add(this.dtpToDate);
            this.groupBox1.Controls.Add(this.dtpFromDate);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(660, 48);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "ระหว่างเดือน";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(164, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "ถึง";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(296, 16);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(68, 20);
            this.btnShow.TabIndex = 2;
            this.btnShow.Text = "Show";
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "MM/yyyy";
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(200, 16);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(80, 20);
            this.dtpToDate.TabIndex = 1;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "MM/yyyy";
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(80, 16);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(80, 20);
            this.dtpFromDate.TabIndex = 0;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 48);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(660, 3);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 51);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(660, 450);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.crvReport1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(652, 424);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "พนักงานปลดออก";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // crvReport1
            // 
            this.crvReport1.ActiveViewIndex = -1;
            this.crvReport1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvReport1.DisplayGroupTree = false;
            this.crvReport1.DisplayStatusBar = false;
            this.crvReport1.DisplayToolbar = false;
            this.crvReport1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvReport1.Location = new System.Drawing.Point(0, 0);
            this.crvReport1.Name = "crvReport1";
            this.crvReport1.ShowCloseButton = false;
            this.crvReport1.ShowGroupTreeButton = false;
            this.crvReport1.Size = new System.Drawing.Size(652, 424);
            this.crvReport1.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.crvReport2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(652, 424);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "พนักงานที่ลาออก";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // crvReport2
            // 
            this.crvReport2.ActiveViewIndex = -1;
            this.crvReport2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvReport2.DisplayGroupTree = false;
            this.crvReport2.DisplayStatusBar = false;
            this.crvReport2.DisplayToolbar = false;
            this.crvReport2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvReport2.Location = new System.Drawing.Point(0, 0);
            this.crvReport2.Name = "crvReport2";
            this.crvReport2.ShowCloseButton = false;
            this.crvReport2.ShowGroupTreeButton = false;
            this.crvReport2.Size = new System.Drawing.Size(652, 424);
            this.crvReport2.TabIndex = 2;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.crvReport3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(652, 424);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "พนักงานใหม่";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // crvReport3
            // 
            this.crvReport3.ActiveViewIndex = -1;
            this.crvReport3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvReport3.DisplayGroupTree = false;
            this.crvReport3.DisplayStatusBar = false;
            this.crvReport3.DisplayToolbar = false;
            this.crvReport3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvReport3.Location = new System.Drawing.Point(0, 0);
            this.crvReport3.Name = "crvReport3";
            this.crvReport3.ShowCloseButton = false;
            this.crvReport3.ShowGroupTreeButton = false;
            this.crvReport3.Size = new System.Drawing.Size(652, 424);
            this.crvReport3.TabIndex = 1;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.crvReport4);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(652, 424);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "พนักงานเกษียณอายุ";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // crvReport4
            // 
            this.crvReport4.ActiveViewIndex = -1;
            this.crvReport4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvReport4.DisplayGroupTree = false;
            this.crvReport4.DisplayStatusBar = false;
            this.crvReport4.DisplayToolbar = false;
            this.crvReport4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvReport4.Location = new System.Drawing.Point(0, 0);
            this.crvReport4.Name = "crvReport4";
            this.crvReport4.ShowCloseButton = false;
            this.crvReport4.ShowGroupTreeButton = false;
            this.crvReport4.Size = new System.Drawing.Size(652, 424);
            this.crvReport4.TabIndex = 3;
            // 
            // FrmListOfPictureEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(660, 501);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmListOfPictureEmployee";
            this.Text = "FrmListOfPictureEmployee";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmListOfPictureEmployee_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmListOfPictureEmployee_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void FrmListOfPictureEmployee_Load(object sender, System.EventArgs e)
		{
			mdiParent = (frmMain)this.MdiParent;
			InitForm();

			crvReport1.Refresh();
			crvReport1.DisplayToolbar = true;
			crvReport2.Refresh();
			crvReport2.DisplayToolbar = true;
			crvReport3.Refresh();
			crvReport3.DisplayToolbar = true;
            crvReport4.Refresh();
            crvReport4.DisplayToolbar = true;		
		}

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
				DateTime startDate = dtpFromDate.Value;
				DateTime endDate = dtpToDate.Value;

				///report1
				ReportDocument rdprint1 = new ReportDocument();
				rdprint1.Load(@ApplicationProfile.REPORT_PATH + "rptListOfDischargeStaff.rpt");
				DataSourceConnections dataSourceConnections1 = rdprint1.DataSourceConnections;
				IConnectionInfo iConnectionInfo1 = dataSourceConnections1[0];
				iConnectionInfo1.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

				rdprint1.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.Thai + "'";
				rdprint1.DataDefinition.FormulaFields["FromDate"].Text = string.Format("CDate ({0}, {1}, {2})",startDate.Year.ToString(),startDate.Month.ToString(),"1");  
				rdprint1.DataDefinition.FormulaFields["ToDate"].Text = string.Format("CDate ({0}, {1}, {2})",endDate.Year.ToString(),endDate.Month.ToString(),DateTime.DaysInMonth(endDate.Year, endDate.Month).ToString());  
				rdprint1.DataDefinition.FormulaFields["FilePath"].Text = @"cstr('" + ApplicationProfile.PHOTO_PATH+ "')";

				crvReport1.ReportSource = rdprint1;
				///

				///report1
				ReportDocument rdprint2 = new ReportDocument();
				rdprint2.Load(@ApplicationProfile.REPORT_PATH + "rptListOfResignStaff.rpt");
				DataSourceConnections dataSourceConnections2 = rdprint2.DataSourceConnections;
				IConnectionInfo iConnectionInfo2 = dataSourceConnections2[0];
				iConnectionInfo2.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

				rdprint2.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.Thai + "'";
				rdprint2.DataDefinition.FormulaFields["FromDate"].Text = string.Format("CDate ({0}, {1}, {2})",startDate.Year.ToString(),startDate.Month.ToString(),"1");  
				rdprint2.DataDefinition.FormulaFields["ToDate"].Text = string.Format("CDate ({0}, {1}, {2})",endDate.Year.ToString(),endDate.Month.ToString(),DateTime.DaysInMonth(endDate.Year, endDate.Month).ToString());  
				rdprint2.DataDefinition.FormulaFields["FilePath"].Text = @"cstr('" + ApplicationProfile.PHOTO_PATH+ "')";

				crvReport2.ReportSource = rdprint2;
				///

				///report3
				ReportDocument rdprint3 = new ReportDocument();
				rdprint3.Load(@ApplicationProfile.REPORT_PATH + "rptListOfNewStaff.rpt");
				DataSourceConnections dataSourceConnections3 = rdprint3.DataSourceConnections;
				IConnectionInfo iConnectionInfo3 = dataSourceConnections3[0];
				iConnectionInfo3.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

				rdprint3.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.Thai + "'";
				rdprint3.DataDefinition.FormulaFields["FromDate"].Text = string.Format("CDate ({0}, {1}, {2})",startDate.Year.ToString(),startDate.Month.ToString(),"1");  
				rdprint3.DataDefinition.FormulaFields["ToDate"].Text = string.Format("CDate ({0}, {1}, {2})",endDate.Year.ToString(),endDate.Month.ToString(),DateTime.DaysInMonth(endDate.Year, endDate.Month).ToString());  
				rdprint3.DataDefinition.FormulaFields["FilePath"].Text = @"cstr('" + ApplicationProfile.PHOTO_PATH+ "')";

				crvReport3.ReportSource = rdprint3;

                ///report4  
                ReportDocument rdprint4 = new ReportDocument();
                rdprint4.Load(@ApplicationProfile.REPORT_PATH + "rptListOfRetireStaffPicture.rpt");
                DataSourceConnections dataSourceConnections4 = rdprint4.DataSourceConnections;
                IConnectionInfo iConnectionInfo4 = dataSourceConnections4[0];
                iConnectionInfo4.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

                rdprint4.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.Thai + "'";
                rdprint4.DataDefinition.FormulaFields["FromDate"].Text = string.Format("CDate ({0}, {1}, {2})", startDate.Year.ToString(), startDate.Month.ToString(), "1");
                rdprint4.DataDefinition.FormulaFields["ToDate"].Text = string.Format("CDate ({0}, {1}, {2})", endDate.Year.ToString(), endDate.Month.ToString(), DateTime.DaysInMonth(endDate.Year, endDate.Month).ToString());
                rdprint4.DataDefinition.FormulaFields["FilePath"].Text = @"cstr('" + ApplicationProfile.PHOTO_PATH + "')";

                crvReport4.ReportSource = rdprint4;
				///
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
			}
		}

		//		==============================Base Event ==============================
		public void InitForm()
		{
			dtpFromDate.Value = DateTime.Now.Date;
			dtpToDate.Value = DateTime.Now.Date;
			crvReport1.Hide();
			crvReport2.Hide();
			crvReport3.Hide();
            crvReport4.Hide();
			mdiParent.EnableExitCommand(true);		
		}

		public void RefreshForm()
		{
			crvReport1.Show();
			crvReport2.Show();
			crvReport3.Show();
            crvReport4.Show();
			mdiParent.EnableExitCommand(true);
		}

		public void PrintForm()
		{
		}

		public void ExitForm()
		{
			this.Hide();
		}

		private void btnShow_Click(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			ReportDatabaseLogon();
			RefreshForm();
			mdiParent.EnableExitCommand(true);
			crvReport1.RefreshReport();
			crvReport2.RefreshReport();
			crvReport3.RefreshReport();
            crvReport4.RefreshReport();
			this.Cursor = System.Windows.Forms.Cursors.Default;

		}

        private void FrmListOfPictureEmployee_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseReport(crvReport1);
            CloseReport(crvReport2);
            CloseReport(crvReport3);
            CloseReport(crvReport4);
        }
	}
}
