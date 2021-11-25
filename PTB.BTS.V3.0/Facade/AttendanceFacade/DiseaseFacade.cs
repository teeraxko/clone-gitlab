using System;

using Entity.AttendanceEntities;

using Flow.AttendanceFlow;

using Facade.CommonFacade;

namespace Facade.AttendanceFacade
{
	public class DiseaseFacade  : MTBFacadeBase
	{
//		============================== Constructor ==============================
		public DiseaseFacade() : base()
		{
			flowMTB = new DiseaseFlow();
			objList = new DiseaseList();	
		}
	}
}
