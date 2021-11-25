using System;

using ictus.Common.Entity.General;

namespace Entity.AttendanceEntities
{
	public class OvernightTripBenefit : TripBenefitBase, IKey
	{
//		============================== Property ==============================
		private DateTime benefitDate = NullConstant.DATETIME;
		public DateTime BenefitDate
		{
			get{return benefitDate;}
			set{benefitDate = value;}
		}

		private OvernightTrip aOvernightTrip;
		public OvernightTrip AOvernightTrip
		{
			get{return aOvernightTrip;}
			set{aOvernightTrip = value;}
		}

//		============================== Constructor ==============================
		public OvernightTripBenefit() : base()
		{
			aOvernightTrip = new OvernightTrip();
		}

//		============================== Public Method ==============================
		public override string EntityKey
		{
			get{return benefitDate.ToShortDateString();}
		}
	}
}