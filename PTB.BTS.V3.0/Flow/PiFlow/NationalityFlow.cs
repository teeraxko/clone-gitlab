using System;

using PTB.BTS.Common.Flow;

using DataAccess.PiDB;

namespace PTB.BTS.PI.Flow
{
	public class NationalityFlow : MTBFlowBase
	{
//		============================== Constructor ==============================
		public NationalityFlow()
		{
			dbMTB = new NationalityDB();
		}
	}
}
