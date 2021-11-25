using System;

using Entity.CommonEntity;
using ictus.PIS.PI.Entity;

namespace Entity.ContractEntities
{
    public class ServiceStaffTypeList : ictus.Common.Entity.CompanyStuffBase
	{
        public ServiceStaffTypeList(ictus.Common.Entity.Company value)
            : base(value)
		{
		}

//		============================== Public Method ==============================
		public void Add(ServiceStaffType value)
		{base.Add(value);}

		public void Remove(ServiceStaffType value)
		{base.Remove(value);}

		public ServiceStaffType this[int index]
		{
			get{return((ServiceStaffType) base.BaseGet(index));}
			set{base.BaseSet(index, value);}
		}

		public ServiceStaffType this[String key]  
		{
			get{return((ServiceStaffType)base.BaseGet(key));}
			set{base.BaseSet(key, value);}
		}
	}
}