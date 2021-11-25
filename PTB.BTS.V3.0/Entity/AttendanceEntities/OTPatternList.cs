using System;

using ictus.PIS.PI.Entity;

namespace Entity.AttendanceEntities
{
    public class OTPatternList : ictus.Common.Entity.CompanyStuffBase	
	{
//		============================== Constructor ==============================
        public OTPatternList(ictus.Common.Entity.Company company)
            : base(company)
    	{}

//		============================== Public Method ==============================
		public void Add(OTPattern value)
		{base.Add(value);}

		public void Remove(OTPattern value)
		{base.Remove(value);}
  
		public OTPattern this[int index]
		{
			get{return (OTPattern) base.BaseGet(index);}
			set{base.BaseSet(index, value);}
		}

		public OTPattern this[String key]  
		{
			get{return (OTPattern) base.BaseGet(key);}
			set{base.BaseSet(key, value);}
		}
	}
}
