using System;

using ictus.PIS.PI.Entity;

namespace Entity.AttendanceEntities
{
    public class EmployeeWorkScheduleList : ictus.Common.Entity.CompanyStuffBase
	{
//		============================== Constructor ==============================
        public EmployeeWorkScheduleList(ictus.Common.Entity.Company value)
            : base(value)
		{
		}

//		============================== Public Method ==============================
		public void Add(EmployeeWorkSchedule value)
		{
			base.Add(value);
		}

		public void Remove(EmployeeWorkSchedule value)  
		{
			base.Remove(value);
		}

		public EmployeeWorkSchedule this[int index]
		{
			get
			{
				return (EmployeeWorkSchedule) base.BaseGet(index);
			}
			set
			{
				base.BaseSet(index, value);
			}
		}

		public EmployeeWorkSchedule this[String key]  
		{
			get
			{
				return (EmployeeWorkSchedule) base.BaseGet(key);
			}
			set
			{
				base.BaseSet(key, value);
			}
		}
	}
}
