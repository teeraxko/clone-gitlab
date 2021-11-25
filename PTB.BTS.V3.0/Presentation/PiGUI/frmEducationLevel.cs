using System;

using Facade.PiFacade;

using Presentation.CommonGUI;

using SystemFramework.AppConfig;

namespace Presentation.PiGUI
{
	public class frmEducationLevel : DualFieldGUIMainBase
	{
		public frmEducationLevel() : base()
		{
			frmEntry = new frmEducationLevelEntry(this);
			facadeMTB = new EducationLevelFacade();
            title = UserProfile.GetFormName("miPI", "miPIMasterEducationLevel");
			columnCode = "รหัสระดับการศึกษา";
			columnTHName = "ชื่อระดับการศึกษา (ภาษาไทย)";
			columnENName = "ชื่อระดับการศึกษา (ภาษาอังกฤษ)";
			isReadonly = UserProfile.IsReadOnly("miPI", "miPIMasterEducationLevel");

		}
		public override void PrintForm()
		{
			frmListofEducationLevel objfrm = new frmListofEducationLevel();
			objfrm.Show();
		}

        public override string FormID()
        {
            return UserProfile.GetFormID("miPI", "miPIMasterEducationLevel");
        }

        public override int MasterCount()
        {
            return base.MasterCount();
        }
	}
}