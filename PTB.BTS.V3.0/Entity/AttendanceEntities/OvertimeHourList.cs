using System;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;

namespace Entity.AttendanceEntities
{
    public class OvertimeHourList : ictus.Common.Entity.CompanyStuffBase
	{		
//		============================== Constructor ==============================
        public OvertimeHourList(ictus.Common.Entity.Company company)
            : base(company)
		{
		}

//		============================== Public Method ==============================
		public void Add(OvertimeHour aOvertimeHour)
		{
			base.Add(aOvertimeHour);
		}

		public void Remove(OvertimeHour value)
		{
			base.Remove(value);
		}
		public OvertimeHour this[int index]
		{
			get
			{
				return (OvertimeHour) base.BaseGet(index);
			}
			set
			{
				base.BaseSet(index, value);
			}
		}
		public OvertimeHour this[String key]  
		{
			get
			{
				return (OvertimeHour) base.BaseGet(key);

			}
			set
			{
				base.BaseSet(key, value);
			}
		}
	}
}
