using System;

using Facade.VehicleFacade;

using Presentation.PiGUI;
using Presentation.CommonGUI;

namespace Presentation.VehicleGUI
{
	public class frmVehicleVatStatus : DualFieldCompanyGUIMainBase
	{
		public frmVehicleVatStatus()
		{
			frmEntry = new frmVehicleVatStatusEntry(this);
			facadeMTB = new VehicleVatStatusFacade();
			title = "ข้อมูลสถานะภาษีรถ";
			columnCode = "รหัสสถานะภาษีรถ";
			columnTHName = "ชื่อสถานะภาษีรถ (ภาษาไทย)";
			columnENName = "ชื่อสถานะภาษีรถ (ภาษาอังกฤษ)";
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
