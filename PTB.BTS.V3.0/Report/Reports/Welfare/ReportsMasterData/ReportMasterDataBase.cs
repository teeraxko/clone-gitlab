using System;
using System.Collections.Generic;
using System.Text;
using Report.Reports;
using Report;

namespace PTB.PIS.Welfare.ReportApp.Reports.ReportsMasterData {
    public class ReportMasterDataBase : ReportBase {

        protected override void InitialReport() {
            base.InitialReport();
            this.SetFormulars();
        }

        private void SetFormulars() {
            this.SetReportFormularField("CompName", "'" + Common.GetCompanyInfo().AFullName.Thai + "'");
        }
    }
}
