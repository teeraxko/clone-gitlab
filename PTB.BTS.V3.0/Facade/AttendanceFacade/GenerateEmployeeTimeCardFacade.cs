using System;

using Entity.CommonEntity;

using Flow.AttendanceFlow;

using ictus.Common.Entity.Time;

namespace Facade.AttendanceFacade
{
	public class GenerateEmployeeTimeCardFacade : GenEmpScheduleFacadeBase
	{
		public GenerateEmployeeTimeCardFacade() : base()
		{
			flowGenerateWorkSchedule = new GenerateEmployeeTimeCardFlow();
		}

		public override bool GenEmployeeListSchedule(DateTime value)
		{
			return flowGenerateWorkSchedule.GenWorkSchedule(selectedEmployeeList, new YearMonth(value));
		}
	}
}