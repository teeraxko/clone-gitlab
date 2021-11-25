using System;

using Facade.PiFacade;

using Presentation.CommonGUI;

namespace Presentation.PiGUI
{
	public class frmMaritalStatus : DualFieldGUIMainBase
	{
		public frmMaritalStatus()
		{
			frmEntry = new frmMaritalStatusEntry(this);
			facadeMTB = new MaritalStatusFacade();
			title = "ข้อมูลสถานภาพสมรส";
			columnCode = "รหัสสถานภาพสมรส";
			columnTHName = "ชื่อสถานภาพสมรส (ภาษาไทย)";
			columnENName = "ชื่อสถานภาพสมรส (ภาษาอังกฤษ)";
		}
	}
}