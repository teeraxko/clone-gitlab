using System;

using Facade.PiFacade;

using Presentation.PiGUI;
using Presentation.CommonGUI;

namespace Presentation.PiGUI
{
	public class frmWorkingStatus : DualFieldCompanyGUIMainBase
	{
		public frmWorkingStatus()
		{
			frmEntry = new frmWorkingStatusEntry(this);
			facadeMTB = new WorkingStatusFacade();
			title = "ข้อมูลสถานภาพทางทหาร";
			columnCode = "รหัสสถานภาพทางทหาร";
			columnTHName = "ชื่อสถานภาพทางทหาร (ภาษาไทย)";
			columnENName = "ชื่อสถานภาพทางทหาร (ภาษาอังกฤษ)";
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