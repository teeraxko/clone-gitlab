using System;

using ictus.Common.Entity.Time;
using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

namespace Entity.AttendanceEntities
{
    public class EmployeeBenefitAdjustment : CompanyStuffBase
	{
//		============================== Property ==============================
		private YearMonth aYearMonth;
		public YearMonth AYearMonth
		{
			get{return aYearMonth;}
			set{aYearMonth = value;}
		}

//		============================== Constructor ==============================
        public EmployeeBenefitAdjustment(Company value)
            : base(value)
		{
		}

        public EmployeeBenefitAdjustment(Company aCompany, YearMonth forYearMonth)
            : base(aCompany)
		{
			aYearMonth = forYearMonth;
		}

//		============================== Public Method ==============================
		public void Add(BenefitAdjustment value)
		{base.Add(value);}

		public void Remove(BenefitAdjustment value)  
		{base.Remove(value);}
		
		public BenefitAdjustment this[int index]
		{
			get{return (BenefitAdjustment)base.BaseGet(index);}
			set{base.BaseSet(index, value);}
		}

		public BenefitAdjustment this[String key]  
		{
			get{return (BenefitAdjustment)base.BaseGet(key);}
			set{base.BaseSet(key, value);}
		}
	}
}
