using System;

using ictus.Common.Entity.General;
using ictus.Framework.ASC.Entity.DNF20;

using Entity.CommonEntity;

namespace Entity.AttendanceEntities
{
	public class OTVariant : EntityBase, IKey
	{
//		============================== Property ==============================
		private TimePeriod aPeriod;
		public TimePeriod APeriod
		{
			set{aPeriod = value;}
			get{return aPeriod;}
		}

		private IN_OUT_STATUS_TYPE inOutStatus = IN_OUT_STATUS_TYPE.NULL;
		public IN_OUT_STATUS_TYPE InOutStatus
		{			
			set{inOutStatus = value;}
			get{return inOutStatus;}
		}

		private DateTime equivalentTimeGroupI = NullConstant.TIME;
		public DateTime EquivalentTimeGroupI
		{
			set{equivalentTimeGroupI = value;}
			get{return equivalentTimeGroupI;}			
		}

		private DateTime equivalentTimeGroupII = NullConstant.TIME;
		public DateTime EquivalentTimeGroupII
		{
			set{equivalentTimeGroupII = value;}
			get{return equivalentTimeGroupII;}			
		}

		private DateTime equivalentTimeGroupIII = NullConstant.TIME;
		public DateTime EquivalentTimeGroupIII
		{			
			set{equivalentTimeGroupIII = value;}
			get{return equivalentTimeGroupIII;}
		}

		private DateTime chargeEquivalentTimeGroupI = NullConstant.TIME;
		public DateTime ChargeEquivalentTimeGroupI
		{
			set{chargeEquivalentTimeGroupI = value;}
			get{return chargeEquivalentTimeGroupI;}			
		}

		private DateTime chargeEquivalentTimeGroupII = NullConstant.TIME;
		public DateTime ChargeEquivalentTimeGroupII
		{
			set{chargeEquivalentTimeGroupII = value;}
			get{return chargeEquivalentTimeGroupII;}			
		}

		private DateTime chargeEquivalentTimeGroupIII = NullConstant.TIME;
		public DateTime ChargeEquivalentTimeGroupIII
		{			
			set{chargeEquivalentTimeGroupIII = value;}
			get{return chargeEquivalentTimeGroupIII;}
		}

		private OT_RATE_TYPE otRateWorkingDay = OT_RATE_TYPE.NULL;
		public OT_RATE_TYPE OtRateWorkingDay
		{
			set{otRateWorkingDay = value;}
			get{return otRateWorkingDay;}			
		}

		private OT_RATE_TYPE otRateHoliday = OT_RATE_TYPE.NULL;
		public OT_RATE_TYPE OtRateHoliday
		{			
			set{otRateHoliday = value;}
			get{return otRateHoliday;}
		}

//		============================== Constructor ==============================
		public OTVariant() : base()
		{
			aPeriod = new TimePeriod();
		}

//		============================== Public Method ==============================
		public override string EntityKey
		{
			get
			{
				return aPeriod.From.ToString("HHmm") + aPeriod.To.ToString("HHmm") + inOutStatus;
			}
		}
	}
}
