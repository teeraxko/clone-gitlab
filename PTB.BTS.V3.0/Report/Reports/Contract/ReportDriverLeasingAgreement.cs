using System;
using System.Collections.Generic;
using System.Text;

namespace Report.Reports.Contract {
    public class ReportDriverLeasingAgreement : ReportBase {
        private string contractNo;
        private int dayPeriodType;

        public void SetCriteria(string contractNo, int dayPeriodType) {
            this.reportFileName = "rptIssueDriverAgreement.rpt";
            this.InitialReport();
            // set criteria
            this.contractNo = contractNo;
            this.dayPeriodType = dayPeriodType;
            this.SetFormulars();
        }

        private void SetFormulars() {
            //this.SetReportFormularField("CompName", "'" + Common.GetCompanyInfo().AFullName.Thai + "'");
            this.SetReportFormularField("contractNo", "'" + this.contractNo + "'");
            this.SetReportFormularField("datePeriod", dayPeriodType.ToString());
        }

        //private void SetParameters() {
        //    this.SetReportParameterField("pFromDate", this.fromDate);
        //    this.SetReportParameterField("pToDate", this.toDate);
        //}

    }

}
