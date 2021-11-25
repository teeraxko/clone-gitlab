using System;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;

using Presentation.CommonGUI;

using SystemFramework.AppConfig;

namespace Presentation.PiGUI
{
	public class frmNationalityEntry :SingleFieldGUIEntryBase
	{
		public frmNationalityEntry(SingleFieldGUIMainBase parentForm): base(parentForm)
		{
			title = "�ѭ�ҵ�";
			lable = "�����ѭ�ҵ�";
			Maxlength = 50;
			isReadonly = UserProfile.IsReadOnly("miPI", "miPIMasterNationality");
		}

        protected override ictus.Common.Entity.General.SingleFieldBase getNew()
		{
			return new Nationality();
		}

	}
}
