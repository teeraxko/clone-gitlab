using System.Collections;

using ictus.PIS.PI.Entity;

using DataAccess.CommonDB;

namespace PTB.BTS.Common.Flow
{
	public class SubDistrictFlow : MTBFlowBase
	{
//		============================== Constructor ==============================
		public SubDistrictFlow() : base()
		{
			dbMTB = new SubDistrictDB();
		}
	}
}
