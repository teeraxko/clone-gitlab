using System;

using DataAccess.AttendanceDB;

using PTB.BTS.PI.Flow;

namespace Flow.AttendanceFlow
{
	public class SpecialLeaveFlow : MTBCompanyFlowBase
	{
//		============================== Constructor ==============================
		public SpecialLeaveFlow() : base()
		{
			dbMTB = new SpecialLeaveDB();
		}
	}
}
