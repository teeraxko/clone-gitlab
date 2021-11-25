using System;

using ictus.Common.Entity.General;

namespace Entity.AttendanceEntities.BenefitEntities
{
	public class BenefitOTHour : BenefitBase
	{
		//============================== Property ==============================
		private TimePeriod beforeTime;
		public TimePeriod BeforeTime
		{
			get{return beforeTime;}
			set{beforeTime = value;}
		}

		private TimePeriod duringTime1;
		public TimePeriod DuringTime1
		{
			get{return duringTime1;}
			set{duringTime1 = value;}
		}

		private TimePeriod breakTime;
		public TimePeriod BreakTime
		{
			get{return breakTime;}
			set{breakTime = value;}
		}

		private TimePeriod duringTime2;
		public TimePeriod DuringTime2
		{
			get{return duringTime2;}
			set{duringTime2 = value;}
		}

		private TimePeriod afterTime;
		public TimePeriod AfterTime
		{
			get{return afterTime;}
			set{afterTime = value;}
		}

		private OTRate otRate;
		public OTRate OTRate
		{
			get{return otRate;}
			set{otRate = value;}
		}

		private OTRate otRateForCharge;
		public OTRate OTRateForCharge
		{
			get{return otRateForCharge;}
			set{otRateForCharge = value;}
		}

		private string reason = NullConstant.STRING;
		public string Reason
		{
			get{return reason;}
			set{reason = value.Trim();}
		}

		public bool ValidOTHour
		{
			get
			{
				if(beforeTime.From == NullConstant.DATETIME || afterTime.To == NullConstant.DATETIME)
				{
					return false;
				}
				else
				{
					if((beforeTime.To == NullConstant.DATETIME && afterTime.From != NullConstant.DATETIME) || (beforeTime.To != NullConstant.DATETIME && afterTime.From == NullConstant.DATETIME))
					{
						return false;
					}
					else
					{
						return true;
					}
				}
			}
		}

		//============================== Constructor ==============================
		public BenefitOTHour(DateTime value) : base(value)
		{
			init();
		}

		public BenefitOTHour() : base(NullConstant.DATETIME)
		{
			init();
		}

		//============================== Public Method ==============================
		public void SetBenefitDate(DateTime value)
		{
			benefitDate = value;
			init();
		}

		private void init()
		{
			beforeTime = new TimePeriod();
			duringTime1 = new TimePeriod();
			breakTime = new TimePeriod();
			duringTime2 = new TimePeriod();
			afterTime = new TimePeriod();

			otRate = new OTRate();
			otRateForCharge = new OTRate();
		}
	}
}