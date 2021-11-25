using System;

using Facade.PiFacade;

using Presentation.CommonGUI;

using SystemFramework.AppConfig;
namespace Presentation.PiGUI
{
	public class frmRelationship : SingleFieldGUIMainBase
	{
		public frmRelationship()
		{
			frmEntry = new frmRelationshipEntry(this);
			facadeMTB = new RelationshipFacade();
            title = UserProfile.GetFormName("miPI", "miPIMasterRelationship");
			columnName = "��������ѹ��";
			isReadonly = UserProfile.IsReadOnly("miPI", "miPIMasterRelationship");
		}

        public override string FormID()
        {
            return UserProfile.GetFormID("miPI", "miPIMasterRelationship");
        }

        public override int MasterCount()
        {
            return base.MasterCount();
        }
	}
}
