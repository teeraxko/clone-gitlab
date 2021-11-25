//using System;
//using System.Data;
//using System.Collections;
//
//using ictus.PIS.PI.Entity;
//using Entity.CommonEntity;
//using Entity.AttendanceEntities;
//
//using PTB.BTS.PI.Flow;
//using Flow.AttendanceFlow;
//using PTB.BTS.Common.Flow;
//
//using Facade.PiFacade;
//using Facade.CommonFacade;
//
//using SystemFramework.AppException;
//
//namespace Facade.AttendanceFacade
//{
//	public class EmployeeTimeCardFacade : CommonPIFacadeBase
//	{
//		#region - Private -
//		private EmployeeTimeCardFlow flowEmployeeTimeCard;	
//		private EmployeeWorkScheduleFlow flowEmployeeWorkSchedule;
//		private AgeFlow flowAge;
//		private bool disposed = false;
//		#endregion
//
////		============================== Property ==============================
//		private EmployeeTimeCard objEmployeeTimeCard;
//		public EmployeeTimeCard ObjEmployeeTimeCard
//		{
//			get{return objEmployeeTimeCard;}
//		}
//
//		#region - Datasource -
//		public ArrayList DataSourceAttendanceStatus
//		{
//			get
//			{
//				AttendanceStatusFlow flowAttendanceStatus = new AttendanceStatusFlow();
//				AttendanceStatusList attendanceStatusList = new AttendanceStatusList(GetCompany());
//				flowAttendanceStatus.FillMTBList(attendanceStatusList);
//				return attendanceStatusList.GetArrayList();
//			}
//		}
//		#endregion
//
////		============================== Constructor ==============================
//		public EmployeeTimeCardFacade() : base()
//		{
//			flowEmployeeTimeCard = new EmployeeTimeCardFlow();
//			flowEmployeeWorkSchedule = new EmployeeWorkScheduleFlow();
//		}
//
////		============================== Method ==============================
//		public YearMonth CalculateAge(DateTime birthDate)
//		{
//			flowAge = new AgeFlow();
//			return flowAge.CalculateAge(birthDate);
//		}
//
//		public WorkSchedule GetWorkSchedule(Employee aEmployee, DateTime forDate)
//		{
//			return flowEmployeeWorkSchedule.GetWorkSchedule(aEmployee, forDate);
//		}
//
//		public bool DisplayEmployeeTimeCard(string employeeNo, DateTime forDate)
//		{
//			Employee employee = GetEmployee(employeeNo);
//			YearMonth yearMonth = new YearMonth(forDate);
//			objEmployeeTimeCard = new EmployeeTimeCard(employee, yearMonth);
//			employee = null;
//
//			return flowEmployeeTimeCard.FillEmployeeTimeCard(ref objEmployeeTimeCard);		
//		}
//
//		public bool InsertEmployeeTimeCard(TimeCard value)
//		{
//			if (objEmployeeTimeCard.Contain(value))
//			{
//				throw new DuplicateException("EmployeeTimeCardFacade");
//			}
//			else
//			{
//				if (flowEmployeeTimeCard.InsertEmployeeTimeCard(value, objEmployeeTimeCard.Employee))
//				{
//					objEmployeeTimeCard.Add(value);
//					return true;
//				}
//				return false;
//			}
//		}
//
//		public bool UpdateEmployeeTimeCard(TimeCard value)
//		{
//			if (flowEmployeeTimeCard.UpdateEmployeeTimeCard(value, objEmployeeTimeCard.Employee))
//			{
//				objEmployeeTimeCard[value.EntityKey] = value;
//				return true;
//			}
//			return false;	
//		}
//		
//		public bool DeleteEmployeeTimeCard(TimeCard value)
//		{
//			if (flowEmployeeTimeCard.DeleteEmployeeTimeCard(value, objEmployeeTimeCard.Employee))
//			{
//				objEmployeeTimeCard.Remove(value);
//				return true;
//			}
//			return false;		
//		}
//
//		#region IDisposable Members
//		protected override void Dispose(bool disposing)
//		{
//			if(!this.disposed)
//			{
//				try
//				{
//					if(disposing)
//					{
//						flowEmployeeTimeCard.Dispose();
//						objEmployeeTimeCard.Dispose();
//
//						flowEmployeeTimeCard = null;
//						objEmployeeTimeCard = null;
//						
//					}
//					this.disposed = true;
//				}
//				finally
//				{
//					base.Dispose(disposing);
//				}
//			}
//		}
//		#endregion
//	}
//}
