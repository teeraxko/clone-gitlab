using System;
using System.Collections.Generic;
using System.Text;

namespace Report.Reports.PI
{
    public class ReportEmployeeRegist : ReportBase
    {
        public void SetCriteria()
        {
            this.reportFileName = "rptEmployeeRegist.rpt";
            this.InitialReport();      
            this.SetFormulars();
        }
        private void SetFormulars()
        {
            this.SetReportFormularField("Comp_Name", "'" + Common.GetCompanyInfo().AFullName.Thai + "'");
        }
    }
     
}
