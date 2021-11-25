using System;

using Entity.AttendanceEntities;

using ictus.Common.Entity;
using ictus.PIS.PI.Entity;

using DataAccess.AttendanceDB;
using DataAccess.CommonDB;

using PTB.BTS.Common.Flow;

namespace Flow.AttendanceFlow
{
	public class EmployeeBenefitAdjustmentFlow : FlowBase
	{
		#region - Private -
		private EmployeeBenefitAdjustmentDB dbEmployeeBenefitAdjustment;
		#endregion - Private -

//		============================== Constructor ==============================
		public EmployeeBenefitAdjustmentFlow() : base()
		{
			dbEmployeeBenefitAdjustment = new EmployeeBenefitAdjustmentDB();
		}

//		============================== Public Method ==============================
		public bool FillEmployeeBenefitAdjustment(ref EmployeeBenefitAdjustment value)
		{
			return dbEmployeeBenefitAdjustment.FillEmployeeBenefitAdjustment(ref value);
		}

		public bool InsertBenefitAdjustment(BenefitAdjustment value, Company aCompany)
		{
			return dbEmployeeBenefitAdjustment.InsertBenefitAdjustment(value, aCompany);
		}

		public bool UpdateBenefitAdjustment(BenefitAdjustment value, Company aCompany)
		{
			return dbEmployeeBenefitAdjustment.UpdateBenefitAdjustment(value, aCompany);	
		}
		
		public bool DeleteBenefitAdjustment(BenefitAdjustment value, Company aCompany)
		{
			return dbEmployeeBenefitAdjustment.DeleteBenefitAdjustment(value, aCompany);		
		}
	}
}
