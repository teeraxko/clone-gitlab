using System;

using PTB.BTS.Common.Flow;

using DataAccess.PiDB;

namespace PTB.BTS.PI.Flow
{
	public class RelationshipFlow : MTBFlowBase
	{
//		============================== Constructor ==============================
		public RelationshipFlow()
		{
			dbMTB = new RelationshipDB();
		}
	}
}
