using System;
using System.Collections.Generic;
using System.Text;

namespace Report.Reports.PI {
    public class ReportExpiredDrivingLicense : ReportSpecifyMonthBase {
        public ReportExpiredDrivingLicense()
            : base() {
            this.reportFileName = "rptExpiredDrivingLicense.rpt";
            this.InitialReport();
        }
    }
}
