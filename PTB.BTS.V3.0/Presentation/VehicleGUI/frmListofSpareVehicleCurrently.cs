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

namespace Presentation.VehicleGUI
{
	public class frmListofSpareVehicleCurrently : ChildFormBase, IMDIChildForm
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

		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabAssigned;
		private System.Windows.Forms.TabPage tabRepaired;
		private System.Windows.Forms.TabPage tabAvailable;
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvAssigned;
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvRepaired;
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvAvailable;
        private GroupBox groupBox1;
        private Label label2;
        private DateTimePicker dtpToDate;
        private Button btnShow;
        private DateTimePicker dtpFromDate;
        private Label label1;
		private System.ComponentModel.Container components = null;
		private void InitializeComponent()
		{
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabAssigned = new System.Windows.Forms.TabPage();
            this.crvAssigned = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.tabRepaired = new System.Windows.Forms.TabPage();
            this.crvRepaired = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.tabAvailable = new System.Windows.Forms.TabPage();
            this.crvAvailable = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.btnShow = new System.Windows.Forms.Button();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabAssigned.SuspendLayout();
            this.tabRepaired.SuspendLayout();
            this.tabAvailable.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabAssigned);
            this.tabControl1.Controls.Add(this.tabRepaired);
            this.tabControl1.Controls.Add(this.tabAvailable);
            this.tabControl1.Location = new System.Drawing.Point(0, 70);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1028, 430);
            this.tabControl1.TabIndex = 13;
            // 
            // tabAssigned
            // 
            this.tabAssigned.Controls.Add(this.crvAssigned);
            this.tabAssigned.Location = new System.Drawing.Point(4, 22);
            this.tabAssigned.Name = "tabAssigned";
            this.tabAssigned.Size = new System.Drawing.Size(1020, 404);
            this.tabAssigned.TabIndex = 0;
            this.tabAssigned.Text = "ระหว่างจ่ายงาน";
            // 
            // crvAssigned
            // 
            this.crvAssigned.ActiveViewIndex = -1;
            this.crvAssigned.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvAssigned.DisplayGroupTree = false;
            this.crvAssigned.DisplayToolbar = false;
            this.crvAssigned.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvAssigned.Location = new System.Drawing.Point(0, 0);
            this.crvAssigned.Name = "crvAssigned";
            this.crvAssigned.ShowCloseButton = false;
            this.crvAssigned.ShowGroupTreeButton = false;
            this.crvAssigned.Size = new System.Drawing.Size(1020, 404);
            this.crvAssigned.TabIndex = 2;
            // 
            // tabRepaired
            // 
            this.tabRepaired.Controls.Add(this.crvRepaired);
            this.tabRepaired.Location = new System.Drawing.Point(4, 22);
            this.tabRepaired.Name = "tabRepaired";
            this.tabRepaired.Size = new System.Drawing.Size(1020, 404);
            this.tabRepaired.TabIndex = 1;
            this.tabRepaired.Text = "อุบัติเหตุ/ซ่อมบำรุง";
            // 
            // crvRepaired
            // 
            this.crvRepaired.ActiveViewIndex = -1;
            this.crvRepaired.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvRepaired.DisplayGroupTree = false;
            this.crvRepaired.DisplayStatusBar = false;
            this.crvRepaired.DisplayToolbar = false;
            this.crvRepaired.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvRepaired.Location = new System.Drawing.Point(0, 0);
            this.crvRepaired.Name = "crvRepaired";
            this.crvRepaired.ShowCloseButton = false;
            this.crvRepaired.ShowGroupTreeButton = false;
            this.crvRepaired.Size = new System.Drawing.Size(1020, 404);
            this.crvRepaired.TabIndex = 1;
            // 
            // tabAvailable
            // 
            this.tabAvailable.Controls.Add(this.crvAvailable);
            this.tabAvailable.Location = new System.Drawing.Point(4, 22);
            this.tabAvailable.Name = "tabAvailable";
            this.tabAvailable.Size = new System.Drawing.Size(1020, 404);
            this.tabAvailable.TabIndex = 2;
            this.tabAvailable.Text = "พร้อมใช้";
            // 
            // crvAvailable
            // 
            this.crvAvailable.ActiveViewIndex = -1;
            this.crvAvailable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvAvailable.DisplayGroupTree = false;
            this.crvAvailable.DisplayStatusBar = false;
            this.crvAvailable.DisplayToolbar = false;
            this.crvAvailable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvAvailable.Location = new System.Drawing.Point(0, 0);
            this.crvAvailable.Name = "crvAvailable";
            this.crvAvailable.ShowCloseButton = false;
            this.crvAvailable.ShowGroupTreeButton = false;
            this.crvAvailable.Size = new System.Drawing.Size(1020, 404);
            this.crvAvailable.TabIndex = 2;
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
            this.groupBox1.Size = new System.Drawing.Size(1028, 64);
            this.groupBox1.TabIndex = 14;
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
            // frmListofSpareVehicleCurrently
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1028, 500);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmListofSpareVehicleCurrently";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmListofSpareVehicleCurrently_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabAssigned.ResumeLayout(false);
            this.tabRepaired.ResumeLayout(false);
            this.tabAvailable.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		#region Private Variable
        private CompanyInfo objCompanyInfo;
		private CompanyFacade facadeCompany;
        private frmMain mdiParent;
        #endregion

        #region Constructor
        public frmListofSpareVehicleCurrently()
            : base()
        {
            InitializeComponent();
            facadeCompany = new CompanyFacade();
            this.Text = "รายงานรถ Spare";
        } 
        #endregion

        #region IMDIChildFormGUI Members

        public void InitForm()
        {
            crvRepaired.Hide();
            crvAssigned.Hide();
            crvAvailable.Hide();
            dtpFromDate.Focus();
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
                    objCompanyInfo = getCompany();

                    //1111111111111111
                    ReportDocument rdprint1 = new ReportDocument();
                    rdprint1.Load(@ApplicationProfile.REPORT_PATH + "rptListofSpareVehicleCurrentlyAssigned.rpt");
                    DataSourceConnections dataSourceConnections1 = rdprint1.DataSourceConnections;
                    IConnectionInfo iConnectionInfo1 = dataSourceConnections1[0];
                    iConnectionInfo1.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

                    rdprint1.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompanyInfo.AFullName.Thai + "'";
                    rdprint1.DataDefinition.ParameterFields["@FromDate"].ApplyCurrentValues(CrytalParameterValue(dtpFromDate.Value.Date));
                    rdprint1.DataDefinition.ParameterFields["@ToDate"].ApplyCurrentValues(CrytalParameterValue(dtpToDate.Value.Date));

                    crvAssigned.ReportSource = rdprint1;

                    //22222222222222
                    ReportDocument rdprint2 = new ReportDocument();

                    rdprint2.Load(@ApplicationProfile.REPORT_PATH + "rptListofSpareVehicleCurrentlyRepaired.rpt");

                    DataSourceConnections dataSourceConnections2 = rdprint2.DataSourceConnections;
                    IConnectionInfo iConnectionInfo2 = dataSourceConnections2[0];
                    iConnectionInfo2.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

                    rdprint2.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompanyInfo.AFullName.Thai + "'";
                    rdprint2.DataDefinition.ParameterFields["@FromDate"].ApplyCurrentValues(CrytalParameterValue(dtpFromDate.Value.Date));
                    rdprint2.DataDefinition.ParameterFields["@ToDate"].ApplyCurrentValues(CrytalParameterValue(dtpToDate.Value.Date));

                    crvRepaired.ReportSource = rdprint2;

                    //33333333333333
                    ReportDocument rdprint3 = new ReportDocument();

                    rdprint3.Load(@ApplicationProfile.REPORT_PATH + "rptListofSpareVehicleCurrentlyAvailable.rpt");

                    DataSourceConnections dataSourceConnections3 = rdprint3.DataSourceConnections;
                    IConnectionInfo iConnectionInfo3 = dataSourceConnections3[0];
                    iConnectionInfo3.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

                    rdprint3.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompanyInfo.AFullName.Thai + "'";
                    rdprint3.DataDefinition.ParameterFields["@FromDate"].ApplyCurrentValues(CrytalParameterValue(dtpFromDate.Value.Date));
                    rdprint3.DataDefinition.ParameterFields["@ToDate"].ApplyCurrentValues(CrytalParameterValue(dtpToDate.Value.Date));

                    crvAvailable.ReportSource = rdprint3;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
            }
        }

        private CompanyInfo getCompany()
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
        private void frmListofSpareVehicleCurrently_Load(object sender, System.EventArgs e)
        {
            mdiParent = (frmMain)this.MdiParent;
            InitForm();            
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            ReportDatabaseLogon();
            crvRepaired.Show();
            crvAssigned.Show();
            crvAvailable.Show();         
            this.crvAssigned.DisplayToolbar = true;
            this.crvAvailable.DisplayToolbar = true;
            this.crvRepaired.DisplayToolbar = true;
            this.Cursor = System.Windows.Forms.Cursors.Default;
        } 
        #endregion        
    }
}
