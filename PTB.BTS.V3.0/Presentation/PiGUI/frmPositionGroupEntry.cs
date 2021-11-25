using System;

using Entity.CommonEntity;

using ictus.Common.Entity;
using ictus.PIS.PI.Entity;
using ictus.Common.Entity.General;

using Presentation.PiGUI;
using Presentation.CommonGUI;

namespace Presentation.PiGUI
{
	public class frmPositionGroupEntry: DualFieldCompanyGUIEntryBase
	{
		public frmPositionGroupEntry(DualFieldCompanyGUIMainBase parentForm): base(parentForm)
		{
			maxLength = 1;
			title = "��������˹�";
			lable1 = "���ʡ�������˹�";
			lable2 = "���͡�������˹� (������)";
			lable3 = "���͡�������˹� (�����ѧ���)";
		}
		protected override DualFieldBase getNew()
		{
			return new PositionGroup();
		}
	}
}