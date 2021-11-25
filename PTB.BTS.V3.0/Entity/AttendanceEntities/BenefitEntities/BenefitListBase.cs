using System;

using ictus.Common.Entity.Time;
using ictus.PIS.PI.Entity;

namespace Entity.AttendanceEntities.BenefitEntities
{
	public class BenefitListBase : EmployeeStuffBase
	{
		//============================== Property ==============================
		private YearMonth forMonth;
		public YearMonth ForMonth
		{
			get{return forMonth;}
		}

		//============================== Constructor ==============================
		public BenefitListBase(Employee value, YearMonth forMonth) : base(value)
		{
			this.forMonth = forMonth;
		}

		//============================== Public Method ==============================

	}
}