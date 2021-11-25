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
			title = "�����š�����١���";
			columnCode = "���ʡ�����١���";
			columnTHName = "���͡�����١��� (������)";
			columnENName = "���͡�����١��� (�����ѧ���)";
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