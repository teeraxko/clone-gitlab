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
			title = "�������ѭ��";
			lable1 = "���ʻ������ѭ��";
			lable2 = "���ͻ������ѭ�� (������)";
			lable3 = "���ͻ������ѭ�� (�����ѧ���)";
		}

		protected override DualFieldBase getNew()
		{
			return new ContractType();
		}
	}
}
