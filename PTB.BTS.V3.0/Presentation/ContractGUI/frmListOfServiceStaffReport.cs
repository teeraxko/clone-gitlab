using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using SystemFramework.AppConfig;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

using ictus.Common.Entity;
using ictus.PIS.PI.Entity;

using Entity.VehicleEntities;
using Facade.PiFacade;
using Presentation.CommonGUI;

namespace Presentation.ContractGUI
{
	/// <summary>
	/// Summary description for frmListOfServiceStaffReport.
	/// </summary>
	public class frmListOfServiceStaffReport :  ChildFormBase,IMDIChildForm
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Splitter splitter1;
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvPrint;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;


		#region - private -
		private CompanyFacade facadeCompany;
		private System.Windows.Forms.DateTimePicker dtpDateFrom;
		private System.Windows.Forms.DateTimePicker dtpDateTo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnShow;
		private frmMain mdiParent;
		#endregion

		public frmListOfServiceStaffReport()
		{
			InitializeComponent();
			facadeCompany = new CompanyFacade();
			this.Text = "Service Staff Contract Report";
		}

		private CompanyInfo getCompany()
		{
			CompanyInfo objCompany = new CompanyInfo("12");
			if(facadeCompany.FillCompany(ref objCompany))
			{
				return objCompany;
			}
			else
			{
				return null;
			}
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
            this.btnShow = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.crvPrint = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnShow);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpDateTo);
            this.groupBox1.Controls.Add(this.dtpDateFrom);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1028, 56);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(152, 20);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(75, 23);
            this.btnShow.TabIndex = 11;
            this.btnShow.Text = "ดูข้อมูล";
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "วันที่";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(468, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "-";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Visible = false;
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.CustomFormat = "dd/MM/yyyy";
            this.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateTo.Location = new System.Drawing.Point(48, 20);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(96, 20);
            this.dtpDateTo.TabIndex = 8;
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateFrom.Location = new System.Drawing.Point(364, 20);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(96, 20);
            this.dtpDateFrom.TabIndex = 7;
            this.dtpDateFrom.Visible = false;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 56);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1028, 3);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            this.splitter1.Visible = false;
            // 
            // crvPrint
            // 
            this.crvPrint.ActiveViewIndex = -1;
            this.crvPrint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvPrint.DisplayGroupTree = false;
            this.crvPrint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvPrint.Location = new System.Drawing.Point(0, 59);
            this.crvPrint.Name = "crvPrint";
            this.crvPrint.ShowCloseButton = false;
            this.crvPrint.ShowGroupTreeButton = false;
            this.crvPrint.Size = new System.Drawing.Size(1028, 687);
            this.crvPrint.TabIndex = 5;
            // 
            // frmListOfServiceStaffReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1028, 746);
            this.Controls.Add(this.crvPrint);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmListOfServiceStaffReport";
            this.Text = "frmListOfServiceStaffReport";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmListOfServiceStaffReport_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		public void InitForm()
		{
			//init control date
			DateTime initFromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
			DateTime initToDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
			dtpDateFrom.Value = initFromDate;
			dtpDateTo.Value = initToDate;


			crvPrint.Hide();
			mdiParent.EnableExitCommand(true);
		}

		public void RefreshForm()
		{
			crvPrint.Show();
			mdiParent.EnableExitCommand(true);
		}

		public void PrintForm()
		{
		}

		public void ExitForm()
		{
			this.Hide();
		}

		private void frmListOfServiceStaffReport_Load(object sender, System.EventArgs e)
		{
			mdiParent = (frmMain)this.MdiParent;
			InitForm();
		}

		private bool ValiDateReportParameter()
		{
            return true;

			//return dtpDateFrom.Value <= dtpDateTo.Value;
		}

		private void btnShow_Click(object sender, System.EventArgs e)
		{
			if (ValiDateReportParameter())
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

				ReportDatabaseLogon();
				RefreshForm();
				mdiParent.EnableExitCommand(true);
				crvPrint.RefreshReport();
				this.Cursor = System.Windows.Forms.Cursors.Default;

			}
			else
			{
				MessageBox.Show("Invalid Preiod date", "Report could not be created", MessageBoxButtons.OK);
				
			}
		}

		private void ReportDatabaseLogon()
		{
			try
			{
				ReportDocument rdprint1 = new ReportDocument();

				rdprint1.Load(@ApplicationProfile.REPORT_PATH + "rptServiceStaffContract.rpt");
				DataSourceConnections dataSourceConnections1 = rdprint1.DataSourceConnections;
				IConnectionInfo iConnectionInfo1 = dataSourceConnections1[0];
				iConnectionInfo1.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

				
				rdprint1.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + this.getCompany().AFullName.Thai + "'";
				rdprint1.DataDefinition.FormulaFields["FromDate"].Text = string.Format("CDate ({0}, {1}, {2})",dtpDateFrom.Value.Year.ToString(),dtpDateFrom.Value.Month.ToString(),dtpDateFrom.Value.Day.ToString());  
				rdprint1.DataDefinition.FormulaFields["ToDate"].Text = string.Format("CDate ({0}, {1}, {2})",dtpDateTo.Value.Year.ToString(),dtpDateTo.Value.Month.ToString(),dtpDateTo.Value.Day.ToString());  

				crvPrint.ReportSource = rdprint1;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
			}
		}
	}
}
