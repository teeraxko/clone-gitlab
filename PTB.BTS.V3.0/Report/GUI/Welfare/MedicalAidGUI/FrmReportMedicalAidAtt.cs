using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PTB.PIS.Welfare.ReportApp.Reports.ReportsMedicalAid;

namespace PTB.PIS.Welfare.ReportApp.GUI.MedicalAidGUI {
    public partial class FrmReportMedicalAidAtt : FrmReportBase {
        public FrmReportMedicalAidAtt():base() {
            InitializeComponent();

            this.dtpDateFrom.Value = DateTime.Now.Date;

        }

        private void btnRetiveData_Click(object sender, EventArgs e) {
            ReportMedicalAidAtt report = new ReportMedicalAidAtt();
            report.SetCriteria(Report.Common.EndMonthDate(this.dtpDateFrom.Value.Date));
            Application.DoEvents();
            this.crvMain.ReportSource = report.Report;

        }
    }
}