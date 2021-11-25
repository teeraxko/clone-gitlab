using System;
using System.Data.SqlClient;
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
using Facade.AttendanceFacade;

using Presentation.CommonGUI;

using SystemFramework.AppConfig;
using SystemFramework.AppMessage;
using SystemFramework.AppException;

namespace Presentation.AttendanceGUI
{
	public class frmrptNonPayrollBenefit : ChildFormBase,IMDIChildForm
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
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvNonpayroll;
		private System.Windows.Forms.DateTimePicker dtpDate;
		private System.Windows.Forms.Button cmdShow;
		private System.Windows.Forms.Label label;
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvReport;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvReport2;
		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.cmdShow = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.crvNonpayroll = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.crvReport = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.crvReport2 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpDate);
            this.groupBox1.Controls.Add(this.cmdShow);
            this.groupBox1.Controls.Add(this.label);
            this.groupBox1.Location = new System.Drawing.Point(367, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(294, 56);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // dtpDate
            // 
            this.dtpDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpDate.CustomFormat = "dd/MM/yyyy";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(78, 24);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(96, 20);
            this.dtpDate.TabIndex = 8;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // cmdShow
            // 
            this.cmdShow.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmdShow.Location = new System.Drawing.Point(190, 24);
            this.cmdShow.Name = "cmdShow";
            this.cmdShow.Size = new System.Drawing.Size(75, 23);
            this.cmdShow.TabIndex = 9;
            this.cmdShow.Text = "ส่งข้อมูล";
            this.cmdShow.Click += new System.EventHandler(this.cmdShow_Click);
            // 
            // label
            // 
            this.label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(30, 24);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(46, 13);
            this.label.TabIndex = 7;
            this.label.Text = "จ่ายวันที่";
            // 
            // crvNonpayroll
            // 
            this.crvNonpayroll.ActiveViewIndex = -1;
            this.crvNonpayroll.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.crvNonpayroll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvNonpayroll.DisplayGroupTree = false;
            this.crvNonpayroll.Location = new System.Drawing.Point(688, 24);
            this.crvNonpayroll.Name = "crvNonpayroll";
            this.crvNonpayroll.ShowCloseButton = false;
            this.crvNonpayroll.ShowGroupTreeButton = false;
            this.crvNonpayroll.Size = new System.Drawing.Size(266, 48);
            this.crvNonpayroll.TabIndex = 24;
            // 
            // crvReport
            // 
            this.crvReport.ActiveViewIndex = -1;
            this.crvReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.crvReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvReport.DisplayGroupTree = false;
            this.crvReport.DisplayToolbar = false;
            this.crvReport.Location = new System.Drawing.Point(8, 16);
            this.crvReport.Name = "crvReport";
            this.crvReport.ShowCloseButton = false;
            this.crvReport.ShowGroupTreeButton = false;
            this.crvReport.Size = new System.Drawing.Size(960, 584);
            this.crvReport.TabIndex = 14;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(16, 88);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(992, 640);
            this.tabControl1.TabIndex = 25;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.crvReport);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(984, 614);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Non-Payroll Bank Deposit List";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.crvReport2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(984, 614);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Bank Deposit List";
            // 
            // crvReport2
            // 
            this.crvReport2.ActiveViewIndex = -1;
            this.crvReport2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.crvReport2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvReport2.DisplayGroupTree = false;
            this.crvReport2.DisplayStatusBar = false;
            this.crvReport2.DisplayToolbar = false;
            this.crvReport2.Location = new System.Drawing.Point(8, 16);
            this.crvReport2.Name = "crvReport2";
            this.crvReport2.ShowCloseButton = false;
            this.crvReport2.ShowGroupTreeButton = false;
            this.crvReport2.Size = new System.Drawing.Size(960, 584);
            this.crvReport2.TabIndex = 15;
            // 
            // frmrptNonPayrollBenefit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1028, 746);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.crvNonpayroll);
            this.Name = "frmrptNonPayrollBenefit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmrptNonPayrollBenefit_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmrptNonPayrollBenefit_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		#region - private -
		private CompanyInfo objCompany;
		private CompanyFacade facadeCompany;
		private frmMain mdiParent;
		private NonPayrollBenefitFacade facadeNonPayrollBenefit;
		private DateTime yearMonth;
		#endregion

//		==============================Contructor==============================
		public frmrptNonPayrollBenefit() : base()
		{
			InitializeComponent();
			facadeCompany = new CompanyFacade();
			facadeNonPayrollBenefit = new NonPayrollBenefitFacade();
			this.Text = "Non Payroll Benefit";
		}

