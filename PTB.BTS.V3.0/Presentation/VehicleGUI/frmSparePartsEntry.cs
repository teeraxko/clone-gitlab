using System;

using Entity.CommonEntity;
using Entity.VehicleEntities;

using Presentation.PiGUI;
using Presentation.CommonGUI;

using SystemFramework.AppConfig;

using ictus.Common.Entity.General;

namespace Presentation.VehicleGUI
{
	public class frmSparePartsEntry: DualFieldCompanyGUIEntryBase
	{
		public frmSparePartsEntry(DualFieldCompanyGUIMainBase parentForm): base(parentForm)
		{
			maxLength = 4;
			title = "������";
			lable1 = "����������";
			lable2 = "����������(������)";
			lable3 = "����������(�����ѧ���)";
			isReadonly = UserProfile.IsReadOnly("miVehicle", "miVehicleMaintenanceSpareParts");
		}
		protected override DualFieldBase getNew()
		{
			return new SpareParts();
		}
		protected override void KeytxtCodeMaxLength()
		{
	       setFocusTHName();
		}
	}
}
