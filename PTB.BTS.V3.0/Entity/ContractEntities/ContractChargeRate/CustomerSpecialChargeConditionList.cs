using System;
using System.Collections.Generic;
using System.Text;
using ictus.Common.Entity;
using PTB.BTS.ContractEntities.ContractChargeRate;

namespace PTB.BTS.ContractEntities.ContractChargeRate
{
    public class CustomerSpecialChargeConditionList : CompanyStuffBase
    {
        //============================== Constructor ==============================
        public CustomerSpecialChargeConditionList(Company value) : base(value)
        {

        }

        //============================== Public Method ==============================
        public void Add(CustomerSpecialChargeCondition value)
        {base.Add(value);}

        public void Remove(CustomerSpecialChargeCondition value)
        {base.Remove(value);}

        public CustomerSpecialChargeCondition this[int index]
        {
            get { return (CustomerSpecialChargeCondition)base.BaseGet(index); }
            set { base.BaseSet(index, value); }
        }

        public CustomerSpecialChargeCondition this[String key]
        {
            get { return (CustomerSpecialChargeCondition)base.BaseGet(key); }
            set { base.BaseSet(key, value); }
        }
    }
}
