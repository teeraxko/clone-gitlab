using System;

using Entity.CommonEntity;

using ictus.Common.Entity.General;
using ictus.PIS.PI.Entity;

using Presentation.PiGUI;
using Presentation.CommonGUI;

namespace Presentation.PiGUI
{
	public class frmWorkingStatusEntry: DualFieldCompanyGUIEntryBase
	{
		public frmWorkingStatusEntry(DualFieldCompanyGUIMainBase parentForm): base(parentForm)
		{
			maxLength = 2;
			title = "ʶҹС�÷ӧҹ";
			lable1 = "����ʶҹС�÷ӧҹ";
			lable2 = "����ʶҹС�÷ӧҹ (������)";
			lable3 = "����ʶҹС�÷ӧҹ (�����ѧ���)";
		}
		protected override DualFieldBase getNew()
		{
			return new WorkingStatus();
		}
	}
}