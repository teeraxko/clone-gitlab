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
    public partial class FrmReportContractCarLeasing : FrmReportBase {
        private ReportCarLeasingAgreement report = new ReportCarLeasingAgreement();
        public FrmReportContractCarLeasing():base() {
            InitializeComponent();
            txtContractNo.Text = string.Empty;
        }

        private void btnRetiveData_Click(object sender, EventArgs e) {
            string contractNo = "PTB-C-" + txtContractNo.Text.Trim();
            if (EntitiesProvider.CheckCarContract(contractNo)) {
                this.Cursor = Cursors.WaitCursor;
                report.SetCriteria(contractNo);
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