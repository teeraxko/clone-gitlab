using System;
using System.Collections.Generic;
using System.Text;
using ictus.Common.Entity;

namespace PTB.BTS.ContractEntities.ContractChargeRate
{
    public class CustomerChargeAdjustmentList : CompanyStuffBase
    {
        //============================== Constructor ==============================
        public CustomerChargeAdjustmentList(Company company)
            : base(company)
		{}

//		============================== Public Method ==============================
        public void Add(CustomerChargeAdjustment value)
		{base.Add(value);}

        public void Remove(CustomerChargeAdjustment value)
		{base.Remove(value);}

        public CustomerChargeAdjustment this[int index]
		{
			get{return (CustomerChargeAdjustment)base.BaseGet(index);}
			set{base.BaseSet(index, value);}
		}

        public CustomerChargeAdjustment this[String key]  
		{
			get{return (CustomerChargeAdjustment)base.BaseGet(key);}
			set{base.BaseSet(key, value);}
		}
    }
}
