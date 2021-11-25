using System;

using Facade.CommonFacade;

using SystemFramework.AppConfig;

namespace Presentation.CommonGUI
{

	public class frmDistrict : SingleFieldGUIMainBase
	{
		public frmDistrict()
		{
			frmEntry = new frmDistrictEntry(this);
			facadeMTB = new DistrictFacade();
            title = UserProfile.GetFormName("miPI", "miPIMasterPlaceDistrict");
			columnName = "ࢵ";
			isReadonly = UserProfile.IsReadOnly("miPI", "miPIMasterPlaceDistrict");

		}
		public override void PrintForm()
		{
			frmListofDistrict objfrm = new frmListofDistrict();
			objfrm.Show();
		}

        public override string FormID()
        {
            return UserProfile.GetFormID("miPI", "miPIMasterPlaceDistrict");
        }

        public override int MasterCount()
        {
            return base.MasterCount();
        }
	}
}
