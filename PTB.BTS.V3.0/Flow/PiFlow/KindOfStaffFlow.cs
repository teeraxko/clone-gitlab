using System;

using PTB.BTS.Common.Flow;

using DataAccess.PiDB;

namespace PTB.BTS.PI.Flow
{
	public class KindOfStaffFlow : MTBCompanyFlowBase
	{
//		============================== Constructor ==============================
		public KindOfStaffFlow() : base()
		{
			dbMTB = new KindOfStaffDB();	
		}
	}
}
