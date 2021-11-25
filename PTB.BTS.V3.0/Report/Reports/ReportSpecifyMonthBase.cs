using System;
using System.Collections.Generic;
using System.Text;

namespace Report.Reports {
    public abstract class ReportSpecifyMonthBase : ReportBase  {
        private DateTime criteriaInMonth;

        public void SetCriteria(DateTime inMonth) {

            // set criteria
            this.criteriaInMonth = inMonth;
            this.SetFormulars();
            this.SetParameters();
        }

        private void SetFormulars() {
            this.SetReportFormularField("CompName", "'" + Common.GetCompanyInfo().AFullName.Thai + "'");
        }

        private void SetParameters() {
            this.SetReportParameterField("inMonth", criteriaInMonth);
        }

    }
}
