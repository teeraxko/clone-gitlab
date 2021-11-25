using PTB.BTS.Common.Flow;
using DataAccess.ContractDB.ContractChargeRateDB;
using ictus.Common.Entity;
using PTB.BTS.ContractEntities.ContractChargeRate;

namespace Flow.ContractFlow.ContractChargeRateFlow
{
    public class CustomerSpecialChargeFlow : FlowBase
    {
        private CustomerSpecialChargeDB dbCustomerSpecialCharge;

        //============================== Constructor ==============================
        public CustomerSpecialChargeFlow()
            : base()
        {
            dbCustomerSpecialCharge = new CustomerSpecialChargeDB();
        }
    }
}
