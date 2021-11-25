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
			title = "ʶҹ��ѭ��";
			lable1 = "����ʶҹ��ѭ��";
			lable2 = "����ʶҹ��ѭ�� (������)";
			lable3 = "����ʶҹ��ѭ�� (�����ѧ���)";
		}

		protected override DualFieldBase getNew()
		{
			return new ContractStatus();
		}
	}
}

