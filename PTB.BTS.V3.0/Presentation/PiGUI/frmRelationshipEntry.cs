using System;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;

using Presentation.CommonGUI;

using SystemFramework.AppConfig;
namespace Presentation.PiGUI
{
	public class frmRelationshipEntry : SingleFieldGUIEntryBase
	{
		public frmRelationshipEntry(SingleFieldGUIMainBase parentForm): base(parentForm)
		{
			title = "��������ѹ��";
			lable = "���ͤ�������ѹ��";
			Maxlength = 50;
			isReadonly = UserProfile.IsReadOnly("miPI", "miPIMasterRelationship");

		}
        protected override ictus.Common.Entity.General.SingleFieldBase getNew()
		{
			return new Relationship();
		}
	}
}
