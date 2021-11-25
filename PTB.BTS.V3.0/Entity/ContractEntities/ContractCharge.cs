using System;

using ictus.Common.Entity.General;
using ictus.Framework.ASC.Entity.DNF20;
using Entity.AttendanceEntities;
using Entity.CommonEntity;

namespace Entity.ContractEntities
{
	public class ContractCharge : EntityBase, IKey
	{
//		============================== Property ==============================
        protected TimePeriod aPeriod;
		public TimePeriod APeriod
		{
			get{return aPeriod;}
			set{aPeriod = value;}
		}

        protected Decimal unitChargeAmount = NullConstant.DECIMAL;
		public Decimal UnitChargeAmount
		{
			get{return unitChargeAmount;}
			set{unitChargeAmount = value;}
		}

        protected Decimal firstMonthCharge = NullConstant.DECIMAL;
		public Decimal FirstMonthCharge
		{
			get{return firstMonthCharge;}
			set{firstMonthCharge = value;}
		}

        protected Decimal monthlyCharge = NullConstant.DECIMAL;
		public Decimal MonthlyCharge
		{
			get{return monthlyCharge;}
			set{monthlyCharge = value;}
		}

        protected Decimal lastMonthCharge = NullConstant.DECIMAL;
		public Decimal LastMonthCharge
		{
			get{return lastMonthCharge;}
			set{lastMonthCharge = value;}
		}

//		============================== Constructor ==============================
		public ContractCharge() : base()
		{
			aPeriod = new TimePeriod();
		}

		#region IKey Members

		public override string EntityKey
		{
			get{return aPeriod.From.ToShortDateString() + aPeriod.To.ToShortDateString();}
		}

		#endregion
	}
}
