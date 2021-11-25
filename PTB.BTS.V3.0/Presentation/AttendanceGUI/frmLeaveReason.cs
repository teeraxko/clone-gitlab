using System;

using Facade.AttendanceFacade;

using Presentation.CommonGUI;

using SystemFramework.AppConfig;

namespace Presentation.AttendanceGUI
{
	public class frmLeaveReason : SingleFieldGUIMainBase
	{
		public frmLeaveReason() : base()
		{
			frmEntry = new frmLeaveReasonEntry(this);
			facadeMTB = new LeaveReasonFacade();
            title = UserProfile.GetFormName("miAttendance", "miLeaveReason");
			columnName = "เหตุผลในการลา";
			isReadonly = UserProfile.IsReadOnly("miAttendance", "miLeaveReason");
		}

		public override void PrintForm()
		{
			frmLeaveReason objfrm = new frmLeaveReason();
			objfrm.Show();
		}

        public override string FormID()
        {
            return UserProfile.GetFormID("miAttendance", "miLeaveReason");
        }

        public override int MasterCount()
        {
            return base.MasterCount();
        }
	}
}
