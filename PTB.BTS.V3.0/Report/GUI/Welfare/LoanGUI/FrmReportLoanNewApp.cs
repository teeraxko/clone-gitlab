using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PTB.PIS.Welfare.ReportApp.Reports.ReportsLoan;

namespace PTB.PIS.Welfare.ReportApp.GUI.LoanGUI {
    public partial class FrmReportLoanNewApp : FrmReportBase {
        public FrmReportLoanNewApp() {
            InitializeComponent();
            this.dtpDateFrom.Value = DateTime.Now.Date;
            this.dtpDateTo.Value = DateTime.Now.Date;

        }

        private void btnRetiveData_Click(object sender, EventArgs e) {
            ReportLoanNewApp report = new ReportLoanNewApp();
            report.SetCriteria(this.dtpDateFrom.Value.Date, this.dtpDateTo.Value.Date);
            Application.DoEvents();
            this.crvMain.ReportSource = report.Report;
        }
    }
}