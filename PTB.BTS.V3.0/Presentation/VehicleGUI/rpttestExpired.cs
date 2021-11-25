using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared ;
using System.IO;
using System.Configuration;

using Presentation.CommonGUI;

using SystemFramework.AppConfig;
using SystemFramework.AppMessage;

namespace Presentation.VehicleGUI
{
	public class rpttestExpired : ChildFormBase, IMDIChildForm
	{
		#region Windows Form Designer generated code
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
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvtest;
		private System.ComponentModel.Container components = null;
		ReportDocument rdPrint;

		private void InitializeComponent()
		{
			this.crvtest = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.SuspendLayout();
			// 
			// crvtest
			// 
			this.crvtest.ActiveViewIndex = -1;
			this.crvtest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.crvtest.DisplayGroupTree = false;
			this.crvtest.Location = new System.Drawing.Point(14, 8);
			this.crvtest.Name = "crvtest";
			this.crvtest.ReportSource = null;
			this.crvtest.ShowCloseButton = false;
			this.crvtest.ShowGroupTreeButton = false;
			this.crvtest.Size = new System.Drawing.Size(1000, 464);
			this.crvtest.TabIndex = 9;
			this.crvtest.ReportRefresh += new CrystalDecisions.Windows.Forms.RefreshEventHandler(this.crvtest_ReportRefresh);
			// 
			// rpttestExpired
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(1028, 486);
			this.Controls.Add(this.crvtest);
			this.Name = "rpttestExpired";
			this.Text = "rpttestExpired";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.rpttestExpired_Load);
			this.ResumeLayout(false);

		}
		#endregion

		#region - private -
		#endregion

		private DateTime selectedDate;
		public DateTime SelectedDate
		{
			set
			{
				selectedDate = value;
			}
		}

		private string selectedReportName;
		public string SelectedReportName
		{
			set
			{
				selectedReportName = value;
			}
		}

		public rpttestExpired()
		{
			InitializeComponent();
			rdPrint = new ReportDocument();
		}
		//		============================== Private Method ==============================
		private void ReportDatabaseLogon()
		{
			try
			{
				ReportDocument rdPrint = new ReportDocument();
				string StartDate1 = Convert.ToString(selectedDate.Month);
				string StartDate2 = Convert.ToString(selectedDate.Year);

				rdPrint.Load(@ApplicationProfile.REPORT_PATH + selectedReportName);

				DataSourceConnections dataSourceConnections = rdPrint.DataSourceConnections;
				IConnectionInfo iConnectionInfo = dataSourceConnections[0];
				iConnectionInfo.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

				rdPrint.DataDefinition.FormulaFields["Month_Num"].Text = StartDate1;
				rdPrint.DataDefinition.FormulaFields["Year"].Text = "'"+StartDate2+"'";
				crvtest.ReportSource = rdPrint;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
			}
		}
		
		//		============================== Event ==============================
		public void InitForm()
		{
//			dtpExpireDate.Value = DateTime.Today;
//			crvtest.Hide();
//			dtpExpireDate.Focus();
		}

		public void RefreshForm()
		{
//			crvtest.Show();
		}

		public void PrintForm()
		{
		}

		public void ExitForm()
		{
			this.Close();
		}

		//		============================== Event ==============================
		private void rpttestExpired_Load(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			ReportDatabaseLogon();
			crvtest.RefreshReport();
			this.Cursor = System.Windows.Forms.Cursors.Default;
//			InitForm();
		}

		private void cmdShow_Click(object sender, System.EventArgs e)
		{			
//			RefreshForm();
		}

		private void crvtest_ReportRefresh(object source, CrystalDecisions.Windows.Forms.ViewerEventArgs e)
		{
		}
	}
}
