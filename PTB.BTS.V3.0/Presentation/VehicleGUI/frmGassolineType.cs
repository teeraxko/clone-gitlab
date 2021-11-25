using System;

using Facade.VehicleFacade;

using Presentation.CommonGUI;

namespace Presentation.VehicleGUI
{
	public class frmGassolineType : DualFieldGUIMainBase
	{
		public frmGassolineType() : base()
		{
			frmEntry = new frmGassolineTypeEntry(this);
			facadeMTB = new GasolineTypeFacade();
			title = "ข้อมูลเชื้อเพลิง";
			columnCode = "รหัสเชื้อเพลิง";
			columnTHName = "ชื่อเชื้อเพลิง (ภาษาไทย)";
			columnENName = "ชื่อเชื้อเพลิง (ภาษาอังกฤษ)";
		}
	}
}