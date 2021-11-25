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
			title = "ประเภทรุ่นรถ";
			lable1 = "รหัสประเภทรุ่นรถ";
			lable2 = "ชื่อประเภทรุ่นรถ (ภาษาไทย)";
			lable3 = "ชื่อประเภทรุ่นรถ (ภาษาอังกฤษ)";
		}
        protected override ictus.Common.Entity.General.DualFieldBase getNew()
		{
			return new ModelType();
		}
	}
}
