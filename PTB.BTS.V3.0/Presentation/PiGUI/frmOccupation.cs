using System;

using Facade.PiFacade;

using Presentation.CommonGUI;

using SystemFramework.AppConfig;
namespace Presentation.PiGUI
{
	public class frmOccupation :SingleFieldGUIMainBase
	{
		public frmOccupation()
		{
			frmEntry = new frmOccupationEntry(this);
			facadeMTB = new OccupationFacade();
            title = UserProfile.GetFormName("miPI", "miPIMasterOccupation");
			columnName = "�Ҫվ";
			isReadonly = UserProfile.IsReadOnly("miPI", "miPIMasterOccupation");

		}
		public override void PrintForm()
		{
			frmListofOccupation objfrm = new frmListofOccupation();
			objfrm.Show();
		}

        public override string FormID()
        {
            return UserProfile.GetFormID("miPI", "miPIMasterOccupation");
        }

        public override int MasterCount()
        {
            return base.MasterCount();
        }
	}
}
