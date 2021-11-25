using System;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

using Entity.CommonEntity;

using SystemFramework.AppConfig;

namespace Presentation.CommonGUI
{
	public class frmFacultyEntry : DualFieldGUIEntryBase
	{
		public frmFacultyEntry(DualFieldGUIMainBase parentForm): base(parentForm)
		{
			maxLength = 3;
			title = "���";
			lable1 = "���ʤ��";
			lable2 = "���ͤ�� (������)";
			lable3 = "���ͤ�� (�����ѧ���)";
			isReadonly = UserProfile.IsReadOnly("miPI", "miPIMasterEducationFaculty");

		}
        protected override ictus.Common.Entity.General.DualFieldBase getNew()
		{
			return new Faculty();
		}
	}
}