using System;

using ictus.PIS.PI.Entity;

namespace Entity.AttendanceEntities
{
	public abstract class EmployeeBenefitBase : EmployeeStuffBase
	{
//		============================== Constructor ==============================
		protected EmployeeBenefitBase(Employee aEmployee) : base(aEmployee)
		{
		}

//		============================== Public Method ==============================
		public decimal CalculateTotalAmount()
		{
			return 0m;
		}
	}
}
