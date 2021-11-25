using System;

using ictus.Common.Entity.General;
using ictus.PIS.PI.Entity;
using ictus.Common.Entity.Time;

namespace Entity.AttendanceEntities.BenefitEntities
{
	public class WorkInfoList : BenefitListBase
	{
		//============================== Property ==============================

		//============================== Constructor ==============================
		public WorkInfoList(Employee value, YearMonth forMonth) : base(value, forMonth)
		{
		}

		//============================== Public Method ==============================
		public void Add(WorkInfo value)
		{base.Add(value);}

		public void Remove(WorkInfo value)
		{base.Remove(value);}

		public WorkInfo this[int index]
		{
			get{return (WorkInfo) base.BaseGet(index);}
			set{base.BaseSet(index, value);}
		}

		public WorkInfo this[String key]  
		{
			get{return (WorkInfo) base.BaseGet(key);}
			set{base.BaseSet(key, value);}
		}

		public WorkInfo this[DateTime key]  
		{
			get{return (WorkInfo) base.BaseGet(key.ToShortDateString());}
			set{base.BaseSet(key.ToShortDateString(), value);}
		}
	}
}