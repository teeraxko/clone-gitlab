using System;

using Entity.VehicleEntities;
using Entity.CommonEntity;

using Presentation.PiGUI;
using Presentation.CommonGUI;

using ictus.Common.Entity.General;

namespace Presentation.VehicleGUI
{
	public class frmKindOfVehicleEntry : DualFieldCompanyGUIEntryBase
	{
		public frmKindOfVehicleEntry(DualFieldCompanyGUIMainBase parentForm): base(parentForm)
		{
			maxLength = 1;
			title = "ประเภทรถ";
			lable1 = "รหัสประเภทรถ";
			lable2 = "ชื่อประเภทรถ (ภาษาไทย)";
			lable3 = "ชื่อประเภทรถ(ภาษาอังกฤษ)";
		}
		protected override DualFieldBase getNew()
		{
			return new KindOfVehicle();
		}
	}
}