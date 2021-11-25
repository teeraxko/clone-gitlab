using System;

using ictus.PIS.PI.Entity;

namespace Entity.AttendanceEntities
{
    public class OTPatternConditionList : ictus.Common.Entity.CompanyStuffBase
	{
//		============================== Property ==============================


//		============================== Constructor ==============================
        public OTPatternConditionList(ictus.Common.Entity.Company value)
            : base(value)
		{}

//		============================== Public Method ==============================
		public void Add(OTPatternConditionBase value)
		{base.Add(value);}

		public void Remove(OTPatternConditionBase value)
		{base.Remove(value);}

		public OTPatternConditionBase this[int index]
		{
			get{return (OTPatternConditionBase) base.BaseGet(index);}
			set{base.BaseSet(index, value);}
		}

		public OTPatternConditionBase this[String key]  
		{
			get{return (OTPatternConditionBase) base.BaseGet(key);}
			set{base.BaseSet(key, value);}
		}
	}
}
