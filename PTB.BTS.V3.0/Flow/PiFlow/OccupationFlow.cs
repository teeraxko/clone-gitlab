using System;

using PTB.BTS.Common.Flow;

using DataAccess.PiDB;

namespace PTB.BTS.PI.Flow
{
	public class OccupationFlow : MTBFlowBase
	{
//		============================== Constructor ==============================
		public OccupationFlow()
		{
			dbMTB = new OccupationDB();
		}
	}
}
