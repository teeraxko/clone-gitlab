using System;

using PTB.BTS.Common.Flow;

using DataAccess.PiDB;

namespace PTB.BTS.PI.Flow
{	
	public class ReligionFlow : MTBFlowBase
	{
//		============================== Constructor ==============================
		public ReligionFlow()
		{
			dbMTB = new ReligionDB();
		}
	}
}
