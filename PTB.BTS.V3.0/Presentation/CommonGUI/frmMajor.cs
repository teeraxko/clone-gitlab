using System;

using Facade.CommonFacade;

using SystemFramework.AppConfig;

namespace Presentation.CommonGUI
{
	public class frmMajor : DualFieldGUIMainBase
	{
		public frmMajor() : base()
		{
			frmEntry = new frmMajorEntry(this);
			facadeMTB = new MajorFacade();
            title = UserProfile.GetFormName("miPI", "miPIMasterEducationMajor");
			columnCode = "�����Ԫ��͡";
			columnTHName = "�����Ԫ��͡ (������)";
			columnENName = "�����Ԫ��͡ (�����ѧ���)";
			isReadonly = UserProfile.IsReadOnly("miPI", "miPIMasterEducationMajor");

		}
		public override void PrintForm()
		{
			frmListofMajor objfrm = new frmListofMajor();
			objfrm.Show();
		}

        public override string FormID()
        {
            return UserProfile.GetFormID("miPI", "miPIMasterEducationMajor");
        }

        public override int MasterCount()
        {
            return base.MasterCount();
        }
	}
}