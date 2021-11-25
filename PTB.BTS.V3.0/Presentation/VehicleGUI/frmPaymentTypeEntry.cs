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
			title = "ประเภทการชำระเงิน";
			lable1 = "รหัสประเภทการชำระเงิน";
			lable2 = "ชื่อประเภทการชำระเงิน(ภาษาไทย)";
			lable3 = "ชื่อประเภทการชำระเงิน(ภาษาอังกฤษ)";
		}
        protected override ictus.Common.Entity.General.DualFieldBase getNew()
		{
			return new PaymentType();
		}
	}
}