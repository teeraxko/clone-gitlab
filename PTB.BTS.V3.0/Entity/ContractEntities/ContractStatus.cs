using System;

using ictus.Common.Entity.General;
using Entity.CommonEntity;

namespace Entity.ContractEntities
{
	public class ContractStatus : DualFieldBase
	{
        #region Public Const
        //Temporary specific type for contract status
        public const string CONTRACT_STS_CREATED = "1";
        public const string CONTRACT_STS_APPROVED = "2";
        public const string CONTRACT_STS_CANCELLED = "3";
        public const string CONTRACT_STS_EXPIRED = "4"; 
        #endregion

        #region Constructor
        public ContractStatus()
            : base()
        {
        } 
        #endregion
	}
}
