using System;

using Entity.CommonEntity;
using ictus.PIS.PI.Entity;

namespace Entity.ContractEntities
{
    public class CustomerGroupList : ictus.Common.Entity.CompanyStuffBase
	{
//		============================== Constructor ==============================
        public CustomerGroupList(ictus.Common.Entity.Company value)
            : base(value)
		{
		}

//		============================== Public Method ==============================
		public void Add(CustomerGroup value)
		{base.Add(value);}

		public void Remove(CustomerGroup value)
		{base.Remove(value);}
	
		public CustomerGroup this[int index]
		{
			get{return (CustomerGroup) base.BaseGet(index);}
			set{base.BaseSet(index, value);}
		}

		public CustomerGroup this[String key]  
		{
			get{return (CustomerGroup) base.BaseGet(key);}
			set{base.BaseSet(key, value);}
		}
	}
}
