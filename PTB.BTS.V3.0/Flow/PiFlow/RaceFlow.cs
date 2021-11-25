using System;

using PTB.BTS.Common.Flow;

using DataAccess.PiDB;

namespace PTB.BTS.PI.Flow
{	
	public class RaceFlow : MTBFlowBase
	{
//		============================== Constructor ==============================
		public RaceFlow()
		{
			dbMTB = new RaceDB();
		}
	}
}
