using System;

using Entity.VehicleEntities;
using Entity.CommonEntity;

using Presentation.CommonGUI;

using SystemFramework.AppConfig;

namespace Presentation.VehicleGUI
{
	public class frmColorEntry : DualFieldGUIEntryBase
	{
		public frmColorEntry(DualFieldGUIMainBase parentForm): base(parentForm)
		{
			maxLength = 3;
			title = "สี";
			lable1 = "รหัสสี";
			lable2 = "ชื่อสี (ภาษาไทย)";
			lable3 = "ชื่อสี (ภาษาอังกฤษ)";
			isReadonly = UserProfile.IsReadOnly("miVehicle", "miVehicleVehicleColor");
		}
        protected override ictus.Common.Entity.General.DualFieldBase getNew()
		{
			return new Color();
		}
	}
}