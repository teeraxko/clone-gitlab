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
    public partial class FrmReportPersonnalDataWelfare : FrmReportBase
    {
        ReportPersonnalDataWelfare report;

        public FrmReportPersonnalDataWelfare()
        {
            InitializeComponent();
            this.report = new ReportPersonnalDataWelfare();
        }

        private void btnRetiveData_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Application.DoEvents();
            report.SetCriteria(dtpInMonth.Value.Date);
            this.crvMain.ReportSource = report.Report;
            this.Cursor = Cursors.Default; 
        }
    }
}
