using System;

using Facade.ContractFacade;

using Presentation.PiGUI;
using Presentation.CommonGUI;

namespace Presentation.ContractGUI
{
	public class frmKindOfContract : DualFieldCompanyGUIMainBase
	{
		public frmKindOfContract()
		{
			InitializeComponent();

			frmEntry = new frmKindOfContractEntry(this);
			facadeMTB = new KindOfContractFacade();
			title = "ข้อมูลชนิดสัญญา";
			columnCode = "รหัสชนิดสัญญา";
			columnTHName = "ชื่อชนิดสัญญา (ภาษาไทย)";
			columnENName = "ชื่อชนิดสัญญา (ภาษาอังกฤษ)";
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
