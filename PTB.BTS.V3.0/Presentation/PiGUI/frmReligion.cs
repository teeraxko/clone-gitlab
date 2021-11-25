using System;

using Facade.PiFacade;

using Presentation.CommonGUI;

using SystemFramework.AppConfig;
namespace Presentation.PiGUI
{

	public class frmReligion : SingleFieldGUIMainBase
	{
		public frmReligion()
		{
			frmEntry = new frmReligionEntry(this);
			facadeMTB = new ReligionFacade();
            title = UserProfile.GetFormName("miPI", "miPIMasterReligion");
			columnName = "ศาสนา";
			isReadonly = UserProfile.IsReadOnly("miPI", "miPIMasterReligion");

		}
		public override void PrintForm()
		{
			frmListofReligion objfrm = new frmListofReligion();
			objfrm.Show();
		}

        public override string FormID()
        {
            return UserProfile.GetFormID("miPI", "miPIMasterReligion");
        }

        public override int MasterCount()
        {
            return base.MasterCount();
        }
	}
}
