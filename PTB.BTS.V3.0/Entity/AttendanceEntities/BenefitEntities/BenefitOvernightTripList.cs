using System;

using ictus.Common.Entity.Time;
using ictus.PIS.PI.Entity;

namespace Entity.AttendanceEntities.BenefitEntities
{
	public class BenefitOvernightTripList : EmployeeStuffBase
	{
		//==============================  Property  ==============================
		private YearMonth forMonth;
		public YearMonth ForMonth
		{
			get{return forMonth;}
		}

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
		public BenefitOvernightTripList(Employee value, DateTime forMonth) : base(value)
		{
			this.forMonth = new YearMonth(forMonth);
		}

		public BenefitOvernightTripList(Employee value, YearMonth forMonth) : base(value)
		{
			this.forMonth = forMonth;
		}

		//============================== Public Method ==============================
		public void Add(BenefitOvernightTrip value)
		{base.Add(value);}

		public void Remove(BenefitOvernightTrip value)
		{base.Remove(value);}

		public BenefitOvernightTrip this[int index]
		{
			get{return (BenefitOvernightTrip) base.BaseGet(index);}
			set{base.BaseSet(index, value);}
		}

		public BenefitOvernightTrip this[String key]  
		{
			get{return (BenefitOvernightTrip) base.BaseGet(key);}
			set{base.BaseSet(key, value);}
		}

		public bool Contain(DateTime value)
		{
			for(int i=0; i<this.Count; i++)
			{
				if(this[i].Contain(value))
				{
					return true;
				}
			}
			return false;
		}
	}
}