using System;
using System.Collections.Generic;
using System.Text;

namespace Report.Reports.PI {
    public class ReportSalaryEmployee :ReportBase {
        public ReportSalaryEmployee()
            : base() {
            this.reportFileName = "rptSalaryEmployee.rpt";
//            this.InitialReport();
        }
        public void SetCriteria(string selectingFormula) {
            this.InitialReport();
            this.AppendRecordSelectionFormula(selectingFormula);
            this.SetFormulars();
        }

        private void SetFormulars() {
            this.SetReportFormularField("CompName", "'" + Common.GetCompanyInfo().AFullName.Thai + "'");
        }



    }
}
