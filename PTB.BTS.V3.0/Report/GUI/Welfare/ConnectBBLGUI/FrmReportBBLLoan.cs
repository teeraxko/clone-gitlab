using System;
using System.Collections.Generic;
using System.Text;
using PTB.PIS.Welfare.ReportApp.Reports.ReportConnectBBL;

namespace PTB.PIS.Welfare.ReportApp.GUI.ConnectBBLGUI {
    public class FrmReportBBLLoan :FrmReportBBLBase {
        public FrmReportBBLLoan(DateTime paymentDateTime)
            : base() {
            this.Text = "";
            this.reportConnectBBLBase = new ReportConnectBBLLoan(paymentDateTime);
        }
    }
}
