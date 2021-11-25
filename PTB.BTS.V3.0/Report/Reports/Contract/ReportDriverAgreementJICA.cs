using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Report.Reports.Contract
{
    public class ReportDriverAgreementJICA : ReportBase
    {
        #region Variable
        private const string REPORT_NAME = "rptDriverAgreementJICA.rpt";
        private string tempCustomerCodeCharge;
        private string tempContractNo;
        private decimal tempCommonRate;
        private string tempWorkDayFrom;
        private string tempWorkDayTo;
        private string tempRemark;
        private string tempCustomerCodeWorkingTime;
        #endregion

        #region Constructor
        public ReportDriverAgreementJICA()
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
        public void SetCriteria(string customerCodeCharge, string contractNo, decimal commonRate, string workDayFrom, string workDayTo, string remark, string customerCodeWorkingTime)
        {
            tempCustomerCodeCharge = customerCodeCharge;
            tempContractNo = contractNo;
            tempCommonRate = commonRate;
            tempWorkDayFrom = workDayFrom;
            tempWorkDayTo = workDayTo;
            tempRemark = remark;
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
            this.SetReportParameterField("@pWorkDayFrom", tempWorkDayFrom);
            this.SetReportParameterField("@pWorkDayTo", tempWorkDayTo);
            this.SetReportParameterField("@pRemark", tempRemark);
            this.SetReportParameterField("@pCustomerCodeWorkingTime", tempCustomerCodeWorkingTime);
        }
    }
}
