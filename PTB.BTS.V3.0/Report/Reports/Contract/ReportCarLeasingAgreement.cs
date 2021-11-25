using System;
using System.Collections.Generic;
using System.Text;

namespace Report.Reports.Contract {
    public class ReportCarLeasingAgreement : ReportBase {
        private string contractNo;

        public void SetCriteria(string contractNo) {
            this.reportFileName = "rptContractLeasingAgreement.rpt";
            this.InitialReport();

            // set criteria
            this.contractNo = contractNo;
            this.SetFormulars();
//            this.SetParameters();


        }

        private void SetFormulars() {
            this.SetReportFormularField("CompName", "'" + Common.GetCompanyInfo().AFullName.Thai + "'");
            this.SetReportFormularField("contractNo", "'" + this.contractNo + "'");
        }

        //private void SetParameters() {
        //    this.SetReportParameterField("pFromDate", this.fromDate);
        //    this.SetReportParameterField("pToDate", this.toDate);
        //}

    }
}
