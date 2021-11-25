using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Report.Reports;

namespace Report.GUI {
//    public partial class FrmSpecifyMonthBase : Form  {
    public partial class FrmSpecifyMonthBase : Report.FrmReportBase {
        protected ReportSpecifyMonthBase report;
        public FrmSpecifyMonthBase():base() {
            InitializeComponent();
            this.dtpInMonth.Value = DateTime.Now.Date;
        }

        private void btnRetiveData_Click(object sender, EventArgs e) {
            this.Cursor = Cursors.WaitCursor; 
            report.SetCriteria(this.dtpInMonth.Value);
            Application.DoEvents();
            this.crvMain.ReportSource = report.Report;
            this.Cursor = Cursors.Default; 
        }



    }
}

