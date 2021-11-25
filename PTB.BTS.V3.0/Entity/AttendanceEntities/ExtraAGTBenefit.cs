using System;

using ictus.Common.Entity.General;

namespace Entity.AttendanceEntities
{
	public class ExtraAGTBenefit : ExtraBenefit, IKey
	{
//		============================== Property ==============================
		private decimal monthlyAmount = NullConstant.DECIMAL;
		public decimal MonthlyAmount
		{
			get{return monthlyAmount;}
			set{monthlyAmount = value;}
		}

		private decimal daysDeduction = NullConstant.DECIMAL;
		public decimal DaysDeduction
		{
			get{return daysDeduction;}
			set{daysDeduction = value;}
		}

		private decimal deductionAmountPerDay = NullConstant.DECIMAL;
		public decimal DeductionAmountPerDay
		{
			get{return deductionAmountPerDay;}
			set{deductionAmountPerDay = value;}
		}

		private decimal totalDeductionAmount = NullConstant.DECIMAL;
		public decimal TotalDeductionAmount
		{
			get{return totalDeductionAmount;}
			set{totalDeductionAmount = value;}
		}

//		============================== Constructor ==============================
		public ExtraAGTBenefit() : base()
		{}		

//		============================== Public Method ==============================
		public override string EntityKey
		{
			get{return base.EntityKey;}
		}
	}
}
