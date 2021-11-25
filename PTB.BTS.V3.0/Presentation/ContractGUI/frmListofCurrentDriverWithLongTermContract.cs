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
	public class frmListofCurrentDriverWithLongTermContract : ChildFormBase
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
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvCurrentDriverWithLong;
		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
            this.crvCurrentDriverWithLong = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvCurrentDriverWithLong
            // 
            this.crvCurrentDriverWithLong.ActiveViewIndex = -1;
            this.crvCurrentDriverWithLong.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.crvCurrentDriverWithLong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvCurrentDriverWithLong.DisplayGroupTree = false;
            this.crvCurrentDriverWithLong.Location = new System.Drawing.Point(16, 16);
            this.crvCurrentDriverWithLong.Name = "crvCurrentDriverWithLong";
            this.crvCurrentDriverWithLong.ShowCloseButton = false;
            this.crvCurrentDriverWithLong.ShowGroupTreeButton = false;
            this.crvCurrentDriverWithLong.Size = new System.Drawing.Size(984, 610);
            this.crvCurrentDriverWithLong.TabIndex = 0;
            // 
            // frmListofCurrentDriverWithLongTermContract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1016, 638);
            this.Controls.Add(this.crvCurrentDriverWithLong);
            this.Name = "frmListofCurrentDriverWithLongTermContract";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmListofCurrentDriverWithLongTermContract_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmListofCurrentDriverWithLongTermContract_FormClosed);
            this.ResumeLayout(false);

		}
		#endregion

		#region - private -
		private CompanyInfo objCompany;
		private CompanyFacade facadeCompany;
		#endregion
		//		============================== Constructor ==============================

		public frmListofCurrentDriverWithLongTermContract()
		{
			InitializeComponent();
			facadeCompany = new CompanyFacade();
			this.Text = "พนักงานขับรถแยกตามบริษัทลูกค้า(เฉพาะสัญญาเช่าระยะยาว)";
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

				rdprint.Load(@ApplicationProfile.REPORT_PATH + "rptListofCurrentDriver_WithLongTermContract.rpt");

				DataSourceConnections dataSourceConnections = rdprint.DataSourceConnections;
				IConnectionInfo iConnectionInfo = dataSourceConnections[0];
				iConnectionInfo.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

				rdprint.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.Thai + "'";

				crvCurrentDriverWithLong.ReportSource = rdprint;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
			}
		}
		//		============================== Event ==============================

		private void frmListofCurrentDriverWithLongTermContract_Load(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			ReportDatabaseLogon();
			crvCurrentDriverWithLong.RefreshReport();
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}

        private void frmListofCurrentDriverWithLongTermContract_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseReport(crvCurrentDriverWithLong);
        }


	}
}
