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
			title = "�����š�����١���";
			columnCode = "���ʡ�����١���";
			columnTHName = "���͡�����١��� (������)";
			columnENName = "���͡�����١��� (�����ѧ���)";
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