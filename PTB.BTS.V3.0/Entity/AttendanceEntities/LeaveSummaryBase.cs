using System;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.Time;
using ictus.Common.Entity.General;
using ictus.Framework.ASC.Entity.DNF20;

namespace Entity.AttendanceEntities
{
	public class LeaveSummaryBase : EntityBase, IKey
	{
//		============================== Property ==============================
		protected Employee aEmployee;
		public Employee AEmployee
		{
			get{return aEmployee;}
			set{aEmployee = value;}
		}

		protected YearMonth aYearMonth;
		public YearMonth AYearMonth
		{
			get{return aYearMonth;}
			set{aYearMonth = value;}
		}

		protected int countAsYear = NullConstant.INT;
		public int CountAsYear
		{
			get{return countAsYear;}
			set{countAsYear = value;}
		}

		protected decimal totalLeaveDaysByMonth = NullConstant.DECIMAL;
		public decimal TotalLeaveDaysByMonth
		{
			get{return totalLeaveDaysByMonth;}
			set{totalLeaveDaysByMonth = value;}
		}

		protected decimal totalLeaveDaysUpToThisMonth = NullConstant.DECIMAL;
		public decimal TotalLeaveDaysUpToThisMonth
		{
			get{return totalLeaveDaysUpToThisMonth;}
			set{totalLeaveDaysUpToThisMonth = value;}
		}

//		============================== Constructor ==============================
		protected LeaveSummaryBase() : base()
		{
		}

//		============================== Public Method ==============================
		public override string EntityKey
		{
			get{return aEmployee.EntityKey + aYearMonth.Year.ToString() + aYearMonth.Month.ToString();}
		}
	}
}
