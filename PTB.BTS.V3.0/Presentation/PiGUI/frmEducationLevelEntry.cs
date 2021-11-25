using System;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

using Entity.CommonEntity;

using Presentation.CommonGUI;
using SystemFramework.AppConfig;
namespace Presentation.PiGUI
{
	public class frmEducationLevelEntry : DualFieldGUIEntryBase
	{
		public frmEducationLevelEntry(DualFieldGUIMainBase parentForm): base(parentForm)
		{
			maxLength = 2;
			title = "ระดับการศึกษา";
			lable1 = "รหัสระดับการศึกษา";
			lable2 = "ชื่อระดับการศึกษา (ภาษาไทย)";
			lable3 = "ชื่อระดับการศึกษา (ภาษาอังกฤษ)";
			isReadonly = UserProfile.IsReadOnly("miPI", "miPIMasterEducationLevel");

		}
        protected override ictus.Common.Entity.General.DualFieldBase getNew()
		{
			return new EducationLevel();
		}
	}
}

