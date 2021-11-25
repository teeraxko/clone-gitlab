using System;

using Entity.CommonEntity;
using ictus.PIS.PI.Entity;
using Entity.AttendanceEntities;

using Presentation.CommonGUI;

using SystemFramework.AppConfig;

namespace Presentation.AttendanceGUI
{
	public class frmLeaveReasonEntry : SingleFieldGUIEntryBase
	{
		public frmLeaveReasonEntry(SingleFieldGUIMainBase parentForm): base(parentForm)
		{
			title = "เหตุผลในการลา";
			lable = "เหตุผลในการลา";
			Maxlength = 30;
			isReadonly = UserProfile.IsReadOnly("miAttendance", "miLeaveReason");
		}
        protected override ictus.Common.Entity.General.SingleFieldBase getNew()
		{
			return new LeaveReason();
		}
	}
}
