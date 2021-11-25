using System;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

using Entity.CommonEntity;

using SystemFramework.AppConfig;

namespace Presentation.CommonGUI
{
	public class frmSubDistrictEntry : SingleFieldGUIEntryBase
	{
		public frmSubDistrictEntry(SingleFieldGUIMainBase parentForm): base(parentForm)
		{
			title = "�ǧ";
			lable = "�����ǧ";
			Maxlength = 30;
			isReadonly = UserProfile.IsReadOnly("miPI", "miPIMasterPlaceSubDistrict");

		}
        protected override ictus.Common.Entity.General.SingleFieldBase getNew()
		{
			return new SubDistrict(); 
		}
	}
}
