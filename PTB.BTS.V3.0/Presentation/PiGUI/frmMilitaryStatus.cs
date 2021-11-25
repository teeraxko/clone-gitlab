using System;

using Facade.PiFacade;

using Presentation.CommonGUI;

namespace Presentation.PiGUI
{
	public class frmMilitaryStatus : DualFieldGUIMainBase
	{
		public frmMilitaryStatus()
		{
			frmEntry = new frmMilitaryStatusEntry(this);
			facadeMTB = new MilitaryStatusFacade();
			title = "������ʶҹ�Ҿ�ҧ����";
			columnCode = "����ʶҹ�Ҿ�ҧ����";
			columnTHName = "����ʶҹ�Ҿ�ҧ���� (������)";
			columnENName = "����ʶҹ�Ҿ�ҧ���� (�����ѧ���)";
		}
	}
}