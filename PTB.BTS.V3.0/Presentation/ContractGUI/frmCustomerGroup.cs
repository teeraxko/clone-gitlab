using System;

using Facade.ContractFacade;

using Presentation.PiGUI;
using Presentation.CommonGUI;

namespace Presentation.ContractGUI
{
	public class frmCustomerGroup : DualFieldCompanyGUIMainBase
	{
		public frmCustomerGroup()
		{
			frmEntry = new frmCustomerGroupEntry(this);
			facadeMTB = new CustomerGroupFacade();
			title = "ข้อมูลกลุ่มลูกค้า";
			columnCode = "รหัสกลุ่มลูกค้า";
			columnTHName = "ชื่อกลุ่มลูกค้า (ภาษาไทย)";
			columnENName = "ชื่อกลุ่มลูกค้า (ภาษาอังกฤษ)";
		}
		public override void PrintForm()
		{
			frmListofCustomerGroup objfrm = new frmListofCustomerGroup();
			objfrm.Show();
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