using System;

using Entity.CommonEntity;
using Entity.ContractEntities;

using Presentation.PiGUI;
using Presentation.CommonGUI;

using ictus.Common.Entity.General;

namespace Presentation.ContractGUI
{
	public class frmContractStatusEntry : DualFieldCompanyGUIEntryBase
	{
		public frmContractStatusEntry(DualFieldCompanyGUIMainBase parentForm): base(parentForm)
		{
			maxLength = 1;
			title = "สถานะสัญญา";
			lable1 = "รหัสสถานะสัญญา";
			lable2 = "ชื่อสถานะสัญญา (ภาษาไทย)";
			lable3 = "ชื่อสถานะสัญญา (ภาษาอังกฤษ)";
		}

		protected override DualFieldBase getNew()
		{
			return new ContractStatus();
		}
	}
}

