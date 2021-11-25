using System;

using Entity.CommonEntity;
using ictus.PIS.PI.Entity;

namespace Entity.ContractEntities
{
    public class ContractList : ictus.Common.Entity.CompanyStuffBase
	{
//		============================== Constructor ==============================
        public ContractList(ictus.Common.Entity.Company aCompany)
            : base(aCompany)
		{}

//		============================== Public Method ==============================
		public void Add(ContractBase value)
		{base.Add(value);}

		public void Remove(ContractBase value)
		{base.Remove(value);}
	
		public ContractBase this[int index]
		{
			get{return (ContractBase) base.BaseGet(index);}
			set{base.BaseSet(index, value);}
		}

		public ContractBase this[String key]  
		{
			get{return (ContractBase)base.BaseGet(key);}
			set{base.BaseSet(key, value);}
		}
	}
}
