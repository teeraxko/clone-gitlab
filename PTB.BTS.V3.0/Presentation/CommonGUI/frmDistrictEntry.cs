using System;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

using Entity.CommonEntity;

using SystemFramework.AppConfig;

namespace Presentation.CommonGUI
{
	public class frmDistrictEntry : SingleFieldGUIEntryBase
	{
		public frmDistrictEntry(SingleFieldGUIMainBase parentForm): base(parentForm)
		{
			title = "เขต";
			lable = "ชื่อเขต";
			Maxlength = 30;
			isReadonly = UserProfile.IsReadOnly("miPI", "miPIMasterPlaceDistrict");

		}
        protected override ictus.Common.Entity.General.SingleFieldBase getNew()
		{
			return new District();
		}
	}
}
