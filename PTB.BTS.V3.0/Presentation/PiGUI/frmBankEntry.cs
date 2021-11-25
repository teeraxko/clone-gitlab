using System;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;

using Presentation.CommonGUI;

using SystemFramework.AppConfig;

namespace Presentation.PiGUI
{
	public class frmBankEntry : DualFieldGUIEntryBase
	{
		public frmBankEntry(DualFieldGUIMainBase parentForm): base(parentForm)
		{
			maxLength = 3;
			title = "ธนาคาร";
			lable1 = "รหัสธนาคาร";
			lable2 = "ชื่อธนาคาร (ภาษาไทย)";
			lable3 = "ชื่อธนาคาร (ภาษาอังกฤษ)";
			isReadonly = UserProfile.IsReadOnly("miPI", "miPIMasterBank");

		}
        protected override ictus.Common.Entity.General.DualFieldBase getNew()
		{
			return new Bank();
		}
	}
}

