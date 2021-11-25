using System;

using Entity.AttendanceEntities;

using Flow.AttendanceFlow;

using Facade.CommonFacade;

namespace Facade.AttendanceFacade
{
	public class LeaveReasonFacade : MTBFacadeBase
	{
//		============================== Constructor ==============================
		public LeaveReasonFacade() : base()
		{
			flowMTB = new LeaveReasonFlow();
			objList = new LeaveReasonList();	
		}
	}
}
