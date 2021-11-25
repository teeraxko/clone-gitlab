using System;

using Entity.CommonEntity;
using Entity.AttendanceEntities;

using Presentation.PiGUI;
using Presentation.CommonGUI;

using ictus.Common.Entity.General;

namespace Presentation.AttendanceGUI
{
	public class frmTraditionalHolidayPatternEntry : DualFieldCompanyGUIEntryBase
	{
		public frmTraditionalHolidayPatternEntry(DualFieldCompanyGUIMainBase parentForm): base(parentForm)
		{
			title = "�ѹ��ش�ѡ�ѵġ��";
			lable1 = "�����ٻẺ�ѹ��ش�ѡ�ѵġ��";
			lable2 = "�����ٻẺ�ѹ��ش�ѡ�ѵġ�� (������)";
			lable3 = "�����ٻẺ�ѹ��ش�ѡ�ѵġ�� (�����ѧ���)";
			txtCode.MaxLength = 2;
		}

		protected override DualFieldBase getNew()
		{
			return new TraditionalHolidayPattern();
		}
	}
}
