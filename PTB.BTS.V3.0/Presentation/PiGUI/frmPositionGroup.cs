using System;

using Facade.PiFacade;

using Presentation.PiGUI;
using Presentation.CommonGUI;

namespace Presentation.PiGUI
{
	public class frmPositionGroup : DualFieldCompanyGUIMainBase
	{
		public frmPositionGroup()
		{
			frmEntry = new frmWorkingStatusEntry(this);
			facadeMTB = new PositionGroupFacade();
			title = "�����š�������˹�";
			columnCode = "���ʡ�������˹�";
			columnTHName = "���͡�������˹� (������)";
			columnENName = "���͡�������˹� (�����ѧ���)";
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