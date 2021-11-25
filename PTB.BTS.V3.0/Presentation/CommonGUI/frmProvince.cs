using System;

using Facade.CommonFacade;

using SystemFramework.AppConfig;

namespace Presentation.CommonGUI
{
	public class frmProvince :SingleFieldGUIMainBase
	{
		public frmProvince()
		{
			frmEntry = new frmProvinceEntry(this);
			facadeMTB = new ProvinceFacade();
            title = UserProfile.GetFormName("miPI", "miPIMasterPlaceProvince");
			columnName = "จังหวัด";
			isReadonly = UserProfile.IsReadOnly("miPI", "miPIMasterPlaceProvince");

		}

		public override void PrintForm()
		{
			frmListofProvince objfrm = new frmListofProvince();
			objfrm.Show();
		}

        public override string FormID()
        {
            return UserProfile.GetFormID("miPI", "miPIMasterPlaceProvince");
        }

        public override int MasterCount()
        {
            return base.MasterCount();
        }
	}
}
