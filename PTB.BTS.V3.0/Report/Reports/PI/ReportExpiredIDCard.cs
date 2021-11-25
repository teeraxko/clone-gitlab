using System;
using System.Collections.Generic;
using System.Text;

namespace Report.Reports.PI
{
    public class ReportExpiredIDCard : ReportSpecifyMonthBase
    {
        public ReportExpiredIDCard()
            : base() {
            this.reportFileName = "rptExpiredIDCard.rpt";
            this.InitialReport();
    }
    }
}
