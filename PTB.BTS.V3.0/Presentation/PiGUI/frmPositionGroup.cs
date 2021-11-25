using System;

using Facade.PiFacade;

using Presentation.PiGUI;
using Presentation.CommonGUI;

namespace Presentation.PiGUI
{
	public class frmPositionGroup : DualFieldCompanyGUIMainBase
	{
		public frmPositionGroup()
		{
			frmEntry = new frmWorkingStatusEntry(this);
			facadeMTB = new PositionGroupFacade();
			title = "ข้อมูลกลุ่มตำแหน่ง";
			columnCode = "รหัสกลุ่มตำแหน่ง";
			columnTHName = "ชื่อกลุ่มตำแหน่ง (ภาษาไทย)";
			columnENName = "ชื่อกลุ่มตำแหน่ง (ภาษาอังกฤษ)";
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