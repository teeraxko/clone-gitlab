using System;

using Entity.AttendanceEntities;
using ictus.PIS.PI.Entity;

using DataAccess.AttendanceDB;
using DataAccess.PiDB;

using PTB.BTS.Common.Flow;
using ictus.Common.Entity;

namespace Flow.AttendanceFlow
{
	public class EmployeeOTWorkScheduleFlow : FlowBase
	{
		private EmployeeOvertimeHourDB dbEmployeeOvertimeHour;

		public EmployeeOTWorkScheduleFlow() : base()
		{
			dbEmployeeOvertimeHour = new EmployeeOvertimeHourDB();
		}

//		================================= Process OTWorkSchedule =================================
		public bool ProcessOTWorkSchedule(Company value)
		{
			return dbEmployeeOvertimeHour.ProcessOTWorkSchedule(value);
		}
	}
}
