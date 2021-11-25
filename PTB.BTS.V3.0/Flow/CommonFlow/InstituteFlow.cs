using System;

using PTB.BTS.Common.Flow;

using DataAccess.CommonDB;

namespace PTB.BTS.Common.Flow
{
	public class InstituteFlow : MTBFlowBase
	{
//		============================== Constructor ==============================
		public InstituteFlow() : base()
		{
			dbMTB = new InstituteDB();
		}
	}
}
