using System;

using Entity.VehicleEntities;
using Entity.CommonEntity;

using Presentation.CommonGUI;

using SystemFramework.AppConfig;

namespace Presentation.VehicleGUI
{
	public class frmBrandEntry : DualFieldGUIEntryBase
	{
		public frmBrandEntry(DualFieldGUIMainBase parentForm): base(parentForm)
		{
			maxLength = 2;
			title = "������";
			lable1 = "����������";
			lable2 = "���������� (������)";
			lable3 = "���������� (�����ѧ���)";
			isReadonly = UserProfile.IsReadOnly("miVehicle", "miVehicleVehicleBrand");

		}
        protected override ictus.Common.Entity.General.DualFieldBase getNew()
		{
			return new Brand();
		}
	}
}
