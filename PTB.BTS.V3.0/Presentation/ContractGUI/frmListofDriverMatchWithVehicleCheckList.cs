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
	public class frmListofDriverMatchWithVehicleCheckList : ChildFormBase, IMDIChildForm
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

		private CrystalDecisions.Windows.Forms.CrystalReportViewer crvReport;
        private GroupBox groupBox1;
        private Label label2;
        private DateTimePicker dtpToDate;
        private Button btnShow;
        private DateTimePicker dtpFromDate;
        private Label label1;

		#region Windows Form Designer generated code

		private System.ComponentModel.Container components = null;


		private void InitializeComponent()
		{
            this.crvReport = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.btnShow = new System.Windows.Forms.Button();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
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
            this.crvReport.Location = new System.Drawing.Point(0, 64);
            this.crvReport.Name = "crvReport";
            this.crvReport.ShowCloseButton = false;
            this.crvReport.ShowGroupTreeButton = false;
            this.crvReport.Size = new System.Drawing.Size(689, 295);
            this.crvReport.TabIndex = 0;
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
            this.groupBox1.Size = new System.Drawing.Size(689, 56);
            this.groupBox1.TabIndex = 6;
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
            // frmListofDriverMatchWithVehicleCheckList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(689, 357);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.crvReport);
            this.Name = "frmListofDriverMatchWithVehicleCheckList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmListofDriverMatchWithVehicleCheckList_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmListofDriverMatchWithVehicleCheckList_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		#region Private Variable
		private CompanyInfo objCompany;
		private CompanyFacade facadeCompany;
        private frmMain mdiParent;
        #endregion

		public frmListofDriverMatchWithVehicleCheckList()
            : base()
		{
			InitializeComponent();
			facadeCompany = new CompanyFacade();
			this.Text = "รายงานการจ่ายงานให้คนขับรถตามเลขที่สัญญา";
		}

        #region IMDIChildFormGUI Members

        public void InitForm()
        {
            crvReport.Hide();
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
                if (validateDate())
                {
                    objCompany = getCompany();
                    ReportDocument rdprint1 = new ReportDocument();

                    rdprint1.Load(@ApplicationProfile.REPORT_PATH + "rptDriverMatchWithVehicleCheckList.rpt");
                    DataSourceConnections dataSourceConnections1 = rdprint1.DataSourceConnections;
                    IConnectionInfo iConnectionInfo1 = dataSourceConnections1[0];
                    iConnectionInfo1.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

                    rdprint1.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.Thai + "'";
                    rdprint1.DataDefinition.ParameterFields["@Company_Code"].ApplyCurrentValues(CrytalParameterValue(objCompany.CompanyCode));
                    rdprint1.DataDefinition.ParameterFields["@FromDate"].ApplyCurrentValues(CrytalParameterValue(dtpFromDate.Value.Date));
                    rdprint1.DataDefinition.ParameterFields["@ToDate"].ApplyCurrentValues(CrytalParameterValue(dtpToDate.Value.Date));
                    rdprint1.DataDefinition.ParameterFields["@Employee_No"].ApplyCurrentValues(CrytalParameterValue(string.Empty));

                    crvReport.ReportSource = rdprint1;
                }
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

		private void frmListofDriverMatchWithVehicleCheckList_Load(object sender, System.EventArgs e)
		{
            mdiParent = (frmMain)this.MdiParent;
            InitForm(); 			
		}

        private void btnShow_Click(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            ReportDatabaseLogon();
            crvReport.Show();
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void frmListofDriverMatchWithVehicleCheckList_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseReport(crvReport);
        }
    }
}
