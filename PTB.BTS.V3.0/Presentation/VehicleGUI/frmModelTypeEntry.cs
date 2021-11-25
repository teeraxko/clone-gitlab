using System;

using Entity.VehicleEntities;
using Entity.CommonEntity;

using Presentation.CommonGUI;

namespace Presentation.VehicleGUI
{
	public class frmModelTypeEntry : DualFieldGUIEntryBase
	{
		public frmModelTypeEntry(DualFieldGUIMainBase parentForm): base(parentForm)
		{
			maxLength = 1;
			title = "���������ö";
			lable1 = "���ʻ��������ö";
			lable2 = "���ͻ��������ö (������)";
			lable3 = "���ͻ��������ö (�����ѧ���)";
		}
        protected override ictus.Common.Entity.General.DualFieldBase getNew()
		{
			return new ModelType();
		}
	}
}
