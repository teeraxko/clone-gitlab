using System;

using Facade.PiFacade;

using Presentation.CommonGUI;

using SystemFramework.AppConfig;

namespace Presentation.PiGUI
{
	public class frmBloodGroup : SingleFieldGUIMainBase
	{
		public frmBloodGroup() : base()
		{
			frmEntry = new frmBloodGroupEntry(this);
			facadeMTB = new BloodGroupFacade();
            title = UserProfile.GetFormName("miPI", "miPIMasterBloodGroup");
			columnName = "หมู่เลือด";
			isReadonly = UserProfile.IsReadOnly("miPI", "miPIMasterBloodGroup");

		}

        public override string FormID()
        {
            return UserProfile.GetFormID("miPI", "miPIMasterBloodGroup");
        }

        public override int MasterCount()
        {
            return base.MasterCount();
        }
	}
}
