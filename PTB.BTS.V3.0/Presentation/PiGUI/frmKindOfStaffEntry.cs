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
			title = "��Դ��ѡ�ҹ";
			lable1 = "���ʪ�Դ��ѡ�ҹ";
			lable2 = "���ͪ�Դ��ѡ�ҹ (������)";
			lable3 = "���ͪ�Դ��ѡ�ҹ (�����ѧ���)";
		}
		protected override DualFieldBase getNew()
		{
			return new KindOfStaff();
		}
	}
}
