using System;

using ictus.Common.Entity.General;
using ictus.Common.Entity.Time;

namespace Entity.AttendanceEntities
{
	public class MiscBenefit : BenefitContributionBase, IKey	
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

		private string description = NullConstant.STRING;
		public string Description
		{
			get{return description;}
			set{description = value;}
		}

//		============================== Constructor ==============================
		public MiscBenefit()
		{
			aBenefitPayment = new BenefitPayment();
		}

//		============================== Public Method ==============================
		public override string EntityKey
		{
			get{return base.EntityKey + aYearMonth.Year.ToString() + aYearMonth.Month.ToString() + description;}
		}
	}
}
