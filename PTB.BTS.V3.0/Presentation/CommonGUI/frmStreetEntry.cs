using System;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

using Entity.CommonEntity;

using SystemFramework.AppConfig;

namespace Presentation.CommonGUI
{
	public class frmStreetEntry : SingleFieldGUIEntryBase
	{
		public frmStreetEntry(SingleFieldGUIMainBase parentForm): base(parentForm)
		{
			title = "¶¹¹";
			lable = "ª×èÍ¶¹¹";
			Maxlength = 30;
			isReadonly = UserProfile.IsReadOnly("miPI", "miPIMasterPlaceStreet");

		}
        protected override ictus.Common.Entity.General.SingleFieldBase getNew()
		{
			return new Street();
		}
	}
}
