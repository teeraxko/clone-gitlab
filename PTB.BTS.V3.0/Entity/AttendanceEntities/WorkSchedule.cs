using System;
using Entity.CommonEntity;

using ictus.Common.Entity.General;
using ictus.Framework.ASC.Entity.DNF20;

namespace Entity.AttendanceEntities
{
	public class WorkSchedule: EntityBase, IKey
	{
//		============================== Property ==============================
		private DateTime workDate = NullConstant.DATETIME;
		public DateTime WorkDate
		{
			set
			{workDate = value;}
			get
			{return workDate;}	
		}

		private WORKINGDAY_TYPE dayType = WORKINGDAY_TYPE.NULL;
		public WORKINGDAY_TYPE DayType
		{
			set
			{dayType = value;}
			get
			{return dayType;}	
		}

		private TimePeriod aWorkingTime;
		public TimePeriod AWorkingTime
		{
			set
			{aWorkingTime = value;}
			get
			{return aWorkingTime;}	
		}

		private TimePeriod aBreakTime;
		public TimePeriod ABreakTime
		{
			set
			{aBreakTime = value;}
			get
			{return aBreakTime;}	
		}

//		============================== Constructor ==============================
		public WorkSchedule(): base()
		{
			aWorkingTime = new TimePeriod();
			aBreakTime = new TimePeriod();
		}

//		============================== Public Method ==============================
		public override string EntityKey
		{
			get
			{
				return workDate.ToShortDateString();
			}
		}
	}
}
