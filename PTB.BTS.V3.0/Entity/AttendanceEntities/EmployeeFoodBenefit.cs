using System;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.Time;

namespace Entity.AttendanceEntities
{
	public class EmployeeFoodBenefit : EmployeeBenefitBase
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
		public EmployeeFoodBenefit(Employee employee, YearMonth yearMonth) : base(employee)
		{
			aYearMonth = yearMonth;
		}

//		============================== Public Method ==============================
		public void Add(FoodBenefit value)
		{base.Add(value);}

		public void Remove(FoodBenefit value)  
		{base.Remove(value);}
		
		public FoodBenefit this[int index]
		{
			get{return (FoodBenefit)base.BaseGet(index);}
			set{base.BaseSet(index, value);}
		}

		public FoodBenefit this[String key]  
		{
			get{return (FoodBenefit) base.BaseGet(key);}
			set{base.BaseSet(key, value);}
		}
	}
}
