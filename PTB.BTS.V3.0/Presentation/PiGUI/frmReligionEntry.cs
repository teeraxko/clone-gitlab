using System;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;

using Presentation.CommonGUI;

using SystemFramework.AppConfig;
namespace Presentation.PiGUI
{
	public class frmReligionEntry : SingleFieldGUIEntryBase
	{
		public frmReligionEntry(SingleFieldGUIMainBase parentForm): base(parentForm)
		{
			title = "ศาสนา";
			lable = "ชื่อศาสนา";
			Maxlength = 50;
			isReadonly = UserProfile.IsReadOnly("miPI", "miPIMasterReligion");

		}
        protected override ictus.Common.Entity.General.SingleFieldBase getNew()
		{
			return new Religion();
		}
	}
}
