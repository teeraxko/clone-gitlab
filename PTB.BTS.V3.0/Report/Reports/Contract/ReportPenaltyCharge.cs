using System;
using System.Collections.Generic;
using System.Text;

namespace Report.Reports.Contract {
    public class ReportPenaltyCharge : ReportBase {
        private string brandCode;
        private string modelCode;

        public ReportPenaltyCharge()
            : base() {
            this.ReportFileName = "rptPenaltyCharge.rpt";
        }

        public void SetCriteria(string brandCode, string modelCode) {
            // set criteria
            this.InitialReport();
            this.brandCode = brandCode;
            this.modelCode = modelCode;
            this.SetFormulars();
            string selectionFormula = string.Empty;
            if (brandCode != "ZZ") {
                selectionFormula = "{VPenaltyCharge.brand_code}='" + brandCode + "'";
            }

            if (modelCode != "ZZZZZ") {
                if (brandCode != "ZZ") selectionFormula += " AND ";
                selectionFormula += "{VPenaltyCharge.model_code} = '" + modelCode + "'";
            }
            this.SetRecordSelectionFormula(selectionFormula);
        }

        private void SetFormulars() {
            this.SetReportFormularField("CompName", "'" + Common.GetCompanyInfo().AFullName.Thai + "'");
        }
    }
}
