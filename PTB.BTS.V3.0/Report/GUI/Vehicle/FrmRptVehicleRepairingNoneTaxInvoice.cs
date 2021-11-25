using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Report.Reports.Vehicle;

namespace Report.GUI.Vehicle
{
    public partial class FrmRptVehicleRepairingNoneTaxInvoice : FrmReportBase 
    {
        private ReportVehicleRepairingNoneTaxInvoice _report = new ReportVehicleRepairingNoneTaxInvoice();

        public FrmRptVehicleRepairingNoneTaxInvoice()
            : base()
        {
            InitializeComponent();
            crvMain.ReportSource = _report.Report;
        }
    }
}