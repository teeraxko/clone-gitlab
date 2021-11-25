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
			title = "ʶҺѹ";
			lable1 = "����ʶҺѹ";
			lable2 = "����ʶҺѹ (������)";
			lable3 = "����ʶҺѹ (�����ѧ���)";
			isReadonly = UserProfile.IsReadOnly("miPI", "miPIMasterEducationInstitute");

		}
        protected override ictus.Common.Entity.General.DualFieldBase getNew()
		{
			return new Institute();
		}
	}
}