using System;

using Entity.AttendanceEntities;
using ictus.PIS.PI.Entity;

using DataAccess.AttendanceDB;
using DataAccess.CommonDB;

using PTB.BTS.Common.Flow;

namespace Flow.AttendanceFlow
{
	public class EmployeeExtraAGTBenefitDeductionFlow : FlowBase
	{
		#region - Private -
		private EmployeeExtraAGTBenefitDeductionDB dbEmployeeExtraAGTBenefitDeduction;
		#endregion

//		============================== Constructor ==============================
		public EmployeeExtraAGTBenefitDeductionFlow() : base()
		{
			dbEmployeeExtraAGTBenefitDeduction = new EmployeeExtraAGTBenefitDeductionDB();
		}

//		============================== Public Method ==============================
		public bool FillEmployeeExtraAGTBenefitDeduction(ref EmployeeExtraAGTBenefitDeduction value, ExtraAGTBenefitDeduction aExtraAGTBenefitDeduction)
		{
			return dbEmployeeExtraAGTBenefitDeduction.FillEmployeeExtraAGTBenefitDeduction(ref value, aExtraAGTBenefitDeduction);
		}

		public bool InsertExtraAGTBenefitDeduction(ExtraAGTBenefitDeduction value, Employee aEmployee)
		{
			return dbEmployeeExtraAGTBenefitDeduction.InsertExtraAGTBenefitDeduction(value, aEmployee);
		}
		
		public bool DeleteExtraAGTBenefitDeduction(ExtraAGTBenefitDeduction value, Employee aEmployee)
		{
			return dbEmployeeExtraAGTBenefitDeduction.DeleteExtraAGTBenefitDeduction(value, aEmployee);		
		}
	}
}
