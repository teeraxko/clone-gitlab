using System;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;
using Entity.ContractEntities;
using Entity.VehicleEntities;
using Entity.AttendanceEntities;

using DataAccess.ContractDB;
using DataAccess.PiDB;

using PTB.BTS.Common.Flow;
using PTB.BTS.PI.Flow;

using SystemFramework.AppException;

using ictus.Common.Entity;

namespace PTB.BTS.Contract.Flow 
{	
	public class ServiceStaffFlow : FlowBase
	{
		#region Private Variable
		private ServiceStaffDB dbServiceStaff;
		private EmployeeDB dbEmployee;
		#endregion 

        #region Constructor
        public ServiceStaffFlow()
        {
            dbServiceStaff = new ServiceStaffDB();
            dbEmployee = new EmployeeDB();
        } 
        #endregion
		
        #region Public Method
        public ServiceStaff GetCompleteServiceStaff(string employeeNo, Company aCompany)
        {
            Employee employee;
            ServiceStaff serviceStaff;
            try
            {
                employee = dbEmployee.GetAllEmployee(employeeNo, aCompany);
                if (employee != null)
                {
                    serviceStaff = new ServiceStaff(employee);
                    if (dbServiceStaff.FillAllStaff(ref serviceStaff))
                    {
                        employee = null;
                        return serviceStaff;
                    }
                }
            }
            catch (EmpNotFoundException ex)
            {
                nullEmpNotFoundException(ex);
            }
            finally
            {
                employee = null;
            }
            return null;
        }

        private void nullEmpNotFoundException(EmpNotFoundException value)
        {
            value = null;
        }

        public ServiceStaff GetServiceStaff(string employeeNo, Company aCompany)
        {
            Employee employee = dbServiceStaff.GetAvailableStaff(employeeNo, aCompany);
            if (employee != null && (employee.APosition.APositionType.Type == "S"))
            {
                return (ServiceStaff)employee;
            }
            return null;
        }

        public ServiceStaff GetAllServiceStaff(string employeeNo, Company aCompany)
        {
            Employee employee = dbServiceStaff.GetAllStaff(employeeNo, aCompany);
            if (employee != null && (employee.APosition.APositionType.Type == "S"))
            {
                return (ServiceStaff)employee;
            }
            return null;
        }

        public ServiceStaff GetFormerlyServiceStaff(string employeeNo, Company company)
        {
            return dbServiceStaff.GetFormerlyServiceStaff(employeeNo, company);
        }

        public bool FillEmployeeServiceStaff(ref EmployeeList value)
        {
            bool result = false;
            Employee employee;

            if (value.Count > 0)
            {
                result = true;
                for (int i = 0; i < value.Count; i++)
                {
                    employee = value[i];
                    if (dbEmployee.FillAvailableEmployee(employee, DateTime.Today))
                    {
                        value[i] = employee;
                        result &= true;
                    }
                    else
                    {
                        result &= false;
                    }
                }
            }

            return result;
        }

        public bool FillAvailableStaffList(ref EmployeeList value)
        {
            return dbServiceStaff.FillAvailableStaffList(ref value);
        }

        public bool FillServiceStaffByRole(ref EmployeeList value, Employee conditionServiceStaff, TimePeriod conditionTimePeriod)
        {
            bool result = false;
            PositionList positionList = new PositionList(value.Company);
            Position position = new Position();
            ServiceStaffTypeList serviceStaffTypeList = new ServiceStaffTypeList(value.Company);
            ServiceStaffType serviceStaffType = new ServiceStaffType();
            ServiceStaff serviceStaff = new ServiceStaff(value.Company);
            ServiceStaffAssignmentList serviceStaffAssignmentList = new ServiceStaffAssignmentList(value.Company);

            PositionDB dbPosition = new PositionDB();
            ServiceStaffTypeDB dbServiceStaffType = new ServiceStaffTypeDB();
            ServiceStaffAssignmentDB dbServiceStaffAssignment = new ServiceStaffAssignmentDB();
            ServiceStaffDB dbServiceStaff = new ServiceStaffDB();

            if (conditionServiceStaff.APosition != null)
            {
                position.APositionRole = conditionServiceStaff.APosition.APositionRole;
                result = dbPosition.FillPositionList(ref positionList, position);
            }

            if (result)
            {
                for (int i = 0; i < positionList.Count; i++)
                {
                    serviceStaffType.APosition = positionList[i];
                    result &= dbServiceStaffType.FillServiceStaffTypeList(ref serviceStaffTypeList, serviceStaffType);
                }

                for (int i = 0; i < serviceStaffTypeList.Count; i++)
                {
                    serviceStaff.AServiceStaffType = serviceStaffTypeList[i];
                    result &= dbServiceStaff.FillAvailableStaffList(ref value, serviceStaff.AServiceStaffType);
                }
            }

            if (result)
            {
                result &= FillEmployeeServiceStaff(ref value);

                if (dbServiceStaffAssignment.FillNotAvailableServiceStaffAssignmentList(ref serviceStaffAssignmentList, conditionTimePeriod))
                {
                    for (int i = 0; i < serviceStaffAssignmentList.Count; i++)
                    {
                        value.Remove(serviceStaffAssignmentList[i].AAssignedServiceStaff);
                    }
                }
            }

            return result;
        }

        public bool DeleteServiceStaff(Employee value)
        {
            ServiceStaff serviceStaff = new ServiceStaff(value.Company);
            serviceStaff.EmployeeNo = value.EmployeeNo;
            bool result = dbServiceStaff.DeleteServiceStaff(serviceStaff);
            serviceStaff = null;
            return result;
        }

        /// <summary>
        /// To get employee detail with time period
        /// </summary>
        /// <param name="employeeNo"></param>
        /// <param name="timePeriod"></param>
        /// <param name="aCompany"></param>
        /// <returns></returns>
        public ServiceStaff GetServiceStaffMainByPeriod(string employeeNo, TimePeriod timePeriod, Company aCompany)
        {
            //TODO : P'Ya

            ServiceStaff serviceStaff;
            try
            {
                serviceStaff = new ServiceStaff(aCompany);
                serviceStaff.EmployeeNo = employeeNo;
                if (dbServiceStaff.FillServiceStaffMainByPeriod(serviceStaff, timePeriod))
                {
                    return serviceStaff;
                }
            }
            catch (EmpNotFoundException ex)
            {
                nullEmpNotFoundException(ex);
            }
            
            return null;

        }
        #endregion
	}
}
