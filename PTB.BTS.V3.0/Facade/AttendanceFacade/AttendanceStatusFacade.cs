using System;

using Entity.AttendanceEntities;

using Flow.AttendanceFlow;

using Facade.PiFacade;
using Facade.CommonFacade;

namespace Facade.AttendanceFacade
{
	public class AttendanceStatusFacade  : MTBCompanyFacadeBase
	{
//		============================== Constructor ==============================
		public AttendanceStatusFacade()
		{
			flowMTB = new AttendanceStatusFlow();
			objList = new AttendanceStatusList(GetCompany());
		}
	}
}
