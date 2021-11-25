using System;

using Facade.CommonFacade;

using SystemFramework.AppConfig;

namespace Presentation.CommonGUI
{
	public class frmStreet : SingleFieldGUIMainBase
	{
		public frmStreet()
		{
			frmEntry = new frmStreetEntry(this);
			facadeMTB = new StreetFacade();
            title = UserProfile.GetFormName("miPI", "miPIMasterPlaceStreet");
			columnName = "¶¹¹";			
			isReadonly = UserProfile.IsReadOnly("miPI", "miPIMasterPlaceStreet");

		}
		public override void PrintForm()
		{
			frmListofStreet objfrm = new frmListofStreet();
			objfrm.Show();
		}

        public override string FormID()
        {
            return UserProfile.GetFormID("miPI", "miPIMasterPlaceStreet");
        }

        public override int MasterCount()
        {
            return base.MasterCount();
        }
	}
}
