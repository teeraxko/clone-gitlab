using System;

using ictus.Common.Entity.General;
using Entity.CommonEntity;

namespace Entity.AttendanceEntities
{
	public class AnnualLeaveDay : LeaveBase
	{
		//==============================   Property    ==============================
		private int forYear = NullConstant.INT;
		public int ForYear
		{
			get{return forYear;}
			set{forYear = value;}
		}

		private LeaveReason reason;
		public LeaveReason Reason
		{
			get{return reason;}
			set{reason = value;}
		}

		public decimal DaysUsed
		{
			get
			{
				switch(periodStatus)
				{
					case LEAVE_PERIOD_TYPE.ONE_DAY :
					{
						return 1;
					}
					case LEAVE_PERIOD_TYPE.AM :
					case LEAVE_PERIOD_TYPE.PM :
					{
						return 0.5m;
					}
					default :
					{
						return 0;
					}
				}
			}
		}

		private LEAVE_YEAR_STATUS_TYPE leaveYearStatus;
		public LEAVE_YEAR_STATUS_TYPE LeaveYearStatus
		{
			get{return leaveYearStatus;}
			set{leaveYearStatus = value;}
		}

		//==============================  Constructor  ==============================
		public AnnualLeaveDay(DateTime leaveDate) : base(leaveDate)
		{
			reason = new LeaveReason();
		}

		//============================== Public Method ==============================
		public AnnualLeaveDay Clone()
		{
			AnnualLeaveDay annualLeaveDay = new AnnualLeaveDay(this.LeaveDate);
			annualLeaveDay.ForYear = this.ForYear;
			annualLeaveDay.PeriodStatus = this.PeriodStatus;
			annualLeaveDay.Reason = this.Reason;
			return annualLeaveDay;
		}
	}
}