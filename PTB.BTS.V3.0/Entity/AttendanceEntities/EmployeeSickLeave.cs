using System;

using ictus.Common.Entity.Time;
using ictus.PIS.PI.Entity;

namespace Entity.AttendanceEntities
{
	public class EmployeeSickLeave : EmployeeBenefitBase
	{
//		============================== Property ==============================
		private YearMonth aYearMonth;
		public YearMonth AYearMonth
		{
			get{return aYearMonth;}
			set{aYearMonth = value;}
		}

//		============================== Constructor ==============================
		public EmployeeSickLeave(Employee aEmployee, YearMonth yearMonth) : base(aEmployee)
		{
			aYearMonth = yearMonth;
		}

		public EmployeeSickLeave(Employee aEmployee, DateTime dateTime) : base(aEmployee)
		{
			aYearMonth = new YearMonth(dateTime);
		}

//		============================== Public Method ==============================
		public void Add(SickLeave value)
		{base.Add(value);}

		public void Remove(SickLeave value)  
		{base.Remove(value);}
		
		public SickLeave this[int index]
		{
			get{return (SickLeave)base.BaseGet(index);}
			set{base.BaseSet(index, value);}
		}

		public SickLeave this[String key]  
		{
			get{return (SickLeave)base.BaseGet(key);}
			set{base.BaseSet(key, value);}
		}
	}
}