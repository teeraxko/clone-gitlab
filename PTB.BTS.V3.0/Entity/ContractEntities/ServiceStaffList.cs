using System;

using Entity.CommonEntity;
using ictus.PIS.PI.Entity;

namespace Entity.ContractEntities
{
    public class ServiceStaffList : ictus.Common.Entity.CompanyStuffBase
	{
        public ServiceStaffList(ictus.Common.Entity.Company aCompany)
            : base(aCompany)
		{
		}

		//		============================== Public Method ==============================
		public void Add(ServiceStaff aServiceStaff)
		{
			base.Add(aServiceStaff);
		}

		public void Remove(ServiceStaff aServiceStaff)
		{
			base.Remove(aServiceStaff);
		}

		public ServiceStaff this[int index]
		{
			get
			{
				return((ServiceStaff) base.BaseGet(index));
			}
			set
			{
				base.BaseSet(index, value);
			}
		}

		public ServiceStaff this[String key]  
		{
			get
			{
				return((ServiceStaff)base.BaseGet(key));
			}
			set
			{
				base.BaseSet(key, value);
			}
		}
	}
}
