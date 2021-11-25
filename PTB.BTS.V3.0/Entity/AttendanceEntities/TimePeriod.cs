using System;

using ictus.Common.Entity.General;
using ictus.Framework.ASC.Entity.DNF20;
using Entity.CommonEntity;

namespace Entity.AttendanceEntities
{
	public class TimePeriod : EntityBase
    {
        #region Declaration

        private DateTime from = NullConstant.DATETIME;
        private DateTime to = NullConstant.DATETIME;

        #endregion

        #region Properties
        
        public DateTime From
        {
            get
            { return from; }
            set
            { from = value; }
        }
        public DateTime To
        {
            get
            { return to; }
            set
            { to = value; }
        }

        /// <summary>
        /// Get day difference between from and to date
        /// </summary>
        public int DayDiff
        {
            get
            {
                return this.to.Subtract(from).Days + 1;
            }
        }

        /// <summary>
        /// Get timespan difference between from and to date
        /// </summary>
        private TimeSpan TimeSpanDiff
        {
            get
            {
                return this.to.Subtract(from);
            }
        }

        #endregion

        #region Constructor
        public TimePeriod()
            : base()
        { }

        public TimePeriod(DateTime fromDate, DateTime toDate)
            : base()
        {
            from = fromDate;
            to = toDate;
        } 
        #endregion

        #region Public Method

        public override string EntityKey
        {
            get { return null; }
        }

        public bool IsOverlap(TimePeriod comparedPeriod)
        {
            if ((this.From <= comparedPeriod.To) && (this.To >= comparedPeriod.From))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ValidateRange()
        {
            if (this.From > this.To)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool IsSubRange(TimePeriod superRange)
        {
            if ((this.From >= superRange.From) && (this.To <= superRange.To))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool EqualsByPeriod(TimePeriod period1, TimePeriod period2)
        {
            if ((period1 == null) && (period2 == null))
            {
                return true;
            }
            else if ((period1 != null) && (period2 != null))
            {
                if (period1.From != period2.From)
                {
                    return false;
                }
                else if (period1.To != period2.To)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        } 

        #endregion
    }
}
