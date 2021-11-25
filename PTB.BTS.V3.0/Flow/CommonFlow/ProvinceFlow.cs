using System.Collections;

using ictus.PIS.PI.Entity;

using DataAccess.CommonDB;

namespace PTB.BTS.Common.Flow
{
	public class ProvinceFlow : MTBFlowBase
	{
//		============================== Constructor ==============================
		public ProvinceFlow()
		{
			dbMTB = new ProvinceDB();
		}
	}
}
