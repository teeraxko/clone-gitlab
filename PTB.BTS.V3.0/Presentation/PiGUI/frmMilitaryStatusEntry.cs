using System;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;

using Presentation.CommonGUI;

namespace Presentation.PiGUI
{
	public class frmMilitaryStatusEntry : DualFieldGUIEntryBase
	{
		public frmMilitaryStatusEntry(DualFieldGUIMainBase parentForm): base(parentForm)
		{
			maxLength = 1;
			title = "สถานทางทหาร";
			lable1 = "รหัสสถานภาพทางทหาร";
			lable2 = "ชื่อสถานภาพทางทหาร(ภาษาไทย)";
			lable3 = "ชื่อสถานภาพทางทหาร(ภาษาอังกฤษ)";
		}
        protected override ictus.Common.Entity.General.DualFieldBase getNew()
		{
			return new MilitaryStatus();
		}
	}
}