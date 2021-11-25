using System;

using ictus.Common.Entity.General;
using Entity.CommonEntity;

namespace Entity.ContractEntities
{
	public class ContractType : DualFieldBase
	{
		public const string CONTRACT_TYPE_VEHICLE = "V";
		public const string CONTRACT_TYPE_DRIVER = "D";
        public const string CONTRACT_TYPE_OTHER = "O";
//		============================== Constructor ==============================
		public ContractType(): base()
		{
		}
	}
}
