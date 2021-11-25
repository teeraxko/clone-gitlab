using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Report.Reports.PI;

namespace Report.GUI.PI {
//    public partial class FrmReportRetiredEmployee : Form {
    public partial class FrmReportRetiredEmployee : FrmReportBase {
        protected ReportRetiredEmployee report;
        public FrmReportRetiredEmployee()
            : base() {
            InitializeComponent();
            this.dtpFrom.Value = DateTime.Now.Date;
            this.dtpTo.Value = DateTime.Now.Date;
            this.report = new ReportRetiredEmployee();
        }

        private void btnRetiveData_Click(object sender, EventArgs e) {
            this.Cursor = Cursors.WaitCursor;
            DateTime fromDate = new DateTime(dtpFrom.Value.Year, dtpFrom.Value.Month, 1);
            DateTime toDate = Common.EndMonthDate(dtpTo.Value.Year, dtpTo.Value.Month);
            report.SetCriteria(fromDate, toDate);
            Application.DoEvents();
            this.crvMain.ReportSource = report.Report;
            this.Cursor = Cursors.Default; 
        }

    }
}