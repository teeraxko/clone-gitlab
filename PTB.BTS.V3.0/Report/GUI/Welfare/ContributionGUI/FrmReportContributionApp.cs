using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PTB.PIS.Welfare.ReportApp.Reports.ReportsContribution;

namespace PTB.PIS.Welfare.ReportApp.GUI.ContributionGUI
{
    public partial class FrmReportContributionApp : PTB.PIS.Welfare.ReportApp.GUI.FrmReportBase
    {
        public FrmReportContributionApp()
            : base()
        {
            InitializeComponent();

            this.dtpDateFrom.Value = DateTime.Now.Date;
            this.dtpDateTo.Value = DateTime.Now.Date;
        }

        private void btnRetiveData_Click(object sender, EventArgs e)
        {
            ReportContributionApp reportContributionApp = new ReportContributionApp();
            reportContributionApp.SetCriteria(this.dtpDateFrom.Value.Date, this.dtpDateTo.Value.Date);
            Application.DoEvents();
            this.crvMain.ReportSource = reportContributionApp.Report;
        }
    }
}

