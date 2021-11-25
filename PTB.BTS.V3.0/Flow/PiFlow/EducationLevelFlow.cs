using System;

using PTB.BTS.Common.Flow;

using DataAccess.PiDB;

namespace PTB.BTS.PI.Flow
{	
	public class EducationLevelFlow : MTBFlowBase
	{
//		============================== Constructor ==============================
		public EducationLevelFlow() : base()
		{
			dbMTB = new EducationLevelDB();			
		}
	}
}
