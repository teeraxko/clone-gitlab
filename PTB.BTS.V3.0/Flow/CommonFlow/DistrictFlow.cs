using System;

using PTB.BTS.Common.Flow;

using DataAccess.CommonDB;

namespace PTB.BTS.Common.Flow
{
	public class DistrictFlow : MTBFlowBase
	{
//		============================== Constructor ==============================
		public DistrictFlow() : base()
		{
			dbMTB = new DistrictDB();
		}
	}
}
