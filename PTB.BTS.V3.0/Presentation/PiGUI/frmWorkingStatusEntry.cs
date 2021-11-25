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
			title = "สถานะการทำงาน";
			lable1 = "รหัสสถานะการทำงาน";
			lable2 = "ชื่อสถานะการทำงาน (ภาษาไทย)";
			lable3 = "ชื่อสถานะการทำงาน (ภาษาอังกฤษ)";
		}
		protected override DualFieldBase getNew()
		{
			return new WorkingStatus();
		}
	}
}