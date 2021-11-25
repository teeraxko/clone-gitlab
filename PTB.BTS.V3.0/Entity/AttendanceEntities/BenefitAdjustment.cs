using System;

using ictus.Common.Entity.Time;
using ictus.PIS.PI.Entity;
using ictus.Common.Entity.General;
using ictus.Framework.ASC.Entity.DNF20;

namespace Entity.AttendanceEntities
{
	public class BenefitAdjustment : EntityBase, IKey
	{
//		============================== Property ==============================
        private Employee aEmployee;
        public Employee AEmployee
		{
			get{return aEmployee;}
			set{aEmployee = value;}
		}

		private YearMonth aYearMonth;
		public YearMonth AYearMonth
		{
			get{return aYearMonth;}
			set{aYearMonth = value;}
		}

		private decimal otAHour = NullConstant.DECIMAL;
		public decimal OTAHour
		{
			get{return otAHour;}
			set{otAHour = value;}
		}

		private decimal otBHour = NullConstant.DECIMAL;
		public decimal OTBHour
		{
			get{return otBHour;}
			set{otBHour = value;}
		}

		private decimal otCHour = NullConstant.DECIMAL;
		public decimal OTCHour
		{
			get{return otCHour;}
			set{otCHour = value;}
		}

		private int taxiTimes = NullConstant.INT;
		public int TaxiTimes
		{
			get{return taxiTimes;}
			set{taxiTimes = value;}
		}

		private decimal taxiAmount = NullConstant.DECIMAL;
		public decimal TaxiAmount
		{
			get{return taxiAmount;}
			set{taxiAmount = value;}
		}

		private int oneDayTripFarTimes = NullConstant.INT;
		public int OneDayTripFarTimes
		{
			get{return oneDayTripFarTimes;}
			set{oneDayTripFarTimes = value;}
		}

		private decimal oneDayTripFarAmount = NullConstant.DECIMAL;
		public decimal OneDayTripFarAmount
		{
			get{return oneDayTripFarAmount;}
			set{oneDayTripFarAmount = value;}
		}       

		private int oneDayTripNearTimes = NullConstant.INT;
		public int OneDayTripNearTimes
		{
			get{return oneDayTripNearTimes;}
			set{oneDayTripNearTimes = value;}
		}

		private decimal oneDayTripNearAmount = NullConstant.DECIMAL;
		public decimal OneDayTripNearAmount
		{
			get{return oneDayTripNearAmount;}
			set{oneDayTripNearAmount = value;}
		}

		private int overnightTripTimes = NullConstant.INT;
		public int OvernightTripTimes
		{
			get{return overnightTripTimes;}
			set{overnightTripTimes = value;}
		}

		private decimal overnightTripAmount = NullConstant.DECIMAL;
		public decimal OvernightTripAmount
		{
			get{return overnightTripAmount;}
			set{overnightTripAmount = value;}
		}      

		private int foodTimes = NullConstant.INT;
		public int FoodTimes
		{
			get{return foodTimes;}
			set{foodTimes = value;}
		}

		private decimal foodAmount = NullConstant.DECIMAL;
		public decimal FoodAmount
		{
			get{return foodAmount;}
			set{foodAmount = value;}
		}

		private int extraTimes = NullConstant.INT;
		public int ExtraTimes
		{
			get{return extraTimes;}
			set{extraTimes = value;}
		}

		private decimal extraAmount = NullConstant.DECIMAL;
		public decimal ExtraAmount
		{
			get{return extraAmount;}
			set{extraAmount = value;}
		}

		private int extraAGTMonths = NullConstant.INT;
		public int ExtraAGTMonths
		{
			get{return extraAGTMonths;}
			set{extraAGTMonths = value;}
		}

		private decimal extraAGTAmount = NullConstant.DECIMAL;
		public decimal ExtraAGTAmount
		{
			get{return extraAGTAmount;}
			set{extraAGTAmount = value;}
		}

		private int addAGTDays = NullConstant.INT;
		public int AddAGTDays
		{
			get{return addAGTDays;}
			set{addAGTDays = value;}
		}

		private decimal addAGTAmount = NullConstant.DECIMAL;
		public decimal AddAGTAmount
		{
			get{return addAGTAmount;}
			set{addAGTAmount = value;}
		}

		private decimal telephoneAmount = NullConstant.DECIMAL;
		public decimal TelephoneAmount
		{
			get{return telephoneAmount;}
			set{telephoneAmount = value;}
		}

		private decimal miscAmount = NullConstant.DECIMAL;
		public decimal MiscAmount
		{
			get{return miscAmount;}
			set{miscAmount = value;}
		}

        //private decimal oneDayTripFarAmountForCharge = NullConstant.DECIMAL;
        //public decimal OneDayTripFarAmountForCharge
        //{
        //    get { return oneDayTripFarAmountForCharge; }
        //    set { oneDayTripFarAmountForCharge = value; }
        //}
        //private decimal oneDayTripNearAmountForCharge = NullConstant.DECIMAL;
        //public decimal OneDayTripNearAmountForCharge
        //{
        //    get { return oneDayTripNearAmountForCharge; }
        //    set { oneDayTripNearAmountForCharge = value; }
        //}
        //private decimal overnightTripAmountForCharge = NullConstant.DECIMAL;
        //public decimal OvernightTripAmountForCharge
        //{
        //    get { return overnightTripAmountForCharge; }
        //    set { overnightTripAmountForCharge = value; }
        //}
        //private decimal miscAmountForCharge = NullConstant.DECIMAL;
        //public decimal MiscAmountForCharge
        //{
        //    get { return miscAmountForCharge; }
        //    set { miscAmountForCharge = value; }
        //}

        //private decimal taxiAmountForCharge = NullConstant.DECIMAL;
        //public decimal TaxiAmountForCharge
        //{
        //    get { return taxiAmountForCharge; }
        //    set { taxiAmountForCharge = value; }
        //}

//		============================== Constructor ==============================
		public BenefitAdjustment() : base()
		{
		}

//		============================== Public Method ==============================
		public override string EntityKey
		{
			get{return aEmployee.EntityKey + aYearMonth.Year.ToString() + aYearMonth.Month.ToString();}
		}
	}
}
