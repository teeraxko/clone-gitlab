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
			title = "สถานภาพสมรส";
			lable1 = "รหัสสถานภาพสมรส";
			lable2 = "ชื่อสถานภาพสมรส(ภาษาไทย)";
			lable3 = "ชื่อสถานภาพสมรส(ภาษาอังกฤษ)";
		}
        protected override ictus.Common.Entity.General.DualFieldBase getNew()
		{
			return new MaritalStatus();
		}
	}
}