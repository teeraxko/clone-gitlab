using System;
using System.Collections.Generic;
using System.Text;
using Facade.PiFacade;
using Flow.ContractFlow.ContractChargeRateFlow;
using PTB.BTS.ContractEntities.ContractChargeRate;
using SystemFramework.AppException;
using Entity.ContractEntities;
using ictus.Common.Entity.Time;
using PTB.BTS.Contract.Flow;

namespace Facade.ContractFacade.ContractChargeRateFacade
{
    public class CustomerSpecialChargeConditionFacade : CommonPIFacadeBase
    {
        private ServiceStaffFlow flowServiceStaff;
        private ServiceStaffAssignmentFlow flowServiceStaffAssignment;
        private CustomerSpecialChargeConditionFlow flowCustomerSpecialChargeCondition;

        //============================== Property ==============================
        private CustomerSpecialChargeConditionList objSpecialChargeList;
        public CustomerSpecialChargeConditionList ObjSpecialChargeList
        {
            get { return objSpecialChargeList; }
        }

        private ServiceStaffAssignmentList objSSAssignmentList;
        public ServiceStaffAssignmentList ObjSSAssignmentList
        {
            get { return objSSAssignmentList; }
        }

        //============================== Constructor ==============================
        public CustomerSpecialChargeConditionFacade()
            : base()
        {
            flowServiceStaff = new ServiceStaffFlow();
            flowServiceStaffAssignment = new ServiceStaffAssignmentFlow();
            flowCustomerSpecialChargeCondition = new CustomerSpecialChargeConditionFlow();
            objSpecialChargeList = new CustomerSpecialChargeConditionList(GetCompany());
        }

        //============================== public method ==============================
        public bool DisplayCustomerSpecialChargeCondition()
        {
            objSpecialChargeList.Clear();
            if (flowCustomerSpecialChargeCondition.FillCustomerSpecialChargeConditionList(objSpecialChargeList))
            {
                foreach (CustomerSpecialChargeCondition charge in objSpecialChargeList)
                {
                    AssignmentList assignmentList = new AssignmentList(charge.Contract, new YearMonth(DateTime.Today), GetCompany());
                    charge.DriverStaff = flowServiceStaffAssignment.GetStaffAssignmentInYearMonthList(assignmentList);
                }
                return true;
            }
            return false;
        }

        public bool FillServiceStaffAssignmentInPeriodList(ServiceStaff serviceStaff, DateTime date)
        {
            objSSAssignmentList = new ServiceStaffAssignmentList(serviceStaff, GetCompany());
            return flowServiceStaffAssignment.FillServiceStaffAssignmentInPeriodList(ref objSSAssignmentList, new YearMonth(date));
        }

        public ChargeRate GetCustomerChargeRate(ContractBase contract)
        {
            return flowCustomerSpecialChargeCondition.GetCustomerChargeRate(contract, GetCompany());
        }

        public ServiceStaff GetServiceStaff(string employeeNo)
        {
            return flowServiceStaff.GetFormerlyServiceStaff(employeeNo, GetCompany());
        }

        public bool InsertCustomerSpecialChargeCondition(CustomerSpecialChargeCondition value)
        {
            if (objSpecialChargeList.Contain(value))
            {
                throw new DuplicateException("CustomerSpecialChargeConditionFacade");
            }
            else
            {
                if (flowCustomerSpecialChargeCondition.InsertCustomerSpecialChargeCondition(value, GetCompany()))
                {
                    objSpecialChargeList.Add(value);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool UpdateCustomerSpecialChargeCondition(CustomerSpecialChargeCondition value)
        {
            if (flowCustomerSpecialChargeCondition.UpdateCustomerSpecialChargeCondition(value, GetCompany()))
            {
                objSpecialChargeList[value.EntityKey] = value;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteCustomerSpecialChargeCondition(CustomerSpecialChargeCondition value)
        {
            if (flowCustomerSpecialChargeCondition.DeleteCustomerSpecialChargeCondition(value, GetCompany()))
            {
                objSpecialChargeList.Remove(value);
                return true;
            }
            else
            {
                return false;
            }
        }

        public CustomerDepartmentList GetCustomerDepartmentList(Customer customer)
        {
            CustomerDepartmentList custDeptList = new CustomerDepartmentList(GetCompany());
            custDeptList.ACustomer = customer;

            using (CustomerDepartmentFlow flow = new CustomerDepartmentFlow())
            {
                if (flow.FillCustomerDepartmentList(ref custDeptList))
                {
                    return custDeptList;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
