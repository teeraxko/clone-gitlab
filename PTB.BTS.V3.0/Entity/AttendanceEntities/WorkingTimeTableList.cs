using System;

using ictus.PIS.PI.Entity;

namespace Entity.AttendanceEntities
{
    public class WorkingTimeTableList : ictus.Common.Entity.CompanyStuffBase
	{
//		============================== Constructor ==============================
        public WorkingTimeTableList(ictus.Common.Entity.Company company)
            : base(company)
		{}

//		============================== Public Method ==============================
		public void Add(WorkingTimeTable aWorkingTimeTable)
		{
			base.Add(aWorkingTimeTable);
		}

		public void Remove(WorkingTimeTable aWorkingTimeTable)
		{
			base.Remove(aWorkingTimeTable);
		}

		public WorkingTimeTable this[int index]
		{
			get
			{
				return (WorkingTimeTable) base.BaseGet(index);

			}
			set
			{
				base.BaseSet(index, value);
			}
		}

		public WorkingTimeTable this[String key]  
		{
			get
			{
				return (WorkingTimeTable) base.BaseGet(key);
			}
			set
			{
				base.BaseSet(key, value);
			}
		}
	}
}

