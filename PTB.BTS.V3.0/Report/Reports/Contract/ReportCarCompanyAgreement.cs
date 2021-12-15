using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Report.Reports.Contract
{
    public class ReportCarCompanyAgreement : ReportBase
    {
        private string tempCompanyCode;
        private string tempCustomerCode;
        private DateTime calContractDate;

         public ReportCarCompanyAgreement()
            : base()
        {
            this.ReportFileName = "rptCompanyAgreement.rpt";
            this.InitialReport();
        }

         /// <summary>
         /// set value from screen to parameter
         /// </summary>
         /// <param name="customerCode"></param>
         /// <param name="contractYear"></param>
         /// <param name="quatationYear"></param>
         public void SetCriteria(string companyCode, string customerCode, DateTime contractDate)
         {
             tempCompanyCode = companyCode;
             tempCustomerCode = customerCode;
             calContractDate = contractDate;             

             this.setFormulars();
         }
         /// <summary>
         /// send value to parameter in report
         /// </summary>
         private void setFormulars()
         {
             this.SetReportParameterField("@pCompanyCode", tempCompanyCode);
             this.SetReportParameterField("@pCustomerCode", tempCustomerCode);
             this.SetReportParameterField("@pContractDate", calContractDate);
             
         }
    }
}
