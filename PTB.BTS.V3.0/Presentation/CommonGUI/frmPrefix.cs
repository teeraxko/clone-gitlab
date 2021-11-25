using System;

using Facade.CommonFacade;

using SystemFramework.AppConfig;

namespace Presentation.CommonGUI
{
	public class frmPrefix : SingleFieldGUIMainBase
	{
		public frmPrefix()
		{
			frmEntry = new frmPrefixEntry(this);
			facadeMTB = new PrefixFacade();
            title = UserProfile.GetFormName("miPI", "miPIMasterPrefix");
			columnName = "คำนำหน้าชื่อ";
			isReadonly = UserProfile.IsReadOnly("miPI", "miPIMasterPrefix");
		}

        public override string FormID()
        {
            return UserProfile.GetFormID("miPI", "miPIMasterPrefix");
        }

        public override int MasterCount()
        {
            return base.MasterCount();
        }
	}
}
