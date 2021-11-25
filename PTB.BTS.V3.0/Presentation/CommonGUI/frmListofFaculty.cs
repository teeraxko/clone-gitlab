using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using System.Data.SqlClient;
using CrystalDecisions.Shared;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

using Facade.PiFacade;
using SystemFramework.AppConfig;

namespace Presentation.CommonGUI
{
	public class frmListofFaculty : ChildFormBase, IMDIChildForm
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
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvFaculty;
		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
            this.crvFaculty = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvFaculty
            // 
            this.crvFaculty.ActiveViewIndex = -1;
            this.crvFaculty.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.crvFaculty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvFaculty.DisplayGroupTree = false;
            this.crvFaculty.Location = new System.Drawing.Point(16, 16);
            this.crvFaculty.Name = "crvFaculty";
            this.crvFaculty.ShowCloseButton = false;
            this.crvFaculty.ShowGroupTreeButton = false;
            this.crvFaculty.Size = new System.Drawing.Size(656, 440);
            this.crvFaculty.TabIndex = 0;
            // 
            // frmListofFaculty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(688, 478);
            this.Controls.Add(this.crvFaculty);
            this.Name = "frmListofFaculty";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmListofFaculty_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmListofFaculty_FormClosed);
            this.ResumeLayout(false);

		}
		#endregion

		#region - private -
        private CompanyInfo objCompany;
		private CompanyFacade facadeCompany;
		#endregion
		//		============================== Constructor ==============================
		public frmListofFaculty()
		{
			InitializeComponent();
			facadeCompany = new CompanyFacade();
			this.Text = "รายงานคณะ";

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
				ReportDocument rdPrint = new ReportDocument();
				rdPrint.Load(@ApplicationProfile.REPORT_PATH + "rptListofFaculty.rpt");

				DataSourceConnections dataSourceConnections = rdPrint.DataSourceConnections;
				IConnectionInfo iConnectionInfo = dataSourceConnections[0];
				iConnectionInfo.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

				
				rdPrint.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.Thai + "'";
				crvFaculty.ReportSource = rdPrint;
			}
			catch(SqlException sqlex)
			{
				Message(sqlex);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
			}
		}

		//		============================== Event ==============================


		private void frmListofFaculty_Load(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			ReportDatabaseLogon();
			crvFaculty.RefreshReport();
			this.Cursor = System.Windows.Forms.Cursors.Default;
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

        private void frmListofFaculty_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseReport(crvFaculty);
        }
    }
}