//		============================== Private Method ==============================
		private CompanyInfo getCompany()
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

		private void ReportDatabaseLogon()
		{
			try
			{
				objCompany = getCompany();
				if(facadeNonPayrollBenefit.GenNonPayrollBenefitProcess(yearMonth))
				{
					//If error in execute process, it show by try-catch
					facadeNonPayrollBenefit.GenNonPayrollBenefit(yearMonth, dtpDate.Value);
					
					SaveFileDialog savef = new SaveFileDialog();
					savef.InitialDirectory = @"c:\..";

					//string exportPath = "C:\\COMDAT.DAT"; 
                    string exportPath = "COMDAT.DAT"; 
					savef.FileName = exportPath;
					savef.ShowDialog();
					//======================================
					//	string exportPath =  exportFileName;			
					string StartDate1 = Convert.ToString(dtpDate.Value.Day);
					string StartDate2 = Convert.ToString(dtpDate.Value.Month);
					string StartDate3 = Convert.ToString(dtpDate.Value.Year);

					ReportDocument crReportDocument = new ReportDocument(); 
					crReportDocument.Load(@ApplicationProfile.REPORT_PATH + "rptNonPayrollBenefit.rpt");
					DataSourceConnections dataSourceConnections = crReportDocument.DataSourceConnections;
					IConnectionInfo iConnectionInfo = dataSourceConnections[0];
					iConnectionInfo.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);
		
					crReportDocument.DataDefinition.FormulaFields["DAY"].Text = StartDate1;
					crReportDocument.DataDefinition.FormulaFields["MONTH"].Text = StartDate2;
					crReportDocument.DataDefinition.FormulaFields["YEAR"].Text = StartDate3;
				
					crvNonpayroll.ReportSource = crReportDocument;

					ExportOptions crExportOptions; 
					DiskFileDestinationOptions crDestOptions = new DiskFileDestinationOptions(); 

					//crDestOptions.DiskFileName = exportPath; 

                    crDestOptions.DiskFileName = savef.FileName; 

					crExportOptions = crReportDocument.ExportOptions; 
					crExportOptions.DestinationOptions = crDestOptions; 
					crExportOptions.ExportDestinationType = ExportDestinationType.DiskFile; 
					crExportOptions.ExportFormatType = ExportFormatType.Text; 

					TextFormatOptions csValuesFormatOptions;
					csValuesFormatOptions = ExportOptions.CreateTextFormatOptions();
					csValuesFormatOptions.CharactersPerInch = 12;
					csValuesFormatOptions.LinesPerPage = 0;

					crExportOptions = crReportDocument.ExportOptions; 
					crExportOptions.DestinationOptions = crDestOptions; 
					crExportOptions.ExportDestinationType = ExportDestinationType.DiskFile; 
					crExportOptions.ExportFormatType = ExportFormatType.Text; 
					crExportOptions.ExportFormatOptions = csValuesFormatOptions;

					crReportDocument.Export(crExportOptions); 
//						crReportDocument.ExportToDisk (ExportFormatType.Text, exportPath); 
					//rptPayrollConnectionCheckList
					string Date1 = Convert.ToString(dtpDate.Value.AddMonths(-1).Month);
                    string Date2 = Convert.ToString(dtpDate.Value.AddMonths(-1).Year);

					ReportDocument crReportDocument1 = new ReportDocument(); 
					crReportDocument1.Load(@ApplicationProfile.REPORT_PATH + "rptNonPayrollConnectionCheckList.rpt");
					DataSourceConnections dataSourceConnections1 = crReportDocument1.DataSourceConnections;
					IConnectionInfo iConnectionInfo1 = dataSourceConnections1[0];
					iConnectionInfo1.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);
		
					crReportDocument1.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.English + "'";
					crReportDocument1.DataDefinition.FormulaFields["MONTH"].Text = Date1;
					crReportDocument1.DataDefinition.FormulaFields["YEAR"].Text = Date2;

					crvReport.ReportSource = crReportDocument1;
/////
					ReportDocument crReportDocument2 = new ReportDocument(); 
					crReportDocument2.Load(@ApplicationProfile.REPORT_PATH + "rptNonPayrollBenefitBankDeposit.rpt");
					DataSourceConnections dataSourceConnections2 = crReportDocument2.DataSourceConnections;
					IConnectionInfo iConnectionInfo2 = dataSourceConnections2[0];
					iConnectionInfo2.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);
		
					crvReport2.ReportSource = crReportDocument2;
				}
			}
			catch(SqlException sqlex)
			{
				Message(sqlex);
			}
			catch(AppExceptionBase ex)
			{
				Message(ex);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
			}
		}

//		==============================Base Event ==============================
		public void InitForm()
		{
			try
			{
				dtpDate.Value = facadeNonPayrollBenefit.RetriveDate(new System.DateTime(DateTime.Today.Year, DateTime.Today.Month, 7));
				crvNonpayroll.Hide();
				tabControl1.Hide();
				mdiParent.EnableExitCommand(true);
			}
			catch(SqlException sqlex)
			{
				Message(sqlex);
			}
			catch(AppExceptionBase ex)
			{
				Message(ex);
			}
			catch(Exception ex)
			{
				Message(ex);
			}		
			finally
			{
			}
		}

		public void RefreshForm()
		{
			tabControl1.Show();

			this.crvReport.DisplayToolbar = true;
			this.crvReport2.DisplayToolbar = true;
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
		private void cmdShow_Click(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			ReportDatabaseLogon();
			RefreshForm();
			mdiParent.EnableExitCommand(true);
			crvReport.RefreshReport();
			crvReport2.RefreshReport();
			this.crvReport.DisplayToolbar = true;
			this.crvReport2.DisplayToolbar = true;
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}

		private void frmrptNonPayrollBenefit_Load(object sender, System.EventArgs e)
		{
			mdiParent = (frmMain)this.MdiParent;
			InitForm();
		}

		private void dtpDate_ValueChanged(object sender, System.EventArgs e)
		{
			yearMonth = new System.DateTime(dtpDate.Value.AddMonths(-1).Year, dtpDate.Value.AddMonths(-1).Month, 1);
		}

        private void frmrptNonPayrollBenefit_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseReport(crvNonpayroll);
            CloseReport(crvReport);
            CloseReport(crvReport2);
        }
	}
}
