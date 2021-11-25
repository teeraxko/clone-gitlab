using System;
using System.Collections.Generic;
using System.Text;

namespace Report.Reports.Vehicle {
    public abstract class ReportAvgMaintenanceCustBase : ReportBase  {
        private string customerCode;
        private string brandCode;
        private string modelCode;

        public void SetCriteria(string customerCode, string brandCode, string modelCode, string contractType, int month, int year) {
            
            // set criteria
            this.InitialReport();
            this.customerCode = customerCode;
            this.brandCode = brandCode;
            this.modelCode = modelCode;
            this.SetFormulars();
            string selectionFormula = string.Empty;

            selectionFormula = "month({VStartVehicleContract.StartDate}) = " + month.ToString() + " AND year({VStartVehicleContract.StartDate}) = " + year.ToString() + "";


            if (customerCode != "XXXXXX") {
                if (selectionFormula.Trim().Length > 0) selectionFormula += " AND ";
                selectionFormula += "{Customer.Customer_Code}='" + customerCode + "'";
            }

            if (brandCode != "ZZ") {
                if (selectionFormula.Trim().Length > 0) selectionFormula += " AND ";
                selectionFormula += "{Brand.Brand_Code}='" + brandCode + "'";
            }

            if (modelCode != "ZZZZZ") {
                if (selectionFormula.Trim().Length > 0) selectionFormula += " AND ";
                selectionFormula += "{Model.Model_Code} = '" + modelCode + "'";
            }
            //{SVehicleMaintenanceByCustomer;1.Month1}

            if (contractType == "==ALL==") {
            } else if (contractType == "3") {
                if (selectionFormula.Trim().Length > 0) selectionFormula += " AND ";
                selectionFormula += "{SVehicleMaintenanceByCustomer;1.Month4} = 0  AND {SVehicleMaintenanceByCustomer;1.Month5} = 0 ";
            } else if (contractType == "4") {
                if (selectionFormula.Trim().Length > 0) selectionFormula += " AND ";
                selectionFormula += "{SVehicleMaintenanceByCustomer;1.Month4} > 0  AND {SVehicleMaintenanceByCustomer;1.Month5} = 0 ";
            } else if (contractType == "3") {
                if (selectionFormula.Trim().Length > 0) selectionFormula += " AND ";
                selectionFormula += "{SVehicleMaintenanceByCustomer;1.Month4} > 0  AND {SVehicleMaintenanceByCustomer;1.Month5} > 0 ";
            }

            this.SetRecordSelectionFormula(selectionFormula);

        }

        private void SetFormulars() {
            this.SetReportFormularField("CompName", "'" + Common.GetCompanyInfo().AFullName.Thai + "'");
        }


    }
}
