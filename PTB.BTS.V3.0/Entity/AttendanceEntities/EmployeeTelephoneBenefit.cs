using System;

using ictus.Common.Entity.General;
using ictus.PIS.PI.Entity;

namespace Entity.AttendanceEntities
{
	public class EmployeeTelephoneBenefit : EmployeeBenefitBase
	{
//		============================== Constructor ==============================
		public EmployeeTelephoneBenefit(Employee aEmployee) : base(aEmployee)
		{
		}

//		============================== Public Method ==============================
		public void Add(TelephoneBenefit value)
		{base.Add(value);}

		public void Remove(TelephoneBenefit value)  
		{base.Remove(value);}
		
		public TelephoneBenefit this[int index]
		{
			get{return (TelephoneBenefit)base.BaseGet(index);}
			set{base.BaseSet(index, value);}
		}

		public TelephoneBenefit this[String key]  
		{
			get{return (TelephoneBenefit)base.BaseGet(key);}
			set{base.BaseSet(key, value);}
		}
	}
}
