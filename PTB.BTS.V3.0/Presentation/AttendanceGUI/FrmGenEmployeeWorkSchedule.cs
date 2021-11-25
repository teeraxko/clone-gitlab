using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using ictus.PIS.PI.Entity;

using Facade.AttendanceFacade;

using SystemFramework.AppConfig;

namespace Presentation.AttendanceGUI
{
    public partial class FrmGenEmployeeWorkSchedule : Presentation.AttendanceGUI.FrmGenEmpScheduleBase
    {
        public FrmGenEmployeeWorkSchedule() : base()
        {
            InitializeComponent();
            facadeGenEmpSchedule = new GenerateEmployeeWorkScheduleFacade();
        }

        private void frmGenEmployeeWorkSchedule_Load(object sender, EventArgs e)
        {
            InitForm();
            this.title = UserProfile.GetFormName("miAttendance", "miGenEmployeeWorkSchedule");
            isReadonly = UserProfile.IsReadOnly("miAttendance", "miGenEmployeeWorkSchedule");
        }

        public override string FormID()
        {
            return UserProfile.GetFormID("miAttendance", "miGenEmployeeWorkSchedule");
        }
    }
}

