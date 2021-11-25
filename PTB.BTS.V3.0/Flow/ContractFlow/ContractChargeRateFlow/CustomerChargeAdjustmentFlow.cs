using System;
using System.Collections.Generic;
using System.Text;
using PTB.BTS.Common.Flow;
using DataAccess.ContractDB.ContractChargeRateDB;
using Entity.ContractEntities;
using ictus.Common.Entity;
using ictus.PIS.PI.Entity;
using PTB.BTS.ContractEntities.ContractChargeRate;
using ictus.Common.Entity.Time;
using DataAccess.ContractDB;
using SystemFramework.AppException;

namespace Flow.ContractFlow.ContractChargeRateFlow
{
    public class CustomerChargeAdjustmentFlow : CustomerChargeFlowBase
    {
        private CustomerChargeAdjustmentDB dbCustomerChargeAdjustment;

        //============================== Constructor ==============================
        public CustomerChargeAdjustmentFlow() : base()
        {
            dbCustomerChargeAdjustment = new CustomerChargeAdjustmentDB();
        }

        //============================== public method ==============================
        public bool FillCustomerChargeAdjustmentList(CustomerChargeAdjustmentList value, YearMonth yearMonth, bool isDriver)
        {
            if (dbCustomerChargeAdjustment.FillCustomerChargeAdjustmentList(value, yearMonth))
            {
                CustomerChargeAdjustmentList tempList = new CustomerChargeAdjustmentList(value.Company);

                foreach (CustomerChargeAdjustment charge in value)
                {
                    string contractType = charge.Contract.AContractType.Code;

                    if (isDriver & contractType == ContractType.CONTRACT_TYPE_DRIVER)
                    {
                        tempList.Add(charge);
                    }
                    else if (!isDriver & contractType == ContractType.CONTRACT_TYPE_OTHER)
                    {
                        tempList.Add(charge);
                    }  
                }

                value.Clear();
                foreach (CustomerChargeAdjustment charge in tempList)
                {
                    value.Add(charge);
                }

                return (value.Count > 0);
            }
            return false;
        }

        public ChargeRate GetCustomerChargeRate(ContractBase contract, Company company)
        {
            return base.GetChargeRate(contract, company);
        }

        public decimal GetCustomerMinOTAmount(ContractBase contract, Company company)
        {
            return base.GetMinOTAmount(contract, company);
        }

        public bool InsertCustomerChargeAdjustment(CustomerChargeAdjustment value, Company company)
        {
            return dbCustomerChargeAdjustment.InsertCustomerChargeAdjustment(value, company);
        }

        public bool UpdateCustomerChargeAdjustment(CustomerChargeAdjustment value, Company company)
        {
            return dbCustomerChargeAdjustment.UpdateCustomerChargeAdjustment(value, company);
        }

        public bool DeleteCustomerChargeAdjustment(CustomerChargeAdjustment value, Company company)
        {
            return dbCustomerChargeAdjustment.DeleteCustomerChargeAdjustment(value, company);
        }
    }
}
