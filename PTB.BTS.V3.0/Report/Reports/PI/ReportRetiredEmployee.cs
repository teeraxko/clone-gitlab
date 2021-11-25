using System;
using System.Collections.Generic;
using System.Text;

namespace Report.Reports.PI {
    public class ReportRetiredEmployee : ReportBase {
        private DateTime fromDate;
        private DateTime toDate;

        public ReportRetiredEmployee():base() {
            this.reportFileName = "rptRetiredEmployee.rpt";
            this.InitialReport();
        }
        public void SetCriteria(DateTime fromDate, DateTime toDate) {
            // set criteria
            this.fromDate = fromDate;
            this.toDate = toDate;
            this.SetFormulars();
            this.SetParameters();
        }

        private void SetFormulars() {
            this.SetReportFormularField("CompName", "'" + Common.GetCompanyInfo().AFullName.Thai + "'");
        }

        private void SetParameters() {
            this.SetReportParameterField("pFromDate", this.fromDate);
            this.SetReportParameterField("pToDate", this.toDate);
        }

    }
}
