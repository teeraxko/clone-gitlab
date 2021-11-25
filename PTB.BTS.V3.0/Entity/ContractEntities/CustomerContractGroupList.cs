using System;

using Entity.CommonEntity;
using ictus.PIS.PI.Entity;

namespace Entity.ContractEntities
{
    public class CustomerContractGroupList : ictus.Common.Entity.CompanyStuffBase
	{
//		============================== Constructor ==============================
        public CustomerContractGroupList(ictus.Common.Entity.Company value)
            : base(value)
		{
		}

//		============================== Public Method ==============================
		public void Add(CustomerContractGroup value)
		{base.Add(value);}

		public void Remove(CustomerContractGroup value)
		{base.Remove(value);}
	
		public CustomerContractGroup this[int index]
		{
			get{return (CustomerContractGroup) base.BaseGet(index);}
			set{base.BaseSet(index, value);}
		}

		public CustomerContractGroup this[String key]  
		{
			get{return (CustomerContractGroup) base.BaseGet(key);}
			set{base.BaseSet(key, value);}
		}
	}
}
