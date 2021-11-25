using System;
using System.Collections;

using Entity.ContractEntities;
using ictus.PIS.PI.Entity;

using PTB.BTS.Contract.Flow;
using Flow.AttendanceFlow;

using Facade.PiFacade;

namespace Facade.AttendanceFacade
{
	public class GenEmpScheduleFacadeBase : CommonPIFacadeBase
	{
		#region - Private -
			protected GenerateWorkScheduleFlowBase flowGenerateWorkSchedule;
		#endregion

		#region - Property -
			public EmployeeList ListBoxCandidate;

			private EmployeeList listEmployeeList;
			public EmployeeList ListEmployeeList
			{
				get
				{
					return listEmployeeList;
				}
				set
				{
					listEmployeeList = value;
				}
			}

			protected EmployeeList selectedEmployeeList;
			public EmployeeList SelectedEmployeeList
			{
				get
				{
					return selectedEmployeeList;
				}
				set
				{
					selectedEmployeeList = value;
				}
			}

			private ServiceStaff conditionSelectedEmployee;
			public PositionType ConditionPositionType
			{
				get
				{
					return conditionSelectedEmployee.APosition.APositionType;
				}
				set
				{
					conditionSelectedEmployee.APosition.APositionType = value;
				}
			}

			public ServiceStaffType ConditionServiceStaffType
			{
				get
				{
					return conditionSelectedEmployee.AServiceStaffType;
				}
				set
				{
					conditionSelectedEmployee.AServiceStaffType = value;
				}
			}

			public Customer ConditionCustomer
			{
				get
				{
					return conditionSelectedEmployee.ACurrentContract.ACustomer;
				}
				set
				{
					conditionSelectedEmployee.ACurrentContract.ACustomer = value;
				}
			}

			public CustomerDepartment ConditionCustomerDepartment
			{
				get
				{
					return conditionSelectedEmployee.ACurrentContract.ACustomerDepartment;
				}
				set
				{
					conditionSelectedEmployee.ACurrentContract.ACustomerDepartment = value;
				}
			}
		#endregion

		#region - DataSource -
			public ArrayList DataSourceServiceStaffType
			{
				get
				{
					ServiceStaffTypeFlow flowServiceStaffType = new ServiceStaffTypeFlow();
					return flowServiceStaffType.GetServiceStaffTypeList(GetCompany()).GetArrayList();
				}
			}

			public ArrayList DataSourceCustomer
			{
				get
				{
					CustomerFlow flowCustomer = new CustomerFlow();
					return flowCustomer.GetCustomerList(GetCompany()).GetArrayList();
				}
			}
	
			public ArrayList DataSourceCustomerDepartment(Customer value)
			{
				CustomerDepartmentFlow flowCustomerDepartment = new CustomerDepartmentFlow();
				return flowCustomerDepartment.GetCustomerDepartmentList(value, GetCompany()).GetArrayList();
			}
		#endregion

//		============================== Constructor ==============================
		public GenEmpScheduleFacadeBase() : base()
		{
			selectedEmployeeList = new EmployeeList(GetCompany());
			conditionSelectedEmployee = new ServiceStaff(GetCompany());
			conditionSelectedEmployee.ACurrentContract = new ServiceStaffContract(GetCompany());

			listEmployeeList = new EmployeeList(GetCompany());
			selectedEmployeeList = new EmployeeList(GetCompany());
			conditionSelectedEmployee = new ServiceStaff(GetCompany());
			ListBoxCandidate = new EmployeeList(GetCompany());
		}
		
		#region - Private Method -
		#endregion

		//============================== Public Method ==============================
		public void ClearCondition()
		{
			conditionSelectedEmployee.APosition.APositionType = null;
			conditionSelectedEmployee.AServiceStaffType = null;
			conditionSelectedEmployee.ACurrentContract.ACustomer = null;
			conditionSelectedEmployee.ACurrentContract.ACustomerDepartment = null;
		}
		
		public bool FillEmployeeList(DateTime effectiveDate)
		{
			return flowGenerateWorkSchedule.FillEmployeeList(listEmployeeList, effectiveDate);
		}

		public bool FillEmployeeList(PositionType condition, DateTime effectiveDate)
		{
			return flowGenerateWorkSchedule.FillEmployeeList(listEmployeeList, condition, effectiveDate);
		}

		public bool FillEmployeeList(ServiceStaffType condition, DateTime effectiveDate)
		{
			return flowGenerateWorkSchedule.FillEmployeeList(listEmployeeList, condition, effectiveDate);
		}

