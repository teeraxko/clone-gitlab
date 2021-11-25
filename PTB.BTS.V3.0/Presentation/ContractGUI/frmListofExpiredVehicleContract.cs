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
	public class frmListofExpiredVehicleContract : ChildFormBase, IMDIChildForm
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
		private System.Windows.Forms.DateTimePicker dtpExpireDate;
		private System.Windows.Forms.Label label1;
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvExpiredVehicleContract;
		private System.ComponentModel.Container components = null;
		private void InitializeComponent()
		{
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdShow = new System.Windows.Forms.Button();
            this.dtpExpireDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.crvExpiredVehicleContract = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.cmdShow);
            this.groupBox1.Controls.Add(this.dtpExpireDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(24, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(984, 64);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // cmdShow
            // 
            this.cmdShow.Location = new System.Drawing.Point(256, 24);
            this.cmdShow.Name = "cmdShow";
            this.cmdShow.Size = new System.Drawing.Size(80, 24);
            this.cmdShow.TabIndex = 10;
            this.cmdShow.Text = "ดูรายงาน";
            this.cmdShow.Click += new System.EventHandler(this.cmdShow_Click);
            // 
            // dtpExpireDate
            // 
            this.dtpExpireDate.CustomFormat = "MM/yyyy";
            this.dtpExpireDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpExpireDate.Location = new System.Drawing.Point(96, 24);
            this.dtpExpireDate.Name = "dtpExpireDate";
            this.dtpExpireDate.Size = new System.Drawing.Size(120, 20);
            this.dtpExpireDate.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "สัญญาเดือนที่";
            // 
            // crvExpiredVehicleContract
            // 
            this.crvExpiredVehicleContract.ActiveViewIndex = -1;
            this.crvExpiredVehicleContract.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.crvExpiredVehicleContract.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvExpiredVehicleContract.DisplayGroupTree = false;
            this.crvExpiredVehicleContract.Location = new System.Drawing.Point(32, 96);
            this.crvExpiredVehicleContract.Name = "crvExpiredVehicleContract";
            this.crvExpiredVehicleContract.ShowCloseButton = false;
            this.crvExpiredVehicleContract.ShowGroupTreeButton = false;
            this.crvExpiredVehicleContract.Size = new System.Drawing.Size(976, 488);
            this.crvExpiredVehicleContract.TabIndex = 12;
            // 
            // frmListofExpiredVehicleContract
            // 
            this.AcceptButton = this.cmdShow;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1028, 598);
            this.Controls.Add(this.crvExpiredVehicleContract);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmListofExpiredVehicleContract";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmListofExpiredVehicleContract_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmListofExpiredVehicleContract_FormClosed);
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
		public frmListofExpiredVehicleContract()
		{
			InitializeComponent();
			facadeCompany = new CompanyFacade();
			this.Text = "รายงานรถหมดสัญญา(เฉพาะสัญญาเช่าระยะยาว)";
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
				string StartDate1 = Convert.ToString(dtpExpireDate.Value.Month);
				string StartDate2 = Convert.ToString(dtpExpireDate.Value.Year);

				rdprint.Load(@ApplicationProfile.REPORT_PATH + "rptExpiredVehicleContract.rpt");

				DataSourceConnections dataSourceConnections = rdprint.DataSourceConnections;
				IConnectionInfo iConnectionInfo = dataSourceConnections[0];
				iConnectionInfo.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

				rdprint.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.Thai + "'";
				rdprint.DataDefinition.FormulaFields["Month_Num"].Text = StartDate1;
				rdprint.DataDefinition.FormulaFields["Year"].Text = "'"+StartDate2+"'";

				crvExpiredVehicleContract.ReportSource = rdprint;
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
				dtpExpireDate.Value = new DateTime(DateTime.Today.AddYears(-1).Year, DateTime.Today.AddMonths(-1).Month, 1);

			}
			else
			{
				dtpExpireDate.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
			}
			crvExpiredVehicleContract.Hide();
			dtpExpireDate.Focus();
			mdiParent.EnableExitCommand(true);
		}

		public void RefreshForm()
		{
			crvExpiredVehicleContract.Show();
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
			crvExpiredVehicleContract.RefreshReport();
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}

		private void frmListofExpiredVehicleContract_Load(object sender, System.EventArgs e)
		{
			mdiParent = (frmMain)this.MdiParent;
			InitForm();
		}

        private void frmListofExpiredVehicleContract_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseReport(crvExpiredVehicleContract);
        }
	}
}
