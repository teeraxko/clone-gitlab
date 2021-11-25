using System;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.Time;
using ictus.Common.Entity.General;

namespace Entity.AttendanceEntities
{
	public class EmployeeOneDayTripBenefit : EmployeeBenefitBase
	{
//		============================== Property ==============================
		private YearMonth forYearMonth = NullConstant.YEARMONTH;
		public YearMonth ForYearMonth
		{
			get{return forYearMonth;}
			set{forYearMonth = value;}
		}

		private int totalTimes;
		public int TotalTimes
		{
			get{return totalTimes;}
			set{totalTimes = value;}
		}

		private decimal totalAmount;
		public decimal TotalAmount
		{
			get{return totalAmount;}
			set{totalAmount = value;}
		}

//		============================== Constructor ==============================
		public EmployeeOneDayTripBenefit(Employee value) : base(value)
		{}

		public EmployeeOneDayTripBenefit(Employee value, DateTime forYearMonth) : base(value)
		{
			this.forYearMonth.DateTime = forYearMonth;
		}

		public EmployeeOneDayTripBenefit(Employee value, YearMonth forYearMonth) : base(value)
		{
			this.forYearMonth = forYearMonth;
		}

//		============================== Public Method ==============================
		public void Add(OneDayTripBenefit value)
		{base.Add(value);}

		public void Remove(OneDayTripBenefit value)
		{base.Remove(value);}

		public OneDayTripBenefit this[int index]
		{
			get{return (OneDayTripBenefit) base.BaseGet(index);}
			set{base.BaseSet(index, value);}
		}

		public OneDayTripBenefit this[String key]  
		{
			get{return (OneDayTripBenefit) base.BaseGet(key);}
			set{base.BaseSet(key, value);}
		}
	}
}