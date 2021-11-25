using System;
using System.Collections.Generic;
using System.Text;
using Report.Reports;
using Report;

namespace PTB.PIS.Welfare.ReportApp.Reports.ReportsMedicalAid
{
    public class ReportMedicalAidAtt : ReportBase
    {
        private DateTime criteriaFromDate;

        public ReportMedicalAidAtt()
            : base()
        {
            this.reportFileName = "rptMedicalAidAppAtt.rpt";
            this.InitialReport();
        }

        public void SetCriteria(DateTime fromDate)
        {

            // set criteria
            this.criteriaFromDate = fromDate;
            this.SetFormulars();
            this.SetParameters();
        }

        private void SetFormulars()
        {
            this.SetReportFormularField("CompName", "'" + Common.GetCompanyInfo().AFullName.Thai + "'");
        }

        private void SetParameters()
        {
            this.SetReportParameterField("FromDate", criteriaFromDate);
        }
    }
}
