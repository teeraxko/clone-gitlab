
using System;

using Facade.CommonFacade;

using SystemFramework.AppConfig;

namespace Presentation.CommonGUI
{
	public class frmFaculty : DualFieldGUIMainBase
	{
		public frmFaculty() : base()
		{
			frmEntry = new frmFacultyEntry(this);
			facadeMTB = new FacultyFacade();
            title = UserProfile.GetFormName("miPI", "miPIMasterEducationFaculty");
			columnCode = "���ʤ��";
			columnTHName = "���ͤ�� (������)";
			columnENName = "���ͤ�� (�����ѧ���)";
			isReadonly = UserProfile.IsReadOnly("miPI", "miPIMasterEducationFaculty");

		}
		public override void PrintForm()
		{
			frmListofFaculty objfrm = new frmListofFaculty();
			objfrm.Show();
		}

        public override string FormID()
        {
            return UserProfile.GetFormID("miPI", "miPIMasterEducationFaculty");
        }

        public override int MasterCount()
        {
            return base.MasterCount();
        }
	}
}