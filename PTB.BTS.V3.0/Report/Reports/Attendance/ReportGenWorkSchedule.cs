using System;
using System.Collections.Generic;
using System.Text;
using ictus.Common.Entity.Time;

namespace Report.Reports.Attendance
{
    public class ReportGenWorkSchedule : ReportBase
    {
        public ReportGenWorkSchedule() : base()
        {
            this.ReportFileName = "rptGenWorkSchedule.rpt";
        }

        public void SetCriteria(List<string> listEmployeeNo,DateTime dateTime)
        {
            YearMonth yearMonth = new YearMonth(dateTime);

            this.InitialReport();
            string list = "";
            foreach (string employeeNo in listEmployeeNo)
            { 
                //TODO : Ben loop here.
                if (list == "")
                {
                    list = "'"+ employeeNo + "'";
                }
                else
                {
                    list = list + ",'" + employeeNo + "'";
                }
            }
            string selectionFormula = "{Employee.Employee_No} in [" + list + "]";

            this.SetReportFormularField("Year", "'" + yearMonth.Year.ToString() + "'");
            this.SetReportFormularField("Month", "'" + yearMonth.Month.ToString() + "'");
            this.SetRecordSelectionFormula(selectionFormula);


        }
    }
}
