using System.Collections;

using ictus.PIS.PI.Entity;

using DataAccess.CommonDB;


namespace PTB.BTS.Common.Flow
{
	public class StreetFlow : MTBFlowBase
	{
//		============================== Constructor ==============================
		public StreetFlow()
		{
			dbMTB = new StreetDB();
		}
	}
}
