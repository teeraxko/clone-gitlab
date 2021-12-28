using System;
using System.Collections.Generic;
using System.Text;

namespace Report.Reports.Contract
{
    public class ReportExpectedIncome : ReportBase
    {
        private string tempCompanyCode;


        public ReportExpectedIncome()
            : base()
        {
            this.ReportFileName = "rptExptedIncomeReport.rpt";
            this.InitialReport();
        }
        /// <summary>
        /// set value from screen to parameter
        /// </summary>
        /// <param name="companyCode"></param>
        public void SetCriteria(string companyCode)
        {
            tempCompanyCode = companyCode;
            this.setFormulars();
        }

        /// <summary>
        /// send value to parameter in report
        /// </summary>
        private void setFormulars()
        {
            this.SetReportParameterField("@CompanyCode", tempCompanyCode);
        }
    }
}
