using System;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.Time;

namespace Entity.AttendanceEntities
{
	public class EmployeeOvertimeHour : EmployeeStuffBase
	{
//		============================== Property ==============================
		private YearMonth aYearMonth;
		public YearMonth AYearMonth
		{
			get
			{
				return aYearMonth;
			}
			set
			{
				aYearMonth = value;
			}
		}

//		============================== Constructor ==============================
		public EmployeeOvertimeHour(Employee employee, YearMonth yearMonth) : base(employee)
		{
			aYearMonth = yearMonth;			
		}

//		============================== Public Method ==============================
		public void Add(OvertimeHour value)
		{
			base.Add(value);
		}

		public void Remove(OvertimeHour value)  
		{
			base.Remove(value);
		}

		public OvertimeHour this[int index]
		{
			get{return (OvertimeHour) base.BaseGet(index);}
			set{base.BaseSet(index, value);}
		}

		public OvertimeHour this[String key]  
		{
			get{return (OvertimeHour) base.BaseGet(key);}
			set{base.BaseSet(key, value);}
		}
	}
}
