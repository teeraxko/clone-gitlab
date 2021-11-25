using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using SystemFramework.AppConfig;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

using ictus.Common.Entity;
using ictus.PIS.PI.Entity;

using Facade.PiFacade;
using Presentation.CommonGUI;
using SystemFramework.AppMessage;

namespace Presentation.ContractGUI
{
    /// <summary>
    /// Summary description for frmListForNoAccidentReward.
    /// </summary>
    public class frmListForNoAccidentReward : ChildFormBase, IMDIChildForm
    {
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        /// 
        private System.Windows.Forms.GroupBox gpbMain;
        private System.Windows.Forms.Splitter splitter1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvPrint;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnShow;
        private DateTimePicker dtpTo;
        private DateTimePicker dtpFrom;
        private System.ComponentModel.Container components = null;

        private void InitializeComponent()
        {
            this.gpbMain = new System.Windows.Forms.GroupBox();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.btnShow = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.crvPrint = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.gpbMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbMain
            // 
            this.gpbMain.Controls.Add(this.dtpTo);
            this.gpbMain.Controls.Add(this.dtpFrom);
            this.gpbMain.Controls.Add(this.btnShow);
            this.gpbMain.Controls.Add(this.label4);
            this.gpbMain.Controls.Add(this.label3);
            this.gpbMain.Controls.Add(this.label2);
            this.gpbMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.gpbMain.Location = new System.Drawing.Point(0, 0);
            this.gpbMain.Name = "gpbMain";
            this.gpbMain.Size = new System.Drawing.Size(636, 64);
            this.gpbMain.TabIndex = 0;
            this.gpbMain.TabStop = false;
            this.gpbMain.Text = "Specific Date";
            // 
            // dtpTo
            // 
            this.dtpTo.CustomFormat = "dd/MM/yyyy";
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(192, 24);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(88, 20);
            this.dtpTo.TabIndex = 6;
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(56, 24);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(88, 20);
            this.dtpFrom.TabIndex = 5;
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(304, 22);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(75, 24);
            this.btnShow.TabIndex = 1;
            this.btnShow.Text = "ดูข้อมูล";
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(148, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "-";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(168, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "To";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "From";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 64);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(636, 3);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // crvPrint
            // 
            this.crvPrint.ActiveViewIndex = -1;
            this.crvPrint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvPrint.DisplayGroupTree = false;
            this.crvPrint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvPrint.Location = new System.Drawing.Point(0, 67);
            this.crvPrint.Name = "crvPrint";
            this.crvPrint.ShowCloseButton = false;
            this.crvPrint.ShowGroupTreeButton = false;
            this.crvPrint.ShowRefreshButton = false;
            this.crvPrint.Size = new System.Drawing.Size(636, 362);
            this.crvPrint.TabIndex = 0;
            // 
            // frmListForNoAccidentReward
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(636, 429);
            this.Controls.Add(this.crvPrint);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.gpbMain);
            this.Name = "frmListForNoAccidentReward";
            this.Text = "frmListForNoAccidentReward";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmListForNoAccidentReward_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmListForNoAccidentReward_FormClosed);
            this.gpbMain.ResumeLayout(false);
            this.gpbMain.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        #region Variable
        private frmMain mdiParent;
        private CompanyFacade facadeCompany; 
        #endregion

        #region Constructor
        public frmListForNoAccidentReward()
            : base()
        {
            InitializeComponent();
            facadeCompany = new CompanyFacade();
            this.Text = "Name List For No Accident Reward Report";
        } 
        #endregion

        #region IChildForm
        public void InitForm()
        {
            crvPrint.Hide();
            mdiParent.EnableExitCommand(true);
            mdiParent.EnableNewCommand(false);
        }

        public void RefreshForm()
        {
            crvPrint.Show();
            mdiParent.EnableNewCommand(true);
            mdiParent.EnableExitCommand(true);
        }

        public void PrintForm()
        { }

        public void ExitForm()
        {
            this.Close();
        } 
        #endregion

        #region Private Method
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

        private void ReportDatabaseLogon()
        {
            try
            {
                crvPrint.Show();

                ReportDocument rdprint1 = new ReportDocument();

                rdprint1.Load(@ApplicationProfile.REPORT_PATH + "rptNoAccidentReward.rpt");
                DataSourceConnections dataSourceConnections1 = rdprint1.DataSourceConnections;
                IConnectionInfo iConnectionInfo1 = dataSourceConnections1[0];
                iConnectionInfo1.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);


                rdprint1.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + this.getCompany().AFullName.Thai + "'";
                rdprint1.DataDefinition.ParameterFields["@fromDate"].ApplyCurrentValues(CrytalParameterValue(dtpFrom.Value.Date));
                rdprint1.DataDefinition.ParameterFields["@toDate"].ApplyCurrentValues(CrytalParameterValue(dtpTo.Value.Date));
                crvPrint.ReportSource = rdprint1;
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

        private bool ValidYear()
        {
            if (dtpFrom.Value.Date > dtpTo.Value.Date)
            {
                Message(MessageList.Error.E0011, "วันที่เริ่มต้น", "วันที่สิ้นสุด");
                dtpFrom.Focus();
                return false;
            }
            return true;
        } 
        #endregion

        #region Form Event
        private void frmListForNoAccidentReward_Load(object sender, System.EventArgs e)
        {
            mdiParent = (frmMain)this.MdiParent;
            InitForm();
        }

        private void btnShow_Click(object sender, System.EventArgs e)
        {
            if (ValidYear())
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                ReportDatabaseLogon();
                RefreshForm();
                mdiParent.EnableExitCommand(true);
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        } 
        #endregion

        private void frmListForNoAccidentReward_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseReport(crvPrint);
        }
    }
}
