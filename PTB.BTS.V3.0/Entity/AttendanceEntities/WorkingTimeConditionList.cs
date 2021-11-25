using System;

using ictus.PIS.PI.Entity;

namespace Entity.AttendanceEntities
{

    public class WorkingTimeConditionList : ictus.Common.Entity.CompanyStuffBase
	{
//		============================== Constructor ==============================
        public WorkingTimeConditionList(ictus.Common.Entity.Company company)
            : base(company)
		{}

//		============================== Public Method ==============================
		public void Add(WorkingTimeCondition aWorkingTimeCondition)
		{
			base.Add(aWorkingTimeCondition);
		}

		public void Remove(WorkingTimeCondition aWorkingTimeCondition)
		{
			base.Remove(aWorkingTimeCondition);
		}

		public WorkingTimeCondition this[int index]
		{
			get
			{
				return (WorkingTimeCondition) base.BaseGet(index);

			}
			set
			{
				base.BaseSet(index, value);
			}
		}

		public WorkingTimeCondition this[String key]  
		{
			get
			{
				return (WorkingTimeCondition) base.BaseGet(key);

			}
			set
			{
				base.BaseSet(key, value);
			}
		}
	}
}
