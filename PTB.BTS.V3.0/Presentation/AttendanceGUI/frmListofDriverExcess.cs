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

namespace Presentation.AttendanceGUI
{
    public class frmListofDriverExcess : ChildFormBase, IMDIChildForm
    {
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cmdShow;
        private System.Windows.Forms.Label label1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvDriverExcess;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.ComponentModel.Container components = null;

        private void InitializeComponent()
        {
            this.crvDriverExcess = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdShow = new System.Windows.Forms.Button();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // crvDriverExcess
            // 
            this.crvDriverExcess.ActiveViewIndex = -1;
            this.crvDriverExcess.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.crvDriverExcess.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvDriverExcess.DisplayGroupTree = false;
            this.crvDriverExcess.Location = new System.Drawing.Point(24, 72);
            this.crvDriverExcess.Name = "crvDriverExcess";
            this.crvDriverExcess.ShowCloseButton = false;
            this.crvDriverExcess.ShowGroupTreeButton = false;
            this.crvDriverExcess.Size = new System.Drawing.Size(976, 592);
            this.crvDriverExcess.TabIndex = 14;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.cmdShow);
            this.groupBox1.Controls.Add(this.dtpDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(24, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(976, 64);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // cmdShow
            // 
            this.cmdShow.Location = new System.Drawing.Point(152, 26);
            this.cmdShow.Name = "cmdShow";
            this.cmdShow.Size = new System.Drawing.Size(80, 24);
            this.cmdShow.TabIndex = 10;
            this.cmdShow.Text = "ดูรายงาน";
            this.cmdShow.Click += new System.EventHandler(this.cmdShow_Click);
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "yyyy";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(72, 28);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.ShowUpDown = true;
            this.dtpDate.Size = new System.Drawing.Size(64, 20);
            this.dtpDate.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "สำหรับปี";
            // 
            // frmListofDriverExcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1028, 678);
            this.Controls.Add(this.crvDriverExcess);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmListofDriverExcess";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmListofDriverExcess";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmListofDriverExcess_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmListofDriverExcess_FormClosed);
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
        public frmListofDriverExcess()
        {
            InitializeComponent();
            facadeCompany = new CompanyFacade();
            this.Text = "รายงานการหักเงินค่า Excess ของพนักงานขับรถ";
        }
        //		============================== Property ==============================
        public CompanyInfo getCompany()
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
        //		============================== Private Method ==============================
        private void ReportDatabaseLogon()
        {
            try
            {
                objCompany = getCompany();
                ReportDocument rdprint = new ReportDocument();
                string StartDate = Convert.ToString(dtpDate.Value.Year);

                rdprint.Load(@ApplicationProfile.REPORT_PATH + "rptDriverExcess.rpt");

                DataSourceConnections dataSourceConnections = rdprint.DataSourceConnections;
                IConnectionInfo iConnectionInfo = dataSourceConnections[0];
                iConnectionInfo.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

                rdprint.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + objCompany.AFullName.Thai + "'";
                rdprint.DataDefinition.FormulaFields["Year"].Text = "'" + StartDate + "'";

                crvDriverExcess.ReportSource = rdprint;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
            }
        }
        //		============================== Event ==============================
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
            crvDriverExcess.Hide();
            dtpDate.Focus();
            mdiParent.EnableExitCommand(true);
        }

        public void RefreshForm()
        {
            crvDriverExcess.Show();
            mdiParent.EnableExitCommand(true);
        }

        public void PrintForm()
        {
        }

        public void ExitForm()
        {
            this.Hide();
        }

        //		============================== Event ==============================
        private void cmdShow_Click(object sender, System.EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            ReportDatabaseLogon();
            RefreshForm();
            mdiParent.EnableExitCommand(true);
            crvDriverExcess.RefreshReport();
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void frmListofDriverExcess_Load(object sender, System.EventArgs e)
        {
            mdiParent = (frmMain)this.MdiParent;
            InitForm();
        }

        private void frmListofDriverExcess_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseReport(crvDriverExcess);
        }
    }
}
