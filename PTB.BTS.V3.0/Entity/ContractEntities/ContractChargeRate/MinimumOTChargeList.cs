using System;

using ictus.Common.Entity;

namespace PTB.BTS.ContractEntities.ContractChargeRate
{
    public class MinimumOTChargeList : CompanyStuffBase
    {
        //============================== Constructor ==============================
        public MinimumOTChargeList(Company aCompany) : base(aCompany)
		{}

        //============================== Public Method ==============================
        public void Add(MinimumOTCharge value)
        { base.Add(value); }

        public void Remove(MinimumOTCharge value)
        { base.Remove(value); }

        public MinimumOTCharge this[int index]
		{
            get { return (MinimumOTCharge)base.BaseGet(index); }
            set { base.BaseSet(index, value); }
		}

        public MinimumOTCharge this[String key]  
		{
            get { return (MinimumOTCharge)base.BaseGet(key); }
            set { base.BaseSet(key, value); }
		}
    }
}
