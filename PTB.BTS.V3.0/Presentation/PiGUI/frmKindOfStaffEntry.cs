using System;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.General;

using Entity.CommonEntity;

using Presentation.CommonGUI;

namespace Presentation.PiGUI
{
	public class frmKindOfStaffEntry : DualFieldCompanyGUIEntryBase
	{
		public frmKindOfStaffEntry(DualFieldCompanyGUIMainBase parentForm): base(parentForm)
		{
			maxLength = 1;
			title = "ชนิดพนักงาน";
			lable1 = "รหัสชนิดพนักงาน";
			lable2 = "ชื่อชนิดพนักงาน (ภาษาไทย)";
			lable3 = "ชื่อชนิดพนักงาน (ภาษาอังกฤษ)";
		}
		protected override DualFieldBase getNew()
		{
			return new KindOfStaff();
		}
	}
}
