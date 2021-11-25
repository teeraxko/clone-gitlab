using System;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

using Entity.CommonEntity;

using SystemFramework.AppConfig;

namespace Presentation.CommonGUI
{
	public class frmPrefixEntry :SingleFieldGUIEntryBase
	{
		public frmPrefixEntry(SingleFieldGUIMainBase parentForm): base(parentForm)
		{
			title = "�ӹ�˹�Ҫ���";
			lable = "�ӹ�˹�Ҫ���";
			Maxlength = 10;
			isReadonly = UserProfile.IsReadOnly("miPI", "miPIMasterPrefix");
		}
        protected override ictus.Common.Entity.General.SingleFieldBase getNew()
		{
			return new Prefix();
		}
	}
}
