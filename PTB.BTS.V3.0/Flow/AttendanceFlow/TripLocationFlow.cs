using System;

using Entity.CommonEntity;
using ictus.PIS.PI.Entity;

using PTB.BTS.Common.Flow;

using DataAccess.AttendanceDB;

namespace Flow.AttendanceFlow
{
	public class TripLocationFlow : MTBFlowBase
	{
		//============================== Constructor ==============================
		public TripLocationFlow()
		{
			dbMTB = new TripLocationDB();
		}
	}
}