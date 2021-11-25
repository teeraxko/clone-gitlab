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
			title = "������ö";
			lable1 = "���ʻ�����ö";
			lable2 = "���ͻ�����ö (������)";
			lable3 = "���ͻ�����ö(�����ѧ���)";
		}
		protected override DualFieldBase getNew()
		{
			return new KindOfVehicle();
		}
	}
}