using System;

using ictus.PIS.PI.Entity;

namespace Entity.AttendanceEntities
{
	public class EmployeeExtraAGTBenefitDeduction : EmployeeBenefitBase
	{
//		============================== Constructor ==============================
		public EmployeeExtraAGTBenefitDeduction(Employee aEmployee) : base(aEmployee)
		{
		}

//		============================== Public Method ==============================
		public void Add(ExtraAGTBenefitDeduction value)
		{base.Add(value);}

		public void Remove(ExtraAGTBenefitDeduction value)  
		{base.Remove(value);}

		public  ExtraAGTBenefitDeduction this[int index]
		{
			get{return (ExtraAGTBenefitDeduction)base.BaseGet(index);}
			set{base.BaseSet(index, value);}
		}

		public  ExtraAGTBenefitDeduction this[String key]  
		{
			get{return (ExtraAGTBenefitDeduction)base.BaseGet(key);}
			set{base.BaseSet(key, value);}
		}
	}
}
