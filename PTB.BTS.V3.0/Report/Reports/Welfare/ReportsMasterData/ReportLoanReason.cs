using System;
using System.Collections.Generic;
using System.Text;

namespace PTB.PIS.Welfare.ReportApp.Reports.ReportsMasterData {
    public class ReportLoanReason : ReportMasterDataBase {
        public ReportLoanReason() {
            this.reportFileName = "rptLoanReason.rpt";
            this.InitialReport();
        }
    }
}
