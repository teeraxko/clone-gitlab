using System;

using Entity.VehicleEntities;
using Entity.CommonEntity;

using Presentation.CommonGUI;

using ictus.Common.Entity;

namespace Presentation.VehicleGUI
{
	public class frmPaymentTypeEntry : DualFieldGUIEntryBase
	{
		public frmPaymentTypeEntry(DualFieldGUIMainBase parentForm): base(parentForm)
		{
			maxLength = 1;
			title = "��������ê����Թ";
			lable1 = "���ʻ�������ê����Թ";
			lable2 = "���ͻ�������ê����Թ(������)";
			lable3 = "���ͻ�������ê����Թ(�����ѧ���)";
		}
        protected override ictus.Common.Entity.General.DualFieldBase getNew()
		{
			return new PaymentType();
		}
	}
}