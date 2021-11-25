//using System;
//using System.Collections;
//
//using ictus.PIS.PI.Entity;
//using Entity.CommonEntity;
//using Entity.AttendanceEntities;
//
//using Flow.AttendanceFlow;
//
//using Facade.PiFacade;
//
//namespace Facade.AttendanceFacade
//{
//	public class EmployeeTripFacade : CommonPIFacadeBase
//	{
//		#region - Private - 
//			private EmployeeTripFlow flowEmployeeTrip;
//			private bool disposed = false;
//		#endregion
//
////		============================== Property ==============================
//		private EmployeeOneDayTripBenefit objOneDayTrip;
//		public EmployeeOneDayTripBenefit ObjOneDayTrip
//		{
//			get
//			{
//				return objOneDayTrip;
//			}
//		}
//		
//		private EmployeeOvernightTripBenefitList objOvernightTripList;
//		public EmployeeOvernightTripBenefitList ObjOvernightTripList
//		{
//			get
//			{
//				return objOvernightTripList;
//			}
//		}
//
//		private Employee employee;
//		public Employee Employee
//		{
//			get
//			{
//				return employee;
//			}
//		}
//
//		private TripLocationList tripLocationList;
//		public ArrayList LocationDataSource
//		{
//			get
//			{
//				return tripLocationList.GetArrayList();
//			}
//		}
//
////		============================== Constructor ==============================
//		public EmployeeTripFacade() : base()
//		{
//			flowEmployeeTrip = new EmployeeTripFlow(GetCompany());
//
//			AttendanceComboboxFlow flowAttendanceCombobox = new AttendanceComboboxFlow();
//			tripLocationList = flowAttendanceCombobox.GetLocation(GetCompany());
//			flowAttendanceCombobox = null;
//		}
//
////		============================== Private Method ==============================
////		private void insertLocation(TripLocation value)
////		{		
////			if (tripLocationList[value.EntityKey] == null)
////			{
////				AttendanceComboboxFlow flowAttendanceCombobox = new AttendanceComboboxFlow();
////				flowAttendanceCombobox.InsertLocation(ref tripLocationList, value);
////				flowAttendanceCombobox = null;			
////			}
////		}
//
////		============================== Public Method ==============================
//		public bool DisplayEmployeeTrip(string employeeNo, DateTime forYearMonth)
//		{
//			employee = GetEmployee(employeeNo);
//
//			objOneDayTrip = new EmployeeOneDayTripBenefit(employee, forYearMonth);
//			objOvernightTripList = new EmployeeOvernightTripBenefitList(employee, forYearMonth);
//
//			return flowEmployeeTrip.FillEmployeeTrip(ref objOneDayTrip, ref objOvernightTripList);
//		}
//
//		public bool InsertEmployeeTrip(OneDayTripBenefit aOneDayTripBenefit)
//		{
//			insertLocation(aOneDayTripBenefit.AOneDayTrip.ATripLocation);
//			return flowEmployeeTrip.InsertEmployeeTrip(ref objOneDayTrip, aOneDayTripBenefit);
//		}
//
//		public bool InsertEmployeeTrip(EmployeeOvernightTripBenefit aEmployeeOvernightTripBenefit)
//		{
//			insertLocation(aEmployeeOvernightTripBenefit.AOvernightTrip.ATripLocation);
//			return flowEmployeeTrip.InsertEmployeeTrip(ref objOvernightTripList, aEmployeeOvernightTripBenefit);
//		}
//
//		public bool UpdateEmployeeTrip(OneDayTripBenefit aOneDayTripBenefit)
//		{
//			insertLocation(aOneDayTripBenefit.AOneDayTrip.ATripLocation);
//			return flowEmployeeTrip.UpdateEmployeeTrip(ref objOneDayTrip, aOneDayTripBenefit);
//		}
//
//		public bool UpdateEmployeeTrip(EmployeeOvernightTripBenefit aEmployeeOvernightTripBenefit)
//		{
//			insertLocation(aEmployeeOvernightTripBenefit.AOvernightTrip.ATripLocation);
//			return flowEmployeeTrip.UpdateEmployeeTrip(ref objOvernightTripList, aEmployeeOvernightTripBenefit);
//		}
//
//		public bool DeleteEmployeeTrip(OneDayTripBenefit aOneDayTripBenefit)
//		{
//			return flowEmployeeTrip.DeleteEmployeeTrip(ref objOneDayTrip, aOneDayTripBenefit);
//		}
//
//		public bool DeleteEmployeeTrip(EmployeeOvernightTripBenefit aEmployeeOvernightTripBenefit)
//		{
//			return flowEmployeeTrip.DeleteEmployeeTrip(ref objOvernightTripList, aEmployeeOvernightTripBenefit);
//		}
//
//		public bool CalculateBenefit(ref OneDayTripBenefit aOneDayTripBenefit, Employee aEmployee)
//		{
//			return flowEmployeeTrip.CalculateBenefit(ref aOneDayTripBenefit, aEmployee);
//		}
//
////		public bool CalculateBenefit(ref EmployeeOvernightTripBenefit aEmployeeOvernightTripBenefit)
////		{
////			return flowEmployeeTrip.CalculateBenefit(ref aEmployeeOvernightTripBenefit);
////		}
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
//						flowEmployeeTrip.Dispose();
//						objOneDayTrip.Dispose();
//						objOvernightTripList.Dispose();
//						tripLocationList.Dispose();
//
//						flowEmployeeTrip = null;
//						objOneDayTrip = null;
//						objOvernightTripList = null;
//						tripLocationList = null;
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