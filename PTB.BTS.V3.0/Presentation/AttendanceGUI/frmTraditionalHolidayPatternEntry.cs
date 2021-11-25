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
			title = "วันหยุดนักขัตฤกษ์";
			lable1 = "รหัสรูปแบบวันหยุดนักขัตฤกษ์";
			lable2 = "ชื่อรูปแบบวันหยุดนักขัตฤกษ์ (ภาษาไทย)";
			lable3 = "ชื่อรูปแบบวันหยุดนักขัตฤกษ์ (ภาษาอังกฤษ)";
			txtCode.MaxLength = 2;
		}

		protected override DualFieldBase getNew()
		{
			return new TraditionalHolidayPattern();
		}
	}
}
