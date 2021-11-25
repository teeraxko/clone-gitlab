using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Facade.AttendanceFacade;

using SystemFramework.AppConfig;

namespace Presentation.AttendanceGUI
{
    public class frmGenEmployeeTimeCard : Presentation.AttendanceGUI.FrmGenEmpScheduleBase
    {
        #region Designer generated code

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            // 
            // frmGenEmployeeTimeCard
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 16);
            this.ClientSize = new System.Drawing.Size(842, 566);
            this.Name = "frmGenEmployeeTimeCard";
            this.Text = "สร้างเวลาทำงานพื้นฐานประจำเดือน";
            this.Load += new System.EventHandler(this.frmGenEmployeeTimeCard_Load);

        }
        #endregion

        //This class not use : woranai

        public frmGenEmployeeTimeCard()
            : base()
        {
            InitializeComponent();
            facadeGenEmpSchedule = new GenerateEmployeeTimeCardFacade();
        }

        private void frmGenEmployeeTimeCard_Load(object sender, System.EventArgs e)
        {
            InitForm();
            isReadonly = UserProfile.IsReadOnly("miAttendance", "miAttendanceGenTimeCard");
        }
    }
}