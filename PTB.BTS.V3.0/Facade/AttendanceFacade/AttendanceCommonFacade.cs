using System;

using Entity.AttendanceEntities;
using Entity.CommonEntity;

using Flow.AttendanceFlow;

using ictus.Common.Entity.General;

namespace Facade.AttendanceFacade
{
	public class AttendanceCommonFacade
	{
		private static AttendanceCommonFlow flowAttendanceCommon = new AttendanceCommonFlow();

		public AttendanceCommonFacade()
		{
		}

		public static TimePeriod GetTimePeriod(TimePeriod value, DateTime forDate)
		{
			return flowAttendanceCommon.GetTimePeriod(value.From, value.To, forDate);
		}

		public static TimePeriod GetTimePeriod(TimePeriod value)
		{
			return flowAttendanceCommon.GetTimePeriod(value.From, value.To, NullConstant.TIME);
		}

		public static TimePeriod GetTimePeriod(DateTime form, DateTime to, DateTime forDate)
		{
			return flowAttendanceCommon.GetTimePeriod(form, to, forDate);
		}

		public static TimePeriod GetTimePeriod(DateTime form, DateTime to)
		{
			return flowAttendanceCommon.GetTimePeriod(form, to, NullConstant.TIME);
		}

		public static TimePeriod GetBreakTimePeriod(DateTime startBreak, DateTime endBreak, DateTime startWork, DateTime endWork, DateTime forDate)
		{
			return flowAttendanceCommon.GetBreakTimePeriod(startBreak, endBreak, startWork, endWork, forDate);
		}

		public static TimePeriod GetBreakTimePeriod(DateTime startBreak, DateTime endBreak, DateTime startWork, DateTime endWork)
		{
			return flowAttendanceCommon.GetBreakTimePeriod(startBreak, endBreak, startWork, endWork, NullConstant.TIME);
		}

		public static DateTime GetTime(DateTime time)
		{
			return flowAttendanceCommon.GetTime(time);
		}

		public static TimePeriod GetTime(DateTime from, DateTime to)
		{
			return flowAttendanceCommon.GetTime(from, to);
		}
	}
}
