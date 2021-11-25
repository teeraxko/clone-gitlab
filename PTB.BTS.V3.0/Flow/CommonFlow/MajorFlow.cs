using System;

using PTB.BTS.Common.Flow;

using DataAccess.CommonDB;

namespace PTB.BTS.Common.Flow
{	
	public class MajorFlow : MTBFlowBase
	{
//		============================== Constructor ==============================
		public MajorFlow() : base()
		{
			dbMTB = new MajorDB();
		}
	}
}
