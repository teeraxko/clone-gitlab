using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Report.Reports.PI;

namespace Report.GUI.PI
{
    public partial class FrmReportProvidentFund : FrmReportBase
    {
        private ReportProvidentFund report;

        public FrmReportProvidentFund()
        {
            InitializeComponent();
            dtpFrom.Value = DateTime.Today;
            dtpTo.Value = DateTime.Today;
            report = new ReportProvidentFund();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            report.SetCriteria(dtpFrom.Value.Date, dtpTo.Value.Date);
            Application.DoEvents();
            this.crvMain.ReportSource = report.Report;
            this.Cursor = Cursors.Default; 
        }
    }
}
