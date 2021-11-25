using System;
using System.Collections.Generic;
using System.Text;

namespace Report.Reports.Vehicle
{
    public class ReportVehicleSelling : ReportBase
    {
        private string tempBrandCode;
        private DateTime tempFromDate;
        private DateTime tempToDate;

        public ReportVehicleSelling()
            : base()
        {
            this.ReportFileName = "rptVehicleSelling.rpt";
            this.InitialReport();
        }

        /// <summary>
        /// set value from screen to parameter
        /// </summary>
        /// <param name="customerCode"></param>
        /// <param name="contractYear"></param>
        /// <param name="quatationYear"></param>
        public void SetCriteria(string brandCode, DateTime fromDate, DateTime toDate)
        {
            tempBrandCode = brandCode;
            tempFromDate = fromDate;
            tempToDate = toDate;

            this.setFormulars();
        }

        /// <summary>
        /// send value to parameter in report
        /// </summary>
        private void setFormulars()
        {
            this.SetReportFormularField("@CompName", "'" + Common.GetCompanyInfo().AFullName.English + "'");
            this.SetReportParameterField("@pBrand", tempBrandCode);
            this.SetReportParameterField("@pFromDate", tempFromDate);
            this.SetReportParameterField("@pToDate", tempToDate);

        }
    }
}
