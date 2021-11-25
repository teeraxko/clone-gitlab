using System;
using System.Collections.Generic;
using System.Text;

namespace Report.Reports.Vehicle
{
    public class ReportDiscountCar : ReportBase 
    {


        //Todsporn Modified 25/2/2020 PO. Discount
        
        
        
        private string tempPoNo;
        private string tempQuotationNo;
        private int tempYear;
        private int tempMonth;
        private string tempQuotationStatus;

        public ReportDiscountCar()
            : base()
        {
            this.ReportFileName = "rptDiscountCar.rpt";
            this.InitialReport();
        }
        /// <summary>
        /// set value from screen to parameter
        /// </summary>
        /// <param name="customerCode"></param>
        /// <param name="contractYear"></param>
        /// <param name="quatationYear"></param>
        public void SetCriteria(string PoNo, string QuotationNo, int Year , int Month)
        {
            tempPoNo = PoNo;
            tempQuotationNo = QuotationNo;

    
            tempYear = Year;
            tempMonth = Month;
            //tempQuotationStatus = QuotationStatus;



            this.setFormulars();
        }

        /// <summary>
        /// send value to parameter in report
        /// </summary>
        private void setFormulars()
        {
            //this.SetReportFormularField("@CompName", "'" + Common.GetCompanyInfo().AFullName.English + "'");
            //Create parameter
            this.SetReportParameterField("@pPoNo", tempPoNo);
            this.SetReportParameterField("@pQuotationNo", tempQuotationNo);
            this.SetReportParameterField("@pYear", tempYear);
            this.SetReportParameterField("@pMonth", tempMonth);
            //this.SetReportParameterField("@pQuotationStatus", tempQuotationStatus);
        }
    }
}
