using System;

using PTB.BTS.Common.Flow;
using ictus.Common.Entity;

using DataAccess.ContractDB.ContractChargeRateDB;
using PTB.BTS.ContractEntities.ContractChargeRate;

namespace Flow.ContractFlow.ContractChargeRateFlow
{
    public class ChargeRateByContractFlow : FlowBase
    {
        private ChargeRateByContractDB dbChargeRateByContract;

        //============================== Constructor ==============================
        public ChargeRateByContractFlow()
            : base()
        {
            dbChargeRateByContract = new ChargeRateByContractDB();
        }

        //============================== public method ==============================
        public bool FillChargeRateByContractList(ChargeRateByContractList value)
        {
            return dbChargeRateByContract.FillChargeRateByContractList(value);
        }

        public bool InsertChargeRateByContract(ChargeRateByContract value, Company company)
        {
            return dbChargeRateByContract.InsertChargeRateByContract(value, company);
        }

        public bool UpdateChargeRateByContract(ChargeRateByContract value, Company company)
        {
            return dbChargeRateByContract.UpdateChargeRateByContract(value, company);
        }

        public bool DeleteChargeRateByContract(ChargeRateByContract value, Company company)
        {
            return dbChargeRateByContract.DeleteChargeRateByContract(value, company);
        }
    }
}
