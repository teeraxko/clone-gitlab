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

namespace Presentation.AttendanceGUI
{
	public class frmListofDriverExcessDeductionByMonth : ChildFormBase,IMDIChildForm
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
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvDriverExcess;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button cmdShow;
		private System.Windows.Forms.DateTimePicker dtpDate;
		private System.Windows.Forms.Label label;
		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
            this.crvDriverExcess = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label = new System.Windows.Forms.Label();
            this.cmdShow = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // crvDriverExcess
            // 
            this.crvDriverExcess.ActiveViewIndex = -1;
            this.crvDriverExcess.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.crvDriverExcess.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvDriverExcess.DisplayGroupTree = false;
            this.crvDriverExcess.Location = new System.Drawing.Point(16, 80);
            this.crvDriverExcess.Name = "crvDriverExcess";
            this.crvDriverExcess.ShowCloseButton = false;
            this.crvDriverExcess.ShowGroupTreeButton = false;
            this.crvDriverExcess.Size = new System.Drawing.Size(688, 392);
            this.crvDriverExcess.TabIndex = 16;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dtpDate);
            this.groupBox1.Controls.Add(this.label);
            this.groupBox1.Controls.Add(this.cmdShow);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(696, 56);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "MM/yyyy";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(88, 20);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(72, 20);
            this.dtpDate.TabIndex = 100;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(32, 24);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(45, 13);
            this.label.TabIndex = 101;
            this.label.Text = "เดือน/ปี";
            // 
            // cmdShow
            // 
            this.cmdShow.Location = new System.Drawing.Point(192, 20);
            this.cmdShow.Name = "cmdShow";
            this.cmdShow.Size = new System.Drawing.Size(80, 24);
            this.cmdShow.TabIndex = 10;
            this.cmdShow.Text = "ดูรายงาน";
            this.cmdShow.Click += new System.EventHandler(this.cmdShow_Click);
            // 
            // frmListofDriverExcessDeductionByMonth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(720, 494);
            this.Controls.Add(this.crvDriverExcess);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmListofDriverExcessDeductionByMonth";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmListofDriverExcessDeductionByMonth_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmListofDriverExcessDeductionByMonth_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		#region - private -
		private CompanyInfo objCompany;
		private CompanyFacade facadeCompany;
		private frmMain mdiParent;
		#endregion

		//		============================== Constructor ==============================
		public frmListofDriverExcessDeductionByMonth()
		{
			InitializeComponent();
			facadeCompany = new CompanyFacade();
			this.Text = "รายงานการหักเงินค่า Excess ของพนักงานขับรถประจำเดือน";
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
				string StartMonth = Convert.ToString(dtpDate.Value.Month);
				string StartYear = Convert.ToString(dtpDate.Value.Year);

				rdprint.Load(@ApplicationProfile.REPORT_PATH + "rptDriverExcessDeductionByMonth.rpt");

				DataSourceConnections dataSourceConnections = rdprint.DataSourceConnections;
				IConnectionInfo iConnectionInfo = dataSourceConnections[0];
				iConnectionInfo.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

				rdprint.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.Thai + "'";
				rdprint.DataDefinition.FormulaFields["Month"].Text = "'"+StartMonth+"'";
				rdprint.DataDefinition.FormulaFields["Year"].Text = "'"+StartYear+"'";

				crvDriverExcess.ReportSource = rdprint;
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
				dtpDate.Value = new DateTime(DateTime.Today.AddYears(-1).Year, DateTime.Today.AddMonths(-1).Month, 1);

			}
			else
			{
				dtpDate.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
			}
			crvDriverExcess.Hide();
			dtpDate.Focus();
			mdiParent.EnableExitCommand(true);
		}

		public void RefreshForm()
		{
			crvDriverExcess.Show();
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
			crvDriverExcess.RefreshReport();
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}

		private void frmListofDriverExcessDeductionByMonth_Load(object sender, System.EventArgs e)
		{
			mdiParent = (frmMain)this.MdiParent;
			InitForm();
		}

        private void frmListofDriverExcessDeductionByMonth_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseReport(crvDriverExcess);
        }
	}
}
