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
	public class frmTimeCardForPayment : ChildFormBase,IMDIChildForm
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
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvReport;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button cmdShow;
		private System.Windows.Forms.DateTimePicker dtpDate;
		private System.Windows.Forms.Label label;
		private System.ComponentModel.Container components = null;


		private void InitializeComponent()
		{
            this.crvReport = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdShow = new System.Windows.Forms.Button();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // crvReport
            // 
            this.crvReport.ActiveViewIndex = -1;
            this.crvReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.crvReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvReport.DisplayGroupTree = false;
            this.crvReport.Location = new System.Drawing.Point(18, 89);
            this.crvReport.Name = "crvReport";
            this.crvReport.ShowCloseButton = false;
            this.crvReport.ShowGroupTreeButton = false;
            this.crvReport.Size = new System.Drawing.Size(992, 640);
            this.crvReport.TabIndex = 19;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.cmdShow);
            this.groupBox1.Controls.Add(this.dtpDate);
            this.groupBox1.Controls.Add(this.label);
            this.groupBox1.Location = new System.Drawing.Point(10, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1008, 64);
            this.groupBox1.TabIndex = 18;
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
            this.dtpDate.Size = new System.Drawing.Size(72, 20);
            this.dtpDate.TabIndex = 6;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(24, 24);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(28, 13);
            this.label.TabIndex = 5;
            this.label.Text = "วันที่";
            // 
            // frmTimeCardForPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1028, 746);
            this.Controls.Add(this.crvReport);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmTimeCardForPayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTimeCardForPayment_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmTimeCardForPayment_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		#region - private -
		private CompanyInfo objCompany;
		private CompanyFacade facadeCompany;
		private frmMain mdiParent;
		private TimeCardForPaymentFacade facadeTimeCardForPaymentFacade;
		#endregion

//		============================== Constructor ==============================
		public frmTimeCardForPayment()
		{
			InitializeComponent();
			facadeCompany = new CompanyFacade();
			facadeTimeCardForPaymentFacade = new TimeCardForPaymentFacade();
			this.Text = "TimeCardForPayment";
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
				if(facadeTimeCardForPaymentFacade.GenerateTimeCardPayment(dtpDate.Value))
				{

					objCompany = getCompany();
					ReportDocument rdprint1 = new ReportDocument();
					string StartDate2 = Convert.ToString(dtpDate.Value.Month);
					string StartDate3 = Convert.ToString(dtpDate.Value.Year);

					rdprint1.Load(@ApplicationProfile.REPORT_PATH + "rptTimeCardForPayment.rpt");
					DataSourceConnections dataSourceConnections1 = rdprint1.DataSourceConnections;
					IConnectionInfo iConnectionInfo1 = dataSourceConnections1[0];
					iConnectionInfo1.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

					rdprint1.DataDefinition.FormulaFields["Comp_Name_Thai"].Text = "'" + objCompany.AFullName.Thai + "'";
					rdprint1.DataDefinition.FormulaFields["Comp_Name_Eng"].Text = "'" + objCompany.AFullName.English + "'";
					rdprint1.DataDefinition.FormulaFields["Month"].Text = StartDate2;
					rdprint1.DataDefinition.FormulaFields["Year"].Text = StartDate3;


					crvReport.ReportSource = rdprint1;
				}
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
				dtpDate.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
			}
			crvReport.Hide();
			mdiParent.EnableExitCommand(true);	
		}

		public void RefreshForm()
		{
			crvReport.Show();
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


		private void cmdShow_Click(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			ReportDatabaseLogon();
			RefreshForm();
			mdiParent.EnableExitCommand(true);
			crvReport.RefreshReport();
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}

		private void frmTimeCardForPayment_Load(object sender, System.EventArgs e)
		{
			mdiParent = (frmMain)this.MdiParent;
			InitForm();			
		}

        private void frmTimeCardForPayment_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseReport(crvReport);
        }
	}
}
