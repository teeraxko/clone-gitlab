using System;

using Entity.CommonEntity;

using Flow.AttendanceFlow;

using ictus.Common.Entity.Time;

namespace Facade.AttendanceFacade
{
	public class GenerateEmployeeWorkScheduleFacade : GenEmpScheduleFacadeBase
	{
		public GenerateEmployeeWorkScheduleFacade() : base()
		{			
//			flowGenerateWorkSchedule = new GenerateEmployeeWorkScheduleFlow();
			flowGenerateWorkSchedule = new GenerateEmployeeWorkScheduleAndTimcardFlow();
		}

		public override bool GenEmployeeListSchedule(DateTime value)
		{
			return flowGenerateWorkSchedule.GenWorkSchedule(selectedEmployeeList, new YearMonth(value));
		}
	}
}