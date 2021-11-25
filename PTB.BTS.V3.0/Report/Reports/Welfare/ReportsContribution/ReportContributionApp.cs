using System;
using System.Collections.Generic;
using System.Text;
using Report.Reports;
using Report;

namespace PTB.PIS.Welfare.ReportApp.Reports.ReportsContribution {
    public class ReportContributionApp : ReportBase {

        private DateTime criteriaFromDate;
        private DateTime criteriaToDate;

        public ReportContributionApp():base() {
            this.reportFileName = "rptContributionApp.rpt";
            this.InitialReport();
        }

        public void SetCriteria(DateTime fromDate, DateTime toDate) {

            // set criteria
            this.criteriaFromDate = fromDate;
            this.criteriaToDate = toDate;

            this.SetFormulars();
            this.SetParameters();
        }

        private void SetFormulars() {
            this.SetReportFormularField("CompName", "'" + Common.GetCompanyInfo().AFullName.Thai + "'");
        }

        private void SetParameters() {
            this.SetReportParameterField("FromDate", criteriaFromDate);
            this.SetReportParameterField("ToDate", criteriaToDate);
        }


    }
}
