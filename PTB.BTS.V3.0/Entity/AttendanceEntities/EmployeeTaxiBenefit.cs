using System;

using ictus.Common.Entity.Time;
using ictus.PIS.PI.Entity;

namespace Entity.AttendanceEntities
{
	public class EmployeeTaxiBenefit : EmployeeBenefitBase
	{
		private YearMonth aYearMonth;
		public YearMonth AYearMonth
		{
			get
			{
				return aYearMonth;
			}
			set
			{
				aYearMonth = value;
			}
		}
//		============================== Constructor ==============================
		public EmployeeTaxiBenefit(Employee aEmployee, YearMonth yearMonth) : base(aEmployee)
		{
			aYearMonth = yearMonth;
		}

//		============================== Public Method ==============================
		public void Add(TaxiBenefit value)
		{base.Add(value);}

		public void Remove(TaxiBenefit value)  
		{base.Remove(value);}

		public TaxiBenefit this[int index]
		{
			get{return (TaxiBenefit) base.BaseGet(index);}
			set{base.BaseSet(index, value);}
		}

		public TaxiBenefit this[String key]  
		{
			get{return (TaxiBenefit) base.BaseGet(key);}
			set{base.BaseSet(key, value);}
		}
	}
}
