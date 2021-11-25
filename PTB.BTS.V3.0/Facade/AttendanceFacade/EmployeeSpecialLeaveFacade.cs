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
	public class EmployeeSpecialLeaveFacade : EmployeeAttendanceFacadeBase
	{
		#region - Private -
		private EmployeeSpecialLeaveFlow flowEmployeeSpecialLeave;
		private EmployeeWorkScheduleFlow flowEmployeeWorkSchedule;
		private EmployeeLeaveFlow flowEmployeeLeave;
		private EmployeeTimeCardFlow flowEmployeeTimeCard;
		#endregion

		//		============================== Property ==============================
		private EmployeeSpecialLeave objEmployeeSpecialLeave;
		public EmployeeSpecialLeave ObjEmployeeSpecialLeave
		{
			get{return objEmployeeSpecialLeave;}
		}

		private EmployeeSpecialLeave objSpecialLeaveYear;
		public EmployeeSpecialLeave ObjSpecialLeaveYear
		{
			get{return objSpecialLeaveYear;}
		}

		#region - Data source -
		public ArrayList DataSourceSpecialLeave
		{
			get
			{
				SpecialLeaveFlow flowSpecialLeave = new SpecialLeaveFlow();
				KindOfSpecialLeaveList specialLeaveList = new KindOfSpecialLeaveList(GetCompany());
				flowSpecialLeave.FillMTBData(specialLeaveList);
				flowSpecialLeave = null;
				return specialLeaveList.GetArrayList();			
			}		
		}
		#endregion

		//		============================== Constructor ==============================
		public EmployeeSpecialLeaveFacade() : base()
		{
			flowEmployeeSpecialLeave = new EmployeeSpecialLeaveFlow();
			flowEmployeeLeave = new EmployeeLeaveFlow();
			flowEmployeeWorkSchedule = new EmployeeWorkScheduleFlow();
			flowEmployeeTimeCard = new EmployeeTimeCardFlow();
		}

		//		============================== Public Method ==============================
		public bool DisplayEmployeeSpecialLeave(DateTime forDate)
		{	
			objEmployeeSpecialLeave = new EmployeeSpecialLeave(Employee, forDate);
			objSpecialLeaveYear = new EmployeeSpecialLeave(Employee, forDate);

			if (flowEmployeeSpecialLeave.FillEmployeeSpecialLeaveYear(ref objSpecialLeaveYear))
			{
				return flowEmployeeSpecialLeave.FillEmployeeSpecialLeave(ref objEmployeeSpecialLeave);				
			}
			return false;
		}

        public bool DisplayAllEmployeeSpecialLeave()
        {
            objEmployeeSpecialLeave = new EmployeeSpecialLeave(Employee, DateTime.Today);
            return flowEmployeeSpecialLeave.FillAllEmployeeSpecialLeaveYear(objEmployeeSpecialLeave);
        }

		public SpecialLeave GetspecialLeave(DateTime forDate)
		{
			return flowEmployeeSpecialLeave.GetSpecialLeave(forDate, objEmployeeSpecialLeave.Employee);
		}

		public bool FillWorkSchedule(ref WorkSchedule value)
		{
			return flowEmployeeWorkSchedule.FillWorkSchedule(ref value, objEmployeeSpecialLeave.Employee);
		}

		public bool FillTimeCard(ref TimeCard value)
		{
			return flowEmployeeTimeCard.FillTimeCard(ref value, objEmployeeSpecialLeave.Employee);
		}

		public bool GetCheckEmployeeWorkSchedule(TimePeriod timePeriod)
		{
			return flowEmployeeLeave.GetCheckEmployeeWorkSchedule(timePeriod, objEmployeeSpecialLeave.Employee);
		}

		public bool InsertSpecialLeave(SpecialLeave value)
		{
			if (objEmployeeSpecialLeave.Contain(value))
			{
				throw new DuplicateException("EmployeeSpecialLeaveFacade");
			}
			else
			{
				WorkSchedule workSchedule = new WorkSchedule();
				workSchedule = flowEmployeeLeave.GetLeaveWorkSchedule(value.LeaveDate, objEmployeeSpecialLeave.Employee);

				if(workSchedule.DayType != WORKINGDAY_TYPE.HOLIDAY)
				{
					TimeCard timeCard = new TimeCard();
					timeCard = flowEmployeeSpecialLeave.GetLeaveTimecard(value, objEmployeeSpecialLeave.Employee);
				
					if(flowEmployeeSpecialLeave.InsertSpecialLeave(value, timeCard, objEmployeeSpecialLeave.Employee))
					{
						objEmployeeSpecialLeave.Add(value);
						return true;
					}
				}
				return false;
			}
		}

		public bool UpdateSpecialLeave(SpecialLeave value)
		{
			TimeCard timeCard = new TimeCard();
			timeCard = flowEmployeeSpecialLeave.GetLeaveTimecard(value, objEmployeeSpecialLeave.Employee);

			if (flowEmployeeSpecialLeave.UpdateSpecialLeave(value, timeCard, objEmployeeSpecialLeave.Employee))
			{
				objEmployeeSpecialLeave[value.EntityKey] = value;
				return true;
			}
			return false;
		}
		
		public bool DeleteSpecialLeave(SpecialLeave value)
		{
			if(flowEmployeeSpecialLeave.DeleteSpecialLeave(value, objEmployeeSpecialLeave.Employee))
			{
				objEmployeeSpecialLeave.Remove(value);
				return true;
			}
			return false;
		}		
	}
}
