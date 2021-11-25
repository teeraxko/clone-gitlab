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
using ictus.Common.Entity.Time;

namespace Presentation.ContractGUI
{
	public class frmrptListOfContractMatchWithDriver : ChildFormBase,IMDIChildForm
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
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker dtpDate;
		private System.Windows.Forms.Button btnShow;
		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
            this.crvReport = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnShow = new System.Windows.Forms.Button();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
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
            this.crvReport.Location = new System.Drawing.Point(16, 72);
            this.crvReport.Name = "crvReport";
            this.crvReport.ShowCloseButton = false;
            this.crvReport.ShowGroupTreeButton = false;
            this.crvReport.Size = new System.Drawing.Size(616, 424);
            this.crvReport.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnShow);
            this.groupBox1.Controls.Add(this.dtpDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(16, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(608, 48);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(176, 16);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(75, 23);
            this.btnShow.TabIndex = 2;
            this.btnShow.Text = "ดูข้อมูล";
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "MM/yyyy";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(80, 17);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(80, 20);
            this.dtpDate.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "เดือน/ปี";
            // 
            // frmrptListOfContractMatchWithDriver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(640, 502);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.crvReport);
            this.Name = "frmrptListOfContractMatchWithDriver";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmrptListOfContractMatchWithDriver_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		#region - private -
		private CompanyInfo objCompany;
		private CompanyFacade facadeCompany;
		private frmMain mdiParent;
		#endregion

		//		============================== Constructor ==============================
		public frmrptListOfContractMatchWithDriver()
		{
			InitializeComponent();
			facadeCompany = new CompanyFacade();
			this.Text = "รายงานพนักงานขับรถตามสถานะปัจจุบัน";
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
                YearMonth yearMonth = new YearMonth(dtpDate.Value.Year, dtpDate.Value.Month);

				string StartDate1 = Convert.ToString(dtpDate.Value.Month);
				string StartDate2 = Convert.ToString(dtpDate.Value.Year);

				rdprint1.Load(@ApplicationProfile.REPORT_PATH + "rptContractMatchWithDriver.rpt");
				DataSourceConnections dataSourceConnections1 = rdprint1.DataSourceConnections;
				IConnectionInfo iConnectionInfo1 = dataSourceConnections1[0];
				iConnectionInfo1.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

				rdprint1.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.Thai + "'";
				rdprint1.DataDefinition.FormulaFields["Month"].Text = StartDate1;
				rdprint1.DataDefinition.FormulaFields["Year"].Text = StartDate2;

                rdprint1.DataDefinition.ParameterFields["@Company_Code"].ApplyCurrentValues(CrytalParameterValue(objCompany.CompanyCode));
                rdprint1.DataDefinition.ParameterFields["@Employee_No"].ApplyCurrentValues(CrytalParameterValue(string.Empty));
                rdprint1.DataDefinition.ParameterFields["@FromDate"].ApplyCurrentValues(CrytalParameterValue(yearMonth.MinDateOfMonth));
                rdprint1.DataDefinition.ParameterFields["@ToDate"].ApplyCurrentValues(CrytalParameterValue(yearMonth.MaxDateOfMonth));                
				
				crvReport.ReportSource = rdprint1;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
			}
		}

        private ParameterValues CrytalParameterValue(object paraValue)
        {
            ParameterValues paramValues = new ParameterValues();
            ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = paraValue;
            paramValues.Add(paramDiscreteValue);
            return paramValues;
        }

		//		============================== Event ==============================
        #region Public Method
        public void InitForm()
        {
            if (DateTime.Today.Month == 1)
            {
                dtpDate.Value = new DateTime(DateTime.Today.AddYears(-1).Year, DateTime.Today.AddMonths(-1).Month, 1);

            }
            else
            {
                dtpDate.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            }
            crvReport.Hide();
            dtpDate.Focus();
            mdiParent.EnableExitCommand(true);
        }

        public void RefreshForm()
        {
            crvReport.Show();
            mdiParent.EnableExitCommand(true);
        }

        public void PrintForm()
        {
        }

        public void ExitForm()
        {
            this.Hide();
        } 
        #endregion

		//		==============================Event ==============================
		private void frmrptListOfContractMatchWithDriver_Load(object sender, System.EventArgs e)
		{
			mdiParent = (frmMain)this.MdiParent;
			InitForm();
		}

		private void btnShow_Click(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			ReportDatabaseLogon();
			RefreshForm();
			mdiParent.EnableExitCommand(true);
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}
	}
}
