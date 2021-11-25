using System;

using Facade.VehicleFacade;

using Presentation.CommonGUI;

using SystemFramework.AppConfig;
namespace Presentation.VehicleGUI
{
	public class frmPoliceStation : SingleFieldGUIMainBase
	{
		public frmPoliceStation()
		{
			frmEntry = new frmPoliceStationEntry(this);
			facadeMTB = new PoliceStationFacade();
            title = UserProfile.GetFormName("miVehicle", "miVehicleSettingPoliceStation");
			columnName = "ʶҹյ��Ǩ";
			isReadonly = UserProfile.IsReadOnly("miVehicle", "miVehicleSettingPoliceStation");
		}

        public override string FormID()
        {
            return UserProfile.GetFormID("miVehicle", "miVehicleSettingPoliceStation");
        }

        public override int MasterCount()
        {
            return base.MasterCount();
        }
	}
}
