using System;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

using Entity.CommonEntity;

using SystemFramework.AppConfig;

namespace Presentation.CommonGUI
{
	public class frmProvinceEntry : SingleFieldGUIEntryBase
	{
		public frmProvinceEntry(SingleFieldGUIMainBase parentForm): base(parentForm)
		{
			title = "จังหวัด";
			lable = "ชื่อจังหวัด";
			Maxlength = 30;
			isReadonly = UserProfile.IsReadOnly("miPI", "miPIMasterPlaceProvince");

		}
        protected override ictus.Common.Entity.General.SingleFieldBase getNew()
		{
			return new Province();
		}
	}
}
