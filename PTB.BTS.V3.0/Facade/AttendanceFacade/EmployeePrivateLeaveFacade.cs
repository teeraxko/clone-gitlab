using System;
using System.Data;
using System.Collections;
using SystemFramework.AppException;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;
using Entity.AttendanceEntities;

using PTB.BTS.PI.Flow;
using PTB.BTS.Common.Flow;
using Flow.AttendanceFlow;

using Facade.PiFacade;

namespace Facade.AttendanceFacade
{
	public class EmployeePrivateLeaveFacade : EmployeeAttendanceFacadeBase
	{
		#region - Private -
		private EmployeePrivateLeaveFlow flowEmployeePrivateLeave;
		private EmployeeWorkScheduleFlow flowEmployeeWorkSchedule;
		private EmployeeLeaveFlow flowEmployeeLeave;
		private EmployeeTimeCardFlow flowEmployeeTimeCard;
		#endregion

//		============================== Property ==============================
		private EmployeePrivateLeave objEmployeePrivateLeave;
		public EmployeePrivateLeave ObjEmployeePrivateLeave
		{
			get{return objEmployeePrivateLeave;}
		}

		private EmployeePrivateLeave objPrivateLeaveYear;
		public EmployeePrivateLeave ObjPrivateLeaveYear
		{
			get{return objPrivateLeaveYear;}
		}

		#region - Data source -
		public ArrayList DataSourceLeaveReason
		{
			get
			{
				LeaveReasonFlow flowLeaveReason = new LeaveReasonFlow();
				LeaveReasonList leaveReasonList = new LeaveReasonList();
				flowLeaveReason.FillMTBList(leaveReasonList);
				flowLeaveReason = null;
				return leaveReasonList.GetArrayList();			
			}		
		}
		#endregion

//		============================== Constructor ==============================
		public EmployeePrivateLeaveFacade() : base()
		{
			flowEmployeePrivateLeave = new EmployeePrivateLeaveFlow();
			flowEmployeeWorkSchedule = new EmployeeWorkScheduleFlow();
			flowEmployeeLeave = new EmployeeLeaveFlow();
			flowEmployeeTimeCard = new EmployeeTimeCardFlow();
		}

//		============================== Public Method ==============================
		public bool DisplayEmployeePrivateLeave(DateTime forDate)
		{	
			objEmployeePrivateLeave = new EmployeePrivateLeave(Employee, forDate);
			objPrivateLeaveYear = new EmployeePrivateLeave(Employee, forDate);
			if (flowEmployeePrivateLeave.FillEmployeePrivateLeaveYear(ref objPrivateLeaveYear))
			{
				return flowEmployeePrivateLeave.FillEmployeePrivateLeave(ref objEmployeePrivateLeave);
			}
			return false;
		}

		public PrivateLeave GetPrivateLeave(DateTime forDate)
		{
			return flowEmployeePrivateLeave.GetPrivateLeave(forDate, objEmployeePrivateLeave.Employee);
		}

		public bool FillWorkSchedule(ref WorkSchedule value)
		{
			return flowEmployeeWorkSchedule.FillWorkSchedule(ref value, objEmployeePrivateLeave.Employee);
		}

		public bool FillTimeCard(ref TimeCard value)
		{
			return flowEmployeeTimeCard.FillTimeCard(ref value, objEmployeePrivateLeave.Employee);
		}

		public bool GetCheckEmployeeWorkSchedule(TimePeriod timePeriod)
		{
			return flowEmployeeLeave.GetCheckEmployeeWorkSchedule(timePeriod, objEmployeePrivateLeave.Employee);
		}

		public bool InsertPrivateLeave(PrivateLeave value)
		{
			if (objEmployeePrivateLeave.Contain(value))
			{
				throw new DuplicateException("EmployeePrivateLeaveFacade");
			}
			else
			{
				WorkSchedule workSchedule = new WorkSchedule();
				workSchedule = flowEmployeeLeave.GetLeaveWorkSchedule(value.LeaveDate, objEmployeePrivateLeave.Employee);

				if(workSchedule.DayType != WORKINGDAY_TYPE.HOLIDAY)
				{
					TimeCard timeCard = new TimeCard();
					timeCard = flowEmployeePrivateLeave.GetLeaveTimecard(value, objEmployeePrivateLeave.Employee);
				
					if(flowEmployeePrivateLeave.InsertPrivateLeave(value, timeCard, objEmployeePrivateLeave.Employee))
					{
						objEmployeePrivateLeave.Add(value);
						objPrivateLeaveYear.Add(value);
						return true;
					}
				}	
				return false;
			}
		}

		public bool UpdatePrivateLeave(PrivateLeave value)
		{
			TimeCard timeCard = new TimeCard();
			timeCard = flowEmployeePrivateLeave.GetLeaveTimecard(value, objEmployeePrivateLeave.Employee);

			if (flowEmployeePrivateLeave.UpdatePrivateLeave(value, timeCard, objEmployeePrivateLeave.Employee))
			{
				objEmployeePrivateLeave[value.EntityKey] = value;
				objPrivateLeaveYear[value.EntityKey] = value;
				return true;
			}
			return false;
		}
		
		public bool DeletePrivateLeave(PrivateLeave value)
		{
			if(flowEmployeePrivateLeave.DeletePrivateLeave(value, objEmployeePrivateLeave.Employee))
			{
				objEmployeePrivateLeave.Remove(value);
				objPrivateLeaveYear.Remove(value);
				return true;
			}
			return false;
		}		
	}
}
