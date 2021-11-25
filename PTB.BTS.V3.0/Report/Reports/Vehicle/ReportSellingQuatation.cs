using System;
using System.Collections.Generic;
using System.Text;

namespace Report.Reports.Vehicle
{
    public class ReportSellingQuatation : ReportBase
    {
        private DateTime _bVDate;

        public ReportSellingQuatation()
            : base()
        {
            this.ReportFileName = "rptSellingQuatation.rpt";
            this.InitialReport();
        }

        public void SetCriteria(DateTime bVDate)
        {
            _bVDate = bVDate;
            this.setFormulars();
        }

        private void setFormulars()
        {
            this.SetReportParameterField("@BVDate", _bVDate);
        }
    }
}
