using System;

using Facade.VehicleFacade;

using Presentation.CommonGUI;

namespace Presentation.VehicleGUI
{
	public class frmPaymentType : DualFieldGUIMainBase
	{
		public frmPaymentType() : base()
		{
			frmEntry = new frmPaymentTypeEntry(this);
			facadeMTB = new PaymentTypeFacade();
			title = "��������ê����Թ";
			columnCode = "���ʻ�������ê����Թ";
			columnTHName = "���ͻ�������ê����Թ (������)";
			columnENName = "���ͻ�������ê����Թ (�����ѧ���)";

		}
	}
}