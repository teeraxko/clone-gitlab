using System;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared ;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

using Facade.PiFacade;
using Presentation.CommonGUI;
using SystemFramework.AppConfig;

namespace Presentation.VehicleGUI
{
	/// <summary>
	/// Summary description for frmListofAccident.
	/// </summary>
	public class frmListofAccident : ChildFormBase,IMDIChildForm	 
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnShow;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker dtpReportDate;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#region - private -
		private CompanyFacade facadeCompany;
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvPrint;
		private System.Windows.Forms.Splitter splitter1;
		private frmMain mdiParent;
		#endregion

		public frmListofAccident()
		{
			InitializeComponent();
			facadeCompany = new CompanyFacade();
			this.Text = "รายงานอุบัติเหตุ";

		}
		//		============================== Property ==============================
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
			this.dtpReportDate = new System.Windows.Forms.DateTimePicker();
			this.label2 = new System.Windows.Forms.Label();
			this.crvPrint = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnShow);
			this.groupBox1.Controls.Add(this.dtpReportDate);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(1028, 60);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			// 
			// btnShow
			// 
			this.btnShow.Location = new System.Drawing.Point(216, 24);
			this.btnShow.Name = "btnShow";
			this.btnShow.Size = new System.Drawing.Size(75, 24);
			this.btnShow.TabIndex = 6;
			this.btnShow.Text = "ดูข้อมูล";
			this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
			// 
			// dtpReportDate
			// 
			this.dtpReportDate.CustomFormat = "MM/yyyy";
			this.dtpReportDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpReportDate.Location = new System.Drawing.Point(120, 26);
			this.dtpReportDate.Name = "dtpReportDate";
			this.dtpReportDate.Size = new System.Drawing.Size(75, 20);
			this.dtpReportDate.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(32, 28);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(54, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "ประจำเดือน";
			// 
			// crvPrint
			// 
			this.crvPrint.ActiveViewIndex = -1;
			this.crvPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.crvPrint.DisplayGroupTree = false;
			this.crvPrint.Location = new System.Drawing.Point(0, 60);
			this.crvPrint.Name = "crvPrint";
			this.crvPrint.ReportSource = null;
			this.crvPrint.ShowCloseButton = false;
			this.crvPrint.ShowGroupTreeButton = false;
			this.crvPrint.Size = new System.Drawing.Size(1028, 693);
			this.crvPrint.TabIndex = 5;
			// 
			// splitter1
			// 
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitter1.Location = new System.Drawing.Point(0, 60);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(1028, 3);
			this.splitter1.TabIndex = 6;
			this.splitter1.TabStop = false;
			this.splitter1.Visible = false;
			// 
			// frmListofAccident
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(1028, 746);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.crvPrint);
			this.Controls.Add(this.groupBox1);
			this.Name = "frmListofAccident";
			this.Text = "frmListofAccident";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmListofAccident_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion



		public void InitForm()
		{
			if(DateTime.Today.Month == 1)
			{
				dtpReportDate.Value = new DateTime(DateTime.Today.AddYears(-1).Year, DateTime.Today.AddMonths(-1).Month, 1);

			}
			else
			{
				dtpReportDate.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
			}
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

		private void frmListofAccident_Load(object sender, System.EventArgs e)
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
			crvPrint.RefreshReport();
			this.Cursor = System.Windows.Forms.Cursors.Default;

		}

		private void ReportDatabaseLogon()
		{
			try
			{
				ReportDocument rdprint1 = new ReportDocument();

				rdprint1.Load(@ApplicationProfile.REPORT_PATH + "rptAccident.rpt");
				DataSourceConnections dataSourceConnections1 = rdprint1.DataSourceConnections;
				IConnectionInfo iConnectionInfo1 = dataSourceConnections1[0];
				iConnectionInfo1.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

				rdprint1.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + this.getCompany().AFullName.Thai + "'";
				rdprint1.DataDefinition.FormulaFields["aMonth"].Text = dtpReportDate.Value.Month.ToString();
				rdprint1.DataDefinition.FormulaFields["aYear"].Text = dtpReportDate.Value.Year.ToString();

				crvPrint.ReportSource = rdprint1;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
			}
		}

	}
}
