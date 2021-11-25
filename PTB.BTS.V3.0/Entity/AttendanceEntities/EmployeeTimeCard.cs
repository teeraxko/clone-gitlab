using System;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.Time;
using ictus.Common.Entity.General;

namespace Entity.AttendanceEntities
{
	public class EmployeeTimeCard : EmployeeStuffBase, IKey
	{
//		============================== Property ==============================
		private YearMonth aYearMonth;
		public YearMonth AYearMonth
		{
			get{return aYearMonth;}
			set{aYearMonth = value;}
		}

//		============================== Constructor ==============================
		public EmployeeTimeCard(Employee value) : base(value)
		{
		}

		public EmployeeTimeCard(Employee value, YearMonth yearMonth) : base(value)
		{
			aYearMonth = yearMonth;
		}

		public EmployeeTimeCard(Employee value, DateTime forDate) : base(value)
		{
			aYearMonth.DateTime = forDate;
		}

//		============================== Public Method ==============================
		public void Add(TimeCard value)
		{base.Add(value);}

		public void Remove(TimeCard value)  
		{base.Remove(value);}

		public TimeCard this[int index]
		{
			get{return (TimeCard) base.BaseGet(index);}
			set{base.BaseSet(index, value);}
		}

		public TimeCard this[String key]  
		{
			get{return (TimeCard) base.BaseGet(key);}
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
