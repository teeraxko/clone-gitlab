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
	public class frmListOfDriverWithLongTermContractByDate : ChildFormBase,IMDIChildForm
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
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tbSummary;
		private System.Windows.Forms.TabPage tbDetail;
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvReport2;
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvReport1;
		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdShow = new System.Windows.Forms.Button();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbSummary = new System.Windows.Forms.TabPage();
            this.crvReport1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.tbDetail = new System.Windows.Forms.TabPage();
            this.crvReport2 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tbSummary.SuspendLayout();
            this.tbDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.cmdShow);
            this.groupBox1.Controls.Add(this.dtpDate);
            this.groupBox1.Controls.Add(this.label);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1008, 64);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            // 
            // cmdShow
            // 
            this.cmdShow.Location = new System.Drawing.Point(216, 24);
            this.cmdShow.Name = "cmdShow";
            this.cmdShow.Size = new System.Drawing.Size(75, 23);
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
            this.label.Size = new System.Drawing.Size(45, 13);
            this.label.TabIndex = 5;
            this.label.Text = "เดือน/ปี";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tbSummary);
            this.tabControl1.Controls.Add(this.tbDetail);
            this.tabControl1.Location = new System.Drawing.Point(8, 80);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1008, 656);
            this.tabControl1.TabIndex = 16;
            // 
            // tbSummary
            // 
            this.tbSummary.Controls.Add(this.crvReport1);
            this.tbSummary.Location = new System.Drawing.Point(4, 22);
            this.tbSummary.Name = "tbSummary";
            this.tbSummary.Size = new System.Drawing.Size(1000, 630);
            this.tbSummary.TabIndex = 0;
            this.tbSummary.Text = "สรุปยอดพนักงานขับรถในบริษัทลูกค้า";
            // 
            // crvReport1
            // 
            this.crvReport1.ActiveViewIndex = -1;
            this.crvReport1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.crvReport1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvReport1.DisplayGroupTree = false;
            this.crvReport1.Location = new System.Drawing.Point(20, 19);
            this.crvReport1.Name = "crvReport1";
            this.crvReport1.ShowCloseButton = false;
            this.crvReport1.ShowGroupTreeButton = false;
            this.crvReport1.Size = new System.Drawing.Size(960, 597);
            this.crvReport1.TabIndex = 17;
            // 
            // tbDetail
            // 
            this.tbDetail.Controls.Add(this.crvReport2);
            this.tbDetail.Location = new System.Drawing.Point(4, 22);
            this.tbDetail.Name = "tbDetail";
            this.tbDetail.Size = new System.Drawing.Size(1000, 630);
            this.tbDetail.TabIndex = 1;
            this.tbDetail.Text = "พนักงานขับรถแยกตามบริษัทลูกค้า";
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
            this.crvReport2.Location = new System.Drawing.Point(20, 19);
            this.crvReport2.Name = "crvReport2";
            this.crvReport2.ShowCloseButton = false;
            this.crvReport2.ShowGroupTreeButton = false;
            this.crvReport2.Size = new System.Drawing.Size(960, 592);
            this.crvReport2.TabIndex = 16;
            // 
            // frmListOfDriverWithLongTermContractByDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1028, 746);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmListOfDriverWithLongTermContractByDate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmListOfDriver_WithLongTermContract_ByDate_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmListOfDriverWithLongTermContractByDate_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tbSummary.ResumeLayout(false);
            this.tbDetail.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		#region - private -
		private CompanyInfo objCompany;
		private CompanyFacade facadeCompany;
		private frmMain mdiParent;
		#endregion
		//		============================== Constructor ==============================

		public frmListOfDriverWithLongTermContractByDate()
		{
			InitializeComponent();
			facadeCompany = new CompanyFacade();
			this.Text = "พนักงานขับรถแยกตามบริษัทลูกค้า(เฉพาะสัญญาเช่าระยะยาว)";
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
				////////////1
				rdprint1.Load(@ApplicationProfile.REPORT_PATH + "rptListOfDriver_WithLongTermContract_ByMonth_Summary.rpt");
				DataSourceConnections dataSourceConnections1 = rdprint1.DataSourceConnections;
				IConnectionInfo iConnectionInfo1 = dataSourceConnections1[0];
				iConnectionInfo1.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

				rdprint1.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.Thai + "'";
				rdprint1.DataDefinition.FormulaFields["Date"].Text = string.Format("CDate ({0}, {1}, {2})",dtpDate.Value.Year.ToString(),dtpDate.Value.Month.ToString(),dtpDate.Value.Day.ToString());  
				crvReport1.ReportSource = rdprint1;
				
				////////////2
				///				
				ReportDocument rdprint2 = new ReportDocument();
				rdprint2.Load(@ApplicationProfile.REPORT_PATH + "rptListOfDriver_WithLongTermContract_ByMonth_Detail.rpt");
				DataSourceConnections dataSourceConnections2 = rdprint2.DataSourceConnections;
				IConnectionInfo iConnectionInfo2 = dataSourceConnections2[0];
				iConnectionInfo2.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

				rdprint2.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.Thai + "'";
				//				rdprint2.DataDefinition.FormulaFields["Day"].Text = StartDate2;
				rdprint2.DataDefinition.FormulaFields["Date"].Text = string.Format("CDate ({0}, {1}, {2})",dtpDate.Value.Year.ToString(),dtpDate.Value.Month.ToString(),dtpDate.Value.Day.ToString());  


				crvReport2.ReportSource = rdprint2;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
			}
		}

		//		==============================Base Event ==============================

		public void InitForm()
		{
			//			if(DateTime.Today.Month == 1)
			//			{
			//				dtpDate.Value = new DateTime(DateTime.Today.AddYears(-1).Year, DateTime.Today.AddMonths(-1).Month, 1);
			//
			//			}
			//			else
			//			{
			//				dtpDate.Value = new DateTime(DateTime.Today.Year, DateTime.Today.AddMonths(-1).Month, 1);
			//			}
			dtpDate.Value = DateTime.Today;
			tabControl1.Hide();
			mdiParent.EnableExitCommand(true);		
		}

		public void RefreshForm()
		{
			tabControl1.Show();
			this.crvReport1.DisplayToolbar = true;
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


		//		==============================Base Event ==============================

		private void frmListOfDriver_WithLongTermContract_ByDate_Load(object sender, System.EventArgs e)
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
			crvReport2.RefreshReport();
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}

        private void frmListOfDriverWithLongTermContractByDate_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseReport(crvReport1);
            CloseReport(crvReport2);
        }
	}
}
