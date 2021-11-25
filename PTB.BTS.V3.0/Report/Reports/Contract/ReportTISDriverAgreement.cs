using System;
using System.Collections.Generic;
using System.Text;

namespace Report.Reports.Contract
{
    public class ReportTISDriverAgreement : ReportBase
    {
        #region Variable
        private const string REPORT_NAME = "rptTISDriverAgreement.rpt";
        private string tempCustomerCodeCharge;
        private string tempContractNo;
        private string tempCommonDriver;
        private string tempFamilyDriver;
        private decimal tempCommonRate;
        private decimal tempFamilyRate;
        private string tempWorkDayFrom;
        private string tempWorkDayTo;
        private string tempCustomerCodeWorkingTime; 
        #endregion

        #region Constructor
        public ReportTISDriverAgreement()
            : base()
        {
            this.ReportFileName = REPORT_NAME;
            this.InitialReport();
        } 
        #endregion

        /// <summary>
        /// set value from screen to parameter
        /// </summary>
        /// <param name="customerCode"></param>
        /// <param name="contractYear"></param>
        /// <param name="quatationYear"></param>
        public void SetCriteria(string customerCodeCharge, string contractNo, string commonDriver, string familyDriver, decimal commonRate, decimal familyRate, string workDayFrom, string workDayTo, string customerCodeWorkingTime)
        {
            tempCustomerCodeCharge = customerCodeCharge;
            tempContractNo = contractNo;
            tempCommonDriver = commonDriver;
            tempFamilyDriver = familyDriver;
            tempCommonRate = commonRate;
            tempFamilyRate = familyRate;
            tempWorkDayFrom = workDayFrom;
            tempWorkDayTo = workDayTo;
            tempCustomerCodeWorkingTime = customerCodeWorkingTime;

            this.setFormulars();
        }

        /// <summary>
        /// send value to parameter in report
        /// </summary>
        private void setFormulars()
        {
            this.SetReportParameterField("@pCustomerCodeCharge", tempCustomerCodeCharge);
            this.SetReportParameterField("@pContractNo", tempContractNo);
            this.SetReportParameterField("@pCommonDriver", tempCommonDriver);
            this.SetReportParameterField("@pFamilyDriver", tempFamilyDriver);
            this.SetReportParameterField("@pCommonRate", tempCommonRate);
            this.SetReportParameterField("@pFamilyRate", tempFamilyRate);
            this.SetReportParameterField("@pWorkDayFrom", tempWorkDayFrom);
            this.SetReportParameterField("@pWorkDayTo", tempWorkDayTo);
            this.SetReportParameterField("@pCustomerCodeWorkingTime", tempCustomerCodeWorkingTime);            
        }

    }
}
