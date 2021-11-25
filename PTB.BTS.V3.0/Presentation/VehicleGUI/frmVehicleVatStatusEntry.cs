using System;

using Entity.CommonEntity;
using Entity.VehicleEntities;

using Presentation.PiGUI;
using Presentation.CommonGUI;

using ictus.Common.Entity.General;

namespace Presentation.VehicleGUI
{
	public class frmVehicleVatStatusEntry : DualFieldCompanyGUIEntryBase
	{
		public frmVehicleVatStatusEntry(DualFieldCompanyGUIMainBase parentForm): base(parentForm)
		{
			maxLength = 1;
			title = "สถานะภาษีรถ";
			lable1 = "รหัสสถานะภาษีรถ";
			lable2 = "ชื่อสถานะภาษีรถ (ภาษาไทย)";
			lable3 = "ชื่อสถานะภาษีรถ (ภาษาอังกฤษ)";
		}

		protected override DualFieldBase getNew()
		{
			return new VehicleVatStatus();
		}
	}
}
