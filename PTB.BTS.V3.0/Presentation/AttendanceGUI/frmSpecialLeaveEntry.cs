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
			title = "����ҡԨ�����";
			lable1 = "���ʡ���ҡԨ�����";
			lable2 = "���͡���ҡԨ����� (������)";
			lable3 = "���͡���ҡԨ����� (�����ѧ���)";
			isReadonly = UserProfile.IsReadOnly("miAttendance", "miSpecialLeave");
		}

		protected override DualFieldBase getNew()
		{
			return new KindOfSpecialLeave();
		}
	}
}
