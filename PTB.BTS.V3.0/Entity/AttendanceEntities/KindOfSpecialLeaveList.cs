using System;

using ictus.Common.Entity;
using ictus.PIS.PI.Entity;

namespace Entity.AttendanceEntities
{
    public class KindOfSpecialLeaveList : CompanyStuffBase
	{
//		============================== Constructor ==============================
        public KindOfSpecialLeaveList(ictus.Common.Entity.Company value)
            : base(value)
		{
		}

//		============================== Public Method ==============================
		public void Add(KindOfSpecialLeave value)
		{base.Add(value);}

		public void Remove(KindOfSpecialLeave value)
		{base.Remove(value);}
	
		public KindOfSpecialLeave this[int index]
		{
			get
			{return (KindOfSpecialLeave) base.BaseGet(index);}
			set
			{base.BaseSet(index, value);}
		}

		public KindOfSpecialLeave this[String key]  
		{
			get
			{return (KindOfSpecialLeave) base.BaseGet(key);}
			set
			{base.BaseSet(key, value);}
		}
	}
}
