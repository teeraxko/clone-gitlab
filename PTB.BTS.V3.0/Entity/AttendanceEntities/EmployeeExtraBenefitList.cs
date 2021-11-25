using System;

using ictus.PIS.PI.Entity;

namespace Entity.AttendanceEntities
{
    public class EmployeeExtraBenefitList : ictus.Common.Entity.CompanyStuffBase
	{
//		============================== Constructor ==============================
        public EmployeeExtraBenefitList(ictus.Common.Entity.Company value)
            : base(value)
		{

		}

//		============================== Public Method ==============================
		public void Add(EmployeeExtraBenefit value)
		{
			base.Add(value);
		}

		public void Remove(EmployeeExtraBenefit value)  
		{base.Remove(value);}

		public EmployeeExtraBenefit this[int index]
		{
			get{return (EmployeeExtraBenefit) base.BaseGet(index);}
			set{base.BaseSet(index, value);}
		}

		public EmployeeExtraBenefit this[String key]  
		{
			get{return (EmployeeExtraBenefit) base.BaseGet(key);}
			set{base.BaseSet(key, value);}
		}
	}
}
