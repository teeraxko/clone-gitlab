using System;

using Entity.CommonEntity;
using ictus.Common.Entity.General;
using ictus.Framework.ASC.Entity.DNF20;

namespace Entity.AttendanceEntities
{
	public class OTPattern : EntityBase,IKey
	{
//		============================== Property ==============================
		private string patternId = NullConstant.STRING;
		public string PatternId
		{			
			set{ patternId = value;}
			get{return  patternId;}
		}

		private string patternName = NullConstant.STRING;
		public string PatternName
		{			
			set{patternName = value.Trim();}
			get{return patternName;}
		}

		private WORKINGDAY_TYPE dayType = WORKINGDAY_TYPE.NULL;
		public WORKINGDAY_TYPE DayType
		{
			set{dayType = value;}
			get{return dayType;}			
		}

		private PERIOD_TYPE otPeriod = PERIOD_TYPE.NULL;
		public PERIOD_TYPE OTPeriod
		{
			set{otPeriod= value;}
			get{return otPeriod;}			
		}

		private bool isFixedHour;
		public bool IsFixedHour
		{			
			set{isFixedHour = value;}
			get{return isFixedHour;}
		}

		private decimal fixedHour = NullConstant.DECIMAL;
		public decimal FixedHour
		{
			set{fixedHour = value;}
			get{return fixedHour;}			
		}

		private bool isMaxHourLimit;
		public bool IsMaxHourLimit
		{			
			set{isMaxHourLimit = value;}
			get{return isMaxHourLimit;}
		}

		private decimal maxHourLimit = NullConstant.DECIMAL;
		public decimal MaxHourLimit
		{
			set{maxHourLimit = value;}
	    	get{return maxHourLimit;}			
		}
		private bool isMinHourLimit;
   	    public bool IsMinHourLimit
		{			
			set{isMinHourLimit = value;}
			get{return isMinHourLimit;}
		}

		private decimal minHourLimit = NullConstant.DECIMAL;
		public decimal MinHourLimit
		{
			set{minHourLimit = value;}
			get{return minHourLimit;}			
		}

		private int additionalMinute = NullConstant.INT;
		public int AdditionalMinute
		{			
			set{additionalMinute = value;}
			get{return additionalMinute;}
		}
	
		private OT_RATE_TYPE otRate = OT_RATE_TYPE.NULL;
		public OT_RATE_TYPE OTRate
		{
			set{otRate = value;}
    		get{return otRate;}			
    	}

//		============================== Constructor ==============================
		public OTPattern() : base()
		{}
		
//		============================== Public Method ==============================
		public override string EntityKey
		{
			get{return patternId;}
		}

		public override string ToString()
		{
			return patternId + " : " + patternName;
		}
	}
}
