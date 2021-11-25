using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Report.Reports.PI
{
    public class ReportProvidentFund : ReportBase
    {
        public void SetCriteria(DateTime fromDate, DateTime toDate)
        {
            this.reportFileName = "rptProvidentFund.rpt";
            this.InitialReport();

            // set criteria begin day of from month and last day of to month
            this.SetReportParameterField("@FromDate", fromDate.Date);
            this.SetReportParameterField("@ToDate", toDate.Date);
        }
    }
}
