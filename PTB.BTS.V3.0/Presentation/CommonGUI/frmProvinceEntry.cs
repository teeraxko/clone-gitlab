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
			title = "�ѧ��Ѵ";
			lable = "���ͨѧ��Ѵ";
			Maxlength = 30;
			isReadonly = UserProfile.IsReadOnly("miPI", "miPIMasterPlaceProvince");

		}
        protected override ictus.Common.Entity.General.SingleFieldBase getNew()
		{
			return new Province();
		}
	}
}
