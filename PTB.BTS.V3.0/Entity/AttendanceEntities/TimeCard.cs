using System;

using Entity.CommonEntity;

using ictus.Common.Entity.General;
using ictus.Framework.ASC.Entity.DNF20;

namespace Entity.AttendanceEntities
{
	public class TimeCard : EntityBase, IKey
	{
//		============================== Property ==============================
		private DateTime cardDate = NullConstant.DATETIME;
		public DateTime CardDate
		{
			get{return cardDate;}
			set{cardDate = value;}
		}

		private WORKINGDAY_TYPE dayType = WORKINGDAY_TYPE.NULL;
		public WORKINGDAY_TYPE DayType
		{
			get{return dayType;}
			set{dayType = value;}
		}

		private TimePeriod aTimePeriod;
		public TimePeriod ATimePeriod
		{
			get{return aTimePeriod;}
			set{aTimePeriod = value;}
		}

		private AttendanceStatus aBeforeBreakStatus;
		public AttendanceStatus ABeforeBreakStatus
		{
			get{return aBeforeBreakStatus;}
			set{aBeforeBreakStatus = value;}
		}

		private AttendanceStatus aAfterBreakStatus;
		public AttendanceStatus AAfterBreakStatus
		{
			get{return aAfterBreakStatus;}
			set{aAfterBreakStatus = value;}
		}

//		============================== Constructor ==============================
		public TimeCard() : base()
		{
			aTimePeriod = new TimePeriod();
			aBeforeBreakStatus = new AttendanceStatus();
			aAfterBreakStatus = new AttendanceStatus();
		}

//		============================== Public Method ==============================
		public override string EntityKey
		{
			get
			{
				return cardDate.ToShortDateString();
			}
		}
	}
}
