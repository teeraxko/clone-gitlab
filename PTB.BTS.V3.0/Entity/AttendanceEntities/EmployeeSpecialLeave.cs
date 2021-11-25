using System;

using ictus.Common.Entity.Time;
using ictus.PIS.PI.Entity;

using Entity.CommonEntity;

namespace Entity.AttendanceEntities
{
	public class EmployeeSpecialLeave : EmployeeBenefitBase
	{
//		============================== Property ==============================
		private YearMonth aYearMonth;
		public YearMonth AYearMonth
		{
			get{return aYearMonth;}
			set{aYearMonth = value;}
		}

//		============================== Constructor ==============================
		public EmployeeSpecialLeave(Employee aEmployee, YearMonth yearMonth) : base(aEmployee)
		{
			aYearMonth = yearMonth;
		}

		public EmployeeSpecialLeave(Employee aEmployee, DateTime dateTime) : base(aEmployee)
		{
			aYearMonth = new YearMonth(dateTime);
		}

//		============================== Public Method ==============================
		public void Add(SpecialLeave value)
		{base.Add(value);}

		public void Remove(SpecialLeave value)  
		{base.Remove(value);}
		
		public SpecialLeave this[int index]
		{
			get{return (SpecialLeave)base.BaseGet(index);}
			set{base.BaseSet(index, value);}
		}

		public SpecialLeave this[String key]  
		{
			get{return (SpecialLeave)base.BaseGet(key);}
			set{base.BaseSet(key, value);}
		}

		public decimal CountByMonth(int month, int year)
		{
			decimal result = 0;
			for(int i=0; i<this.Count; i++)
			{
				if(this[i].LeaveDate.Year.Equals(year) && this[i].LeaveDate.Month.Equals(month))
				{
					if (this[i].PeriodStatus == LEAVE_PERIOD_TYPE.ONE_DAY)
					{
						++result;
					}
					else
					{
						result = result + 0.5m;
					}
				}
			}
			return result;
		}
	}
}