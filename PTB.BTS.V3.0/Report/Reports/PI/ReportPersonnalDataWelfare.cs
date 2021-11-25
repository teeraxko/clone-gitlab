using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Report.Reports.PI
{
    public partial class ReportPersonnalDataWelfare : ReportBase
    {
        public void SetCriteria(DateTime forDate)
        {
            this.reportFileName = "rptPersonnalDataWelfare.rpt";
            this.InitialReport();

            // set criteria begin day of from month and last day of to month
            this.SetReportParameterField("@IssueDate", forDate);
            this.SetReportFormularField("Comp_Name", "'" + Common.GetCompanyInfo().AFullName.Thai + "'");
        }
    }
}
