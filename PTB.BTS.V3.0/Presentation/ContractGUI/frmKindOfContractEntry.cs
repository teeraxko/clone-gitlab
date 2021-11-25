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
			title = "��Դ�ѭ��";
			lable1 = "���ʪ�Դ�ѭ��";
			lable2 = "���ͪ�Դ�ѭ�� (������)";
			lable3 = "���ͪ�Դ�ѭ�� (�����ѧ���)";
		}

		protected override DualFieldBase getNew()
		{
			return new KindOfContract();
		}
	}
}

