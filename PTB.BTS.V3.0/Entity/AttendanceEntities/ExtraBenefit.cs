using System;

using ictus.Common.Entity.General;
using ictus.Common.Entity.Time;
using Entity.CommonEntity;

namespace Entity.AttendanceEntities
{
	public class ExtraBenefit : BenefitContributionBase, IKey	
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

		private string remark = NullConstant.STRING;
		public string Remark
		{
			get{return remark;}
			set{remark = value;}
		}

//		============================== Constructor ==============================
		public ExtraBenefit() : base()
		{
			aBenefitPayment = new BenefitPayment();
			aBenefitPayment.PaymentStatus = PAYMENT_STATUS_TYPE.NO;
		}

//		============================== Public Method ==============================
		public override string EntityKey
		{
			get{return base.EntityKey + aYearMonth.Year.ToString() + aYearMonth.Month.ToString();}
		}
	}
}