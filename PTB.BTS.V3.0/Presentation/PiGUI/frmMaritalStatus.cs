using System;

using Facade.PiFacade;

using Presentation.CommonGUI;

namespace Presentation.PiGUI
{
	public class frmMaritalStatus : DualFieldGUIMainBase
	{
		public frmMaritalStatus()
		{
			frmEntry = new frmMaritalStatusEntry(this);
			facadeMTB = new MaritalStatusFacade();
			title = "������ʶҹ�Ҿ����";
			columnCode = "����ʶҹ�Ҿ����";
			columnTHName = "����ʶҹ�Ҿ���� (������)";
			columnENName = "����ʶҹ�Ҿ���� (�����ѧ���)";
		}
	}
}