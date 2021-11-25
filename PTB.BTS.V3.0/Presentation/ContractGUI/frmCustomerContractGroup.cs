using System;

using Facade.ContractFacade;

using Presentation.PiGUI;
using Presentation.CommonGUI;

namespace Presentation.ContractGUI
{
	public class frmCustomerContractGroup : DualFieldCompanyGUIMainBase
	{
		public frmCustomerContractGroup()
		{
			frmEntry = new frmCustomerContractGroupEntry(this);
			facadeMTB = new CustomerContractGroupFacade();
			title = "ข้อมูลกลุ่มลูกค้า";
			columnCode = "รหัสกลุ่มลูกค้า";
			columnTHName = "ชื่อกลุ่มลูกค้า (ภาษาไทย)";
			columnENName = "ชื่อกลุ่มลูกค้า (ภาษาอังกฤษ)";
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