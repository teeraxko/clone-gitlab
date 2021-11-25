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
			title = "�дѺ����֡��";
			lable1 = "�����дѺ����֡��";
			lable2 = "�����дѺ����֡�� (������)";
			lable3 = "�����дѺ����֡�� (�����ѧ���)";
			isReadonly = UserProfile.IsReadOnly("miPI", "miPIMasterEducationLevel");

		}
        protected override ictus.Common.Entity.General.DualFieldBase getNew()
		{
			return new EducationLevel();
		}
	}
}

