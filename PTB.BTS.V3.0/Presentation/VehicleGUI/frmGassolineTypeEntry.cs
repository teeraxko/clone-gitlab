using System;

using Entity.VehicleEntities;
using Entity.CommonEntity;

using Presentation.CommonGUI;
namespace Presentation.VehicleGUI
{
	public class frmGassolineTypeEntry : DualFieldGUIEntryBase
	{
		public frmGassolineTypeEntry(DualFieldGUIMainBase parentForm): base(parentForm)
		{
			maxLength = 1;
			title = "������������ԧ";
			lable1 = "���ʻ�����������ԧ";
			lable2 = "���ͻ�����������ԧ (������)";
			lable3 = "���ͻ�����������ԧ (�����ѧ���)";
		}
        protected override ictus.Common.Entity.General.DualFieldBase getNew()
		{
			return new GasolineType();
		}
	}
}