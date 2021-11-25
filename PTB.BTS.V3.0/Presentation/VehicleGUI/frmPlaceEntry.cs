using System;

using Entity.VehicleEntities;
using Entity.CommonEntity;

using Presentation.CommonGUI;

using SystemFramework.AppConfig;

namespace Presentation.VehicleGUI
{
	public class frmPlaceEntry : SingleFieldGUIEntryBase
	{
		public frmPlaceEntry(SingleFieldGUIMainBase parentForm): base(parentForm)
		{
			title = "ʶҹ���";
			lable = "����ʶҹ���";
			Maxlength = 50;
			isReadonly = UserProfile.IsReadOnly("miVehicle", "miVehicleSettingAccidentPlace");
		}
        protected override ictus.Common.Entity.General.SingleFieldBase getNew()
		{
			return new Place();
		}
	}
}
