using System;

using Facade.CommonFacade;

using SystemFramework.AppConfig;

namespace Presentation.CommonGUI
{
	public class frmSubDistrict : SingleFieldGUIMainBase
	{
		public frmSubDistrict()
		{
			frmEntry = new frmSubDistrictEntry(this);
			facadeMTB = new SubDistrictFacade();
            title = UserProfile.GetFormName("miPI", "miPIMasterPlaceSubDistrict");
			columnName = "св╟з";
			isReadonly = UserProfile.IsReadOnly("miPI", "miPIMasterPlaceSubDistrict");
		}
		public override void PrintForm()
		{
			frmListofSubDistrict objfrm = new frmListofSubDistrict();
			objfrm.Show();
		}

        public override string FormID()
        {
            return UserProfile.GetFormID("miPI", "miPIMasterPlaceSubDistrict");
        }

        public override int MasterCount()
        {
            return base.MasterCount();
        }
	}
}
