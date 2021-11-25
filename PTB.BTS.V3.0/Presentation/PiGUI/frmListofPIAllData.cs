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

using SystemFramework.AppConfig;
using Presentation.CommonGUI;

namespace Presentation.PiGUI
{
	public class frmListofPIAllData : ChildFormBase, IMDIChildForm
	{
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvPI;
		private System.ComponentModel.Container components = null;
	
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
            this.crvPI = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvPI
            // 
            this.crvPI.ActiveViewIndex = -1;
            this.crvPI.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.crvPI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvPI.DisplayGroupTree = false;
            this.crvPI.Location = new System.Drawing.Point(16, 16);
            this.crvPI.Name = "crvPI";
            this.crvPI.ShowCloseButton = false;
            this.crvPI.ShowGroupTreeButton = false;
            this.crvPI.Size = new System.Drawing.Size(688, 448);
            this.crvPI.TabIndex = 0;
            // 
            // frmListofPIAllData
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(712, 470);
            this.Controls.Add(this.crvPI);
            this.Name = "frmListofPIAllData";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmListofPIData_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmListofPIAllData_FormClosed);
            this.ResumeLayout(false);

		}
		#endregion

        private CompanyInfo objCompanyInfo;
		private CompanyFacade facadeCompany;

//		============================== Constructor ==============================
		public frmListofPIAllData()
		{
			InitializeComponent();
			facadeCompany = new CompanyFacade();
			this.Text = "��§ҹ�����ž�ѡ�ҹ";
		}
//		============================== Property ==============================
		public CompanyInfo getCompany()
		{
            objCompanyInfo = new CompanyInfo("12");
            if (facadeCompany.FillCompany(ref objCompanyInfo))
			{
                return objCompanyInfo;
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
				objCompanyInfo = getCompany();
				ReportDocument rdPI = new ReportDocument();

				rdPI.Load(@ApplicationProfile.REPORT_PATH + "rptPIData.rpt");

				DataSourceConnections dataSourceConnections = rdPI.DataSourceConnections;
				IConnectionInfo iConnectionInfo = dataSourceConnections[0];
				iConnectionInfo.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

                rdPI.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompanyInfo.AFullName.Thai + "'";
				crvPI.ReportSource = rdPI;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
			}
		}

//		============================== Event ==============================
		private void frmListofPIData_Load(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			ReportDatabaseLogon();
			crvPI.RefreshReport();
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}

        private void frmListofPIAllData_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseReport(crvPI);   
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
