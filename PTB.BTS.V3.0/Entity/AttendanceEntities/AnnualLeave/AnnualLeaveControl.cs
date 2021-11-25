using System;

using ictus.Common.Entity.General;
using ictus.Framework.ASC.Entity.DNF20;

namespace Entity.AttendanceEntities
{
	public class AnnualLeaveControl : EntityBase
	{
		//==============================   Property    ==============================
		private int forYear = NullConstant.INT;
		public int ForYear
		{
			get{return forYear;}
			set{forYear = value;}
		}

		private TimePeriod validPeriod;
		public TimePeriod ValidPeriod
		{
			get{return validPeriod;}
			set{validPeriod = value;}
		}

		private DateTime createDate = NullConstant.DATETIME;
		public DateTime CreateDate
		{
			get{return createDate;}
			set{createDate = value;}
		}

		private DateTime saleDate = NullConstant.DATETIME;
		public DateTime SaleDate
		{
			get{return saleDate;}
			set{saleDate = value;}
		}

		//==============================  Constructor  ==============================
		public AnnualLeaveControl(int forYear) : base()
		{
			this.forYear = forYear;
			validPeriod = new TimePeriod();
		}

		public AnnualLeaveControl(DateTime hireDate) : base()
		{
            if (hireDate.Year <= 2007)
            {
                this.forYear = hireDate.Year;
            }
            else
            {
                if (hireDate.Month <= 3)
                {
                    this.forYear = hireDate.Year - 1;
                }
                else
                {
                    this.forYear = hireDate.Year;
                }
            }

			validPeriod = new TimePeriod();
		}

        public override string EntityKey
        {
            get { return null; }
        }
    }
}