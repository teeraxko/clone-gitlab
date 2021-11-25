using System;

using ictus.PIS.PI.Entity;

namespace Entity.AttendanceEntities
{
    public class AnnualLeaveSaleList : ictus.Common.Entity.CompanyStuffBase
	{
//		==============================  Constructor  ==============================
        public AnnualLeaveSaleList(ictus.Common.Entity.Company value)
            : base(value)
		{
		}

//		============================== Public Method ==============================
		public void Add(AnnualLeaveSale value)
		{base.Add(value);}

		public void Remove(AnnualLeaveSale value)
		{base.Remove(value);}

		public AnnualLeaveSale this[int index]
		{
			get{return (AnnualLeaveSale) base.BaseGet(index);}
			set{base.BaseSet(index, value);}
		}
		public AnnualLeaveSale this[String key]  
		{
			get{return (AnnualLeaveSale) base.BaseGet(key);}
			set{base.BaseSet(key, value);}
		}
	}
}
