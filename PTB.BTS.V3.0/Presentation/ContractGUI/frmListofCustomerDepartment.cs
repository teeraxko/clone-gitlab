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

namespace Presentation.ContractGUI
{
	public class frmListofCustomerDepartment : System.Windows.Forms.Form
	{
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
			this.crvCustDept = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.SuspendLayout();
			// 
			// crvCustDept
			// 
			this.crvCustDept.ActiveViewIndex = -1;
			this.crvCustDept.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.crvCustDept.DisplayGroupTree = false;
			this.crvCustDept.Location = new System.Drawing.Point(18, 16);
			this.crvCustDept.Name = "crvCustDept";
			this.crvCustDept.ReportSource = null;
			this.crvCustDept.ShowCloseButton = false;
			this.crvCustDept.ShowGroupTreeButton = false;
			this.crvCustDept.Size = new System.Drawing.Size(992, 712);
			this.crvCustDept.TabIndex = 0;
			// 
			// frmListOfCustomerDepartment
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(1028, 746);
			this.Controls.Add(this.crvCustDept);
			this.Name = "frmListOfCustomerDepartment";
			this.Load += new System.EventHandler(this.frmListOfCustomerDepartment_Load);
			this.ResumeLayout(false);

		}
		#endregion

		#region - private -
		private CompanyInfo objCompany;
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvCustDept;
		private CompanyFacade facadeCompany;
		#endregion
		
//		============================== Constructor ==============================
		public frmListofCustomerDepartment()
		{
			InitializeComponent();
			facadeCompany = new CompanyFacade();
			this.Text = "รายงานแผนกลูกค้า";
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
				ReportDocument rdCustomer = new ReportDocument();
				rdCustomer.Load(@ApplicationProfile.REPORT_PATH + "rptCustomerDepartment.rpt");
				DataSourceConnections dataSourceConnections = rdCustomer.DataSourceConnections;
				IConnectionInfo iConnectionInfo = dataSourceConnections[0];
				iConnectionInfo.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

				rdCustomer.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.Thai + "'";
				crvCustDept.ReportSource = rdCustomer;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
			}
		}

//		============================== Event ==============================
		private void frmListOfCustomerDepartment_Load(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			ReportDatabaseLogon();
			crvCustDept.RefreshReport();
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}


	}
}
