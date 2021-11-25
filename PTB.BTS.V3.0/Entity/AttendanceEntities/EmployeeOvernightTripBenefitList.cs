using System;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.Time;
using ictus.Common.Entity.General;

namespace Entity.AttendanceEntities
{	
	public class EmployeeOvernightTripBenefitList : EmployeeBenefitBase
	{
		#region - Private - 
		private bool disposed = false;
		#endregion

//		============================== Property ==============================
		private YearMonth forYearMonth = NullConstant.YEARMONTH;
		public YearMonth ForYearMonth
		{
			get{return forYearMonth;}
			set{forYearMonth = value;}
		}

//		============================== Constructor ==============================
		public EmployeeOvernightTripBenefitList(Employee value) : base(value)
		{}

		public EmployeeOvernightTripBenefitList(Employee value, DateTime forYearMonth) : base(value)
		{
			this.forYearMonth.DateTime = forYearMonth;
		}

		public EmployeeOvernightTripBenefitList(Employee value, YearMonth forYearMonth) : base(value)
		{
			this.forYearMonth = forYearMonth;
		}

//		============================== Public Method ==============================
		public void Add(EmployeeOvernightTripBenefit value)
		{
			value.ForYearMonth = this.ForYearMonth;
			base.Add(value);
		}

		public void Remove(EmployeeOvernightTripBenefit value)
		{base.Remove(value);}

		public EmployeeOvernightTripBenefit this[int index]
		{
			get{return (EmployeeOvernightTripBenefit) base.BaseGet(index);}
			set{base.BaseSet(index, value);}
		}

		public EmployeeOvernightTripBenefit this[String key]  
		{
			get{return (EmployeeOvernightTripBenefit) base.BaseGet(key);}
			set{base.BaseSet(key, value);}
		}
		#region IDisposable Members
		protected override void Dispose(bool disposing)
		{
			if(!this.disposed)
			{
				try
				{
					if(disposing)
					{
						
					}
					this.disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}
		#endregion

	}
}
