using System;
using System.Collections.Generic;
using System.Text;

namespace Report.Reports.Contract
{
    public class ReportContractAttachment : ReportBase
    {
        private string tempCompanyCode;
        private string tempAttachmentNo;


        public ReportContractAttachment()
            : base()
        {
            this.ReportFileName = "rptContractAttachment.rpt";
            this.InitialReport();

        }
        /// <summary>
        /// set value from screen to parameter
        /// </summary>
        /// <param name="companyCode"></param>
        /// <param name="toDate"></param>
        /// <param name="fromDate"></param>
        /// <param name="contractType"></param>
        public void SetCriteria(string companyCode, string attachmentNo)
        {
            tempCompanyCode = companyCode;
            tempAttachmentNo = attachmentNo;

            this.setFormulars();
        }

        /// <summary>
        /// send value to parameter in report
        /// </summary>
        private void setFormulars()
        {
            this.SetReportParameterField("@CompanyCode", tempCompanyCode);
            this.SetReportParameterField("@AttachmentNo", tempAttachmentNo);
        }
    }
}
