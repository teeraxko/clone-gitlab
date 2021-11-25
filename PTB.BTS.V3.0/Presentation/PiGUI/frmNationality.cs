using System;

using Facade.PiFacade;

using Presentation.CommonGUI;

using SystemFramework.AppConfig;

namespace Presentation.PiGUI
{
	public class frmNationality : SingleFieldGUIMainBase
	{
		public frmNationality()
		{
			frmEntry = new frmNationalityEntry(this);
			facadeMTB = new NationalityFacade();
            title = UserProfile.GetFormName("miPI", "miPIMasterNationality");
			columnName = "สัญชาติ";
			isReadonly = UserProfile.IsReadOnly("miPI", "miPIMasterNationality");
		}

		public override void PrintForm()
		{
			frmListofNationality objfrm = new frmListofNationality();
			objfrm.Show();
		}

        public override string FormID()
        {
            return UserProfile.GetFormID("miPI", "miPIMasterNationality");
        }

        public override int MasterCount()
        {
            return base.MasterCount();
        }
	}
}
