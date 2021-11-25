using System;

using Entity.VehicleEntities;
using Entity.CommonEntity;

using Presentation.PiGUI;
using Presentation.CommonGUI;

using ictus.Common.Entity;
using ictus.Common.Entity.General;

namespace Presentation.VehicleGUI
{
	public class frmVehicleStatusEntry : DualFieldCompanyGUIEntryBase
	{
		public frmVehicleStatusEntry(DualFieldCompanyGUIMainBase parentForm): base(parentForm)
		{
			maxLength = 1;
			title = "สถานะรถ";
			lable1 = "รหัสสถานะรถ";
			lable2 = "ชื่อสถานะรถ (ภาษาไทย)";
			lable3 = "ชื่อสถานะรถ (ภาษาอังกฤษ)";
		}
		protected override DualFieldBase getNew()
		{
			return new KindOfVehicle();
		}
	}
}