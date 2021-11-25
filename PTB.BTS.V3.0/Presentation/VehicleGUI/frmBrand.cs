using System;

using Facade.VehicleFacade;

using Presentation.CommonGUI;

using SystemFramework.AppConfig;

namespace Presentation.VehicleGUI
{
	public class frmBrand : DualFieldGUIMainBase
	{
		public frmBrand() : base()
		{
			frmEntry = new frmBrandEntry(this);
			facadeMTB = new BrandFacade();
            title = UserProfile.GetFormName("miVehicle", "miVehicleVehicleBrand");
			columnCode = "รหัสยี่ห้อ";
			columnTHName = "ชื่อยี่ห้อ (ภาษาไทย)";
			columnENName = "ชื่อยี่ห้อ (ภาษาอังกฤษ)";
			isReadonly = UserProfile.IsReadOnly("miVehicle", "miVehicleVehicleBrand");
		}
		public override void PrintForm()
		{
			frmListofBrand objfrm = new frmListofBrand();
			objfrm.Show();
		}

        public override string FormID()
        {
            return UserProfile.GetFormID("miVehicle", "miVehicleVehicleBrand");
        }

        public override int MasterCount()
        {
            return base.MasterCount();
        }
	}
}