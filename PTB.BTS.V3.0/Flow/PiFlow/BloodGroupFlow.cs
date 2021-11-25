using System;

using Entity.CommonEntity;
using ictus.PIS.PI.Entity;

using PTB.BTS.Common.Flow;

using DataAccess.PiDB;

namespace PTB.BTS.PI.Flow
{
	public class BloodGroupFlow : MTBFlowBase
	{
//		============================== Constructor ==============================
		public BloodGroupFlow()
		{
			dbMTB = new BloodGroupDB();
		}
	}
}