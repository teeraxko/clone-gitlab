using System;

using PTB.BTS.Common.Flow;

using DataAccess.PiDB;

namespace PTB.BTS.PI.Flow
{
	public class MaritalStatusFlow : MTBFlowBase
	{
//		============================== Constructor ==============================
		public MaritalStatusFlow() : base()
		{
			dbMTB = new MaritalStatusDB();			
		}
	}
}
