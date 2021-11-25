using System;

using Entity.AttendanceEntities;
using Entity.CommonEntity;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.Time;

using DataAccess.AttendanceDB;
using DataAccess.CommonDB;

using PTB.BTS.Common.Flow;

namespace Flow.AttendanceFlow
{
	public class EmployeeExtraBenefitFlow: FlowBase
	{
		#region - Private -
		private EmployeeExtraBenefitDB dbEmployeeExtraBenefit;
		#endregion - Private -

		//		============================== Constructor ==============================
		public EmployeeExtraBenefitFlow() : base()
		{
			dbEmployeeExtraBenefit = new EmployeeExtraBenefitDB();
		}

		//		============================== Public Method ==============================
		public bool FillEmployeeExtraBenefit(ref EmployeeExtraBenefit value, ExtraBenefit aExtraBenefit)
		{
			return dbEmployeeExtraBenefit.FillEmployeeExtraBenefit(ref value, aExtraBenefit);
		}

		public bool FillEmployeeExtraBenefitList(ref EmployeeExtraBenefitList value, YearMonth yearMonth)
		{
			return dbEmployeeExtraBenefit.FillEmployeeExtraBenefitList(ref value, yearMonth);
		}

		public bool InsertExtraBenefit(ExtraBenefit value, Employee aEmployee)
		{
			return dbEmployeeExtraBenefit.InsertExtraBenefit(value, aEmployee);
		}

		public bool UpdateExtraBenefit(ExtraBenefit value, Employee aEmployee)
		{
			return dbEmployeeExtraBenefit.UpdateExtraBenefit(value, aEmployee);	
		}
		
		public bool DeleteExtraBenefit(ExtraBenefit value, Employee aEmployee)
		{
			return dbEmployeeExtraBenefit.DeleteExtraBenefit(value, aEmployee);		
		}
	}
}
