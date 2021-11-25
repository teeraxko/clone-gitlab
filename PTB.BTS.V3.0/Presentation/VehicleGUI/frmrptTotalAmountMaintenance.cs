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
	public class frmrptTotalAmountMaintenance : ChildFormBase,IMDIChildForm
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
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvVehicle;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button cmdShow;
		private System.Windows.Forms.DateTimePicker dtpFromYear;
		private System.Windows.Forms.DateTimePicker dtpToYear;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;

		private System.ComponentModel.Container components = null;
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.crvVehicle = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.dtpToYear = new System.Windows.Forms.DateTimePicker();
			this.cmdShow = new System.Windows.Forms.Button();
			this.dtpFromYear = new System.Windows.Forms.DateTimePicker();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// crvVehicle
			// 
			this.crvVehicle.ActiveViewIndex = -1;
			this.crvVehicle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.crvVehicle.DisplayGroupTree = false;
			this.crvVehicle.Location = new System.Drawing.Point(16, 88);
			this.crvVehicle.Name = "crvVehicle";
			this.crvVehicle.ReportSource = null;
			this.crvVehicle.ShowCloseButton = false;
			this.crvVehicle.ShowGroupTreeButton = false;
			this.crvVehicle.Size = new System.Drawing.Size(896, 264);
			this.crvVehicle.TabIndex = 15;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.dtpToYear);
			this.groupBox1.Controls.Add(this.cmdShow);
			this.groupBox1.Controls.Add(this.dtpFromYear);
			this.groupBox1.Location = new System.Drawing.Point(268, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(392, 64);
			this.groupBox1.TabIndex = 16;
			this.groupBox1.TabStop = false;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(152, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 16);
			this.label2.TabIndex = 13;
			this.label2.Text = "ปีที่สิ้นสุด";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 16);
			this.label1.TabIndex = 12;
			this.label1.Text = "ปีที่เริ่ม";
			// 
			// dtpToYear
			// 
			this.dtpToYear.CustomFormat = "yyyy";
			this.dtpToYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpToYear.Location = new System.Drawing.Point(208, 24);
			this.dtpToYear.Name = "dtpToYear";
			this.dtpToYear.ShowUpDown = true;
			this.dtpToYear.Size = new System.Drawing.Size(56, 20);
			this.dtpToYear.TabIndex = 11;
			// 
			// cmdShow
			// 
			this.cmdShow.Location = new System.Drawing.Point(296, 24);
			this.cmdShow.Name = "cmdShow";
			this.cmdShow.TabIndex = 10;
			this.cmdShow.Text = "ดูข้อมูล";
			this.cmdShow.Click += new System.EventHandler(this.cmdShow_Click);
			// 
			// dtpFromYear
			// 
			this.dtpFromYear.CustomFormat = "yyyy";
			this.dtpFromYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpFromYear.Location = new System.Drawing.Point(64, 24);
			this.dtpFromYear.Name = "dtpFromYear";
			this.dtpFromYear.ShowUpDown = true;
			this.dtpFromYear.Size = new System.Drawing.Size(56, 20);
			this.dtpFromYear.TabIndex = 9;
			// 
			// frmrptTotalAmountMaintenance
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(928, 366);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.crvVehicle);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmrptTotalAmountMaintenance";
			this.Text = "frmrptTotalAmountMaintenance";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmrptTotalAmountMaintenance_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region - Private -
		private frmMain mdiParent;
		private CompanyInfo objCompany;
		private CompanyFacade facadeCompany;
		#endregion
		
//		============================== Constructor ==============================
		public frmrptTotalAmountMaintenance() : base()
		{
			InitializeComponent();
			this.Text = "รายงานค่าซ่อมรถยนต์ (ค่าซ่อมทั้งหมด)";
			facadeCompany = new CompanyFacade();
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
				ReportDocument rdprint1 = new ReportDocument();

				rdprint1.Load(@ApplicationProfile.REPORT_PATH + "rptTotalAmountMaintenance.rpt");
				DataSourceConnections dataSourceConnections1 = rdprint1.DataSourceConnections;
				IConnectionInfo iConnectionInfo1 = dataSourceConnections1[0];
				iConnectionInfo1.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

				rdprint1.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.Thai + "'";
				rdprint1.DataDefinition.FormulaFields["FromYear"].Text = dtpFromYear.Value.Year.ToString();;
				rdprint1.DataDefinition.FormulaFields["ToYear"].Text = dtpToYear.Value.Year.ToString();;

				crvVehicle.ReportSource = rdprint1;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
			}
		}

//		============================== Base Event ==============================
		public void InitForm()
		{
			
			dtpFromYear.Value = new System.DateTime(DateTime.Today.Year, DateTime.Today.Month, 1, 0, 0, 0, 0);
			dtpToYear.Value = new System.DateTime(DateTime.Today.Year, DateTime.Today.Month, 1, 0, 0, 0, 0);

			crvVehicle.Hide();
			mdiParent.EnableExitCommand(true);
		}

		public void RefreshForm()
		{
			crvVehicle.Show();
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
		private void frmrptTotalAmountMaintenance_Load(object sender, System.EventArgs e)
		{
			mdiParent = (frmMain)this.MdiParent;
			InitForm();
		}

		private void cmdShow_Click(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			ReportDatabaseLogon();
			RefreshForm();
			crvVehicle.RefreshReport();
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}
	}
}
