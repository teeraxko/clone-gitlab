using System;

using ictus.Common.Entity.Time;
using ictus.Common.Entity.General;
using ictus.Framework.ASC.Entity.DNF20;

namespace Entity.VehicleEntities
{
	public class ExcessDeduction : EntityBase, IKey
	{
//		============================== Property ==============================
		private YearMonth aForMonth;
		public YearMonth AForMonth
		{
			set{aForMonth = value;}
			get{return aForMonth;}
		}

		private decimal amount = NullConstant.DECIMAL;
		public decimal Amount
		{			
			set{amount = value;}
			get{return amount;}
		}

		private bool isPaid = false;
		public bool IsPaid
		{
			set{isPaid = value;}
			get{return isPaid;}			
		}

		private DateTime paymentDate = NullConstant.DATETIME;
		public DateTime PaymentDate
		{
			set{paymentDate = value;}
			get{return paymentDate;}			
		}

//		============================== Constructor ==============================
		public ExcessDeduction() : base()
		{}

		#region IKey Members

		public override string EntityKey
		{
			get
			{return aForMonth.Year.ToString() + aForMonth.Month.ToString();}
		}

		#endregion
	}
}
