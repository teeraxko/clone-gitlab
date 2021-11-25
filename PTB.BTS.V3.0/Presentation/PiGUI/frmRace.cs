using System;

using Facade.PiFacade;

using Presentation.CommonGUI;

using SystemFramework.AppConfig;

namespace Presentation.PiGUI
{
	public class frmRace : SingleFieldGUIMainBase
	{
		public frmRace()
		{
			frmEntry = new frmRaceEntry(this);
			facadeMTB = new RaceFacade();
            title = UserProfile.GetFormName("miPI", "miPIMasterRace");
			columnName = "เชื้อชาติ";
			isReadonly = UserProfile.IsReadOnly("miPI", "miPIMasterRace");
		}
		public override void PrintForm()
		{
			frmListofRace objfrm = new frmListofRace();
			objfrm.Show();
		}

        public override string FormID()
        {
            return UserProfile.GetFormID("miPI", "miPIMasterRace");
        }

        public override int MasterCount()
        {
            return base.MasterCount();
        }
	}
}
