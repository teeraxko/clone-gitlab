using System;

using Entity.CommonEntity;
using Entity.ContractEntities;

using PTB.BTS.Common.Flow;

using DataAccess.ContractDB;

namespace PTB.BTS.Contract.Flow
{
	public class SpareVehicleInternalUsageReasonFlow : MTBFlowBase
	{
//		============================== Constructor ==============================
		public SpareVehicleInternalUsageReasonFlow()
		{
			dbMTB = new SpareVehicleInternalUsageReasonDB();
		}
	}
}
