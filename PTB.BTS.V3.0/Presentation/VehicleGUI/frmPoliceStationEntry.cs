using System;

using Entity.VehicleEntities;
using Entity.CommonEntity;

using Presentation.CommonGUI;

using SystemFramework.AppConfig;
namespace Presentation.VehicleGUI
{
	public class frmPoliceStationEntry : SingleFieldGUIEntryBase
	{
		public frmPoliceStationEntry(SingleFieldGUIMainBase parentForm): base(parentForm)
		{
			title = "สถานีตำรวจ";
			lable = "ชื่อสถานีตำรวจ";
			Maxlength = 50;
			isReadonly = UserProfile.IsReadOnly("miVehicle", "miVehicleSettingPoliceStation");

		}
        protected override ictus.Common.Entity.General.SingleFieldBase getNew()
		{
			return new PoliceStation();
		}
	}
}
