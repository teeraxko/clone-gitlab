using System;
using System.Collections.Generic;
using System.Text;

namespace Report.Reports.Vehicle {
    public abstract class ReportAvgMaintenanceBase : ReportBase  {
        private string brandCode;
        private string modelCode;

        public void SetCriteria(string brandCode, string modelCode, string contractType) {
            // set criteria
            this.InitialReport();
            this.brandCode = brandCode;
            this.modelCode = modelCode;
            this.SetFormulars();
            string selectionFormula = string.Empty;
            if (brandCode != "ZZ") {
                selectionFormula = "{Brand.Brand_Code}='" + brandCode + "'";
            }

            if (modelCode != "ZZZZZ") {
                if (brandCode != "ZZ") selectionFormula += " AND ";
                selectionFormula += "{Model.Model_Code} = '" + modelCode + "'";
            }
            //{SVehicleMaintenance;1.Month1}

            if (contractType == "==ALL==") {
            } else if (contractType == "3") {
                if (selectionFormula.Trim().Length > 0) selectionFormula += " AND ";
                selectionFormula += "{SVehicleMaintenance;1.Month4} = 0  AND {SVehicleMaintenance;1.Month5} = 0 ";
            } else if (contractType == "4") {
                if (selectionFormula.Trim().Length > 0) selectionFormula += " AND ";
                selectionFormula += "{SVehicleMaintenance;1.Month4} > 0  AND {SVehicleMaintenance;1.Month5} = 0 ";
            } else if (contractType == "3") {
                if (selectionFormula.Trim().Length > 0) selectionFormula += " AND ";
                selectionFormula += "{SVehicleMaintenance;1.Month4} > 0  AND {SVehicleMaintenance;1.Month5} > 0 ";
            }



            this.SetRecordSelectionFormula(selectionFormula);
        }

        private void SetFormulars() {
            this.SetReportFormularField("CompName", "'" + Common.GetCompanyInfo().AFullName.Thai + "'");
        }

        private void SetParameters() {
            //this.SetReportParameterField("inMonth", criteriaInMonth);
        }

    }
}
