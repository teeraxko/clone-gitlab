using System;

using Facade.ContractFacade;

using Presentation.PiGUI;
using Presentation.CommonGUI;

namespace Presentation.ContractGUI
{
	public class frmContractType : DualFieldCompanyGUIMainBase
	{
		public frmContractType()
		{
			InitializeComponent();

			frmEntry = new frmContractTypeEntry(this);
			facadeMTB = new ContractTypeFacade();
			title = "ข้อมูลประเภทสัญญา";
			columnCode = "รหัสประเภทสัญญา";
			columnTHName = "ชื่อประเภทสัญญา (ภาษาไทย)";
			columnENName = "ชื่อประเภทสัญญา (ภาษาอังกฤษ)";
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
