using System;
using System.Collections.Generic;
using System.Text;

using Entity.CommonEntity;
using ictus.PIS.PI.Entity;

namespace Entity.ContractEntities
{
    public class ContractChargeDetailList : ictus.Common.Entity.CompanyStuffBase
    {
        //		============================== Property ==============================
        protected ContractBase aContract;
        public ContractBase AContract
        {
            get { return aContract; }
            set { aContract = value; }
        }

        //		============================== Constructor ==============================
        public ContractChargeDetailList(ictus.Common.Entity.Company value)
            : base(value)
        {
        }

        //		============================== Public Method ==============================
        public void Add(ContractChargeDetail value)
        { base.Add(value); }

        public void Remove(ContractChargeDetail value)
        { base.Remove(value); }

        public ContractChargeDetail this[int index]
        {
            get { return (ContractChargeDetail)base.BaseGet(index); }
            set { base.BaseSet(index, value); }
        }

        public ContractChargeDetail this[String key]
        {
            get { return (ContractChargeDetail)base.BaseGet(key); }
            set { base.BaseSet(key, value); }
        }
    }
}
