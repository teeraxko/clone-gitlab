using System;

namespace Entity.AttendanceEntities
{
	public abstract class TripBenefitBase : BenefitContributionBase
	{
//		============================== Property ==============================
		protected BenefitPayment aBenefitPayment;
		public BenefitPayment ABenefitPayment
		{
			get{return aBenefitPayment;}
			set{aBenefitPayment = value;}
		}

//		============================== Constructor ==============================
		protected TripBenefitBase() : base()
		{
			aBenefitPayment = new BenefitPayment();
		}
	}
}