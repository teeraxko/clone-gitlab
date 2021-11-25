using System;

using Facade.VehicleFacade;

using Presentation.CommonGUI;

using SystemFramework.AppConfig;

namespace Presentation.VehicleGUI
{
	public class frmPlace : SingleFieldGUIMainBase
	{
		public frmPlace()
		{
			frmEntry = new frmPlaceEntry(this);
			facadeMTB = new PlaceFacade();
            title = UserProfile.GetFormName("miVehicle", "miVehicleSettingAccidentPlace");
			columnName = "สถานที่";
			isReadonly = UserProfile.IsReadOnly("miVehicle", "miVehicleSettingAccidentPlace");

		}

        public override string FormID()
        {
            return UserProfile.GetFormID("miVehicle", "miVehicleSettingAccidentPlace");
        }

        public override int MasterCount()
        {
            return base.MasterCount();
        }
	}
}
