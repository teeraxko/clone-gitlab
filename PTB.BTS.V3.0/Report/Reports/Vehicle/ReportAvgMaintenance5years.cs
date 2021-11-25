using System;
using System.Collections.Generic;
using System.Text;

namespace Report.Reports.Vehicle {
    public class ReportAvgMaintenance5years : ReportAvgMaintenanceBase {
        public ReportAvgMaintenance5years()
            : base() {
            this.ReportFileName = "rptAvgMaintenance5Years.rpt";
        }
    }
}
