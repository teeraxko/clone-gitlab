using System;

using Facade.AttendanceFacade;

using Presentation.PiGUI;
using Presentation.CommonGUI;

namespace Presentation.AttendanceGUI
{
	public class frmTraditionalHolidayPattern : DualFieldCompanyGUIMainBase
	{
		public frmTraditionalHolidayPattern()
		{
			InitializeComponent();

			frmEntry = new frmTraditionalHolidayPatternEntry(this);
			facadeMTB = new TraditionalHolidayPatternFacade();
			title = "ข้อมูลวันหยุดนักขัตฤกษ์";
			columnCode = "รหัสรูปแบบ";
			columnTHName = "ชื่อรูปแบบ (ภาษาไทย)";
			columnENName = "ชื่อรูปแบบ (ภาษาอังกฤษ)";
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
