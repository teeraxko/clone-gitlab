using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;

using Presentation.CommonGUI;

using SystemFramework.AppConfig;
using SystemFramework.AppMessage;

namespace Presentation.VehicleGUI
{
	public class frmPrintRepairingExpenseByGarage : ChildFormBase, IMDIChildForm
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
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvRepairingExpenseByGarage;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button cmdShow;
		private System.Windows.Forms.DateTimePicker dtpEndDate;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker dtpStartDate;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button cmd;
		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			this.crvRepairingExpenseByGarage = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cmdShow = new System.Windows.Forms.Button();
			this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
			this.label2 = new System.Windows.Forms.Label();
			this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.cmd = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// crvRepairingExpenseByGarage
			// 
			this.crvRepairingExpenseByGarage.ActiveViewIndex = -1;
			this.crvRepairingExpenseByGarage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.crvRepairingExpenseByGarage.DisplayGroupTree = false;
			this.crvRepairingExpenseByGarage.Location = new System.Drawing.Point(16, 96);
			this.crvRepairingExpenseByGarage.Name = "crvRepairingExpenseByGarage";
			this.crvRepairingExpenseByGarage.ReportSource = null;
			this.crvRepairingExpenseByGarage.ShowCloseButton = false;
			this.crvRepairingExpenseByGarage.ShowGroupTreeButton = false;
			this.crvRepairingExpenseByGarage.Size = new System.Drawing.Size(832, 552);
			this.crvRepairingExpenseByGarage.TabIndex = 5;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.groupBox1.Controls.Add(this.cmdShow);
			this.groupBox1.Controls.Add(this.dtpEndDate);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.dtpStartDate);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(9, 16);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(848, 56);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			// 
			// cmdShow
			// 
			this.cmdShow.Location = new System.Drawing.Point(448, 24);
			this.cmdShow.Name = "cmdShow";
			this.cmdShow.Size = new System.Drawing.Size(80, 24);
			this.cmdShow.TabIndex = 9;
			this.cmdShow.Text = "ดูรายงาน";
			this.cmdShow.Click += new System.EventHandler(this.cmdShow_Click);
			// 
			// dtpEndDate
			// 
			this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpEndDate.Location = new System.Drawing.Point(240, 24);
			this.dtpEndDate.Name = "dtpEndDate";
			this.dtpEndDate.Size = new System.Drawing.Size(96, 20);
			this.dtpEndDate.TabIndex = 8;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.label2.Location = new System.Drawing.Point(208, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(9, 18);
			this.label2.TabIndex = 7;
			this.label2.Text = "-";
			// 
			// dtpStartDate
			// 
			this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpStartDate.Location = new System.Drawing.Point(96, 24);
			this.dtpStartDate.Name = "dtpStartDate";
			this.dtpStartDate.Size = new System.Drawing.Size(96, 20);
			this.dtpStartDate.TabIndex = 6;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(24, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 16);
			this.label1.TabIndex = 5;
			this.label1.Text = "ค่าซ่อมวันที่";
			// 
			// cmd
			// 
			this.cmd.Location = new System.Drawing.Point(432, 624);
			this.cmd.Name = "cmd";
			this.cmd.TabIndex = 8;
			this.cmd.Text = "ยกเลิก";
			// 
			// frmPrintRepairingExpenseByGarage
			// 
			this.AcceptButton = this.cmdShow;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(866, 664);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.crvRepairingExpenseByGarage);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmPrintRepairingExpenseByGarage";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "พิมพ์ค่าซ่อมของศูนย์ซ่อมต่างๆ";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmPrintRepairingExpenseByGarage_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region - private -
		private frmMain mdiParent;
		#endregion
	
//		============================== Constructor ==============================
		public frmPrintRepairingExpenseByGarage()
		{
			InitializeComponent();
		}

//		============================== Private Method ==============================
		private void ReportDatabaseLogon()
		{
			try
			{
				ReportDocument rdPrint = new ReportDocument();
				string StartDate1 = Convert.ToString(dtpStartDate.Value.Day);
				string StartDate2 = Convert.ToString(dtpStartDate.Value.Month);
				string StartDate3 = Convert.ToString(dtpStartDate.Value.Year);
				string EndDate1 = Convert.ToString(dtpEndDate.Value.Day);
				string EndDate2 = Convert.ToString(dtpEndDate.Value.Month);
				string EndDate3 = Convert.ToString(dtpEndDate.Value.Year);
	
				rdPrint.Load(@ApplicationProfile.REPORT_PATH + "rptVehicleMaintenceByGarageSummary.rpt");
				rdPrint.SetDatabaseLogon(ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD, ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME);
				rdPrint.DataDefinition.FormulaFields[4].Text = StartDate1;
				rdPrint.DataDefinition.FormulaFields[5].Text = StartDate2;
				rdPrint.DataDefinition.FormulaFields[6].Text = StartDate3;
				rdPrint.DataDefinition.FormulaFields[7].Text = EndDate1;
				rdPrint.DataDefinition.FormulaFields[8].Text = EndDate2;
				rdPrint.DataDefinition.FormulaFields[9].Text = EndDate3;
				crvRepairingExpenseByGarage.ReportSource = rdPrint;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
			}
		}
		private void clearForm()
		{
			dtpStartDate.Value = DateTime.Today;
			dtpEndDate.Value = DateTime.Today;
		}
		private void hideCase()
		{
			crvRepairingExpenseByGarage.Hide();
		}
		private void showCase()
		{
			crvRepairingExpenseByGarage.Show();
		}
		private bool validate()
		{
			if (dtpEndDate.Value < dtpStartDate.Value)
			{
				Message(MessageList.Error.E0001,"วันเริ่มต้น","วันสิ้นสุด");
				dtpEndDate.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
//		============================== Event ==============================
		public void InitForm()
		{
			clearForm();
			hideCase();
			dtpStartDate.Focus();
		}

		public void RefreshForm()
		{
			showCase();
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
			if(validate())
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				ReportDatabaseLogon();
				RefreshForm();
				mdiParent.EnableExitCommand(true);
				crvRepairingExpenseByGarage.RefreshReport();
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}
			else
			{
				InitForm();
			}
		}

		private void frmPrintRepairingExpenseByGarage_Load(object sender, System.EventArgs e)
		{
			mdiParent = (frmMain)this.MdiParent;
			InitForm();
		}
	}
}
