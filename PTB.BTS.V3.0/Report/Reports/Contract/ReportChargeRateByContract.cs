using System;
using System.Collections.Generic;
using System.Text;

namespace Report.Reports.Contract
{
    public class ReportChargeRateByContract : ReportBase
    {
        public void SetCriteria()
        {
            this.reportFileName = "rptServiceStaffChargeRateByContract.rpt";
            this.InitialReport();
        }
    }
}
