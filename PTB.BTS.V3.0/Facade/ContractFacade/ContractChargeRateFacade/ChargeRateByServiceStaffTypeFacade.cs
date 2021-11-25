using System;

using Facade.PiFacade;
using ictus.Common.Entity;
using SystemFramework.AppException;

using PTB.BTS.Contract.Flow.ContractChargeRateFlow;
using PTB.BTS.ContractEntities.ContractChargeRate;
using Flow.ContractFlow.ContractChargeRateFlow;
using PTB.BTS.Contract.Flow;
using System.Collections;

namespace Facade.ContractFacade.ContractChargeRateFacade
{
    public class ChargeRateByServiceStaffTypeFacade : CommonPIFacadeBase
    {
        private ChargeRateByServiceStaffTypeFlow flowChargeRateByServiceStaffType;

        //============================== Property ==============================
        private ChargeRateByServiceStaffTypeList objChargeRateByServiceStaffTypeList;
        public ChargeRateByServiceStaffTypeList ObjChargeRateByServiceStaffTypeList
        {
            get { return objChargeRateByServiceStaffTypeList; }
        }

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

        //============================== Constructor ==============================
        public ChargeRateByServiceStaffTypeFacade()
            : base()
        {
            flowChargeRateByServiceStaffType = new ChargeRateByServiceStaffTypeFlow();
            objChargeRateByServiceStaffTypeList = new ChargeRateByServiceStaffTypeList(GetCompany());
        }

        //============================== public method ==============================
        public bool DisplayChargeRateByServiceStaffType()
        {
            objChargeRateByServiceStaffTypeList.Clear();
            return flowChargeRateByServiceStaffType.FillChargeRateByServiceStaffTypeList(objChargeRateByServiceStaffTypeList);
        }

        public bool InsertChargeRateByServiceStaffType(ChargeRateByServiceStaffType value)
        {
            if (objChargeRateByServiceStaffTypeList.Contain(value))
            {
                throw new DuplicateException("ChargeRateByServiceStaffTypeFacade");
            }
            else
            {
                if (flowChargeRateByServiceStaffType.InsertChargeRateByServiceStaffType(value, GetCompany()))
                {
                    objChargeRateByServiceStaffTypeList.Add(value);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool UpdateChargeRateByServiceStaffType(ChargeRateByServiceStaffType value)
        {
            if (flowChargeRateByServiceStaffType.UpdateChargeRateByServiceStaffType(value, GetCompany()))
            {
                objChargeRateByServiceStaffTypeList[value.EntityKey] = value;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteChargeRateByServiceStaffType(ChargeRateByServiceStaffType value)
        {
            if (flowChargeRateByServiceStaffType.DeleteChargeRateByServiceStaffType(value, GetCompany()))
            {
                objChargeRateByServiceStaffTypeList.Remove(value);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
