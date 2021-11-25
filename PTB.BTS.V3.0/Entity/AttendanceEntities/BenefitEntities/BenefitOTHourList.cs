using System;

using ictus.Common.Entity.General;
using ictus.PIS.PI.Entity;
using ictus.Common.Entity.Time;

namespace Entity.AttendanceEntities.BenefitEntities
{
	public class BenefitOTHourList : BenefitListBase
	{
		//==============================  Property  ==============================
		private OTRate totalOTRate;
		public OTRate TotalOTRate
		{
			get{return totalOTRate;}
			set{totalOTRate = value;}
		}

		//============================== Constructor ==============================
		public BenefitOTHourList(Employee value, YearMonth forMonth) : base(value, forMonth)
		{
			totalOTRate = new OTRate();
		}

		//============================== Public Method ==============================
		public void Add(BenefitOTHour value)
		{base.Add(value);}

		public void Remove(BenefitOTHour value)
		{base.Remove(value);}

		public bool Contain(DateTime value)
		{
			return (bool)(base.BaseGet(value.ToShortDateString()) != null);
		}

		public BenefitOTHour this[int index]
		{
			get{return (BenefitOTHour) base.BaseGet(index);}
			set{base.BaseSet(index, value);}
		}

		public BenefitOTHour this[String key]  
		{
			get{return (BenefitOTHour) base.BaseGet(key);}
			set{base.BaseSet(key, value);}
		}

		public BenefitOTHour this[DateTime key]  
		{
			get{return (BenefitOTHour) base.BaseGet(key.ToShortDateString());}
			set{base.BaseSet(key.ToShortDateString(), value);}
		}
	}
}