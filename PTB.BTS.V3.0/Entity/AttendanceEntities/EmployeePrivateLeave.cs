using System;

using ictus.Common.Entity.Time;
using ictus.PIS.PI.Entity;

namespace Entity.AttendanceEntities
{
	public class EmployeePrivateLeave : EmployeeBenefitBase
	{
//		============================== Property ==============================
		private YearMonth aYearMonth;
		public YearMonth AYearMonth
		{
			get{return aYearMonth;}
			set{aYearMonth = value;}
		}

//		============================== Constructor ==============================
		public EmployeePrivateLeave(Employee aEmployee, YearMonth yearMonth) : base(aEmployee)
		{
			aYearMonth = yearMonth;
		}

		public EmployeePrivateLeave(Employee aEmployee, DateTime dateTime) : base(aEmployee)
		{
			aYearMonth = new YearMonth(dateTime);
		}

//		============================== Public Method ==============================
		public void Add(PrivateLeave value)
		{base.Add(value);}

		public void Remove(PrivateLeave value)  
		{base.Remove(value);}
		
		public PrivateLeave this[int index]
		{
			get{return (PrivateLeave)base.BaseGet(index);}
			set{base.BaseSet(index, value);}
		}

		public PrivateLeave this[String key]  
		{
			get{return (PrivateLeave)base.BaseGet(key);}
			set{base.BaseSet(key, value);}
		}
	}
}