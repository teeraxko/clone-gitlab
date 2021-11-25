using System;

using Facade.VehicleFacade;

using Presentation.CommonGUI;

namespace Presentation.VehicleGUI
{
	public class frmModelType : DualFieldGUIMainBase
	{
		public frmModelType() : base()
		{
			frmEntry = new frmModelTypeEntry(this);
			facadeMTB = new ModelTypeFacade();
			title = "�����Ż��������ö";
			columnCode = "���ʻ��������ö";
			columnTHName = "���ͻ��������ö (������)";
			columnENName = "���ͻ��������ö (�����ѧ���)";
		}
		public override void PrintForm()
		{
			frmListofModelType objfrm = new frmListofModelType();
			objfrm.Show();
		}
	
	}
}