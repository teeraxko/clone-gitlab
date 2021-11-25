using System;

using PTB.BTS.Common.Flow;

using DataAccess.PiDB;

namespace PTB.BTS.PI.Flow
{
	public class MilitaryStatusFlow : MTBFlowBase
	{
//		============================== Constructor ==============================
		public MilitaryStatusFlow() : base()
		{
			dbMTB = new MilitaryStatusDB();
		}
	}
}
