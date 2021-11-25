using System;

using Facade.PiFacade;

using Presentation.CommonGUI;

using SystemFramework.AppConfig;

namespace Presentation.PiGUI
{
	public class frmBank : DualFieldGUIMainBase
	{
		public frmBank()
		{
			frmEntry = new frmBankEntry(this);
			facadeMTB = new BankFacade();
            title = UserProfile.GetFormName("miPI", "miPIMasterBank");
			columnCode = "รหัสธนาคาร";
			columnTHName = "ชื่อธนาคาร (ภาษาไทย)";
			columnENName = "ชื่อธนาคาร (ภาษาอังกฤษ)";
			isReadonly = UserProfile.IsReadOnly("miPI", "miPIMasterBank");

		}
		public override void PrintForm()
		{
			frmListofBank objfrm = new frmListofBank();
			objfrm.Show();
		}

        public override string FormID()
        {
            return UserProfile.GetFormID("miPI", "miPIMasterBank");
        }

        public override int MasterCount()
        {
            return base.MasterCount();
        }
	}
}