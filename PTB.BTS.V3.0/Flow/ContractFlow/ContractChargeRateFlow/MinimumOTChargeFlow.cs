using System;

using PTB.BTS.Common.Flow;
using ictus.Common.Entity;

using DataAccess.ContractDB.ContractChargeRateDB;
using PTB.BTS.ContractEntities.ContractChargeRate;

namespace PTB.BTS.Contract.Flow.ContractChargeRateFlow
{
    public class MinimumOTChargeFlow : FlowBase
    {
        private MinimumOTChargeDB dbMinimumOTCharge;

        //============================== Constructor ==============================
        public MinimumOTChargeFlow() : base()
        {
            dbMinimumOTCharge = new MinimumOTChargeDB();
        }

        //============================== public method ==============================
        public bool FillMinimumOTChargeList(MinimumOTChargeList value)
        {
            return dbMinimumOTCharge.FillMinimumOTChargeList(value);
        }

        public bool InsertMinimumOTCharge(MinimumOTCharge value, Company company)
        {
            return dbMinimumOTCharge.InsertMinimumOTCharge(value, company);
        }

        public bool UpdateMinimumOTCharge(MinimumOTCharge value, Company company)
        {
            return dbMinimumOTCharge.UpdateMinimumOTCharge(value, company);
        }

        public bool DeleteMinimumOTCharge(MinimumOTCharge value, Company company)
        {
            return dbMinimumOTCharge.DeleteMinimumOTCharge(value, company);
        }
    }
}
