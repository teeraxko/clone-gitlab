using System;

using Facade.VehicleFacade;

using Presentation.CommonGUI;

namespace Presentation.VehicleGUI
{
	public class frmGassolineType : DualFieldGUIMainBase
	{
		public frmGassolineType() : base()
		{
			frmEntry = new frmGassolineTypeEntry(this);
			facadeMTB = new GasolineTypeFacade();
			title = "������������ԧ";
			columnCode = "����������ԧ";
			columnTHName = "����������ԧ (������)";
			columnENName = "����������ԧ (�����ѧ���)";
		}
	}
}