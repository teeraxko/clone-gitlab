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

        //D21018-BTS Contract Modification : Property "Get" to get the prefix of contract.
        private string _ContractPrefix = "C";
        public string Prefix
        {
            get
            {
                if (this.Code == ContractType.CONTRACT_TYPE_DRIVER)
                {
                    _ContractPrefix = "D";
                }
                else if (this.Code == ContractType.CONTRACT_TYPE_OTHER)
                {
                    _ContractPrefix = "C";

                }
                else
                {
                    _ContractPrefix = "C";
                }
                return _ContractPrefix;
            }
        }       
//		============================== Constructor ==============================
		public ContractType(): base()
		{
		}
	}
}
