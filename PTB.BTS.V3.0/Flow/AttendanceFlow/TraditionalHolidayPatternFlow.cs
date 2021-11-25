using System;

using DataAccess.AttendanceDB;

using PTB.BTS.PI.Flow;

namespace Flow.AttendanceFlow
{
	public class TraditionalHolidayPatternFlow : MTBCompanyFlowBase
	{
		#region -Private-
		private bool disposed = false;
		#endregion -Private-

		public TraditionalHolidayPatternFlow()
		{
			dbMTB = new TraditionalHolidayPatternDB();
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
						// Dispose object here.
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
