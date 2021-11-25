using System;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.Time;
using ictus.Common.Entity.General;
using ictus.Framework.ASC.Entity.DNF20;

namespace Entity.AttendanceEntities
{
	public class LateSummary : EntityBase, IKey
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

		private int countAsYear = NullConstant.INT;
		public int CountAsYear
		{
			get{return countAsYear;}
			set{countAsYear = value;}
		}

		private int totalLateTimesByMonth = NullConstant.INT;
		public int TotalLateTimesByMonth
		{
			get{return totalLateTimesByMonth;}
			set{totalLateTimesByMonth = value;}
		}

		private int totalLateTimesUpToThisMonth = NullConstant.INT;
		public int TotalLateTimesUpToThisMonth
		{
			get{return totalLateTimesUpToThisMonth;}
			set{totalLateTimesUpToThisMonth = value;}
		}

//		============================== Constructor ==============================
		public LateSummary() : base()
		{
		}

//		============================== Public Method ==============================
		public override string EntityKey
		{
			get{return aEmployee.EntityKey + aYearMonth.Year.ToString() + aYearMonth.Month.ToString();}
		}
	}
}
