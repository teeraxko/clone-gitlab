using System;
using System.Collections.Generic;
using System.Text;
using Report.Reports;
using Report;

namespace PTB.PIS.Welfare.ReportApp.Reports.ReportsMedicalAid
{
    public class ReportMedicalAid : ReportBase
    {
        private DateTime criteriaFromDate;
        private DateTime criteriaToDate;
        private DateTime criteriaFromEmployDate;
        private DateTime criteriaToEmployDate;
        private string criteriaEmployeeNo = string.Empty;

        public ReportMedicalAid()
            : base()
        {
            this.reportFileName = "rptMedicalAidApp.rpt";
            this.InitialReport();
        }

        public void SetCriteria(DateTime fromDate, DateTime toDate, DateTime fromEmployDate, DateTime toEmployDate, string employeeNo)
        {
            // set criteria
            this.criteriaFromDate = fromDate;
            this.criteriaToDate = toDate;
            this.criteriaFromEmployDate = fromEmployDate.Date;
            this.criteriaToEmployDate = toEmployDate.Date;
            this.criteriaEmployeeNo = employeeNo;

            this.SetFormulars();
            this.SetParameters();
        }

        private void SetFormulars()
        {
            this.SetReportFormularField("CompName", "'" + Common.GetCompanyInfo().AFullName.Thai + "'");
        }

        private void SetParameters()
        {
            this.SetReportParameterField("FromDate", criteriaFromDate);
            this.SetReportParameterField("ToDate", criteriaToDate);
            this.SetReportParameterField("FromEmployDate", criteriaFromEmployDate);
            this.SetReportParameterField("ToEmployDate", criteriaToEmployDate);
            this.SetReportParameterField("EmployeeNo", criteriaEmployeeNo);
        }

    }
}
