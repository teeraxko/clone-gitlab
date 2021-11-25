using System;

using DataAccess.CommonDB;

using Entity.ContractEntities;
using Entity.CommonEntity;

namespace DataAccess.ContractDB
{
	public class SpareVehicleReplacementReasonDB : SingleFieldDBBase
	{
//		============================== Constructor ==============================
		public SpareVehicleReplacementReasonDB() : base()
		{
			tableName = "Spare_Vehicle_Replacement_Reason";
			descColumnName = "Replacement_Reason";
		}

//		============================== Protected Method ==============================
        protected override ictus.Common.Entity.General.SingleFieldBase getNew()
		{
			return new AssignmentReason();
		}
	}
}
