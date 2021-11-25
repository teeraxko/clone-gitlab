using System;
using System.Collections.Generic;
using System.Text;

namespace Report.Reports.Vehicle {
    public class ReportAvgMaintenance4years : ReportAvgMaintenanceBase {
        public ReportAvgMaintenance4years()
            : base() {
            this.ReportFileName = "rptAvgMaintenance4Years.rpt";
        }
    }
}
