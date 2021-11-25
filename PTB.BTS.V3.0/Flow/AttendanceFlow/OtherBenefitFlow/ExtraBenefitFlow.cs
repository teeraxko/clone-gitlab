using System;

using Entity.AttendanceEntities;
using Entity.CommonEntity;

using ictus.Common.Entity.Time;
using ictus.PIS.PI.Entity;

using DataAccess.AttendanceDB;
using DataAccess.CommonDB;

using PTB.BTS.Common.Flow;

namespace PTB.BTS.Attendance.OtherBenefit.Flow
{
	public class ExtraBenefitFlow : FlowBase
	{
		private bool disposed = false;

//		============================== Constructor ==============================
		public ExtraBenefitFlow() : base()
		{
		}

//		============================== Public Method ==============================
		public bool GenExtraBenefit(EmployeeExtraBenefitList value, YearMonth yearMonth)
		{
			bool result = true;
			EmployeeExtraBenefit objEmployeeExtraBenefit;
			EmployeeExtraBenefitDB dbEmployeeExtraBenefit = new EmployeeExtraBenefitDB();

			dbEmployeeExtraBenefit.DeleteExtraBenefit(yearMonth, value.Company);

			for(int i=0; i<value.Count; i++)
			{
				objEmployeeExtraBenefit = value[i];
				result &= dbEmployeeExtraBenefit.InsertExtraBenefit(objEmployeeExtraBenefit[0], objEmployeeExtraBenefit.Employee);					
			}

			return result;
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