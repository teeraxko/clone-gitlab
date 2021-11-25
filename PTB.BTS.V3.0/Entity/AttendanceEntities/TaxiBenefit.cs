using System;

using ictus.Common.Entity.General;
using Entity.CommonEntity;

namespace Entity.AttendanceEntities
{
	public class TaxiBenefit : BenefitContributionBase, IKey
	{
//		============================== Property ==============================
		private DateTime benefitDate = NullConstant.DATETIME;
		public DateTime BenefitDate
		{
			get{return benefitDate;}
			set{benefitDate = value;}
		}

		private decimal baseAmount = NullConstant.DECIMAL;
		public decimal BaseAmount
		{
			get{return baseAmount;}
			set{baseAmount = value;}
		}

		private byte times;
		public byte Times
		{
			get{return times;}
			set{times = value;}
		}

		private BenefitPayment aBenefitPayment;
		public BenefitPayment ABenefitPayment
		{
			get{return aBenefitPayment;}
			set{aBenefitPayment = value;}
		}

		private decimal benefitAmountForCharge;
		public decimal BenefitAmountForCharge
		{
			get{return benefitAmountForCharge;}
			set{benefitAmountForCharge = value;}
		}

		private byte timesForCharge;
		public byte TimesForCharge
		{
			get{return timesForCharge;}
			set{timesForCharge = value;}
		}

		private decimal benefitTotalAmountForCharge;
		public decimal BenefitTotalAmountForCharge
		{
			get{return benefitTotalAmountForCharge;}
			set{benefitTotalAmountForCharge = value;}
		}

//		============================== Constructor ==============================
		public TaxiBenefit() : base()
		{
			aBenefitPayment = new BenefitPayment();
			aBenefitPayment.PaymentStatus = PAYMENT_STATUS_TYPE.NO;
		}

//		============================== Public Method ==============================
		public override string EntityKey
		{
			get{return benefitDate.ToShortDateString();}
		}
	}
}