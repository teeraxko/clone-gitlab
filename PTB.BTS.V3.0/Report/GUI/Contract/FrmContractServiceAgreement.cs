using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Report.Reports.Contract;

namespace Report.GUI.Contract {
    public partial class FrmContractServiceAgreement : FrmReportBase {
        private ReportServiceAgreement report = new ReportServiceAgreement();
        public FrmContractServiceAgreement()
            : base() {
            InitializeComponent();
            numYear.Maximum = (decimal)(DateTime.Now.Year + 2);
            numYear.Value = (decimal)DateTime.Now.Year;
            cmbWorkingDayPeriod.SelectedIndex = 0;
        }

        private void btnRetiveData_Click(object sender, EventArgs e) {
            this.Cursor = Cursors.WaitCursor;
            report.SetCriteria((int)numYear.Value, cmbWorkingDayPeriod.SelectedIndex, (int)numCommonCount.Value, (int)numFamilyCount.Value, numCommonRate.Value, numFamilyRate.Value);
            Application.DoEvents();
            this.crvMain.ReportSource = report.Report;
            this.Cursor = Cursors.Default;
        }
    }
}