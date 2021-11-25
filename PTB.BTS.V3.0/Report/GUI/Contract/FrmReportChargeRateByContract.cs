using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Report.Reports.Contract;

namespace Report.GUI.Contract
{
    public partial class FrmReportChargeRateByContract : FrmNoneSpecify
    {
        private ReportChargeRateByContract report = new ReportChargeRateByContract();

        public FrmReportChargeRateByContract() : base()
        {
            InitializeComponent();
            this.Text = "Charge Rate By Contract";
            report.SetCriteria();
            this.crvMain.ReportSource = report.Report;
        }
    }
}