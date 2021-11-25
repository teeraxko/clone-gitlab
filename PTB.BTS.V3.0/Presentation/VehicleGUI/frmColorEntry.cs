using System;

using Entity.VehicleEntities;
using Entity.CommonEntity;

using Presentation.CommonGUI;

using SystemFramework.AppConfig;

namespace Presentation.VehicleGUI
{
	public class frmColorEntry : DualFieldGUIEntryBase
	{
		public frmColorEntry(DualFieldGUIMainBase parentForm): base(parentForm)
		{
			maxLength = 3;
			title = "��";
			lable1 = "������";
			lable2 = "������ (������)";
			lable3 = "������ (�����ѧ���)";
			isReadonly = UserProfile.IsReadOnly("miVehicle", "miVehicleVehicleColor");
		}
        protected override ictus.Common.Entity.General.DualFieldBase getNew()
		{
			return new Color();
		}
	}
}