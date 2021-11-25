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
			columnCode = "������";
			columnTHName = "������ (������)";
			columnENName = "������ (�����ѧ���)";
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