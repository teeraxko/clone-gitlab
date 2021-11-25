using System;

using ictus.Common.Entity.General;
using Entity.CommonEntity;

namespace Entity.ContractEntities
{
	public class KindOfContract : DualFieldBase
	{
        #region Public Const
        //Temporary specific type for kind of contract
        public const string KIND_OF_CONTRACT_LONG = "L";
        public const string KIND_OF_CONTRACT_TEMP = "T";
        #endregion

        #region Constructor
        public KindOfContract()
            : base()
        {
        } 
        #endregion
	}
}
