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
			title = "�����Ū�Դ�ѭ��";
			columnCode = "���ʪ�Դ�ѭ��";
			columnTHName = "���ͪ�Դ�ѭ�� (������)";
			columnENName = "���ͪ�Դ�ѭ�� (�����ѧ���)";
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
