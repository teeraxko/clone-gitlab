using System;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.Time;
using ictus.Common.Entity.General;

namespace Entity.AttendanceEntities
{
	public abstract class EmployeeTripBase : EmployeeStuffBase
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
		protected EmployeeTripBase(Employee value) : base(value)
		{
			forYearMonth = new YearMonth(DateTime.Today);
		}

		protected EmployeeTripBase(Employee value, YearMonth forYearMonth) : base(value)
		{
			this.forYearMonth = forYearMonth;
		}

		protected EmployeeTripBase(Employee value, DateTime forYearMonth) : base(value)
		{
			this.forYearMonth.DateTime = forYearMonth;
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