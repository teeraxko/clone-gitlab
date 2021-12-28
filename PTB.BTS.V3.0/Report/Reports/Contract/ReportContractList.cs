using System;
using System.Collections.Generic;
using System.Text;

namespace Report.Reports.Contract
{
    public class ReportContractList : ReportBase
    {
        private string tempCompanyCode;
        private DateTime tempToDate;
        private DateTime tempFromDate;
        private string tempContractType;


        public ReportContractList()
            : base()
        {
            this.ReportFileName = "rptContractListReport.rpt";
            this.InitialReport();
        }
        /// <summary>
        /// set value from screen to parameter
        /// </summary>
        /// <param name="companyCode"></param>
        /// <param name="toDate"></param>
        /// <param name="fromDate"></param>
        /// <param name="contractType"></param>
        public void SetCriteria(string companyCode, DateTime toDate, DateTime fromDate, string contractType)
        {
            tempCompanyCode = companyCode;
            tempFromDate = toDate;
            tempToDate = fromDate;
            tempContractType = contractType;

            this.setFormulars();
        }

        /// <summary>
        /// send value to parameter in report
        /// </summary>
        private void setFormulars()
        {
            this.SetReportParameterField("@CompanyCode", tempCompanyCode);
            this.SetReportParameterField("@FromDate", tempFromDate);
            this.SetReportParameterField("@ToDate", tempToDate);
            this.SetReportParameterField("@ContractType", tempContractType);
        }
    }
}
