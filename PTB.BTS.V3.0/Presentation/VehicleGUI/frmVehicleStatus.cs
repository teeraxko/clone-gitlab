using System;

using Facade.VehicleFacade;

using Presentation.PiGUI;
using Presentation.CommonGUI;

namespace Presentation.VehicleGUI
{
	public class frmVehicleStatus  : DualFieldCompanyGUIMainBase
	{
		public frmVehicleStatus() 
		{
			InitializeComponent();

			frmEntry = new frmVehicleStatusEntry(this);
			facadeMTB = new VehicleStatusFacade();
			title = "������ʶҹ�ö";
			columnCode = "����ʶҹ�ö";
			columnTHName = "����ʶҹ�ö (������)";
			columnENName = "����ʶҹ�ö (�����ѧ���)";
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