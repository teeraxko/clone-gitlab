using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Report.Reports.Attendance;

namespace Report.GUI.Attendance
{
    public partial class FrmReportEmployeeOverNightTripBenefit : Report.GUI.FrmSpecifyMonthBase
    {

        public FrmReportEmployeeOverNightTripBenefit()
        {
            InitializeComponent();
            this.Text = "Employee OverNight Trip Benefit";
            this.report = new Reports.Attendance.ReportEmployeeOverNightTripBenefit(); 
        }
       

    }
}

