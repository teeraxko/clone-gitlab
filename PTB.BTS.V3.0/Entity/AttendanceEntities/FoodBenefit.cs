using System;

using ictus.Common.Entity.General;

namespace Entity.AttendanceEntities
{
	public class FoodBenefit : BenefitContributionBase, IKey
	{
//		============================== Property ==============================
		private DateTime benefitDate = NullConstant.DATETIME;
		public DateTime BenefitDate
		{
			get{return benefitDate;}
			set{benefitDate = value;}
		}

		private BenefitPayment aBenefitPayment;
		public BenefitPayment ABenefitPayment
		{
			get{return aBenefitPayment;}
			set{aBenefitPayment = value;}
		}

//		============================== Constructor ==============================
		public FoodBenefit() : base()
		{
			aBenefitPayment = new BenefitPayment();
		}

//		============================== Public Method ==============================
		public override string EntityKey
		{
			get{return base.EntityKey + benefitDate.ToShortDateString();}
		}
	}
}
