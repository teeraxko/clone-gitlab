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

namespace Presentation.PiGUI
{
	public class frmListofNonEmployee : ChildFormBase,IMDIChildForm
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
		private System.Windows.Forms.DateTimePicker dtpExpireDate;
		private System.Windows.Forms.Label label1;
		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			this.crvReport = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cmdShow = new System.Windows.Forms.Button();
			this.dtpExpireDate = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// crvReport
			// 
			this.crvReport.ActiveViewIndex = -1;
			this.crvReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.crvReport.DisplayGroupTree = false;
			this.crvReport.Location = new System.Drawing.Point(16, 96);
			this.crvReport.Name = "crvReport";
			this.crvReport.ReportSource = null;
			this.crvReport.ShowCloseButton = false;
			this.crvReport.ShowGroupTreeButton = false;
			this.crvReport.Size = new System.Drawing.Size(656, 360);
			this.crvReport.TabIndex = 4;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.cmdShow);
			this.groupBox1.Controls.Add(this.dtpExpireDate);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(8, 15);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(672, 64);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			// 
			// cmdShow
			// 
			this.cmdShow.Location = new System.Drawing.Point(248, 24);
			this.cmdShow.Name = "cmdShow";
			this.cmdShow.Size = new System.Drawing.Size(80, 24);
			this.cmdShow.TabIndex = 13;
			this.cmdShow.Text = "ดูรายงาน";
			this.cmdShow.Click += new System.EventHandler(this.cmdShow_Click);
			// 
			// dtpExpireDate
			// 
			this.dtpExpireDate.CustomFormat = "MM/yyyy";
			this.dtpExpireDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpExpireDate.Location = new System.Drawing.Point(88, 24);
			this.dtpExpireDate.Name = "dtpExpireDate";
			this.dtpExpireDate.Size = new System.Drawing.Size(120, 20);
			this.dtpExpireDate.TabIndex = 12;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(16, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(54, 16);
			this.label1.TabIndex = 11;
			this.label1.Text = "ประจำเดือน";
			// 
			// frmListofNonEmployee
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(688, 486);
			this.Controls.Add(this.crvReport);
			this.Controls.Add(this.groupBox1);
			this.Name = "frmListofNonEmployee";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmListofNonEmployee_Load);
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

		public frmListofNonEmployee()
		{
			InitializeComponent();
			facadeCompany = new CompanyFacade();
			this.Text = "รายงานข้อมูลพนักงานที่พ้นสภาพการทำงานแล้ว";
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
				DateTime StartDate1 = dtpExpireDate.Value;

				rdprint.Load(@ApplicationProfile.REPORT_PATH + "rptListOfNonEmployee.rpt");

				DataSourceConnections dataSourceConnections = rdprint.DataSourceConnections;
				IConnectionInfo iConnectionInfo = dataSourceConnections[0];
				iConnectionInfo.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

				rdprint.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.English + "'";
				rdprint.DataDefinition.FormulaFields["FilterMonth"].Text = string.Format("CDate ({0}, {1}, {2})",dtpExpireDate.Value.Year.ToString(),dtpExpireDate.Value.Month.ToString(),dtpExpireDate.Value.Day.ToString());  

				crvReport.ReportSource = rdprint;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
			}
		}
		//		============================== Event ==============================
		public void InitForm()
		{
			dtpExpireDate.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
			crvReport.Hide();
			dtpExpireDate.Focus();
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


		//		============================== Event ==============================

		private void frmListofNonEmployee_Load(object sender, System.EventArgs e)
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
			crvReport.RefreshReport();
			this.Cursor = System.Windows.Forms.Cursors.Default;
		
		}
	}
}
