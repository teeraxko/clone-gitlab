using System;

using DataAccess.CommonDB;

using Entity.ContractEntities;
using Entity.CommonEntity;

namespace DataAccess.ContractDB
{
	public class SpareVehicleInternalUsageReasonDB : SingleFieldDBBase
	{
//		============================== Constructor ==============================
		public SpareVehicleInternalUsageReasonDB() : base()
		{
			tableName = "Spare_Vehicle_Internal_Usage_Reason";
			descColumnName = "Internal_Usage_Reason";
		}

//		============================== Protected Method ==============================
        protected override ictus.Common.Entity.General.SingleFieldBase getNew()
		{
			return new AssignmentReason();
		}	
	}
}
