using System;

using Entity.CommonEntity;
using Entity.ContractEntities;

using Presentation.PiGUI;
using Presentation.CommonGUI;

using ictus.Common.Entity.General;

namespace Presentation.ContractGUI
{
	public class frmKindOfContractEntry : DualFieldCompanyGUIEntryBase
	{
		public frmKindOfContractEntry(DualFieldCompanyGUIMainBase parentForm): base(parentForm)
		{
			maxLength = 1;
			title = "ชนิดสัญญา";
			lable1 = "รหัสชนิดสัญญา";
			lable2 = "ชื่อชนิดสัญญา (ภาษาไทย)";
			lable3 = "ชื่อชนิดสัญญา (ภาษาอังกฤษ)";
		}

		protected override DualFieldBase getNew()
		{
			return new KindOfContract();
		}
	}
}

