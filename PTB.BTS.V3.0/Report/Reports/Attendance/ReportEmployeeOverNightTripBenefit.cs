using System;
using System.Collections.Generic;
using System.Text;

namespace Report.Reports.Attendance
{
   public class ReportEmployeeOverNightTripBenefit : ReportSpecifyMonthBase 
    {
       public ReportEmployeeOverNightTripBenefit(): base()
        {
            this.ReportFileName = "rptEmployeeOvernightBenefit.rpt";
            this.InitialReport();
        }
       

    }
}
