using System;
using System.Collections.Generic;
using System.Text;

namespace Report.Reports.Vehicle
{
    public class ReportLeasingCar : ReportBase 
    {
        private string tempCustomerCode;
        private int tempContractYear;
        private int tempQuotationYear;

        public ReportLeasingCar()
            : base()
        {
            this.ReportFileName = "rptLeasingCar.rpt";
            this.InitialReport();
        }
        /// <summary>
        /// set value from screen to parameter
        /// </summary>
        /// <param name="customerCode"></param>
        /// <param name="contractYear"></param>
        /// <param name="quatationYear"></param>
        public void SetCriteria(string customerCode, int contractYear, int quotationYear)
        {
            tempCustomerCode = customerCode;
            tempContractYear = contractYear;
            tempQuotationYear = quotationYear;

            this.setFormulars();
        }

        /// <summary>
        /// send value to parameter in report
        /// </summary>
        private void setFormulars()
        {
            this.SetReportFormularField("@CompName", "'" + Common.GetCompanyInfo().AFullName.English + "'");

            this.SetReportParameterField("@pCustomer", tempCustomerCode);
            this.SetReportParameterField("@pYearofContract", tempContractYear);
            this.SetReportParameterField("@pYearofQuatation", tempQuotationYear);
        }
    }
}
