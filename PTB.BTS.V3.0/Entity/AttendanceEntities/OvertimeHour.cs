using System;

using ictus.Common.Entity.General;
using ictus.Framework.ASC.Entity.DNF20;

namespace Entity.AttendanceEntities
{
	public class OvertimeHour : EntityBase, IKey
	{
//		============================== Property ==============================
		private DateTime otDate = NullConstant.DATETIME;
		public DateTime OtDate
		{
			get{return otDate;}
			set{otDate = value;}
		}

		private TimePeriod aBeforeTimePeriod;
		public TimePeriod ABeforeTimePeriod
		{
			get{return aBeforeTimePeriod;}
			set{aBeforeTimePeriod = value;}
		}

		private TimePeriod aDuringTimePeriod;
		public TimePeriod ADuringTimePeriod
		{
			get{return aDuringTimePeriod;}
			set{aDuringTimePeriod = value;}
		}

		private TimePeriod aBreakTimePeriod;
		public TimePeriod ABreakTimePeriod
		{
			get{return aBreakTimePeriod;}
			set{aBreakTimePeriod = value;}
		}

		private TimePeriod aAfterTimePeriod;
		public TimePeriod AAfterTimePeriod
		{
			get{return aAfterTimePeriod;}
			set{aAfterTimePeriod = value;}
		}

		private OTRate aOTRate;
		public OTRate AOTRate
		{
			get{return aOTRate;}
			set{aOTRate = value;}
		}

		private OTRate aOTRateForCharge;
		public OTRate AOTRateForCharge
		{
			get{return aOTRateForCharge;}
			set{aOTRateForCharge = value;}
		}

		private string otReason = NullConstant.STRING;
		public string OtReason
		{
			get{return otReason;}
			set{otReason = value.Trim();}
		}

		private BenefitPayment aBenefitPayment;
		public BenefitPayment ABenefitPayment
		{
			get{return aBenefitPayment;}
			set{aBenefitPayment = value;}
		}

		#region - Private Method -
		private void init()
		{
			aBeforeTimePeriod = new TimePeriod();
			aDuringTimePeriod = new TimePeriod();
			aBreakTimePeriod = new TimePeriod();
			aAfterTimePeriod = new TimePeriod();
			aOTRate = new OTRate();
			aBenefitPayment = new BenefitPayment();	
			aOTRateForCharge = new OTRate();
		}
		#endregion

//		============================== Constructor ==============================
		public OvertimeHour(): base()
		{
			init();
		}

		public OvertimeHour(DateTime value): base()
		{
			init();
			otDate = value;
		}

//		============================== Public Method ==============================
		public override string EntityKey
		{
			get
			{
				return otDate.ToShortDateString();
			}
		}
	}
}