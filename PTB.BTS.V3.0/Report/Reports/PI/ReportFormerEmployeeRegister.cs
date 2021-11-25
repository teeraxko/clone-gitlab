using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Report.Reports.PI;

namespace Report.Reports.PI
{
    public class ReportFormerEmployeeRegist : ReportBase
    {
        public void SetCriteria()
        {
            this.reportFileName = "rptFormerEmployeeRegist.rpt";
            this.InitialReport();
            this.SetFormulars();
        }
        private void SetFormulars()
        {
            this.SetReportFormularField("Comp_Name", "'" + Common.GetCompanyInfo().AFullName.Thai + "'");
        }
    }
}
