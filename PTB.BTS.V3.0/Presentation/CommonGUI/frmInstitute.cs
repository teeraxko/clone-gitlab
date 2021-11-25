using System;

using Facade.CommonFacade;

using SystemFramework.AppConfig;


namespace Presentation.CommonGUI
{
	public class frmInstitute : DualFieldGUIMainBase
	{
		public frmInstitute() : base()
		{
		  	frmEntry = new frmInstituteEntry(this);
			facadeMTB = new InstituteFacade();
            title = UserProfile.GetFormName("miPI", "miPIMasterEducationInstitute");
			columnCode = "����ʶҺѹ����֡��";
			columnTHName = "����ʶҺѹ����֡�� (������)";
			columnENName = "����ʶҺѹ����֡�� (�����ѧ���)";
			isReadonly = UserProfile.IsReadOnly("miPI", "miPIMasterEducationInstitute");

		}
		public override void PrintForm()
		{
			frmListofInstitute objfrm = new frmListofInstitute();
			objfrm.Show();
		}

        public override string FormID()
        {
            return UserProfile.GetFormID("miPI", "miPIMasterEducationInstitute");
        }

        public override int MasterCount()
        {
            return base.MasterCount();
        }
	}
}