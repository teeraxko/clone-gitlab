using System;

using Facade.ContractFacade;

using Presentation.PiGUI;
using Presentation.CommonGUI;

namespace Presentation.ContractGUI
{
	public class frmContractStatus : DualFieldCompanyGUIMainBase
	{
		public frmContractStatus()
		{
			InitializeComponent();

			frmEntry = new frmContractStatusEntry(this);
			facadeMTB = new ContractStatusFacade();
			title = "ข้อมูลสถานะสัญญา";
			columnCode = "รหัสประเภทสัญญา";
			columnTHName = "ชื่อสถานะสัญญา (ภาษาไทย)";
			columnENName = "ชื่อสถานะสัญญา (ภาษาอังกฤษ)";
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