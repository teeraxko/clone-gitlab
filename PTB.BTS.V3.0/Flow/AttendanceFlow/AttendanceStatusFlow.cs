using System;

using DataAccess.AttendanceDB;

using PTB.BTS.PI.Flow;

namespace Flow.AttendanceFlow
{
	public class AttendanceStatusFlow : MTBCompanyFlowBase
	{
		public AttendanceStatusFlow() : base()
		{
			dbMTB = new AttendanceStatusDB();
		}
	}
}
