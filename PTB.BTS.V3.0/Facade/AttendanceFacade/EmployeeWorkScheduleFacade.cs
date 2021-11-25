//using System;
//using System.Data;
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
//	public class EmployeeWorkScheduleFacade : CommonPIFacadeBase
//	{
//		#region - Private -
//		private EmployeeWorkScheduleFlow flowEmployeeWorkSchedule;	
//		private AgeFlow flowAge;
//		private bool disposed = false;
//		#endregion
//
////		============================== Property ==============================
//		private EmployeeWorkSchedule objEmployeeWorkSchedule;
//		public EmployeeWorkSchedule ObjEmployeeWorkSchedule
//		{
//			get{return objEmployeeWorkSchedule;}
//		}
//
////		============================== Constructor ==============================
//		public EmployeeWorkScheduleFacade() : base()
//		{
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
//		public bool DisplayEmployeeWorkSchedule(string employeeNo, DateTime forDate)
//		{
//			Employee employee = GetEmployee(employeeNo);
//			objEmployeeWorkSchedule = new EmployeeWorkSchedule(employee, forDate);
//			employee = null;
//
//			return flowEmployeeWorkSchedule.FillEmployeeWorkSchedule(ref objEmployeeWorkSchedule);		
//		}
//
//		public bool InsertEmployeeWorkSchedule(WorkSchedule value)
//		{
//			if (objEmployeeWorkSchedule.Contain(value))
//			{
//				throw new DuplicateException("EmployeeWorkScheduleFacade");
//			}
//			else
//			{
//				if (flowEmployeeWorkSchedule.InsertEmployeeWorkSchedule(value, objEmployeeWorkSchedule.Employee))
//				{
//					objEmployeeWorkSchedule.Add(value);
//					return true;
//				}
//				return false;
//			}
//		}
//
//		public bool UpdateEmployeeWorkSchedule(WorkSchedule value)
//		{
//			if (flowEmployeeWorkSchedule.UpdateEmployeeWorkSchedule(value, objEmployeeWorkSchedule.Employee))
//			{
//				objEmployeeWorkSchedule[value.EntityKey] = value;
//				return true;
//			}
//			return false;	
//		}
//		
//		public bool DeleteEmployeeWorkSchedule(WorkSchedule value)
//		{
//			if (flowEmployeeWorkSchedule.DeleteEmployeeWorkSchedule(value, objEmployeeWorkSchedule.Employee))
//			{
//				objEmployeeWorkSchedule.Remove(value);
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
//						flowEmployeeWorkSchedule.Dispose();
//						objEmployeeWorkSchedule.Dispose();
//
//						flowEmployeeWorkSchedule = null;
//						objEmployeeWorkSchedule = null;
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
//
//	}
//}
