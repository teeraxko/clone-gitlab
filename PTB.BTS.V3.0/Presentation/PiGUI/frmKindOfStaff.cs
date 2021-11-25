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
			title = "ชนิดพนักงาน";
			columnCode = "ชนิดพนักงาน";
			columnTHName = "ชนิดพนักงาน (ภาษาไทย)";
			columnENName = "ชนิดพนักงาน (ภาษาอังกฤษ)";
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
