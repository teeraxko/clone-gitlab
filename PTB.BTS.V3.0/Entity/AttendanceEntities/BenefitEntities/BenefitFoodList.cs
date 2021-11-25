using System;

using ictus.Common.Entity.General;
using ictus.Common.Entity.Time;
using ictus.PIS.PI.Entity;

namespace Entity.AttendanceEntities.BenefitEntities
{
	public class BenefitFoodList : BenefitListBase
	{
		//============================== Property ==============================
		private int totalTimes;
		public int TotalTimes
		{
			get{return totalTimes;}
			set{totalTimes = value;}
		}

		private decimal totalAmount;
		public decimal TotalAmount
		{
			get{return totalAmount;}
			set{totalAmount = value;}
		}

		//============================== Constructor ==============================
		public BenefitFoodList(Employee value, YearMonth forMonth) : base(value, forMonth)
		{
		}

		//============================== Public Method ==============================
		public void Add(BenefitFood value)
		{base.Add(value);}

		public void Remove(BenefitFood value)
		{base.Remove(value);}

		public BenefitFood this[int index]
		{
			get{return (BenefitFood) base.BaseGet(index);}
			set{base.BaseSet(index, value);}
		}

		public BenefitFood this[String key]  
		{
			get{return (BenefitFood) base.BaseGet(key);}
			set{base.BaseSet(key, value);}
		}

		public BenefitFood this[DateTime key]  
		{
			get{return (BenefitFood) base.BaseGet(key.ToShortDateString());}
			set{base.BaseSet(key.ToShortDateString(), value);}
		}

		public bool Contain(DateTime value)
		{
			return (bool)(base.BaseGet(value.ToShortDateString()) != null);
		}
	}
}