using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PTB.BTS.Common.Flow;
using PTB.BTS.Vehicle.Flow;
using Entity.VehicleEntities;
using Report.BLL;
using Report.Reports.Vehicle;
namespace Report.GUI.Vehicle
{
    public partial class FrmReportVehicleSellingDepreciation : FrmReportBase
    {
        ReportVehicleSellingDepreciation reportVehicle = new ReportVehicleSellingDepreciation();
        DateTime tempBVDate;
        private string tempVehicle;

        public FrmReportVehicleSellingDepreciation(DateTime bvdate , string vehicleNo)
            : base() 
        {
            InitializeComponent();

            tempBVDate = bvdate;
            tempVehicle = vehicleNo;

            PrintReport();            
        }

        private void PrintReport()
        {
            this.Cursor = Cursors.WaitCursor;
            reportVehicle.SetCriteria(tempBVDate, tempVehicle);

            this.crvReport.Visible = true;
            this.crvReport.DisplayToolbar = true;
            this.crvReport.ReportSource = reportVehicle.Report;
            this.Cursor = Cursors.Default;
        }
   
    }
}
