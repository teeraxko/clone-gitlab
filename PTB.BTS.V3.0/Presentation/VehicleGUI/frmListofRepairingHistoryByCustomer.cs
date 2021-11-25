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
	public class frmListofRepairingHistoryByCustomer : ChildFormBase,IMDIChildForm
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
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvPrint;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnShow;
		private System.Windows.Forms.DateTimePicker dtpTimeEnd;
		private System.Windows.Forms.DateTimePicker dtpTimeStart;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.ComponentModel.Container components = null;


		private void InitializeComponent()
		{
			this.crvPrint = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnShow = new System.Windows.Forms.Button();
			this.dtpTimeEnd = new System.Windows.Forms.DateTimePicker();
			this.dtpTimeStart = new System.Windows.Forms.DateTimePicker();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// crvPrint
			// 
			this.crvPrint.ActiveViewIndex = -1;
			this.crvPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.crvPrint.DisplayGroupTree = false;
			this.crvPrint.Location = new System.Drawing.Point(14, 80);
			this.crvPrint.Name = "crvPrint";
			this.crvPrint.ReportSource = null;
			this.crvPrint.ShowCloseButton = false;
			this.crvPrint.ShowGroupTreeButton = false;
			this.crvPrint.Size = new System.Drawing.Size(1000, 648);
			this.crvPrint.TabIndex = 3;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnShow);
			this.groupBox1.Controls.Add(this.dtpTimeEnd);
			this.groupBox1.Controls.Add(this.dtpTimeStart);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Location = new System.Drawing.Point(16, 16);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(1000, 56);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			// 
			// btnShow
			// 
			this.btnShow.Location = new System.Drawing.Point(360, 24);
			this.btnShow.Name = "btnShow";
			this.btnShow.TabIndex = 6;
			this.btnShow.Text = "ดูข้อมูล";
			this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
			// 
			// dtpTimeEnd
			// 
			this.dtpTimeEnd.CustomFormat = "MM/yyyy";
			this.dtpTimeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpTimeEnd.Location = new System.Drawing.Point(240, 24);
			this.dtpTimeEnd.Name = "dtpTimeEnd";
			this.dtpTimeEnd.Size = new System.Drawing.Size(72, 20);
			this.dtpTimeEnd.TabIndex = 4;
			// 
			// dtpTimeStart
			// 
			this.dtpTimeStart.CustomFormat = "MM/yyyy";
			this.dtpTimeStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpTimeStart.Location = new System.Drawing.Point(128, 24);
			this.dtpTimeStart.Name = "dtpTimeStart";
			this.dtpTimeStart.Size = new System.Drawing.Size(72, 20);
			this.dtpTimeStart.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(216, 24);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(8, 16);
			this.label3.TabIndex = 2;
			this.label3.Text = "-";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(32, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(59, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "ระหว่างเดือน";
			// 
			// frmListofRepairingHistoryByCustomer
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(1028, 746);
			this.Controls.Add(this.crvPrint);
			this.Controls.Add(this.groupBox1);
			this.Name = "frmListofRepairingHistoryByCustomer";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmListofRepairingHistoryByCustomer_Load);
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
		public frmListofRepairingHistoryByCustomer()
		{
			InitializeComponent();
			facadeCompany = new CompanyFacade();
			this.Text = "รายงานประวัติการซ่อมตามลูกค้า";
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
				string StartMonth = Convert.ToString(dtpTimeStart.Value.Month);
				string StartYear  = Convert.ToString(dtpTimeStart.Value.Year);

				string EndMonth = Convert.ToString(dtpTimeEnd.Value.Month);
				string EndYear  = Convert.ToString(dtpTimeEnd.Value.Year);

				rdprint1.Load(@ApplicationProfile.REPORT_PATH + "rptRepairingHistoryByCustomer2.rpt");
				DataSourceConnections dataSourceConnections1 = rdprint1.DataSourceConnections;
				IConnectionInfo iConnectionInfo1 = dataSourceConnections1[0];
				iConnectionInfo1.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

				rdprint1.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.Thai + "'";
				rdprint1.DataDefinition.FormulaFields["StartMonth"].Text = StartMonth;
				rdprint1.DataDefinition.FormulaFields["StartYear"].Text = StartYear;
				rdprint1.DataDefinition.FormulaFields["EndMonth"].Text = EndMonth;
				rdprint1.DataDefinition.FormulaFields["EndYear"].Text = EndYear;

				crvPrint.ReportSource = rdprint1;
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
				dtpTimeStart.Value = new DateTime(DateTime.Today.AddYears(-1).Year, DateTime.Today.AddMonths(-1).Month, 1);
				dtpTimeEnd.Value = new DateTime(DateTime.Today.AddYears(-1).Year, DateTime.Today.AddMonths(-1).Month, 1);

			}
			else
			{
				dtpTimeStart.Value = new DateTime(DateTime.Today.Year, DateTime.Today.AddMonths(-1).Month, 1);
				dtpTimeEnd.Value = new DateTime(DateTime.Today.Year, DateTime.Today.AddMonths(-1).Month, 1);
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

		//		============================== Event ==============================

		private void frmListofRepairingHistoryByCustomer_Load(object sender, System.EventArgs e)
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



	}
}
