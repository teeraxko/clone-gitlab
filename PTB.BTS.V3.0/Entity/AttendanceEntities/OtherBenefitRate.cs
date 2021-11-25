using System;

using ictus.Common.Entity.General;using ictus.Framework.ASC.Entity.DNF20;
using ictus.PIS.PI.Entity;

namespace Entity.AttendanceEntities
{
	public class OtherBenefitRate : EntityBase, IKey
	{
//		============================== Property ==============================
		private int taxiRate = 0;
		public int TaxiRate
		{
			get{return taxiRate;}
			set{taxiRate = value;}		
		}

		private int taxiRateForCharge = 0;
		public int TaxiRateForCharge
		{
			get{return taxiRateForCharge;}
			set{taxiRateForCharge = value;}
		}

		private int foodRate = 0;
		public int FoodRate
		{
			get{return foodRate;}
			set{foodRate = value;}		
		}

		private int oneDayTripRateFar = 0;
		public int OneDayTripRateFar
		{
			get{return oneDayTripRateFar;}
			set{oneDayTripRateFar = value;}
		}

		private int oneDayTripRateNear = 0;
		public int OneDayTripRateNear
		{
			get{return oneDayTripRateNear;}
			set{oneDayTripRateNear = value;}		
		}

		private int overnightTripRate = 0;
		public int OvernightTripRate
		{
			get{return overnightTripRate;}
			set{overnightTripRate = value;}		
		}

		private int extraRate = 0;
		public int ExtraRate
		{
			get{return extraRate;}
			set{extraRate = value;}
		}

		private int extraAGTRate = 0;
		public int ExtraAGTRate
		{
			get{return extraAGTRate;}
			set{extraAGTRate = value;}		
		}

		private int deductionAGTPerDay = 0;
		public int DeductionAGTPerDay
		{
			get{return deductionAGTPerDay;}
			set{deductionAGTPerDay = value;}		
		}

        private int mealAllowance = 0;
        public int MealAllowance
        {
            get { return mealAllowance; }
            set { mealAllowance = value; }
        }


//		============================== Constructor ==============================
		public OtherBenefitRate()
		{
		}

//		============================== Public Method ==============================
		public override string EntityKey
		{
			get
			{				
				return null;
			}
		}
	}
}
