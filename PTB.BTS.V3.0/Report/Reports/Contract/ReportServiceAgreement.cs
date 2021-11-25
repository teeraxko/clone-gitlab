using System;
using System.Collections.Generic;
using System.Text;

namespace Report.Reports.Contract {
    public class ReportServiceAgreement : ReportBase {
        private int dayPeriodType;
        private int commonCount;
        private int familyCount;
        private decimal commonRate;
        private decimal familyRate;

        public void SetCriteria(int forYear , int dayPeriodType, int commonCount, int familyCount, decimal commonRate, decimal familyRate) {
            this.reportFileName = "rptServiceAgreementOfDriverForTIS.rpt";
            this.InitialReport();
            // set criteria
            this.dayPeriodType = dayPeriodType;
            this.commonCount = commonCount;
            this.familyCount = familyCount;
            this.commonRate = commonRate;
            this.familyRate = familyRate;
            this.SetFormulars();
        }

        private void SetFormulars() {
            this.SetReportFormularField("datePeriod", dayPeriodType.ToString());
            this.SetReportFormularField("commonDriversCount", commonCount.ToString());
            this.SetReportFormularField("familyDriversCount", familyCount.ToString());
            this.SetReportFormularField("commonDriverRate", commonRate.ToString());
            this.SetReportFormularField("familyDriverRate", familyRate.ToString());
        }
    }
}
