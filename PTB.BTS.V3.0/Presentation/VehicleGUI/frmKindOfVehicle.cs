using System;

using Facade.VehicleFacade;

using Presentation.PiGUI;
using Presentation.CommonGUI;

namespace Presentation.VehicleGUI
{
	public class frmKindOfVehicle : DualFieldCompanyGUIMainBase
	{
		public frmKindOfVehicle() 
		{
			InitializeComponent();
			frmEntry = new frmKindOfVehicleEntry(this);
			facadeMTB = new KindOfVehicleFacade();
			title = "�����Ż�����ö";
			columnCode = "���ʻ�����ö";
			columnTHName = "���ͻ�����ö (������)";
			columnENName = "���ͻ�����ö (�����ѧ���)";
		}

		#region Windows Form Designer generated code
		private void InitializeComponent()
		{
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(778, 240);
		}
		#endregion
	}
}