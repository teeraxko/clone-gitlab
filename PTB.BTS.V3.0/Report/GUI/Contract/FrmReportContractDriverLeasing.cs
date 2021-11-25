using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Report.Reports.Contract;
using Report.BLL;

namespace Report.GUI.Contract {
    public partial class FrmReportContractDriverLeasing : FrmReportBase {
        private ReportDriverLeasingAgreement report = new ReportDriverLeasingAgreement();
        public FrmReportContractDriverLeasing():base() {
            InitializeComponent();
            this.txtContractNo.Text = string.Empty;
            this.cmbWorkingDayPeriod.SelectedIndex = 0;
        }

        private void btnRetiveData_Click(object sender, EventArgs e) {
            string contractNo = "PTB-C-" + txtContractNo.Text.Trim();
            if (EntitiesProvider.CheckDriverContract(contractNo)) {
                this.Cursor = Cursors.WaitCursor;
                report.SetCriteria(contractNo,cmbWorkingDayPeriod.SelectedIndex);
                Application.DoEvents();
                this.crvMain.ReportSource = report.Report;
                this.Cursor = Cursors.Default;
            } else {
                MessageBox.Show("ข้อมูลสัญญาที่ระบุไม่ถูกต้อง", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.crvMain.ReportSource = null;
            }

        }
    }
}