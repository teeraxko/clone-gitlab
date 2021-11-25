using System;

using ictus.Common.Entity.Time;
using ictus.PIS.PI.Entity;

namespace Entity.AttendanceEntities.BenefitEntities
{
	public class BenefitTaxiList : BenefitListBase
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
		public BenefitTaxiList(Employee value, YearMonth forMonth) : base(value, forMonth)
		{
		}

		//============================== Public Method ==============================
		public void Add(BenefitTaxi value)
		{base.Add(value);}

		public void Remove(BenefitTaxi value)
		{base.Remove(value);}

		public BenefitTaxi this[int index]
		{
			get{return (BenefitTaxi) base.BaseGet(index);}
			set{base.BaseSet(index, value);}
		}

		public BenefitTaxi this[String key]  
		{
			get{return (BenefitTaxi) base.BaseGet(key);}
			set{base.BaseSet(key, value);}
		}

		public BenefitTaxi this[DateTime key]  
		{
			get{return (BenefitTaxi) base.BaseGet(key.ToShortDateString());}
			set{base.BaseSet(key.ToShortDateString(), value);}
		}

		public bool Contain(DateTime value)
		{
			return (bool)(base.BaseGet(value.ToShortDateString()) != null);
		}
	}
}