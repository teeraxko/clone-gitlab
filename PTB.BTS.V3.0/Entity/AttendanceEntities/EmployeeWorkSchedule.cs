using System;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.General;
using ictus.Common.Entity.Time;

namespace Entity.AttendanceEntities
{
	public class EmployeeWorkSchedule : EmployeeStuffBase, IKey
	{
		#region - Private - 
		private bool disposed = false;
		#endregion

//		============================== Property ==============================
		private YearMonth forYearMonth = NullConstant.YEARMONTH;
		public YearMonth ForYearMonth
		{
			get{return forYearMonth;}
		}

//		============================== Constructor ==============================
		public EmployeeWorkSchedule(Employee aEmployee) : base(aEmployee)
		{
			forYearMonth = new YearMonth(DateTime.Today);
		}

		public EmployeeWorkSchedule(Employee aEmployee, YearMonth value) : base(aEmployee)
		{
			forYearMonth = value;
		}

		public EmployeeWorkSchedule(Employee aEmployee, DateTime value) : base(aEmployee)
		{
			forYearMonth.DateTime = value;
		}

//		============================== Public Method ==============================
		public void Add(WorkSchedule value)
		{base.Add(value);}

		public void Remove(WorkSchedule value)  
		{base.Remove(value);}

		public WorkSchedule this[int index]
		{
			get{return (WorkSchedule) base.BaseGet(index);}
			set{base.BaseSet(index, value);}
		}

		public WorkSchedule this[String key]  
		{
			get{return (WorkSchedule) base.BaseGet(key);}
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