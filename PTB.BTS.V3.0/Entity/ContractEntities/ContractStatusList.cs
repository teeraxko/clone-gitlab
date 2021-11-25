using System;

using Entity.CommonEntity;
using ictus.PIS.PI.Entity;

namespace Entity.ContractEntities
{
	public class ContractStatusList : ictus.Common.Entity.CompanyStuffBase
	{
//		============================== Constructor ==============================
        public ContractStatusList(ictus.Common.Entity.Company value)
            : base(value)
		{}

//		============================== Public Method ==============================
		public void Add(ContractStatus value)
		{base.Add(value);}

		public void Remove(ContractStatus value)
		{base.Remove(value);}
	
		public ContractStatus this[int index]
		{
			get{return (ContractStatus) base.BaseGet(index);}
			set{base.BaseSet(index, value);}
		}

		public ContractStatus this[String key]  
		{
			get{return (ContractStatus) base.BaseGet(key);}
			set{base.BaseSet(key, value);}
		}
	}
}
