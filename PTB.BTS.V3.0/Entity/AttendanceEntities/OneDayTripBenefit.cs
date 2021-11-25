using System;

using Entity.CommonEntity;
using ictus.Common.Entity.General;
using ictus.Framework.ASC.Entity.DNF20;

namespace Entity.AttendanceEntities
{
	public class OneDayTripBenefit : TripBenefitBase, IKey
	{
//		============================== Property ==============================
		private OneDayTrip aOneDayTrip;
		public OneDayTrip AOneDayTrip
		{
			get	{return aOneDayTrip;}
			set	{aOneDayTrip = value;}
		}

		private decimal benefitAmount = NullConstant.DECIMAL;
		public decimal BenefitAmount
		{
			get	{return benefitAmount;}
			set	{benefitAmount = value;}
		}

		private byte times = 0;
		public byte Times
		{
			get	{return times;}
			set	{times = value;}
		}

		public DateTime BenefitDate 
		{
			get	{return aOneDayTrip.APeriod.From;}
			set
			{
				aOneDayTrip.APeriod.From = value;
				aOneDayTrip.APeriod.To = value;
			}
		}

		private DISTANCE_TYPE distance = DISTANCE_TYPE.NULL;
		public DISTANCE_TYPE Distance
		{
			get{return distance;}
			set{distance = value;}
		}
		
//		============================== Constructor ==============================
		public OneDayTripBenefit() : base()
		{
			aOneDayTrip = new OneDayTrip();
		}

//		============================== Public Method ==============================
		public override string EntityKey
		{
			get
			{
				return BenefitDate.ToShortDateString() + aOneDayTrip.EntityKey;
			}
		}
	}
}