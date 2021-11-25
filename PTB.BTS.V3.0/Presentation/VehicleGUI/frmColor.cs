using System;

using Facade.VehicleFacade;

using Presentation.CommonGUI;

using SystemFramework.AppConfig;

namespace Presentation.VehicleGUI
{
	public class frmColor : DualFieldGUIMainBase
	{
		public frmColor() : base()
		{
			frmEntry = new frmColorEntry(this);
			facadeMTB = new ColorFacade();
            title = UserProfile.GetFormName("miVehicle", "miVehicleVehicleColor");
			columnCode = "รหัสสี";
			columnTHName = "ชื่อสี (ภาษาไทย)";
			columnENName = "ชื่อสี (ภาษาอังกฤษ)";
			isReadonly = UserProfile.IsReadOnly("miVehicle", "miVehicleVehicleColor");
		}
		public override void PrintForm()
		{
			frmListofColor objfrm = new frmListofColor();
			objfrm.Show();
		}

        public override string FormID()
        {
            return UserProfile.GetFormID("miVehicle", "miVehicleVehicleColor");
        }

        public override int MasterCount()
        {
            return base.MasterCount();
        }
	
	}
}