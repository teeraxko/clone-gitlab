using System;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.Time;

namespace Entity.AttendanceEntities
{
	public class EmployeeOneDayTrip : EmployeeTripBase
	{
//		============================== Constructor ==============================
		public EmployeeOneDayTrip(Employee employee) : base(employee)
		{}

		public EmployeeOneDayTrip(Employee employee,DateTime forYearMonth) : base(employee, forYearMonth)
		{}

		public EmployeeOneDayTrip(Employee employee,YearMonth forYearMonth) : base(employee, forYearMonth)
		{}

//		============================== Public Method ==============================
		public void Add(OneDayTrip value)
		{base.Add(value);}

		public void Remove(OneDayTrip value)
		{base.Remove(value);}
		
		public OneDayTrip this[int index]
		{
			get{return (OneDayTrip)base.BaseGet(index);}
			set{base.BaseSet(index, value);}
		}

		public OneDayTrip this[String key]  
		{
			get{return (OneDayTrip)base.BaseGet(key);}
			set{base.BaseSet(key, value);}
		}
	}
}
