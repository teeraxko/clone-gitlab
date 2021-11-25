using System;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;

using Presentation.CommonGUI;

using SystemFramework.AppConfig;

namespace Presentation.PiGUI
{
	public class frmRaceEntry : SingleFieldGUIEntryBase
	{
		public frmRaceEntry(SingleFieldGUIMainBase parentForm): base(parentForm)
		{
			title = "���ͪҵ�";
			lable = "�������ͪҵ�";
			Maxlength = 50;
			isReadonly = UserProfile.IsReadOnly("miPI", "miPIMasterRace");
		}

        protected override ictus.Common.Entity.General.SingleFieldBase getNew()
		{
			return new Race();
		}
	}
}
