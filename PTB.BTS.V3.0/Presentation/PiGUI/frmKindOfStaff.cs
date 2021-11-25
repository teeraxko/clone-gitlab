using System;

using Facade.PiFacade;

using Presentation.CommonGUI;

namespace Presentation.PiGUI
{
	public class frmKindOfStaff: DualFieldCompanyGUIMainBase
	{
		public frmKindOfStaff() : base()
		{
			frmEntry = new frmKindOfStaffEntry(this);
			facadeMTB = new KindOfStaffFacade();
			title = "��Դ��ѡ�ҹ";
			columnCode = "��Դ��ѡ�ҹ";
			columnTHName = "��Դ��ѡ�ҹ (������)";
			columnENName = "��Դ��ѡ�ҹ (�����ѧ���)";
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
