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
	public class frmListofEmployeeBenefitAdjustment : ChildFormBase, IMDIChildForm
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
		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
            this.crvReport = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvReport
            // 
            this.crvReport.ActiveViewIndex = -1;
            this.crvReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.crvReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvReport.DisplayGroupTree = false;
            this.crvReport.Location = new System.Drawing.Point(12, 16);
            this.crvReport.Name = "crvReport";
            this.crvReport.ShowCloseButton = false;
            this.crvReport.ShowGroupTreeButton = false;
            this.crvReport.Size = new System.Drawing.Size(676, 472);
            this.crvReport.TabIndex = 18;
            // 
            // frmListofEmployeeBenefitAdjustment
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(704, 502);
            this.Controls.Add(this.crvReport);
            this.Name = "frmListofEmployeeBenefitAdjustment";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmListofEmployeeBenefitAdjustment_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmListofEmployeeBenefitAdjustment_FormClosed);
            this.ResumeLayout(false);

		}
		#endregion

		#region - private -
        private CompanyInfo objCompany;
		private CompanyFacade facadeCompany;
		#endregion

		//		============================== Constructor ==============================
		public frmListofEmployeeBenefitAdjustment()
		{
			InitializeComponent();
			facadeCompany = new CompanyFacade();
			this.Text = "รายงานเงินขาดเงินเกินตามพนักงานประจำเดือน";
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

		private DateTime selectedDate;
		public DateTime SelectedDate
		{
			set
			{
				selectedDate = value;
			}
		}


		//		============================== Private Method ==============================
		private void ReportDatabaseLogon()
		{
			try
			{
				objCompany = getCompany();
				ReportDocument rdprint = new ReportDocument();
				string StartMonth = Convert.ToString(selectedDate.Month);
				string StartYear = Convert.ToString(selectedDate.Year);

				rdprint.Load(@ApplicationProfile.REPORT_PATH + "rptListofEmployeeBenefitAdjustment.rpt");

				DataSourceConnections dataSourceConnections = rdprint.DataSourceConnections;
				IConnectionInfo iConnectionInfo = dataSourceConnections[0];
				iConnectionInfo.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

				rdprint.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.Thai + "'";
				rdprint.DataDefinition.FormulaFields["Month"].Text = "'" +StartMonth+ "'";
				rdprint.DataDefinition.FormulaFields["Year"].Text = StartYear;

				crvReport.ReportSource = rdprint;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
			}
		}

		//		============================== Event ==============================
		private void frmListofEmployeeBenefitAdjustment_Load(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			ReportDatabaseLogon();
			crvReport.RefreshReport();
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}

        private void frmListofEmployeeBenefitAdjustment_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseReport(crvReport);
        }

        #region IMDIChildFormGUI Members

        public void InitForm()
        {
        }

        public void RefreshForm()
        {
        }

        public void PrintForm()
        { }

        public void ExitForm()
        {
            this.Close();
        }

        #endregion
    }
}
