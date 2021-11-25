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
	public class frmListofNewAnnualLeaveDay : ChildFormBase, IMDIChildForm
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

		#region - private -
		private CompanyInfo objCompany;
		private CompanyFacade facadeCompany;
		#endregion

		#region Windows Form Designer generated code
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvPrint;
		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
            this.crvPrint = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvPrint
            // 
            this.crvPrint.ActiveViewIndex = -1;
            this.crvPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.crvPrint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvPrint.DisplayGroupTree = false;
            this.crvPrint.Location = new System.Drawing.Point(16, 16);
            this.crvPrint.Name = "crvPrint";
            this.crvPrint.ShowCloseButton = false;
            this.crvPrint.ShowGroupTreeButton = false;
            this.crvPrint.Size = new System.Drawing.Size(712, 448);
            this.crvPrint.TabIndex = 0;
            // 
            // frmListofNewAnnualLeaveDay
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(744, 478);
            this.Controls.Add(this.crvPrint);
            this.Name = "frmListofNewAnnualLeaveDay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmListofNewAnnualLeaveDay_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmListofNewAnnualLeaveDay_FormClosed);
            this.ResumeLayout(false);

		}
		#endregion

//		============================== Constructor ==============================
		public frmListofNewAnnualLeaveDay()
		{
			InitializeComponent();
			facadeCompany = new CompanyFacade();
			this.Text = "รายงานจำนวนวันลาพักร้อน";
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

		private int forYear;
		public int ForYear
		{
			set
			{
				forYear = value;
			}
		}

		private DateTime validForm;
		public DateTime ValidForm
		{
			set
			{
				validForm = value;
			}
		}

		private DateTime validTo;
		public DateTime ValidTo
		{
			set
			{
				validTo = value;
			}
		}

//		============================== Private Method ==============================
		private void ReportDatabaseLogon()
		{
			try
			{
				objCompany = getCompany();
				ReportDocument rdprint = new ReportDocument();
				rdprint.Load(@ApplicationProfile.REPORT_PATH + "rptNewAnnualLeaveDays.rpt");

				DataSourceConnections dataSourceConnections = rdprint.DataSourceConnections;
				IConnectionInfo iConnectionInfo = dataSourceConnections[0];
				iConnectionInfo.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

				rdprint.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.Thai + "'";
                rdprint.DataDefinition.FormulaFields["Year"].Text = "'" + forYear.ToString() + "'";
                rdprint.DataDefinition.FormulaFields["From_Date"].Text = "'" + validForm.ToString("dd/MM/yyyy") + "'";
                rdprint.DataDefinition.FormulaFields["To_Date"].Text = "'" + validTo.ToString("dd/MM/yyyy") + "'";
				crvPrint.ReportSource = rdprint;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
			}
		}

		//		============================== Event ==============================
		private void frmListofNewAnnualLeaveDay_Load(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			ReportDatabaseLogon();
			crvPrint.RefreshReport();
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}

        private void frmListofNewAnnualLeaveDay_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseReport(crvPrint);
        }

        #region IMDIChildFormGUI Members

        public void InitForm()
        {
        }

        public void RefreshForm()
        {
        }

        public void PrintForm()
        {
        }

        public void ExitForm()
        {
            this.Close();
        }

        #endregion
    }
}
