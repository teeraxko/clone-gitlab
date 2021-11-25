using System;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

using DataAccess.PiDB;

using PTB.BTS.Common.Flow;

using SystemFramework.AppException;
using System.Data;
// PTB.BTS.PI.Flow
namespace PTB.BTS.PI.Flow
{
	public class EmployeeFlow : FlowBase
	{
		#region - Private -
			private EmployeeDB dbEmployee;
		#endregion

		//================================Constructor=====================
		public EmployeeFlow()
		{
			dbEmployee = new EmployeeDB();
		}

		//================================public Method=====================
		public Employee GetAvailableEmployee(string empNo, DateTime effectiveDate, Company value)
		{
            return dbEmployee.GetAvailableEmployee(empNo, effectiveDate, value);
		}

		public Employee GetFormerlyEmployee(string employeeNo, Company value)
		{
			return dbEmployee.GetFormerlyEmployee(employeeNo, value);
		}

        public EmployeeInfo GetEmployeeInfo(string employeeNo, Company value)
        {
            return dbEmployee.GetAllEmployeeInfo(employeeNo, value);
        }

		public bool FillAvailableEmployee(Employee value, DateTime effectiveDate)
		{
			if(dbEmployee.FillAvailableEmployee(value, effectiveDate))
			{
				return true;
			}
			else
			{
				throw new EmpNotFoundException(value.EmployeeNo);
			}
		}

		public bool FillAllEmployee(ref Employee value)
		{
			if(dbEmployee.FillAllEmployee(ref value))
			{
				return true;
			}
			else
			{
				throw new EmpNotFoundException(value.EmployeeNo);
			}
		}

		public bool FillAvailableEmployeeList(ref EmployeeList value)
		{
			return dbEmployee.FillAvailableEmployeeList(ref value);
		}

		public bool FillAvailableEmployeeList(ref EmployeeList aEmployeeList, Employee aEmployee)
		{
			return dbEmployee.FillAvailableEmployeeList(ref aEmployeeList, aEmployee);
		}

		public bool FillEmployeeNotAvailableList(ref EmployeeList value)
		{
			return dbEmployee.FillEmployeeNotAvailableList(ref value);
		}

		public bool FillAllEmployeeList(ref EmployeeList value, Employee aEmployee)
		{
			return dbEmployee.FillAllEmployeeList(ref value, aEmployee);
		}

        public bool FillAllEmployeeList(EmployeeList value)
        {
            return dbEmployee.FillAllEmployeeList(value);
        }

        public bool FillAvailableEmployeeList(EmployeeList value, DateTime effectiveDate)
        {
            return dbEmployee.FillAvailableEmployeeList(value, effectiveDate);
        }

        public DataTable GetNewEmployeeToExport(DateTime dateFrom, DateTime dateTo)
        {
            return dbEmployee.FillNewEmployeeToExport(dateFrom, dateTo);
        }

        public DataTable GetUpdateEmployeeToExport(DateTime dateFrom, DateTime dateTo)
        {
            return dbEmployee.FillUpdateEmployeeToExport(dateFrom, dateTo);
        }

        public DataTable GetResignEmployeeToExport(DateTime dateFrom, DateTime dateTo)
        {
            return dbEmployee.FillResignEmployeeToExport(dateFrom, dateTo);
        }
	}
}
