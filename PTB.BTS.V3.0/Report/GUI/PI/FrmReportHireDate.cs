using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Report.Reports.PI;

namespace Report.GUI.PI {
//    public partial class FrmReportHireDate : Form {
    public partial class FrmReportHireDate : Report.FrmReportBase {
        protected ReportHireDate report;
        public FrmReportHireDate()
            : base() {
            InitializeComponent();
            this.dtpFrom.Value = DateTime.Now.Date;
            this.dtpTo.Value = DateTime.Now.Date;
            this.report = new ReportHireDate();
        }

        private void btnRetiveData_Click(object sender, EventArgs e) {
            this.Cursor = Cursors.WaitCursor;
            report.SetCriteria(dtpFrom.Value.Date, dtpTo.Value.Date);
            Application.DoEvents();
            this.crvMain.ReportSource = report.Report;
            this.Cursor = Cursors.Default; 
        }

    }
}