using System;

using Entity.CommonEntity;
using Entity.VehicleEntities;

using Presentation.PiGUI;
using Presentation.CommonGUI;

using SystemFramework.AppConfig;

using ictus.Common.Entity.General;

namespace Presentation.VehicleGUI
{
	public class frmSparePartsEntry: DualFieldCompanyGUIEntryBase
	{
		public frmSparePartsEntry(DualFieldCompanyGUIMainBase parentForm): base(parentForm)
		{
			maxLength = 4;
			title = "อะไหล่";
			lable1 = "รหัสอะไหล่";
			lable2 = "ชื่ออะไหล่(ภาษาไทย)";
			lable3 = "ชื่ออะไหล่(ภาษาอังกฤษ)";
			isReadonly = UserProfile.IsReadOnly("miVehicle", "miVehicleMaintenanceSpareParts");
		}
		protected override DualFieldBase getNew()
		{
			return new SpareParts();
		}
		protected override void KeytxtCodeMaxLength()
		{
	       setFocusTHName();
		}
	}
}
