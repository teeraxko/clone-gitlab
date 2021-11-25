using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

using ictus.Common.Entity;

using Facade.PiFacade;
using Facade.AttendanceFacade;

using Presentation.CommonGUI;

using SystemFramework.AppConfig;
using SystemFramework.AppException;

namespace Presentation.AttendanceGUI
{	
	public class frmListOfEmployeeBenefitforTimeCard : ChildFormBase,IMDIChildForm
	{
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
                    facadeCompany.Dispose();
                    facadeTimeCardForCharge.Dispose();
                    facadeTimeCardForPayment.Dispose();

                    facadeCompany = null;
                    facadeTimeCardForCharge = null;
                    facadeTimeCardForPayment = null;
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvReport1;
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvReport2;
		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.crvReport1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.crvReport2 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(16, 16);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1000, 712);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.crvReport1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(992, 686);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "ใบลงเวลาสำหรับพนักงานบริการ(สำหรับลูกค้า)";
            // 
            // crvReport1
            // 
            this.crvReport1.ActiveViewIndex = -1;
            this.crvReport1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.crvReport1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvReport1.DisplayGroupTree = false;
            this.crvReport1.DisplayToolbar = false;
            this.crvReport1.Location = new System.Drawing.Point(8, 8);
            this.crvReport1.Name = "crvReport1";
            this.crvReport1.ShowCloseButton = false;
            this.crvReport1.ShowGroupTreeButton = false;
            this.crvReport1.Size = new System.Drawing.Size(976, 656);
            this.crvReport1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.crvReport2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(992, 686);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "ใบลงเวลาสำหรับพนักงานบริการ(สำหรับพนักงาน)";
            // 
            // crvReport2
            // 
            this.crvReport2.ActiveViewIndex = -1;
            this.crvReport2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.crvReport2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvReport2.DisplayGroupTree = false;
            this.crvReport2.DisplayStatusBar = false;
            this.crvReport2.DisplayToolbar = false;
            this.crvReport2.Location = new System.Drawing.Point(8, 11);
            this.crvReport2.Name = "crvReport2";
            this.crvReport2.ShowCloseButton = false;
            this.crvReport2.ShowGroupTreeButton = false;
            this.crvReport2.Size = new System.Drawing.Size(976, 656);
            this.crvReport2.TabIndex = 1;
            // 
            // frmListOfEmployeeBenefitforTimeCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1028, 746);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmListOfEmployeeBenefitforTimeCard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmListOfEmployeeBenefitforTimeCard_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmListOfEmployeeBenefitforTimeCard_FormClosed);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		#region - private -
		private CompanyInfo objCompany;
		private CompanyFacade facadeCompany;
		private TimeCardForChargeFacade facadeTimeCardForCharge;
		private TimeCardForPaymentFacade facadeTimeCardForPayment;
		#endregion

		private DateTime selectedDate;
		public DateTime SelectedDate
		{
			set
			{
				selectedDate = value;
			}
		}

		private string selectedReportChargeName;
		public string SelectedReportChargeName
		{
			set
			{
				selectedReportChargeName = value;
			}
		}
		private string selectedReportPaymentName;
		public string SelectedReportPaymentName
		{
			set
			{
				selectedReportPaymentName = value;
			}
		}
		private string selectedEmployeeNo;
		public string SelectedEmployeeNo
		{
			set
			{
				selectedEmployeeNo = value;
			}
		}

        #region Constructor
        public frmListOfEmployeeBenefitforTimeCard()
        {
            InitializeComponent();
            facadeCompany = new CompanyFacade();
            facadeTimeCardForCharge = new TimeCardForChargeFacade();
            facadeTimeCardForPayment = new TimeCardForPaymentFacade();
        } 
        #endregion

        #region Private Method
        private CompanyInfo getCompany()
        {
            objCompany = new CompanyInfo("12");
            if (facadeCompany.FillCompany(ref objCompany))
            {
                return objCompany;
            }
            else
            {
                return null;
            }
        }

        private void ReportDatabaseLogon()
        {
            try
            {
                string EmployeeNo = selectedEmployeeNo;
                string StartDate1 = Convert.ToString(selectedDate.Month);
                string StartDate2 = Convert.ToString(selectedDate.Year);
                objCompany = getCompany();

                if (facadeTimeCardForCharge.GenerateTimeCardCharge(selectedDate))
                {
                    ReportDocument rdprint1 = new ReportDocument();

                    rdprint1.Load(@ApplicationProfile.REPORT_PATH + selectedReportChargeName);
                    DataSourceConnections dataSourceConnections1 = rdprint1.DataSourceConnections;
                    IConnectionInfo iConnectionInfo1 = dataSourceConnections1[0];
                    iConnectionInfo1.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

                    rdprint1.DataDefinition.FormulaFields["Comp_Name_Thai"].Text = "'" + objCompany.AFullName.Thai + "'";
                    rdprint1.DataDefinition.FormulaFields["Comp_Name_Eng"].Text = "'" + objCompany.AFullName.English + "'";
                    rdprint1.DataDefinition.FormulaFields["EmployeeNo"].Text = "'" + EmployeeNo + "'";
                    rdprint1.DataDefinition.FormulaFields["Month"].Text = StartDate1;
                    rdprint1.DataDefinition.FormulaFields["Year"].Text = StartDate2;

                    crvReport1.ReportSource = rdprint1;
                }

                if (facadeTimeCardForPayment.GenerateTimeCardPayment(selectedDate))
                {
                    ReportDocument rdprint2 = new ReportDocument();
                    rdprint2.Load(@ApplicationProfile.REPORT_PATH + selectedReportPaymentName);
                    DataSourceConnections dataSourceConnections2 = rdprint2.DataSourceConnections;
                    IConnectionInfo iConnectionInfo2 = dataSourceConnections2[0];
                    iConnectionInfo2.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

                    rdprint2.DataDefinition.FormulaFields["Comp_Name_Thai"].Text = "'" + objCompany.AFullName.Thai + "'";
                    rdprint2.DataDefinition.FormulaFields["Comp_Name_Eng"].Text = "'" + objCompany.AFullName.English + "'";
                    rdprint2.DataDefinition.FormulaFields["EmployeeNo"].Text = "'" + EmployeeNo + "'";
                    rdprint2.DataDefinition.FormulaFields["Month"].Text = StartDate1;
                    rdprint2.DataDefinition.FormulaFields["Year"].Text = StartDate2;


                    crvReport2.ReportSource = rdprint2;
                }

            }
            catch (SqlException sqlex)
            {
                Message(sqlex);
            }
            catch (AppExceptionBase ex)
            {
                Message(ex);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
            }
        }
        
        #endregion

        #region Base Event
        public void InitForm()
        {
            crvReport1.Show();
            crvReport2.Show();
            this.crvReport1.DisplayToolbar = true;
            this.crvReport2.DisplayToolbar = true;
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

        #region Form Event
        private void frmListOfEmployeeBenefitforTimeCard_Load(object sender, System.EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            ReportDatabaseLogon();
            InitForm();
            crvReport1.Refresh();
            crvReport2.Refresh();
            //crvReport1.RefreshReport();
            //crvReport2.RefreshReport();
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void frmListOfEmployeeBenefitforTimeCard_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseReport(crvReport1);
            CloseReport(crvReport2);
        } 
        #endregion
	}
}
