using System;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared ;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

using Facade.PiFacade;
using Presentation.CommonGUI;
using SystemFramework.AppConfig;
using SystemFramework.AppMessage;

namespace Presentation.ContractGUI
{
	/// <summary>
	/// Summary description for frmListOfSprerDriver.
	/// </summary>
	public class frmListOfSprerDriver :  ChildFormBase, IMDIChildForm
	{
		private System.ComponentModel.Container components = null;
		private CompanyFacade facadeCompany;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvTab2;
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvTab1;
        private GroupBox groupBox1;
        private Label label2;
        private DateTimePicker dtpToDate;
        private Button btnShow;
        private DateTimePicker dtpFromDate;
        private Label label1;
		private frmMain mdiParent;
		
		public frmListOfSprerDriver()
            : base()
		{
			InitializeComponent();
			facadeCompany = new CompanyFacade();
			this.Text = "รายงาน Spare Driver";
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.crvTab1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.crvTab2 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.btnShow = new System.Windows.Forms.Button();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 60);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(752, 397);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.crvTab1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(744, 371);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "รายงาน Spare Driver (ที่พร้อมใช้)";
            // 
            // crvTab1
            // 
            this.crvTab1.ActiveViewIndex = -1;
            this.crvTab1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvTab1.DisplayGroupTree = false;
            this.crvTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvTab1.Location = new System.Drawing.Point(0, 0);
            this.crvTab1.Name = "crvTab1";
            this.crvTab1.ShowCloseButton = false;
            this.crvTab1.ShowGroupTreeButton = false;
            this.crvTab1.Size = new System.Drawing.Size(744, 371);
            this.crvTab1.TabIndex = 3;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.crvTab2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(744, 371);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "รายงาน Spare Driver (ที่อยู่ระหว่างปฏิบัติงาน)";
            // 
            // crvTab2
            // 
            this.crvTab2.ActiveViewIndex = -1;
            this.crvTab2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvTab2.DisplayGroupTree = false;
            this.crvTab2.DisplayStatusBar = false;
            this.crvTab2.DisplayToolbar = false;
            this.crvTab2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvTab2.Location = new System.Drawing.Point(0, 0);
            this.crvTab2.Name = "crvTab2";
            this.crvTab2.ShowCloseButton = false;
            this.crvTab2.ShowGroupTreeButton = false;
            this.crvTab2.Size = new System.Drawing.Size(744, 371);
            this.crvTab2.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpToDate);
            this.groupBox1.Controls.Add(this.btnShow);
            this.groupBox1.Controls.Add(this.dtpFromDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(752, 56);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "รายละเอียดวันที่";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(160, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "-";
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(170, 24);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(88, 20);
            this.dtpToDate.TabIndex = 3;
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(272, 23);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(75, 23);
            this.btnShow.TabIndex = 2;
            this.btnShow.Text = "ดูข้อมูล";
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(72, 24);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(88, 20);
            this.dtpFromDate.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ช่วงวันที่";
            // 
            // frmListOfSprerDriver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(752, 457);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmListOfSprerDriver";
            this.Text = "frmListOfSprerDriver";
            this.Load += new System.EventHandler(this.frmListOfSprerDriver_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

        #region Puclic Method
        public void InitForm()
        {
            crvTab1.Hide();
            crvTab2.Hide();
            mdiParent.EnableExitCommand(true);
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

        #region Private Method
        private void ReportDatabaseLogon()
        {
            try
            {
                if (validateDate())
                {
                    string companyName = this.getCompany().AFullName.Thai;

                    //paint tab1 report rptListofSpareVehicleCurrentlyAvailable
                    ReportDocument rdprint1 = new ReportDocument();
                    rdprint1.Load(@ApplicationProfile.REPORT_PATH + "rptListOfSpareDriverCurrentlyAvailable.rpt");
                    DataSourceConnections dataSourceConnections1 = rdprint1.DataSourceConnections;
                    IConnectionInfo iConnectionInfo1 = dataSourceConnections1[0];
                    iConnectionInfo1.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);
                    rdprint1.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + companyName + "'";
                    rdprint1.DataDefinition.ParameterFields["@FromDate"].ApplyCurrentValues(CrytalParameterValue(dtpFromDate.Value.Date));
                    rdprint1.DataDefinition.ParameterFields["@ToDate"].ApplyCurrentValues(CrytalParameterValue(dtpToDate.Value.Date));

                    crvTab1.ReportSource = rdprint1;

                    //paint tab2 report rptListOfSpareDriverCurrentlyAssigned
                    ReportDocument rdprint2 = new ReportDocument();
                    rdprint2.Load(@ApplicationProfile.REPORT_PATH + "rptListOfSpareDriverCurrentlyAssigned.rpt");
                    DataSourceConnections dataSourceConnections2 = rdprint2.DataSourceConnections;
                    IConnectionInfo iConnectionInfo2 = dataSourceConnections2[0];
                    iConnectionInfo2.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

                    rdprint2.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + companyName + "'";
                    crvTab2.ReportSource = rdprint2;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
            }
        }

        private CompanyInfo getCompany()
        {
            CompanyInfo objCompany = new CompanyInfo("12");
            if (facadeCompany.FillCompany(ref objCompany))
            {
                return objCompany;
            }
            else
            {
                return null;
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

        private bool validateDate()
        {
            if (dtpFromDate.Value.Date > dtpToDate.Value.Date)
            {
                Message(MessageList.Error.E0011, "วันที่เริ่มต้น", "วันที่สิ้นสุด");
                dtpFromDate.Focus();
                return false;
            }

            return true;
        } 
        #endregion

        #region Form Event
        private void frmListOfSprerDriver_Load(object sender, System.EventArgs e)
        {
            mdiParent = (frmMain)this.MdiParent;
            InitForm();            
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            ReportDatabaseLogon();
            crvTab1.Show();
            crvTab2.Show();
            crvTab1.DisplayToolbar = true;
            crvTab2.DisplayToolbar = true;
            this.Cursor = System.Windows.Forms.Cursors.Default;
        } 
        #endregion
	}
}
