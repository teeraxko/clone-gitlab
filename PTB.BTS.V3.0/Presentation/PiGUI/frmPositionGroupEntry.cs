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
			title = "กลุ่มตำแหน่ง";
			lable1 = "รหัสกลุ่มตำแหน่ง";
			lable2 = "ชื่อกลุ่มตำแหน่ง (ภาษาไทย)";
			lable3 = "ชื่อกลุ่มตำแหน่ง (ภาษาอังกฤษ)";
		}
		protected override DualFieldBase getNew()
		{
			return new PositionGroup();
		}
	}
}