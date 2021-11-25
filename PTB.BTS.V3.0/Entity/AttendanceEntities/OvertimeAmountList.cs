using System;

using ictus.PIS.PI.Entity;
namespace Entity.AttendanceEntities
{
    public class OvertimeAmountList : ictus.Common.Entity.CompanyStuffBase
	{
//		============================== Constructor ==============================
        public OvertimeAmountList(ictus.Common.Entity.Company company)
            : base(company)
		{
		}

//		============================== Public Method ==============================
		public void Add(OvertimeAmount aOvertimeAmount)
		{
			base.Add(aOvertimeAmount);
		}

		public void Remove(OvertimeAmount value)
		{
			base.Remove(value);
		}

		public OvertimeAmount this[int index]
		{
			get
			{
				return (OvertimeAmount) base.BaseGet(index);
			}
			set
			{
				base.BaseSet(index, value);
			}
		}

		public OvertimeAmount this[String key]  
		{
			get
			{
				return (OvertimeAmount) base.BaseGet(key);

			}
			set
			{
				base.BaseSet(key, value);
			}
		}


	}
}
