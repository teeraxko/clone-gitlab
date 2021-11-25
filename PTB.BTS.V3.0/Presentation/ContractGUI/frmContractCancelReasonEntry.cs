using System;

using Entity.ContractEntities;
using Entity.CommonEntity;

using Presentation.CommonGUI;

using SystemFramework.AppConfig;

namespace Presentation.ContractGUI
{
	public class frmContractCancelReasonEntry : SingleFieldGUIEntryBase
	{
		public frmContractCancelReasonEntry()
		{
		}
		public frmContractCancelReasonEntry(SingleFieldGUIMainBase parentForm): base(parentForm)
		{
			title = "เหตุผลที่ยกเลิกสัญญา";
			lable = "เหตุผลที่ยกเลิกสัญญา";
			Maxlength = 60;
			isReadonly = UserProfile.IsReadOnly("miContract", "miContractSettingContractCancelReason");

		}
        protected override ictus.Common.Entity.General.SingleFieldBase getNew()
		{
			return new ContractCancelReason();
		}
		private void InitializeComponent()
		{
			// 
			// frmBloodGroupEntry
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 266);
			this.Name = "frmContractCancelReasonEntry";

		}
	}
}
