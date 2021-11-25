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
			title = "ประเภทการชำระเงิน";
			columnCode = "รหัสประเภทการชำระเงิน";
			columnTHName = "ชื่อประเภทการชำระเงิน (ภาษาไทย)";
			columnENName = "ชื่อประเภทการชำระเงิน (ภาษาอังกฤษ)";

		}
	}
}