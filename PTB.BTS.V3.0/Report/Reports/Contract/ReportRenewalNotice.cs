using System;
using System.Collections.Generic;
using System.Text;

namespace Report.Reports.Contract
{
    public class ReportRenewalNotice : ReportBase
    {
        #region Private Variable
        private string tempContractNo;
        private DateTime tempContractEndDate;
        private string tempTISAuthorize;
        private string selection; 
        #endregion

        #region Constructor
        public ReportRenewalNotice()
            : base()
        {
            this.ReportFileName = "rptRenewalNotice.rpt";
            this.InitialReport();
        } 
        #endregion

        #region Public Method
        public void SetCriteria(DateTime endDate, string contract, string tisAuthorize)
        {
            tempContractEndDate = endDate;
            tempContractNo = contract;

            if (tempContractNo != "")
            {
                selection = "year({Contract.Contract_End_Date}) = year({?@pContractEndDate}) and month({Contract.Contract_End_Date}) = month({?@pContractEndDate})and {Contract.Contract_No} in [" + tempContractNo + "]";
            }
            else
            {
                selection = "year({Contract.Contract_End_Date}) = year({?@pContractEndDate}) and month({Contract.Contract_End_Date}) = month({?@pContractEndDate})and {Contract.Contract_No} = ''";
            }

            tempTISAuthorize = tisAuthorize;
            this.setFormulars();
        } 
        #endregion

        #region Private Method
        private void setFormulars()
        {
            this.SetReportParameterField("@pContractEndDate", tempContractEndDate);
            this.SetReportParameterField("@pTISAuthorizePerson", tempTISAuthorize);

            this.SetRecordSelectionFormula(selection);
        } 
        #endregion
    }
}
