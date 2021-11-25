using System;

using DataAccess.CommonDB;

using Entity.ContractEntities;
using Entity.CommonEntity;

namespace DataAccess.ContractDB
{
	public class ContractCancelReasonDB : SingleFieldDBBase
	{
//		============================== Constructor ==============================
		public ContractCancelReasonDB(): base()
		{
			tableName = "Contract_Cancel_Reason";
			descColumnName = "Reason";
		}

//		============================== Protected Method ==============================
        protected override ictus.Common.Entity.General.SingleFieldBase getNew()
		{
			return new ContractCancelReason();
		}
	}
}
