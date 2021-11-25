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
			title = "�Ԫ��͡";
			lable1 = "�����Ԫ��͡";
			lable2 = "�����Ԫ��͡ (������)";
			lable3 = "�����Ԫ��͡ (�����ѧ���)";
			isReadonly = UserProfile.IsReadOnly("miPI", "miPIMasterEducationMajor");
		}
        protected override ictus.Common.Entity.General.DualFieldBase getNew()
		{
			return new Major();
		}
	}
}