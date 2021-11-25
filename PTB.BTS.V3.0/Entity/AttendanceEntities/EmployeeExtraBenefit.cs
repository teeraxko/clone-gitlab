using System;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.General;

namespace Entity.AttendanceEntities
{
	public class EmployeeExtraBenefit : EmployeeBenefitBase, IKey
	{
//		============================== Constructor ==============================
		public EmployeeExtraBenefit(Employee aEmployee) : base(aEmployee)
		{}

//		============================== Public Method ==============================
		public void Add(ExtraBenefit value)
		{base.Add(value);}

		public void Remove(ExtraBenefit value)  
		{base.Remove(value);}
		
		public ExtraBenefit this[int index]
		{
			get{return (ExtraBenefit)base.BaseGet(index);}
			set{base.BaseSet(index, value);}
		}

		public ExtraBenefit this[String key]  
		{
			get{return (ExtraBenefit)base.BaseGet(key);}
			set{base.BaseSet(key, value);}
		}

		#region IKey Members

		public string EntityKey
		{
			get
			{
				return this.Employee.EntityKey;
			}
		}

		#endregion
	}
}
