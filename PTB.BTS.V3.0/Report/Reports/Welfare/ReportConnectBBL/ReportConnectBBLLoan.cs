using System;
using System.Collections.Generic;
using System.Text;

namespace PTB.PIS.Welfare.ReportApp.Reports.ReportConnectBBL {
    public class ReportConnectBBLLoan : ReportConnectBBLBase {
        public ReportConnectBBLLoan(DateTime paymentDateTime)
            : base(paymentDateTime) {
            this.reportFileName = "rptLoanBankDeposit.rpt";
            this.InitialReport();

        }
    }
}
