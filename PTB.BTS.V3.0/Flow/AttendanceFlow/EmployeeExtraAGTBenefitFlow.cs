using System;

using Entity.AttendanceEntities;
using ictus.PIS.PI.Entity;

using DataAccess.AttendanceDB;
using DataAccess.CommonDB;

using PTB.BTS.Common.Flow;

namespace Flow.AttendanceFlow
{
	public class EmployeeExtraAGTBenefitFlow : FlowBase
	{
		#region - Private -
		private EmployeeExtraAGTBenefitDB dbEmployeeExtraAGTBenefit;
		#endregion

//		============================== Constructor ==============================
		public EmployeeExtraAGTBenefitFlow() : base()
		{
			dbEmployeeExtraAGTBenefit = new EmployeeExtraAGTBenefitDB();
		}

//		============================== Public Method ==============================
		public bool FillEmployeeExtraAGTBenefit(ref EmployeeExtraAGTBenefit value, ExtraAGTBenefit aExtraAGTBenefit)
		{
			return dbEmployeeExtraAGTBenefit.FillEmployeeExtraAGTBenefit(ref value, aExtraAGTBenefit);
		}

		public bool FillExtraAGTBenefit(ref ExtraAGTBenefit value, Employee aEmployee)
		{
			return dbEmployeeExtraAGTBenefit.FillExtraAGTBenefit(ref value, aEmployee);
		}

		public bool InsertExtraAGTBenefit(ExtraAGTBenefit value, Employee aEmployee)
		{
			return dbEmployeeExtraAGTBenefit.InsertExtraAGTBenefit(value, aEmployee);
		}

		public bool UpdateExtraAGTBenefit(ExtraAGTBenefit value, Employee aEmployee)
		{
			return dbEmployeeExtraAGTBenefit.UpdateExtraAGTBenefit(value, aEmployee);	
		}
		
		public bool DeleteExtraAGTBenefit(ExtraAGTBenefit value, Employee aEmployee)
		{
			return dbEmployeeExtraAGTBenefit.DeleteExtraAGTBenefit(value, aEmployee);		
		}
	}
}
