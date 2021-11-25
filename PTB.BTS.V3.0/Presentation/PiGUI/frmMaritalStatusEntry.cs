using System;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;

using Presentation.CommonGUI;

namespace Presentation.PiGUI
{
	public class frmMaritalStatusEntry : DualFieldGUIEntryBase
	{
		public frmMaritalStatusEntry(DualFieldGUIMainBase parentForm): base(parentForm)
		{
			maxLength = 1;
			title = "ʶҹ�Ҿ����";
			lable1 = "����ʶҹ�Ҿ����";
			lable2 = "����ʶҹ�Ҿ����(������)";
			lable3 = "����ʶҹ�Ҿ����(�����ѧ���)";
		}
        protected override ictus.Common.Entity.General.DualFieldBase getNew()
		{
			return new MaritalStatus();
		}
	}
}