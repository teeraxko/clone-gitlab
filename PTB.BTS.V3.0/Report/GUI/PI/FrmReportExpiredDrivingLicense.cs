using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Report.GUI.PI {
    public partial class FrmReportExpiredDrivingLicense : Report.GUI.FrmSpecifyMonthBase {
        public FrmReportExpiredDrivingLicense():base() {
            InitializeComponent();
            this.report = new Reports.PI.ReportExpiredDrivingLicense(); 
        }
    }
}

