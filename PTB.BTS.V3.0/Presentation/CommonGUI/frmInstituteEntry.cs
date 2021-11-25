using System;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

using Entity.CommonEntity;

using SystemFramework.AppConfig;

namespace Presentation.CommonGUI
{
	public class frmInstituteEntry : DualFieldGUIEntryBase
	{
		public frmInstituteEntry(DualFieldGUIMainBase parentForm): base(parentForm)
		{
			maxLength = 3;
			title = "สถาบัน";
			lable1 = "รหัสสถาบัน";
			lable2 = "ชื่อสถาบัน (ภาษาไทย)";
			lable3 = "ชื่อสถาบัน (ภาษาอังกฤษ)";
			isReadonly = UserProfile.IsReadOnly("miPI", "miPIMasterEducationInstitute");

		}
        protected override ictus.Common.Entity.General.DualFieldBase getNew()
		{
			return new Institute();
		}
	}
}