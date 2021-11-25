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
	public class frmListofDistrict : ChildFormBase, IMDIChildForm
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
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvDistrict;
		private System.ComponentModel.Container components = null;


		private void InitializeComponent()
		{
            this.crvDistrict = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvDistrict
            // 
            this.crvDistrict.ActiveViewIndex = -1;
            this.crvDistrict.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.crvDistrict.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvDistrict.DisplayGroupTree = false;
            this.crvDistrict.Location = new System.Drawing.Point(16, 16);
            this.crvDistrict.Name = "crvDistrict";
            this.crvDistrict.ShowCloseButton = false;
            this.crvDistrict.ShowGroupTreeButton = false;
            this.crvDistrict.Size = new System.Drawing.Size(648, 448);
            this.crvDistrict.TabIndex = 0;
            // 
            // frmListofDistrict
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(680, 478);
            this.Controls.Add(this.crvDistrict);
            this.Name = "frmListofDistrict";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmListofDistrict_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmListofDistrict_FormClosed);
            this.ResumeLayout(false);

		}
		#endregion

		#region - private -
		private CompanyInfo objCompany;
		private CompanyFacade facadeCompany;
		#endregion

//		============================== Constructor ==============================
		public frmListofDistrict()
		{
			InitializeComponent();
			facadeCompany = new CompanyFacade();
			this.Text = "รายงานอำเภอ";

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
				rdPrint.Load(@ApplicationProfile.REPORT_PATH + "rptListofDistrict.rpt");

				DataSourceConnections dataSourceConnections = rdPrint.DataSourceConnections;
				IConnectionInfo iConnectionInfo = dataSourceConnections[0];
				iConnectionInfo.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

				
				rdPrint.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.Thai + "'";
				crvDistrict.ReportSource = rdPrint;
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

		private void frmListofDistrict_Load(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			ReportDatabaseLogon();
			crvDistrict.RefreshReport();
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}

        private void frmListofDistrict_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseReport(crvDistrict);
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
