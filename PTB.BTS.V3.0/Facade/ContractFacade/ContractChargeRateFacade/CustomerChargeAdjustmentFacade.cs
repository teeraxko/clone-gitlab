using System;
using System.Collections.Generic;
using System.Text;
using Facade.PiFacade;
using Flow.ContractFlow.ContractChargeRateFlow;
using Entity.ContractEntities;
using SystemFramework.AppException;
using ictus.PIS.PI.Entity;
using PTB.BTS.PI.Flow;
using System.Collections;
using PTB.BTS.Contract.Flow;
using PTB.BTS.ContractEntities.ContractChargeRate;
using ictus.Common.Entity.Time;
using Flow.AttendanceFlow.CommonBenefitFlow;

namespace Facade.ContractFacade.ContractChargeRateFacade
{
    public class CustomerChargeAdjustmentFacade : CommonPIFacadeBase
    {
        private CustomerChargeAdjustmentFlow flowCustomerChargeAdjustmentFlow;
        private ServiceStaffAssignmentFlow flowServiceStaffAssignment;
        private ServiceStaffFlow flowServiceStaff;

        //============================== Property ==============================
        private CustomerChargeAdjustmentList objCustomerChargeAdjustmentList;
        public CustomerChargeAdjustmentList ObjCustomerChargeAdjustmentList
        {
            get { return objCustomerChargeAdjustmentList; }
        }

        private ServiceStaffAssignmentList objSSAssignmentList;
        public ServiceStaffAssignmentList ObjSSAssignmentList
        {
            get { return objSSAssignmentList; }
        }
	
        //============================== Constructor ==============================
        public CustomerChargeAdjustmentFacade()
            : base()
        {
            flowCustomerChargeAdjustmentFlow = new CustomerChargeAdjustmentFlow();
            flowServiceStaffAssignment = new ServiceStaffAssignmentFlow();
            flowServiceStaff = new ServiceStaffFlow();

            objCustomerChargeAdjustmentList = new CustomerChargeAdjustmentList(GetCompany());
        }

        //============================== public method ==============================
        public bool DisplayCustomerChargeAdjustment(YearMonth yearMonth, bool isDriver)
        {
            objCustomerChargeAdjustmentList.Clear();
            return flowCustomerChargeAdjustmentFlow.FillCustomerChargeAdjustmentList(objCustomerChargeAdjustmentList, yearMonth, isDriver);
        }

        public bool FillServiceStaffAssignmentInPeriodList(ServiceStaff serviceStaff, YearMonth yearMonth)
        {
            objSSAssignmentList = new ServiceStaffAssignmentList(serviceStaff, GetCompany());
            return flowServiceStaffAssignment.FillServiceStaffAssignmentInPeriodList(ref objSSAssignmentList, yearMonth);
        }

        public ChargeRate GetCustomerChargeRate(ContractBase contract)
        {
            return flowCustomerChargeAdjustmentFlow.GetCustomerChargeRate(contract, GetCompany());
        }

        public ServiceStaff GetServiceStaff(string employeeNo)
        {
            return flowServiceStaff.GetFormerlyServiceStaff(employeeNo, GetCompany());
        }

        public decimal GetCustomerMinOTAmount(ContractBase contract)
        {
            return flowCustomerChargeAdjustmentFlow.GetCustomerMinOTAmount(contract, GetCompany());
        }

        public decimal HalfRound(decimal value)
        {
            return CommonAttendanceFlow.HalfRound(value);
        }

        public bool InsertCustomerChargeAdjustment(CustomerChargeAdjustment value)
        {
            if (objCustomerChargeAdjustmentList.Contain(value))
            {
                throw new DuplicateException("CustomerChargeAdjustmentFacade");
            }
            else
            {
                if (flowCustomerChargeAdjustmentFlow.InsertCustomerChargeAdjustment(value, GetCompany()))
                {
                    objCustomerChargeAdjustmentList.Add(value);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool UpdateCustomerChargeAdjustment(CustomerChargeAdjustment value)
        {
            if (flowCustomerChargeAdjustmentFlow.UpdateCustomerChargeAdjustment(value, GetCompany()))
            {
                objCustomerChargeAdjustmentList[value.EntityKey] = value;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteCustomerChargeAdjustment(CustomerChargeAdjustment value)
        {
            if (flowCustomerChargeAdjustmentFlow.DeleteCustomerChargeAdjustment(value, GetCompany()))
            {
                objCustomerChargeAdjustmentList.Remove(value);
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
