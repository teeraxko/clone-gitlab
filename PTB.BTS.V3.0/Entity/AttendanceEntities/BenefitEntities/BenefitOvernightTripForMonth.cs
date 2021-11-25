using System;

using ictus.Common.Entity.General;using ictus.Framework.ASC.Entity.DNF20;
using ictus.PIS.PI.Entity;

namespace Entity.AttendanceEntities.BenefitEntities
{
	public class BenefitOvernightTripForMonth : EntityBase
	{
		//==============================   Property  ==============================
		private BenefitOvernightTripList previousMonth;
		public BenefitOvernightTripList PreviousMonth
		{
			get{return previousMonth;}
		}

		private BenefitOvernightTripList currentMonth;
		public BenefitOvernightTripList CurrentMonth
		{
			get{return currentMonth;}
		}

		private BenefitOvernightTripList nextMonth;
		public BenefitOvernightTripList NextMonth
		{
			get{return nextMonth;}
		}

		//============================== Constructor ==============================
		public BenefitOvernightTripForMonth(Employee value, DateTime forMonth)
		{
			previousMonth = new BenefitOvernightTripList(value, forMonth.AddMonths(-1));
			currentMonth = new BenefitOvernightTripList(value, forMonth);
			nextMonth = new BenefitOvernightTripList(value, forMonth.AddMonths(1));
		}

        public override string EntityKey
        {
            get { return null; }
        }
    }
}