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
	public class frmCustomerContractGroupEntry: DualFieldCompanyGUIEntryBase
	{
		public frmCustomerContractGroupEntry(DualFieldCompanyGUIMainBase parentForm): base(parentForm)
		{
			maxLength = 2;
			title = "������١���";
			lable1 = "���ʡ�����١���";
			lable2 = "���͡�����١���(������)";
			lable3 = "���͡�����١���(�����ѧ���)";
		}
		protected override DualFieldBase getNew()
		{
			return null;
			//return new CustomerContractGroup();
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