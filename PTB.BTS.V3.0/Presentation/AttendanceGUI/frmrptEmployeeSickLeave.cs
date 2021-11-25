using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using CrystalDecisions.Shared;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

using Facade.PiFacade;

using Presentation.CommonGUI;

using SystemFramework.AppConfig;

namespace Presentation.AttendanceGUI
{
	public class frmrptEmployeeSickLeave : ChildFormBase, IMDIChildForm
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

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker dtpForMonth;
		private System.Windows.Forms.Button cmdShow;
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvSickleave;

		#region Windows Form Designer generated code

		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpForMonth = new System.Windows.Forms.DateTimePicker();
            this.cmdShow = new System.Windows.Forms.Button();
            this.crvSickleave = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpForMonth);
            this.groupBox1.Controls.Add(this.cmdShow);
            this.groupBox1.Location = new System.Drawing.Point(16, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(672, 48);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(16, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 22;
            this.label1.Text = "ข้อมูลเดือน";
            // 
            // dtpForMonth
            // 
            this.dtpForMonth.CustomFormat = "MM/yyyy";
            this.dtpForMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpForMonth.Location = new System.Drawing.Point(80, 17);
            this.dtpForMonth.Name = "dtpForMonth";
            this.dtpForMonth.Size = new System.Drawing.Size(72, 20);
            this.dtpForMonth.TabIndex = 21;
            // 
            // cmdShow
            // 
            this.cmdShow.Location = new System.Drawing.Point(160, 16);
            this.cmdShow.Name = "cmdShow";
            this.cmdShow.Size = new System.Drawing.Size(80, 23);
            this.cmdShow.TabIndex = 9;
            this.cmdShow.Text = "ส่งข้อมูล";
            this.cmdShow.Click += new System.EventHandler(this.cmdShow_Click);
            // 
            // crvSickleave
            // 
            this.crvSickleave.ActiveViewIndex = -1;
            this.crvSickleave.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.crvSickleave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvSickleave.DisplayGroupTree = false;
            this.crvSickleave.Location = new System.Drawing.Point(16, 56);
            this.crvSickleave.Name = "crvSickleave";
            this.crvSickleave.ShowCloseButton = false;
            this.crvSickleave.ShowGroupTreeButton = false;
            this.crvSickleave.Size = new System.Drawing.Size(672, 360);
            this.crvSickleave.TabIndex = 18;
            // 
            // frmrptEmployeeSickLeave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(706, 432);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.crvSickleave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmrptEmployeeSickLeave";
            this.Text = "frmrptEmployeeSickLeave";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmrptEmployeeSickLeave_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmrptEmployeeSickLeave_FormClosed);
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

		public frmrptEmployeeSickLeave() : base()
		{
			InitializeComponent();
			facadeCompany = new CompanyFacade();
			this.Text = "รายงานข้อมูลการลาป่วยรายเดือนของพนักงาน";
		}

//		============================== Private method ==============================
        private CompanyInfo getCompany()
		{
            objCompany = new CompanyInfo("12");
			if(facadeCompany.FillCompany(ref objCompany))
			{
				return objCompany;
			}
			else
			{
				objCompany = null;
				return null;
			}
		}

		private void ReportDatabaseLogon()
		{
			try
			{
				objCompany = getCompany();
				ReportDocument rdprint1 = new ReportDocument();
				rdprint1.Load(@ApplicationProfile.REPORT_PATH + "rptEmployeeSickLeave.rpt");

				DataSourceConnections dataSourceConnections = rdprint1.DataSourceConnections;
				IConnectionInfo iConnectionInfo = dataSourceConnections[0];
				iConnectionInfo.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

				rdprint1.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.Thai + "'";
				rdprint1.DataDefinition.FormulaFields["FilterMonth"].Text = string.Format("CDate ({0}, {1}, {2})",dtpForMonth.Value.Year.ToString(),dtpForMonth.Value.Month.ToString(),dtpForMonth.Value.Day.ToString());  

				crvSickleave.ReportSource = rdprint1;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
			}
		}

//		============================== Base Event ==============================
		public void InitForm()
		{
			dtpForMonth.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
			crvSickleave.Hide();
			mdiParent.EnableExitCommand(true);	
		}

		public void RefreshForm()
		{
			crvSickleave.Show();
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
		private void frmrptEmployeeSickLeave_Load(object sender, System.EventArgs e)
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
			crvSickleave.RefreshReport();
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}

        private void frmrptEmployeeSickLeave_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseReport(crvSickleave);
        }
	}
}
