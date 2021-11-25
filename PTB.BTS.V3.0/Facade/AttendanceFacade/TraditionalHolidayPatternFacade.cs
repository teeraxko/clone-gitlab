using System;

using Entity.AttendanceEntities;

using Flow.AttendanceFlow;

using Facade.PiFacade;

namespace Facade.AttendanceFacade
{
	public class TraditionalHolidayPatternFacade : MTBCompanyFacadeBase
	{
		#region - Private -
		private bool disposed = false;
		#endregion - Private -

//		============================== Constructor ==============================
		public TraditionalHolidayPatternFacade()
		{
			flowMTB = new TraditionalHolidayPatternFlow();
			objList = new TraditionalHolidayPatternList(GetCompany());
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