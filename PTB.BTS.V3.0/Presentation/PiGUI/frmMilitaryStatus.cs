using System;

using Facade.PiFacade;

using Presentation.CommonGUI;

namespace Presentation.PiGUI
{
	public class frmMilitaryStatus : DualFieldGUIMainBase
	{
		public frmMilitaryStatus()
		{
			frmEntry = new frmMilitaryStatusEntry(this);
			facadeMTB = new MilitaryStatusFacade();
			title = "ข้อมูลสถานภาพทางทหาร";
			columnCode = "รหัสสถานภาพทางทหาร";
			columnTHName = "ชื่อสถานภาพทางทหาร (ภาษาไทย)";
			columnENName = "ชื่อสถานภาพทางทหาร (ภาษาอังกฤษ)";
		}
	}
}