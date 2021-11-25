using System;

using ictus.PIS.PI.Entity;

namespace Entity.AttendanceEntities
{	
	public class EmployeeOvernightTrip : EmployeeTripBase
	{
//		============================== Constructor ==============================
		public EmployeeOvernightTrip(Employee value) : base(value)
		{}

//		============================== Public Method ==============================
		public void Add(OvernightTrip value)
		{base.Add(value);}

		public void Remove(OvernightTrip value)
		{base.Remove(value);}

		public OvernightTrip this[int index]
		{
			get{return (OvernightTrip) base.BaseGet(index);}
			set{base.BaseSet(index, value);}
		}

		public OvernightTrip this[String key]  
		{
			get{return (OvernightTrip) base.BaseGet(key);}
			set{base.BaseSet(key, value);}
		}
	}
}

