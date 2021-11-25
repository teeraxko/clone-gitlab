using System;
using System.Collections.Generic;
using System.Text;

namespace Report.Reports.Vehicle {
    public class ReportAvgMaintenance3years : ReportAvgMaintenanceBase {
        public ReportAvgMaintenance3years():base() {
            this.ReportFileName = "rptAvgMaintenance3Years.rpt";
        }
    }
}
