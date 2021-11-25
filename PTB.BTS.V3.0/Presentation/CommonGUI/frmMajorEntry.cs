using System;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

using Entity.CommonEntity;

using SystemFramework.AppConfig;

namespace Presentation.CommonGUI
{
	public class frmMajorEntry : DualFieldGUIEntryBase
	{
		public frmMajorEntry(DualFieldGUIMainBase parentForm): base(parentForm)
		{
			maxLength = 3;
			title = "วิชาเอก";
			lable1 = "รหัสวิชาเอก";
			lable2 = "ชื่อวิชาเอก (ภาษาไทย)";
			lable3 = "ชื่อวิชาเอก (ภาษาอังกฤษ)";
			isReadonly = UserProfile.IsReadOnly("miPI", "miPIMasterEducationMajor");
		}
        protected override ictus.Common.Entity.General.DualFieldBase getNew()
		{
			return new Major();
		}
	}
}