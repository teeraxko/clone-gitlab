using System;

using Facade.VehicleFacade;

using Presentation.CommonGUI;

namespace Presentation.VehicleGUI
{
	public class frmModelType : DualFieldGUIMainBase
	{
		public frmModelType() : base()
		{
			frmEntry = new frmModelTypeEntry(this);
			facadeMTB = new ModelTypeFacade();
			title = "ข้อมูลประเภทรุ่นรถ";
			columnCode = "รหัสประเภทรุ่นรถ";
			columnTHName = "ชื่อประเภทรุ่นรถ (ภาษาไทย)";
			columnENName = "ชื่อประเภทรุ่นรถ (ภาษาอังกฤษ)";
		}
		public override void PrintForm()
		{
			frmListofModelType objfrm = new frmListofModelType();
			objfrm.Show();
		}
	
	}
}