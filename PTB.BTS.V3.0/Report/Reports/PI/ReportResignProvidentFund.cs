using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Report.Reports.PI
{
    public class ReportResignProvidentFund : ReportBase
    {
        public void SetCriteria(DateTime fromDate, DateTime toDate)
        {
            this.reportFileName = "rptProvidentFundResigned.rpt";
            this.InitialReport();

            // set criteria begin day of from month and last day of to month
            this.SetReportParameterField("pFromDate", new DateTime(fromDate.Year, fromDate.Month, 1));
            this.SetReportParameterField("pToDate", new DateTime(toDate.Year, toDate.Month, DateTime.DaysInMonth(toDate.Year, toDate.Month)));
        }
    }
}
