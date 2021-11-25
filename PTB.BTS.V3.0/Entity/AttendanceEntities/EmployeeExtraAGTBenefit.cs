using System;

using ictus.PIS.PI.Entity;

namespace Entity.AttendanceEntities
{
	public class EmployeeExtraAGTBenefit : EmployeeBenefitBase
	{
//		============================== Constructor ==============================
		public EmployeeExtraAGTBenefit(Employee aEmployee) : base(aEmployee)
		{}

//		============================== Public Method ==============================
		public void Add(ExtraAGTBenefit value)
		{base.Add(value);}

		public void Remove(ExtraAGTBenefit value)  
		{base.Remove(value);}

		public  ExtraAGTBenefit this[int index]
		{
			get{return (ExtraAGTBenefit)base.BaseGet(index);}
			set{base.BaseSet(index, value);}
		}

		public  ExtraAGTBenefit this[String key]  
		{
			get{return (ExtraAGTBenefit)base.BaseGet(key);}
			set{base.BaseSet(key, value);}
		}
	}
}