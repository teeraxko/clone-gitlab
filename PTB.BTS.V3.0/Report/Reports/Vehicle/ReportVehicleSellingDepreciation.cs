using System;
using System.Collections.Generic;
using System.Text;

namespace Report.Reports.Vehicle
{
    public class ReportVehicleSellingDepreciation : ReportBase
    {
        private string tempVehicleNo;
        private DateTime tempBVDate;
        private string selection;

        public ReportVehicleSellingDepreciation()
            : base()
        {
            this.ReportFileName = "rptVehicleSellingDepreciation.rpt";
            this.InitialReport();
        }
        /// <summary>
        /// set value from screen to paramter
        /// </summary>
        /// <param name="bVDate"></param>
        /// <param name="vehicleNo"></param>
        public void SetCriteria(DateTime bVDate, string vehicleNo)
        {
            tempVehicleNo = vehicleNo;
            tempBVDate = bVDate;

            if (tempVehicleNo != "")
            {
                selection = "{Vehicle_Selling_Plan.BV_Date} = {?@BVDate}and totext({Vehicle.Vehicle_No},0,'') in [" + tempVehicleNo + "]";
            }
            else
            {
                selection = "{Vehicle_Selling_Plan.BV_Date} = {?@BVDate}and totext({Vehicle.Vehicle_No},0,'') = ''";
            } 
            
            this.setFormulars();
        }
        /// <summary>
        /// send value to crystal report
        /// </summary>
        private void setFormulars()
        {
            this.SetReportFormularField("@CompName", "'" + Common.GetCompanyInfo().AFullName.English + "'");
            this.SetReportParameterField("@BVDate", tempBVDate.Date);
            this.SetRecordSelectionFormula(selection);
        }
    }
}
