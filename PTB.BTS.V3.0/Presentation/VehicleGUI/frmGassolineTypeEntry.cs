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
			title = "ประเภทเชื้อเพลิง";
			lable1 = "รหัสประเภทเชื้อเพลิง";
			lable2 = "ชื่อประเภทเชื้อเพลิง (ภาษาไทย)";
			lable3 = "ชื่อประเภทเชื้อเพลิง (ภาษาอังกฤษ)";
		}
        protected override ictus.Common.Entity.General.DualFieldBase getNew()
		{
			return new GasolineType();
		}
	}
}