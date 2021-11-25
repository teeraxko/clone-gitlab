using System;

using ictus.PIS.PI.Entity;

namespace Entity.AttendanceEntities
{
	public class EmployeeMiscBenefit : EmployeeBenefitBase
	{
//		============================== Constructor ==============================
		public EmployeeMiscBenefit(Employee aEmployee) : base(aEmployee)
		{
		}

//		============================== Public Method ==============================
		public void Add(MiscBenefit value)
		{base.Add(value);}

		public void Remove(MiscBenefit value)  
		{base.Remove(value);}
		
		public MiscBenefit this[int index]
		{
			get{return (MiscBenefit)base.BaseGet(index);}
			set{base.BaseSet(index, value);}
		}

		public MiscBenefit this[String key]  
		{
			get{return (MiscBenefit)base.BaseGet(key);}
			set{base.BaseSet(key, value);}
		}
	}
}
