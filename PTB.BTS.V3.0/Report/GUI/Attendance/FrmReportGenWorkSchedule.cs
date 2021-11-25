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
    public partial class FrmReportGenWorkSchedule : FrmNoneSpecify
    {
        private ReportGenWorkSchedule report = new ReportGenWorkSchedule();
        
        public FrmReportGenWorkSchedule(List<string> listEmployeeNo , DateTime dateTime) : base()
        {
            InitializeComponent();
            report.SetCriteria(listEmployeeNo, dateTime);
            this.crvMain.ReportSource = report.Report;
        }
    }
}