using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared ;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

using Facade.PiFacade;
using Facade.AttendanceFacade;

using Presentation.CommonGUI;

using SystemFramework.AppConfig;
using SystemFramework.AppMessage;
using SystemFramework.AppException;

namespace Presentation.AttendanceGUI
{
	public class frmListofAnnualLeaveSale : ChildFormBase, IMDIChildForm
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
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvprint;
		private System.ComponentModel.Container components = null;


		private void InitializeComponent()
		{
            this.crvprint = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvprint
            // 
            this.crvprint.ActiveViewIndex = -1;
            this.crvprint.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.crvprint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvprint.DisplayGroupTree = false;
            this.crvprint.Location = new System.Drawing.Point(8, 16);
            this.crvprint.Name = "crvprint";
            this.crvprint.ShowCloseButton = false;
            this.crvprint.ShowGroupTreeButton = false;
            this.crvprint.Size = new System.Drawing.Size(1008, 720);
            this.crvprint.TabIndex = 0;
            // 
            // frmListofAnnualLeaveSale
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1028, 746);
            this.Controls.Add(this.crvprint);
            this.Name = "frmListofAnnualLeaveSale";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmListofAnnualLeaveSale_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmListofAnnualLeaveSale_FormClosed);
            this.ResumeLayout(false);

		}
		#endregion

		#region - private -
		private CompanyInfo objCompany;
		private CompanyFacade facadeCompany;
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

		public frmListofAnnualLeaveSale()
		{
			InitializeComponent();
			facadeCompany = new CompanyFacade();
			this.Text = "รายงานข้อมูลการขายวันหยุดพักร้อน";
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
				string StartDate = Convert.ToString(selectedDate.Year);

				rdprint1.Load(@ApplicationProfile.REPORT_PATH + selectedReportName);
				DataSourceConnections dataSourceConnections1 = rdprint1.DataSourceConnections;
				IConnectionInfo iConnectionInfo1 = dataSourceConnections1[0];
				iConnectionInfo1.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

				rdprint1.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.Thai + "'";
				rdprint1.DataDefinition.FormulaFields["Year"].Text = "'"+StartDate+"'";

				crvprint.ReportSource = rdprint1;
			}

			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
			}
		}
		//		==============================Base Event ==============================

		private void frmListofAnnualLeaveSale_Load(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			ReportDatabaseLogon();
			crvprint.RefreshReport();
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}

        private void frmListofAnnualLeaveSale_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseReport(crvprint);   
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
