using System;

using Facade.AttendanceFacade;

using Presentation.CommonGUI;

using SystemFramework.AppConfig;

namespace Presentation.AttendanceGUI
{
	public class frmDisease : SingleFieldGUIMainBase
	{
		public frmDisease() : base()
		{
			frmEntry = new frmDiseaseEntry(this);
			facadeMTB = new DiseaseFacade();
            title = UserProfile.GetFormName("miAttendance", "miDisease");
			columnName = "ª×èÍâÃ¤";
			isReadonly = UserProfile.IsReadOnly("miAttendance", "miDisease");
		}

		public override void PrintForm()
		{
			frmDisease objfrm = new frmDisease();
			objfrm.Show();
		}

        public override string FormID()
        {
            return UserProfile.GetFormID("miAttendance", "miDisease");
        }

        public override int MasterCount()
        {
            return base.MasterCount();
        }
	}
}
