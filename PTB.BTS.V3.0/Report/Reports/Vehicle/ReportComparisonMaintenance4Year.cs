using System;
using System.Collections.Generic;
using System.Text;

namespace Report.Reports.Vehicle
{
    public class ReportComparisonMaintenance4Year: ReportBase
    {
        private string tempCustomerCode;
        private string tempBrandCode;
        private int tempRegistYear;

        public ReportComparisonMaintenance4Year()
            : base()
        {
            this.ReportFileName = "rptComparisonMaintenance4Year.rpt";
            this.InitialReport();
        }

        public void SetCriteria(string customerCode, string brandCode, int registYear)
        {
            tempCustomerCode = customerCode;
            tempBrandCode = brandCode;
            tempRegistYear = registYear;

            this.setFormulars();
        }
        /// <summary>
        /// send value to parameter in report
        /// </summary>
        private void setFormulars()
        {
            this.SetReportFormularField("@CompName", "'" + Common.GetCompanyInfo().AFullName.English + "'");

            this.SetReportParameterField("@pCustomer", tempCustomerCode);
            this.SetReportParameterField("@pBrand", tempBrandCode);
            this.SetReportParameterField("@RegistYear", tempRegistYear);
        }
    }
}
