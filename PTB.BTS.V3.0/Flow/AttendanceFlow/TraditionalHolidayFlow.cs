using System;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.Time;
using ictus.Common.Entity;

using Entity.AttendanceEntities;
using Entity.CommonEntity;

using DataAccess.AttendanceDB;
using DataAccess.PiDB;

using PTB.BTS.Common.Flow;

namespace Flow.AttendanceFlow
{
	public class TraditionalHolidayFlow : FlowBase
	{
		#region - Private -
		private TraditionalHolidayDB dbTraditionalHoliday;
		private bool disposed = false;
		#endregion

//		============================== Constructor ==============================
		public TraditionalHolidayFlow(): base()
		{
			dbTraditionalHoliday = new TraditionalHolidayDB();
		}

//		============================== Public Method ==============================
		public bool FillTraditionalHolidayList(ref TraditionalHolidayList value)
		{
			return dbTraditionalHoliday.FillTraditionalHolidayList(ref value);
		}

		public bool FillTraditionalHoliday(ref TraditionalHoliday value, Company aCompany)
		{
			return dbTraditionalHoliday.FillTraditionalHoliday(ref value, aCompany);
		}

		public bool FillTraditionalHoliday(ref TraditionalHoliday aTraditionalHoliday, TraditionalHolidayPattern aTraditionalHolidayPattern, YearMonth yearMonth, Company aCompany)
		{
			return dbTraditionalHoliday.FillTraditionalHoliday(ref aTraditionalHoliday, aTraditionalHolidayPattern, yearMonth, aCompany);
		}

		public bool InsertTraditionalHoliday(TraditionalHolidayList aTraditionalHolidayList, TraditionalHoliday aTraditionalHoliday)
		{
			return dbTraditionalHoliday.InsertTraditionalHoliday(aTraditionalHolidayList, aTraditionalHoliday);
		}

		public bool UpdateTraditionalHoliday(TraditionalHolidayList aTraditionalHolidayList, TraditionalHoliday aTraditionalHoliday)
		{
			return dbTraditionalHoliday.UpdateTraditionalHoliday(aTraditionalHolidayList, aTraditionalHoliday);		
		}
		
		public bool DeleteTraditionalHoliday(TraditionalHolidayList aTraditionalHolidayList, TraditionalHoliday aTraditionalHoliday)
		{
			 return dbTraditionalHoliday.DeleteTraditionalHoliday(aTraditionalHolidayList, aTraditionalHoliday);		
		}

		#region IDisposable Members
		protected override void Dispose(bool disposing)
		{
			if(!this.disposed)
			{
				try
				{
					if(disposing)
					{
						dbTraditionalHoliday.Dispose();

						dbTraditionalHoliday = null;
					}
					this.disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}
		#endregion
	}
}
