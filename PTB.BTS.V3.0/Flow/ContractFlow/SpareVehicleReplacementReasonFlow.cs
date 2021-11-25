using System;

using Entity.CommonEntity;
using Entity.ContractEntities;

using PTB.BTS.Common.Flow;

using DataAccess.ContractDB;

namespace PTB.BTS.Contract.Flow
{
	public class SpareVehicleReplacementReasonFlow : MTBFlowBase
	{
//		============================== Constructor ==============================
		public SpareVehicleReplacementReasonFlow()
		{
			dbMTB = new SpareVehicleReplacementReasonDB();
		}
	}
}
