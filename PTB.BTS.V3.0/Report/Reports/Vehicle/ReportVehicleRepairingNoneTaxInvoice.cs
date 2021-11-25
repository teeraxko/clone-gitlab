using System;
using System.Collections.Generic;
using System.Text;

namespace Report.Reports.Vehicle
{
    public class ReportVehicleRepairingNoneTaxInvoice : ReportBase
    {
        public ReportVehicleRepairingNoneTaxInvoice()
            : base()
        {
            this.ReportFileName = "rptRepairingHistoryNoneTaxInvoice.rpt";
            this.InitialReport();
        }

    }
}
