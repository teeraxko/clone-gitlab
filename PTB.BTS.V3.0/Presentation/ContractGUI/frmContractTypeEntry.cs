using System;

using Entity.CommonEntity;
using Entity.ContractEntities;

using Presentation.PiGUI;
using Presentation.CommonGUI;

using ictus.Common.Entity.General;

namespace Presentation.ContractGUI
{
	public class frmContractTypeEntry : DualFieldCompanyGUIEntryBase
	{
		public frmContractTypeEntry(DualFieldCompanyGUIMainBase parentForm): base(parentForm)
		{
			maxLength = 1;
			title = "ประเภทสัญญา";
			lable1 = "รหัสประเภทสัญญา";
			lable2 = "ชื่อประเภทสัญญา (ภาษาไทย)";
			lable3 = "ชื่อประเภทสัญญา (ภาษาอังกฤษ)";
		}

		protected override DualFieldBase getNew()
		{
			return new ContractType();
		}
	}
}
