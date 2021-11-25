using System;

using Facade.AttendanceFacade;

using Presentation.PiGUI;
using Presentation.CommonGUI;

using SystemFramework.AppConfig;

namespace Presentation.AttendanceGUI
{
	public class frmSpecialLeave : DualFieldCompanyGUIMainBase
	{
		public frmSpecialLeave() : base()
		{
			InitializeComponent();

			frmEntry = new frmSpecialLeaveEntry(this);
			facadeMTB = new SpecialLeaveFacade();
            title = UserProfile.GetFormName("miAttendance", "miSpecialLeave");
			columnCode = "รหัส";
			columnTHName = "ชื่อการลากิจพิเศษ (ภาษาไทย)";
			columnENName = "ชื่อการลากิจพิเศษ (ภาษาอังกฤษ)";
			isReadonly = UserProfile.IsReadOnly("miAttendance", "miSpecialLeave");
		}

        public override string FormID()
        {
            return UserProfile.GetFormID("miAttendance", "miSpecialLeave");
        }

        public override int MasterCount()
        {
            return base.MasterCount();
        }

		#region Windows Form Designer generated code
		private void InitializeComponent()
		{
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(778, 240);
		}
		#endregion
	}
}
