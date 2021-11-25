using System;

using Facade.VehicleFacade;
using Facade.ContractFacade;

using Presentation.PiGUI;
using Presentation.CommonGUI;

using SystemFramework.AppConfig;

namespace Presentation.VehicleGUI
{
	public class frmSpareParts : DualFieldCompanyGUIMainBase
	{
		public frmSpareParts() : base()
		{
			frmEntry = new frmSparePartsEntry(this);
			facadeMTB = new SparePartsFacade();
            title = UserProfile.GetFormName("miVehicle", "miVehicleMaintenanceSpareParts");
			columnCode = "รหัสอะไหล่";
			columnTHName = "ชื่ออะไหล่ (ภาษาไทย)";
			columnENName = "ชื่ออะไหล่ (ภาษาอังกฤษ)";
			isReadonly = UserProfile.IsReadOnly("miVehicle", "miVehicleMaintenanceSpareParts");
		}

		public override void PrintForm()
		{
			frmListofSpareParts objfrm = new frmListofSpareParts();
			objfrm.Show();
		}

        public override string FormID()
        {
            return UserProfile.GetFormID("miVehicle", "miVehicleMaintenanceSpareParts");
        }

        public override int MasterCount()
        {
            return base.MasterCount();
        }
		#region Windows Form Designer generated code
		private void InitializeComponent()
		{
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(778, 240);
		}
		#endregion
	
	}
}