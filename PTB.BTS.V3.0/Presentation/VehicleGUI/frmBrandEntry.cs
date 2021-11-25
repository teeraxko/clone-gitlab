using System;

using Entity.VehicleEntities;
using Entity.CommonEntity;

using Presentation.CommonGUI;

using SystemFramework.AppConfig;

namespace Presentation.VehicleGUI
{
	public class frmBrandEntry : DualFieldGUIEntryBase
	{
		public frmBrandEntry(DualFieldGUIMainBase parentForm): base(parentForm)
		{
			maxLength = 2;
			title = "ยี่ห้อ";
			lable1 = "รหัสยี่ห้อ";
			lable2 = "ชื่อยี่ห้อ (ภาษาไทย)";
			lable3 = "ชื่อยี่ห้อ (ภาษาอังกฤษ)";
			isReadonly = UserProfile.IsReadOnly("miVehicle", "miVehicleVehicleBrand");

		}
        protected override ictus.Common.Entity.General.DualFieldBase getNew()
		{
			return new Brand();
		}
	}
}
