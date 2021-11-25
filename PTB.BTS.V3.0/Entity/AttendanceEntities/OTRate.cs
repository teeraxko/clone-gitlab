using System;

using ictus.Common.Entity.General;using ictus.Framework.ASC.Entity.DNF20;

namespace Entity.AttendanceEntities
{
	public class OTRate : EntityBase
	{
//		============================== Property ==============================
		private decimal otAHour = NullConstant.DECIMAL;
		public decimal OtAHour
		{
			get
			{
				return otAHour;
			}
			set
			{
				otAHour = value;
			}
		}

		private decimal otBHour = NullConstant.DECIMAL;
		public decimal OtBHour
		{
			get
			{
				return otBHour;
			}
			set
			{
				otBHour = value;
			}
		}

		private decimal otCHour = NullConstant.DECIMAL;
		public decimal OtCHour
		{
			get
			{
				return otCHour;
			}
			set
			{
				otCHour = value;
			}
		}

//		============================== Constructor ==============================
		public OTRate(): base()
		{}



        public override string EntityKey
        {
            get { return null; }
        }
    }
}
