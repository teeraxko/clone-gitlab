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
			title = "��Ҥ��";
			lable1 = "���ʸ�Ҥ��";
			lable2 = "���͸�Ҥ�� (������)";
			lable3 = "���͸�Ҥ�� (�����ѧ���)";
			isReadonly = UserProfile.IsReadOnly("miPI", "miPIMasterBank");

		}
        protected override ictus.Common.Entity.General.DualFieldBase getNew()
		{
			return new Bank();
		}
	}
}

