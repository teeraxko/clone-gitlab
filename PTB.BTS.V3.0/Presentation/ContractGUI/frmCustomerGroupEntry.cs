using System;

using SystemFramework.AppException;
using SystemFramework.AppMessage;

using Entity.CommonEntity;
using Entity.ContractEntities;

using Presentation.PiGUI;
using Presentation.CommonGUI;

using ictus.Common.Entity.General;

namespace Presentation.ContractGUI
{
	public class frmCustomerGroupEntry: DualFieldCompanyGUIEntryBase
	{
		public frmCustomerGroupEntry(DualFieldCompanyGUIMainBase parentForm): base(parentForm)
		{
			maxLength = 2;
			title = "กลุ่มลูกค้า";
			lable1 = "รหัสกลุ่มลูกค้า";
			lable2 = "ชื่อกลุ่มลูกค้า(ภาษาไทย)";
			lable3 = "ชื่อกลุ่มลูกค้า(ภาษาอังกฤษ)";
		}
		protected override DualFieldBase getNew()
		{
			return new CustomerGroup();
		}
		protected override bool ValidateInputCode()
		{
			if(Code == "ZZ") 
			{
				Message(MessageList.Error.E0026);
				setFocusCode();
				return false;
			}
			else
			{
				return true;
			}
		}
	}
}