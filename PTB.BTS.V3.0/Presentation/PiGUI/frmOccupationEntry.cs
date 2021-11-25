using System;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;

using Presentation.CommonGUI;

using SystemFramework.AppConfig;
namespace Presentation.PiGUI
{

	public class frmOccupationEntry :SingleFieldGUIEntryBase
	{
		public frmOccupationEntry(SingleFieldGUIMainBase parentForm): base(parentForm)
		{
			title = "อาชีพ";
			lable = "ชื่ออาชีพ";
			Maxlength = 50;
			isReadonly = UserProfile.IsReadOnly("miPI", "miPIMasterOccupation");

		}
        protected override ictus.Common.Entity.General.SingleFieldBase getNew()
		{
			return new Occupation();
		}
	}
}
