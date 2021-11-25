using System;

using Entity.CommonEntity;
using ictus.PIS.PI.Entity;

namespace Entity.ContractEntities
{
    public class CustomerList : ictus.Common.Entity.CompanyStuffBase
	{
//		============================== Constructor ==============================
        public CustomerList(ictus.Common.Entity.Company aCompany)
            : base(aCompany)
		{}

//		============================== Public Method ==============================
		public void Add(Customer aCustomer)
		{
			base.Add(aCustomer);
		}

		public void Remove(Customer aCustomer)
		{
			base.Remove(aCustomer);
		}

		public Customer this[int index]
		{
			get
			{
				return (Customer) base.BaseGet(index);
			}
			set
			{
				base.BaseSet(index, value);
			}
		}

		public Customer this[String key]  
		{
			get
			{
				return (Customer)base.BaseGet(key);
			}
			set
			{
				base.BaseSet(key, value);
			}
		}
	}
}
