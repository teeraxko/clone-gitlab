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
	public class EmployeeSickLeaveFacade : EmployeeAttendanceFacadeBase
	{
		#region - Private -
		private EmployeeSickLeaveFlow flowEmployeeSickLeave;
		private EmployeeWorkScheduleFlow flowEmployeeWorkSchedule;
		private EmployeeLeaveFlow flowEmployeeLeave;
		private EmployeeTimeCardFlow flowEmployeeTimeCard;
		#endregion

//		============================== Property ==============================
		private EmployeeSickLeave objEmployeeSickLeave;
		public EmployeeSickLeave ObjEmployeeSickLeave
		{
			get{return objEmployeeSickLeave;}
		}

		private EmployeeSickLeave objSickLeaveYear;
		public EmployeeSickLeave ObjSickLeaveYear
		{
			get{return objSickLeaveYear;}
		}

		#region - Data source -
		public ArrayList DataSourceDisease
		{
			get
			{
				DiseaseFlow flowDisease = new DiseaseFlow();
				DiseaseList diseaseList = new DiseaseList();
				flowDisease.FillMTBList(diseaseList);
				flowDisease = null;
				return diseaseList.GetArrayList();			
			}		
		}
		#endregion

//		============================== Constructor ==============================
		public EmployeeSickLeaveFacade() : base()
		{
			flowEmployeeSickLeave = new EmployeeSickLeaveFlow();
			flowEmployeeLeave = new EmployeeLeaveFlow();
			flowEmployeeWorkSchedule = new EmployeeWorkScheduleFlow();
			flowEmployeeTimeCard = new EmployeeTimeCardFlow();			
		}

//		============================== Public Method ==============================
		public bool DisplayEmployeeSickLeave(DateTime forDate)
		{	
			objEmployeeSickLeave = new EmployeeSickLeave(Employee, forDate);
			objSickLeaveYear = new EmployeeSickLeave(Employee, forDate);
			 
			if (flowEmployeeSickLeave.FillEmployeeSickLeaveYear(ref objSickLeaveYear))
			{
				return flowEmployeeSickLeave.FillEmployeeSickLeave(ref objEmployeeSickLeave);				
			}
			return false;
		}

		public SickLeave GetSickLeave(DateTime forDate)
		{
			return flowEmployeeSickLeave.GetSickLeave(forDate, objEmployeeSickLeave.Employee);
		}

		public bool FillWorkSchedule(ref WorkSchedule value)
		{
			return flowEmployeeWorkSchedule.FillWorkSchedule(ref value, objEmployeeSickLeave.Employee);
		}

		public bool FillTimeCard(ref TimeCard value)
		{
			return flowEmployeeTimeCard.FillTimeCard(ref value, objEmployeeSickLeave.Employee);
		}

		public bool GetCheckEmployeeWorkSchedule(TimePeriod timePeriod)
		{
			return flowEmployeeLeave.GetCheckEmployeeWorkSchedule(timePeriod, objEmployeeSickLeave.Employee);
		}

		public bool InsertSickLeave(SickLeave value)
		{
			if (objEmployeeSickLeave.Contain(value))
			{
				throw new DuplicateException("EmployeeSickLeaveFacade");
			}
			else
			{
				WorkSchedule workSchedule = new WorkSchedule();
				workSchedule = flowEmployeeLeave.GetLeaveWorkSchedule(value.LeaveDate, objEmployeeSickLeave.Employee);

				if(workSchedule.DayType != WORKINGDAY_TYPE.HOLIDAY)
				{
					TimeCard timeCard = new TimeCard();
					timeCard = flowEmployeeSickLeave.GetLeaveTimecard(value, objEmployeeSickLeave.Employee);
					
					if(flowEmployeeSickLeave.InsertSickLeave(value, timeCard, objEmployeeSickLeave.Employee))
					{
						objEmployeeSickLeave.Add(value);
						objSickLeaveYear.Add(value);
						return true;
					}
				}
				return false;
			}
		}

		public bool UpdateSickLeave(SickLeave value)
		{
			TimeCard timeCard = new TimeCard();
			timeCard = flowEmployeeSickLeave.GetLeaveTimecard(value, objEmployeeSickLeave.Employee);

			if (flowEmployeeSickLeave.UpdateSickLeave(value, timeCard, objEmployeeSickLeave.Employee))
			{
				objEmployeeSickLeave[value.EntityKey] = value;
				objSickLeaveYear[value.EntityKey] = value;
				return true;
			}
			return false;
		}
		
		public bool DeleteSickLeave(SickLeave value)
		{
			if(flowEmployeeSickLeave.DeleteSickLeave(value, objEmployeeSickLeave.Employee))
			{
				objEmployeeSickLeave.Remove(value);
				objSickLeaveYear.Remove(value);
				return true;
			}
			return false;
		}		
	}
}
