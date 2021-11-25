using System;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

namespace Entity.AttendanceEntities
{
    public class AttendanceStatusList : CompanyStuffBase
	{
//		============================== Constructor ==============================
        public AttendanceStatusList(ictus.Common.Entity.Company value)
            : base(value)
		{

		}

//		============================== Public Method ==============================
		public void Add(AttendanceStatus value)
		{base.Add(value);}

		public void Remove(AttendanceStatus value)
		{base.Remove(value);}

		public AttendanceStatus this[int index]
		{
			get{return (AttendanceStatus) base.BaseGet(index);}
			set{base.BaseSet(index, value);}
		}
		public AttendanceStatus this[String key]  
		{
			get{return (AttendanceStatus) base.BaseGet(key);}
			set{base.BaseSet(key, value);}
		}
	}
}
