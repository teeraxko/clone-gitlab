using System;
using System.Collections.Generic;
using System.Text;

namespace Report.Reports.Vehicle
{
    public class ReportVehicleSellingPlan : ReportBase 
    {
        private DateTime tempFromDate;
        private DateTime tempToDate;

        public ReportVehicleSellingPlan():base()
        {
            this.ReportFileName = "rptVehicleSellingPlan.rpt";
            this.InitialReport();
        }

        public void SetCriteria(DateTime fromDate, DateTime toDate)
        {
            this.SetFormulars();
        }

        private void SetFormulars()
        {
            //FOR BEN NA JA

            this.SetReportFormularField("CompName", "'" + Common.GetCompanyInfo().AFullName.Thai + "'");

            this.SetReportParameterField("StartDate", tempFromDate.Date);
            this.SetReportParameterField("EndDate", tempToDate.Date);

        }

    }
}
