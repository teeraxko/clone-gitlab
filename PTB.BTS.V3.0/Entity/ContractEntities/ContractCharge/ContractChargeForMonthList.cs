using System;
using System.Collections.Generic;
using System.Text;

using ictus.Common.Entity;

namespace Entity.ContractEntities
{
    public class ContractChargeForMonthList : CompanyStuffBase
    {
        //============================== Constructor ==============================
        public ContractChargeForMonthList(Company aCompany): base(aCompany)
        {
        }

        //============================== Public Method ==============================
        public void Add(IContractChargeDetail value)
        { base.Add(value); }

        public void Remove(IContractChargeDetail value)
        { base.Remove(value); }

        public IContractChargeDetail this[int index]
        {
            get { return (IContractChargeDetail)base.BaseGet(index); }
            set { base.BaseSet(index, value); }
        }

        public IContractChargeDetail this[String key]
        {
            get { return (IContractChargeDetail)base.BaseGet(key); }
            set { base.BaseSet(key, value); }
        }
    }
}
