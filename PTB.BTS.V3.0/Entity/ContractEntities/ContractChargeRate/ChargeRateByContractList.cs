using System;
using ictus.Common.Entity;

namespace PTB.BTS.ContractEntities.ContractChargeRate
{
    public class ChargeRateByContractList : CompanyStuffBase
    {
        //============================== Constructor ==============================
        public ChargeRateByContractList(Company aCompany)
            : base(aCompany)
		{}

        //============================== Public Method ==============================
        public void Add(ChargeRateByContract value)
        { base.Add(value); }

        public void Remove(ChargeRateByContract value)
        { base.Remove(value); }

        public ChargeRateByContract this[int index]
		{
            get { return (ChargeRateByContract)base.BaseGet(index); }
            set { base.BaseSet(index, value); }
		}

        public ChargeRateByContract this[String key]  
		{
            get { return (ChargeRateByContract)base.BaseGet(key); }
            set { base.BaseSet(key, value); }
		}
    }
}
