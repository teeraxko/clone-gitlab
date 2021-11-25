using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

using Facade.PiFacade;


namespace Presentation.CommonGUI
{
	public class frmReportTest : System.Windows.Forms.Form
	{
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvTest;
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
			this.crvTest = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.SuspendLayout();
			// 
			// crvTest
			// 
			this.crvTest.ActiveViewIndex = -1;
			this.crvTest.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.crvTest.Location = new System.Drawing.Point(0, 0);
			this.crvTest.Name = "crvTest";
			this.crvTest.ReportSource = null;
			this.crvTest.Size = new System.Drawing.Size(616, 400);
			this.crvTest.TabIndex = 0;
			// 
			// frmReportTest
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(632, 414);
			this.Controls.Add(this.crvTest);
			this.Name = "frmReportTest";
			this.Text = "frmReportTest";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmReportTest_Load);
			this.ResumeLayout(false);

		}
		#endregion

		#region - Private -
        private CompanyInfo objCompany;
		private CompanyFacade facadeCompany;
		#endregion - Private -

		//		============================== Constructor ==============================
		public frmReportTest()
		{			
			InitializeComponent();
			facadeCompany = new CompanyFacade();
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
				ReportDocument rdProvince = new ReportDocument();
				rdProvince.Load(@"\\ictdev01\ptb\Report\rptListofStreet.rpt");
				rdProvince.SetDatabaseLogon("bts","bts","ictdev01","btsdb");
				rdProvince.DataDefinition.FormulaFields[0].Text = "'" + objCompany.AFullName.Thai + "'";
				crvTest.ReportSource = rdProvince;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
			}
		}
		//		============================== Event ==============================
		private void frmReportTest_Load(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			ReportDatabaseLogon();
			crvTest.RefreshReport();
			this.Cursor = System.Windows.Forms.Cursors.Default;		
		}
	}
}
