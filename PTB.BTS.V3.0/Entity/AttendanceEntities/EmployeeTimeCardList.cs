using System;

using ictus.PIS.PI.Entity;

namespace Entity.AttendanceEntities
{
    public class EmployeeTimeCardList : ictus.Common.Entity.CompanyStuffBase
	{
		//==============================  Constructor  ==============================
        public EmployeeTimeCardList(ictus.Common.Entity.Company value)
            : base(value)
		{
		}

		//============================== Public Method ==============================
		public void Add(EmployeeTimeCard value)
		{
			base.Add(value);
		}

		public void Remove(EmployeeTimeCard value)  
		{
			base.Remove(value);
		}

		public EmployeeTimeCard this[int index]
		{
			get
			{
				return (EmployeeTimeCard) base.BaseGet(index);
			}
			set
			{
				base.BaseSet(index, value);
			}
		}

		public EmployeeTimeCard this[String key]  
		{
			get
			{
				return (EmployeeTimeCard) base.BaseGet(key);
			}
			set
			{
				base.BaseSet(key, value);
			}
		}
	}
}