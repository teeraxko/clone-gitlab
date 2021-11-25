using System;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;

using Presentation.CommonGUI;

namespace Presentation.PiGUI
{
	public class frmMilitaryStatusEntry : DualFieldGUIEntryBase
	{
		public frmMilitaryStatusEntry(DualFieldGUIMainBase parentForm): base(parentForm)
		{
			maxLength = 1;
			title = "ʶҹ�ҧ����";
			lable1 = "����ʶҹ�Ҿ�ҧ����";
			lable2 = "����ʶҹ�Ҿ�ҧ����(������)";
			lable3 = "����ʶҹ�Ҿ�ҧ����(�����ѧ���)";
		}
        protected override ictus.Common.Entity.General.DualFieldBase getNew()
		{
			return new MilitaryStatus();
		}
	}
}