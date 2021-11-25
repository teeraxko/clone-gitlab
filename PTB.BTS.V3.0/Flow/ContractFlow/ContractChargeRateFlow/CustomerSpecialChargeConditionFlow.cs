using PTB.BTS.Common.Flow;
using DataAccess.ContractDB.ContractChargeRateDB;
using ictus.Common.Entity;
using PTB.BTS.ContractEntities.ContractChargeRate;
using Entity.ContractEntities;

namespace Flow.ContractFlow.ContractChargeRateFlow
{
    public class CustomerSpecialChargeConditionFlow : CustomerChargeFlowBase
    {
        private CustomerSpecialChargeConditionDB dbCustomerSpecialChargeCondition;

        //============================== Constructor ==============================
        public CustomerSpecialChargeConditionFlow()
            : base()
        {
            dbCustomerSpecialChargeCondition = new CustomerSpecialChargeConditionDB();
        }

        //============================== Public Method ============================
        public bool FillCustomerSpecialChargeCondition(CustomerSpecialChargeCondition value, Company company)
        {
            return dbCustomerSpecialChargeCondition.FillCustomerSpecialChargeCondition(value, company);
        }

        public bool FillCustomerSpecialChargeConditionList(CustomerSpecialChargeConditionList value)
        {
            return dbCustomerSpecialChargeCondition.FillCustomerSpecialChargeConditionList(value);
        }

        public ChargeRate GetCustomerChargeRate(ContractBase contract, Company company)
        {
            return base.GetChargeRate(contract, company);
        }

        public decimal GetCustomerMinOTAmount(ContractBase contract, Company company)
        {
            return base.GetMinOTAmount(contract, company);
        }

        public bool InsertCustomerSpecialChargeCondition(CustomerSpecialChargeCondition value, Company company)
        {
            return dbCustomerSpecialChargeCondition.InsertCustomerSpecialChargeCondition(value, company);
        }

        public bool UpdateCustomerSpecialChargeCondition(CustomerSpecialChargeCondition value, Company company)
        {
            return dbCustomerSpecialChargeCondition.UpdateCustomerSpecialChargeCondition(value, company);
        }

        public bool DeleteCustomerSpecialChargeCondition(CustomerSpecialChargeCondition value, Company company)
        {
            return dbCustomerSpecialChargeCondition.DeleteCustomerSpecialChargeCondition(value, company);
        }
    }
}
