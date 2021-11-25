using System;

using Entity.CommonEntity;
using Entity.AttendanceEntities;

using Presentation.PiGUI;
using Presentation.CommonGUI;

using SystemFramework.AppConfig;

using ictus.Common.Entity.General;

namespace Presentation.AttendanceGUI
{
	public class frmSpecialLeaveEntry : DualFieldCompanyGUIEntryBase
	{
		public frmSpecialLeaveEntry(DualFieldCompanyGUIMainBase parentForm): base(parentForm)
		{
			maxLength = 2;
			title = "การลากิจพิเศษ";
			lable1 = "รหัสการลากิจพิเศษ";
			lable2 = "ชื่อการลากิจพิเศษ (ภาษาไทย)";
			lable3 = "ชื่อการลากิจพิเศษ (ภาษาอังกฤษ)";
			isReadonly = UserProfile.IsReadOnly("miAttendance", "miSpecialLeave");
		}

		protected override DualFieldBase getNew()
		{
			return new KindOfSpecialLeave();
		}
	}
}