		public virtual bool GenEmployeeListSchedule(DateTime value)
		{
			return false;
		}
	}
}










//		#region - Private - 
//			private GenEmpWorkScheduleFlow flowGenEmpWorkSchedule;
//			private PositionTypeList positionTypeList;
//			private PositionTypeFlow flowPositionType;
//			private bool disposed = false;
//		#endregion
//
////		============================== Property ==============================
//		public EmployeeList AllEmployeeList
//		{
//			get
//			{
//				return flowGenEmpWorkSchedule.AllEmployeeList;
//			}
//		}
//		
//		public EmployeeList SelectEmployeeList
//		{
//			get
//			{
//				return flowGenEmpWorkSchedule.SelectEmployeeList;
//			}
//		}
//
////		============================== Select Data ==============================
//		public DateTime SelectYearMonth
//		{
//			set
//			{
//				flowGenEmpWorkSchedule.SelectYearMonth = value;
//			}
//		}
//
//		private bool selectForAll;
//		public bool SelectForAll
//		{
//			set
//			{
//				selectForAll = value;
//			}
//		}
//
//		private PositionType selectPositionType;
//		public PositionType SelectPositionType
//		{
//			set
//			{
//				selectPositionType = value;
//			}
//		}
//
//		private ServiceStaffType selectServiceStaffType;
//		public ServiceStaffType SelectServiceStaffType
//		{
//			set
//			{
//				selectServiceStaffType = value;
//			}
//		}
//
//		private Customer selectCustomer;
//		public Customer SelectCustomer
//		{
//			set
//			{
//				selectCustomer = value;
//			}
//		}
//
//		private CustomerDepartment selectCustomerDepartment;
//		public CustomerDepartment SelectCustomerDepartment
//		{
//			set
//			{
//				selectCustomerDepartment = value;
//			}
//		}
//
//		private SHIFT_TYPE selectShiftType;
//		public SHIFT_TYPE SelectShiftType
//		{
//			set
//			{
//				selectShiftType = value;
//			}
//		}
//
////		============================== DataSource ==============================
//		public PositionType DataSourceOfficeStaff
//		{
//			get
//			{
//				return positionTypeList["O"];
//			}
//		}
//
//		public PositionType DataSourceServiceStaff
//		{
//			get
//			{
//				return positionTypeList["S"];
//			}
//		}
//

//

//
//		public string[] DataSourceShiftType
//		{
//			get
//			{
//				CTFunction ctFunction = new CTFunction();
//				return ctFunction.ShiftTypeArray;			
//			}
//		}
//
//flowGenEmpWorkSchedule = new GenEmpWorkScheduleFlow(GetCompany());
//flowPositionType = new PositionTypeFlow();
//positionTypeList = flowPositionType.GetPositionTypeList(GetCompany());
//

//		============================== Private Method ==============================


//		============================== Public Method ==============================
//public void GetEmployeeList()
//{
//if(selectForAll)
//{
//flowGenEmpWorkSchedule.GetEmployeeList();
//}
//else
//{
//switch(selectPositionType.Type)
//{
//case "O" :
//{
//flowGenEmpWorkSchedule.GetOfficeStaffList(selectShiftType);
//break;
//}
//case "S" :
//{
//flowGenEmpWorkSchedule.GetServiceStaffList(selectServiceStaffType, selectCustomer, selectCustomerDepartment, selectShiftType);
//break;
//}
//default :
//{
//break;
//}
//}
//}
//}
//
//public void AddSelectEmployee(Employee value)
//{
//flowGenEmpWorkSchedule.AddSelectEmployee(value);
//}
//
//public void AddAllSelect()
//{
//flowGenEmpWorkSchedule.AddAllSelect();
//}
//
//public void RemoveAllSelect()
//{
//flowGenEmpWorkSchedule.RemoveAllSelect();
//}
//
//public void RemoveSelectEmployee(Employee value)
//{
//flowGenEmpWorkSchedule.RemoveSelectEmployee(value);
//}
//
//public bool GenEmployeeWorkSchedule()
//{
//return flowGenEmpWorkSchedule.GenEmployeeWorkScheduleList();
//}
//
//#region IDisposable Members
//protected override void Dispose(bool disposing)
//{
//if(!this.disposed)
//{
//try
//{
//if(disposing)
//{
//flowGenEmpWorkSchedule.Dispose();
//positionTypeList.Dispose();
//
//flowGenEmpWorkSchedule = null;
//positionTypeList = null;
//						
//}
//this.disposed = true;
//}
//finally
//{
//base.Dispose(disposing);
//}
//}
//}
//#endregion