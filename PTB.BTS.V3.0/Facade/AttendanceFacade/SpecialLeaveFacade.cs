using System;

using Entity.AttendanceEntities;

using Flow.AttendanceFlow;

using Facade.PiFacade;

namespace Facade.AttendanceFacade
{
	public class SpecialLeaveFacade : MTBCompanyFacadeBase
	{
		public SpecialLeaveFacade() : base()
		{
			flowMTB = new SpecialLeaveFlow();
			objList = new KindOfSpecialLeaveList(GetCompany());
		}
	}
}
