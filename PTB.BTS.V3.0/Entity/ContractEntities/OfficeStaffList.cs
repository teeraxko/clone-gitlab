using System;

using Entity.CommonEntity;
using ictus.PIS.PI.Entity;
namespace Entity.ContractEntities
{
    public class OfficeStaffList : ictus.Common.Entity.CompanyStuffBase
	{
        public OfficeStaffList(ictus.Common.Entity.Company aCompany)
            : base(aCompany)
		{
		}
//		============================== Public Method ==============================
		public void Add(OfficeStaff value)
		{base.Add(value);}

		public void Remove(OfficeStaff value)
		{base.Remove(value);}

		public OfficeStaff this[int index]
		{
			get{return((OfficeStaff) base.BaseGet(index));}
			set{base.BaseSet(index, value);}
		}

		public OfficeStaff this[String key]  
		{
			get{return((OfficeStaff)base.BaseGet(key));}
			set{base.BaseSet(key, value);}
		}
	}
}
