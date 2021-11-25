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
	public class EmployeeWorkAttendanceFacade : EmployeeAttendanceFacadeBase
	{
		#region - Private -
		private EmployeeWorkAttedanceFlow flowEmployeeWorkAttedance;
		private EmployeeWorkScheduleFlow flowEmployeeWorkSchedule;
		#endregion

		#region - Datasource -
		public ArrayList DataSourceAttendanceStatus
		{
			get
			{
				AttendanceStatusFlow flowAttendanceStatus = new AttendanceStatusFlow();
				AttendanceStatusList attendanceStatusList = new AttendanceStatusList(GetCompany());
				flowAttendanceStatus.FillMTBList(attendanceStatusList);
				return attendanceStatusList.GetArrayList();
			}
		}
		#endregion

//		============================== Property ==============================
		private EmployeeWorkSchedule objEmployeeWorkSchedule;
		public EmployeeWorkSchedule ObjEmployeeWorkSchedule
		{
			get{return objEmployeeWorkSchedule;}
			set{objEmployeeWorkSchedule = value;}
		}

		private EmployeeTimeCard objEmployeeTimeCard;
		public EmployeeTimeCard ObjEmployeeTimeCard
		{
			get{return objEmployeeTimeCard;}
			set{objEmployeeTimeCard = value;}
		}

//		============================== Constructor ==============================
		public EmployeeWorkAttendanceFacade() : base()
		{
			flowEmployeeWorkAttedance = new EmployeeWorkAttedanceFlow();
		}

//		============================== Public Method ==============================
		public WorkSchedule GetWorkSchedule(DateTime forDate)
		{
			flowEmployeeWorkSchedule = new EmployeeWorkScheduleFlow();
			return flowEmployeeWorkSchedule.GetWorkSchedule(Employee, forDate);
		}

		public bool DisplayEmployeeWorkAttendance(DateTime forDate)
		{	
			objEmployeeTimeCard = new EmployeeTimeCard(Employee, forDate);
			objEmployeeWorkSchedule = new EmployeeWorkSchedule(Employee, forDate);
			return flowEmployeeWorkAttedance.FillEmployeeWorkAttedance(ref objEmployeeWorkSchedule, ref objEmployeeTimeCard);
		}

		public bool InsertEmployeeWorkAttendance(WorkSchedule aWorkSchedule, TimeCard aTimeCard)
		{
			if (objEmployeeWorkSchedule.Contain(aWorkSchedule) || objEmployeeTimeCard.Contain(aTimeCard))
			{
				throw new DuplicateException("EmployeeWorkAttendanceFacade");
			}
			else
			{
				if (flowEmployeeWorkAttedance.InsertEmployeeWorkAttedance(aWorkSchedule, aTimeCard, objEmployeeWorkSchedule.Employee))
				{
					objEmployeeWorkSchedule.Add(aWorkSchedule);
					objEmployeeTimeCard.Add(aTimeCard);
					return true;
				}
				return false;
			}
		}

		public bool UpdateEmployeeWorkAttendance(WorkSchedule aWorkSchedule, TimeCard aTimeCard)
		{
			if (flowEmployeeWorkAttedance.UpdateEmployeeWorkAttedance(aWorkSchedule, aTimeCard, objEmployeeWorkSchedule.Employee))
			{
				objEmployeeWorkSchedule[aWorkSchedule.EntityKey] = aWorkSchedule;
				objEmployeeTimeCard[aTimeCard.EntityKey] = aTimeCard;
				return true;
			}
			return false;	
		}
		
		public bool DeleteEmployeeWorkAttendance(WorkSchedule aWorkSchedule, TimeCard aTimeCard)
		{
			if (flowEmployeeWorkAttedance.DeleteEmployeeWorkAttedance(aWorkSchedule, aTimeCard, objEmployeeWorkSchedule.Employee))
			{
				objEmployeeWorkSchedule.Remove(aWorkSchedule);
				objEmployeeTimeCard.Remove(aTimeCard);
				return true;
			}
			return false;		
		}
	}
}
