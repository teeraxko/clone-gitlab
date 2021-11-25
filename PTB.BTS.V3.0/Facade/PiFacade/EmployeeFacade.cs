using System;
using System.Data;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

using Entity.CommonEntity;

using PTB.BTS.PI.Flow;

using Facade.PiFacade;
using Facade.CommonFacade;

using SystemFramework.AppException;

namespace Facade.PiFacade
{
	public class EmployeeFacade : CommonPIFacadeBase
	{
		#region - Private -
			private EmployeeFlow flowEmployee;
		#endregion

//		============================== Property ==============================
		private Employee employee;
		public Employee Employee
		{
			get{return employee;}
			set{employee = value;}
		}

		private EmployeeAddress employeeAddress;
		public Address EmployeeCurrentAddress
		{
			get{return employeeAddress.ACurrentAddress;}
			set{employeeAddress.ACurrentAddress = value;}
		}

		public Address EmployeeRegisterAddress
		{
			get{return employeeAddress.ARegisterAddress;}
			set{employeeAddress.ARegisterAddress = value;}
		}

		private EmployeeEducation employeeEducation;
		public EmployeeEducation EmployeeEducation
		{
			get{return employeeEducation;}
			set{employeeEducation = value;}
		}

//		============================== Constructor ==============================
		public EmployeeFacade()
		{
			flowEmployee = new EmployeeFlow();
			employee = new Employee();
			employeeAddress = new EmployeeAddress();
			employeeAddress.AEmployee = employee;
		}
		
//		============================== Public Method ==============================

        public DataTable GetNewEmployeeToExport(DateTime dateFrom, DateTime dateTo)
        {
            return flowEmployee.GetNewEmployeeToExport(dateFrom, dateTo);
        }

        public DataTable GetUpdateEmployeeToExport(DateTime dateFrom, DateTime dateTo)
        {
            return flowEmployee.GetUpdateEmployeeToExport(dateFrom, dateTo);
        }

        public DataTable GetResignEmployeeToExport(DateTime dateFrom, DateTime dateTo)
        {
            return flowEmployee.GetResignEmployeeToExport(dateFrom, dateTo);
        }
	}
}
