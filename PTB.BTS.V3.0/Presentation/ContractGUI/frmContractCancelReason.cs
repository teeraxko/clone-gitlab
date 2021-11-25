using System;

using Facade.ContractFacade;

using Presentation.CommonGUI;

using SystemFramework.AppConfig;

namespace Presentation.ContractGUI
{
	public class frmContractCancelReason : SingleFieldGUIMainBase
	{
		public frmContractCancelReason(): base()
		{
			frmEntry = new frmContractCancelReasonEntry(this);
			facadeMTB = new ContractCancelReasonFacade();
            title = UserProfile.GetFormName("miContract", "miContractSettingContractCancelReason");
			columnName = "เหตุผลที่ยกเลิกสัญญา";
			isReadonly = UserProfile.IsReadOnly("miContract", "miContractSettingContractCancelReason");

		}

        public override string FormID()
        {
            return UserProfile.GetFormID("miContract", "miContractSettingContractCancelReason");
        }

        public override int MasterCount()
        {
            return base.MasterCount();
        }
	}
}
