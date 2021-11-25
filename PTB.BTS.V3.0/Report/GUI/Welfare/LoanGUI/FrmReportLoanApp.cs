using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PTB.PIS.Welfare.ReportApp.Reports.ReportsLoan;

namespace PTB.PIS.Welfare.ReportApp.GUI.LoanGUI {
    public partial class FrmReportLoanApp : FrmReportBase {
        public FrmReportLoanApp() :base(){
            InitializeComponent();

            this.dtpDateFrom.Value = DateTime.Now.Date;
            this.dtpDateTo.Value = DateTime.Now.Date;

            this.crvMain.DisplayToolbar = true;
            this.crvMain2.DisplayToolbar = true;

            this.Text = @"รายงานเงินกู้พนักงาน";

        }

        private void btnRetiveData_Click(object sender, EventArgs e) {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            Application.DoEvents();

            ReportLoanApp report1 = new ReportLoanApp();
            report1.SetCriteria(this.dtpDateFrom.Value.Date, this.dtpDateTo.Value.Date);
            
            ReportLoanAppGroupByReson report2 = new ReportLoanAppGroupByReson();
            report2.SetCriteria(this.dtpDateFrom.Value.Date, this.dtpDateTo.Value.Date);

            Application.DoEvents();
            this.crvMain.ReportSource = report1.Report;
            this.crvMain2.ReportSource = report2.Report;

            this.Cursor = System.Windows.Forms.Cursors.Default;
        }
    }
}