using System;

using ictus.Common.Entity.General;using ictus.Framework.ASC.Entity.DNF20;
using ictus.PIS.PI.Entity;

namespace Entity.AttendanceEntities
{
	public class TrPayrollBenefit : EntityBase, IKey
	{
//		============================== Property ==============================
		private Employee aEmployee;
		public Employee AEmployee
		{
			set{aEmployee = value;}
			get{return aEmployee;}
		}

		private decimal otAHour = NullConstant.DECIMAL;
		public decimal OTAHour
		{
			set{otAHour = value;}
			get{return otAHour;}			
		}

		private decimal otBHour = NullConstant.DECIMAL;
		public decimal OTBHour
		{
			set{otBHour = value;}
			get{return otBHour;}			
		}

		private decimal otCHour = NullConstant.DECIMAL;
		public decimal OTCHour
		{
			set{otCHour = value;}
			get{return otCHour;}			
		}

		private decimal extraAmount = NullConstant.DECIMAL;
		public decimal ExtraAmount
		{
			set{extraAmount = value;}
			get{return extraAmount;}			
		}

		private decimal deductionAmount = NullConstant.DECIMAL;
		public decimal DeductionAmount
		{
			set{deductionAmount = value;}
			get{return deductionAmount;}			
		}

		private DateTime paymentDate = NullConstant.DATETIME;
		public DateTime PaymentDate 
		{
			set{paymentDate = value;}
			get{return paymentDate;}			
		}

//		============================== Constructor ==============================
		public TrPayrollBenefit() : base()
		{		
		}

		#region IKey Members

		public override string EntityKey
		{
			get
			{
				return aEmployee.EntityKey;
			}
		}

		#endregion
	}
}
