using System;
using System.Collections.Generic;
using System.Text;

namespace PTB.PIS.Welfare.ReportApp.Reports.ReportsMasterData {
    public  class ReportContribution : ReportMasterDataBase {
        public ReportContribution() {
            this.reportFileName = "rptContribution.rpt";
            this.InitialReport();
        }
    }
}
