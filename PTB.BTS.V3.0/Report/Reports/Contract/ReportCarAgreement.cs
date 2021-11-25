using System;
using System.Collections.Generic;
using System.Text;

namespace Report.Reports.Contract
{
    public class ReportCarAgreement : ReportBase
    {
        private string tempCompanyCode;
        private string tempCustomerCode;
        private string tempContractNo;
        private string tempAccessory;

        public ReportCarAgreement()
            : base()
        {
            this.ReportFileName = "rptCarAgreement.rpt";
            this.InitialReport();
        }
        /// <summary>
        /// set value from screen to parameter
        /// </summary>
        /// <param name="customerCode"></param>
        /// <param name="contractYear"></param>
        /// <param name="quatationYear"></param>
        public void SetCriteria(string companyCode, string customerCode, string contractNo, string accessory)
        {
            tempCompanyCode = companyCode;
            tempCustomerCode = customerCode;
            tempContractNo = contractNo;
            tempAccessory = accessory;

            this.setFormulars();
        }
        /// <summary>
        /// send value to parameter in report
        /// </summary>
        private void setFormulars()
        {
            this.SetReportParameterField("@pCompanyCode", tempCompanyCode);
            this.SetReportParameterField("@pCustomerCode", tempCustomerCode);
            this.SetReportParameterField("@pContractNo", tempContractNo);
            this.SetReportParameterField("@pAccessory", tempAccessory);
        }
    }
}
