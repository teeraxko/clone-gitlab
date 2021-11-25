using System;

using ictus.Common.Entity;
using ictus.PIS.PI.Entity;

namespace Entity.ContractEntities
{
    public class CustomerDepartmentList : CompanyStuffBase
	{
//		============================== Property ==============================
		private Customer aCustomer;
		public  Customer ACustomer
		{
			get{return aCustomer;}
			set{aCustomer = value;}
		}

//		============================== Constructor ==============================
        public CustomerDepartmentList(Company aCompany)
            : base(aCompany)
		{
			aCustomer = new Customer();
		}

//		============================== Public Method ==============================
		public void Add(CustomerDepartment aCustomerDepartment)
		{base.Add(aCustomerDepartment);}

		public void Remove(CustomerDepartment aCustomerDepartment)
		{base.Remove(aCustomerDepartment);}

		public CustomerDepartment this[int index]
		{
			get{return (CustomerDepartment) base.BaseGet(index);}
			set{base.BaseSet(index, value);}
		}

		public CustomerDepartment this[String key]  
		{
			get{return (CustomerDepartment)base.BaseGet(key);}
			set{base.BaseSet(key, value);}
		}
	}
}