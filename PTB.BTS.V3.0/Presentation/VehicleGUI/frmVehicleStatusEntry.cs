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
			title = "ʶҹ�ö";
			lable1 = "����ʶҹ�ö";
			lable2 = "����ʶҹ�ö (������)";
			lable3 = "����ʶҹ�ö (�����ѧ���)";
		}
		protected override DualFieldBase getNew()
		{
			return new KindOfVehicle();
		}
	}
}