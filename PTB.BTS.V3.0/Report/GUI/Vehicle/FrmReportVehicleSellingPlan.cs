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
    public partial class FrmReportVehicleSellingPlan : FrmReportBase 
    {
        private ReportVehicleSellingPlan report = new ReportVehicleSellingPlan();
        
        private FrmReportVehicleSellingPlan():base()
        {
            InitializeComponent();
            this.Text = "Vehicle Selling Plan";
        }

        public FrmReportVehicleSellingPlan(DateTime fromDate, DateTime toDate)
            : this()
        {
            report.SetCriteria(fromDate, toDate);
            crvMain.ReportSource = report.Report;
        }






    }
}

