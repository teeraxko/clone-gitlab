using System.Collections;

using ictus.PIS.PI.Entity;

using DataAccess.CommonDB;

namespace PTB.BTS.Common.Flow
{
	public class PrefixFlow : MTBFlowBase
	{
//		============================== Constructor ==============================
		public PrefixFlow()
		{	
			dbMTB = new PrefixDB();
		}
	}
}
