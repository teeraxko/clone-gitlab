using System;

using ictus.PIS.PI.Entity;

namespace Entity.AttendanceEntities
{
	public class TrPayrollBenefitList : ictus.Common.Entity.CompanyStuffBase
	{
//		============================== Constructor ==============================
        public TrPayrollBenefitList(ictus.Common.Entity.Company company)
            : base(company)
		{
		}

//		============================== Public Method ==============================
		public void Add(TrPayrollBenefit value)
		{base.Add(value);}

		public void Remove(TrPayrollBenefit value)
		{base.Remove(value);}
  
		public TrPayrollBenefit this[int index]
		{
			get{return (TrPayrollBenefit) base.BaseGet(index);}
			set{base.BaseSet(index, value);}
		}

		public TrPayrollBenefit this[String key]  
		{
			get{return (TrPayrollBenefit) base.BaseGet(key);}
			set{base.BaseSet(key, value);}
		}
	}
}
