using System;

using ictus.PIS.PI.Entity;

namespace Entity.AttendanceEntities.BenefitEntities
{
	public class BenefitTaxi : BenefitBase
	{
		//============================== Property ==============================
		private int times;
		public int Times
		{
			get{return times;}
			set{times = value;}
		}

		private decimal amount;
		public decimal Amount
		{
			get{return amount;}
			set{amount = value;}
		}

		private decimal totalAmount;
		public decimal TotalAmount
		{
			get{return totalAmount;}
			set{totalAmount = value;}
		}

		//============================== Constructor ==============================
		public BenefitTaxi(DateTime value) : base(value)
		{
		}

		//============================== Public Method ==============================

	}
}