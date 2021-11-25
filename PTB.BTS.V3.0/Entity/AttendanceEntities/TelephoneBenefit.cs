using System;

using ictus.Common.Entity.Time;
using ictus.Common.Entity.General;

namespace Entity.AttendanceEntities
{
	public class TelephoneBenefit : BenefitContributionBase, IKey	
	{
//		============================== Property ==============================
		private YearMonth aYearMonth = NullConstant.YEARMONTH;
		public YearMonth AYearMonth
		{
			get{return aYearMonth;}
			set{aYearMonth = value;}
		}

		private BenefitPayment aBenefitPayment;
		public BenefitPayment ABenefitPayment
		{
			get{return aBenefitPayment;}
			set{aBenefitPayment = value;}
		}

//		============================== Constructor ==============================
		public TelephoneBenefit() : base()
		{
			aBenefitPayment = new BenefitPayment();
		}

//		============================== Public Method ==============================
		public override string EntityKey
		{
			get{return base.EntityKey + aYearMonth.Year.ToString() + aYearMonth.Month.ToString();}
		}
	}
}
