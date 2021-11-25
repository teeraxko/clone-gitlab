using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Report.Reports.PI;

namespace Report.GUI.PI
{
    public partial class FrmReportEmployeeRegist : FrmReportBase
    {
        protected ReportEmployeeRegist report;
        protected ReportFormerEmployeeRegist report2;
        public FrmReportEmployeeRegist() : base()
        {
            InitializeComponent();
            this.report = new Reports.PI.ReportEmployeeRegist();
            this.report2 = new Reports.PI.ReportFormerEmployeeRegist();
            this.Cursor = Cursors.WaitCursor;
            report.SetCriteria();
            report2.SetCriteria();
            this.crvMain.DisplayToolbar = true;
            this.crvMain2.DisplayToolbar = true;
            this.crvMain.ReportSource = report.Report;       
            this.crvMain2.ReportSource = report2.Report;
            this.crvMain.RefreshReport();
            this.crvMain2.RefreshReport();
            this.Cursor = Cursors.Default; 
        }
    }
}