using System;

using PTB.BTS.Common.Flow;
using Flow.AttendanceFlow;

using DataAccess.AttendanceDB;

namespace Flow.AttendanceFlow
{
	public class LeaveReasonFlow : MTBFlowBase
	{
//		============================== Constructor ==============================
		public LeaveReasonFlow() : base()
		{
			dbMTB = new LeaveReasonDB();
		}
	}
}
