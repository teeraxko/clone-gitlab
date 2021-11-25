using System;
using System.Collections.Generic;
using System.Text;

namespace Report.Reports.PI {
    public class ReportProbationEmployee : ReportSpecifyMonthBase {
        public ReportProbationEmployee()
            : base() {
            this.reportFileName = "rptProbationEmployee.rpt";
            this.InitialReport();
        }
    }
}
