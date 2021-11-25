using System;

namespace Entity.AttendanceEntities.BenefitEntities
{
	public class BenefitFood : BenefitBase
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

		//============================== Constructor ==============================
		public BenefitFood(DateTime value) : base(value)
		{
		}

		//============================== Public Method ==============================

	}
}