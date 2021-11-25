using System;

using ictus.Common.Entity.Time;
using ictus.Common.Entity.General;
using ictus.Framework.ASC.Entity.DNF20;

namespace Entity.AttendanceEntities
{
	public class PayrollPaymentControl : EntityBase, IKey
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
		public PayrollPaymentControl()
		{
			aBenefitPayment = new BenefitPayment();
		}

//		============================== Public Method ==============================
		public override string EntityKey
		{
			get{return aYearMonth.Year.ToString() + aYearMonth.Month.ToString();}
		}
	}
}
