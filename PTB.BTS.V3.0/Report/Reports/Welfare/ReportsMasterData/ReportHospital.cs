using System;
using System.Collections.Generic;
using System.Text;

namespace PTB.PIS.Welfare.ReportApp.Reports.ReportsMasterData {
    public class ReportHospital : ReportMasterDataBase {
        public ReportHospital() {
            this.reportFileName = "rptHospital.rpt";
            this.InitialReport();
        }
    }
}
