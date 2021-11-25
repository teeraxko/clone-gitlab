using System;

using Entity.AttendanceEntities;
using ictus.PIS.PI.Entity;

using DataAccess.AttendanceDB;
using DataAccess.CommonDB;

using PTB.BTS.Common.Flow;

namespace Flow.AttendanceFlow
{
	public class EmployeeFoodBenefitFlow : FlowBase
	{
		#region - Private -
		private EmployeeFoodBenefitDB dbEmployeeFoodBenefit;
		#endregion - Private -

		//		============================== Constructor ==============================
		public EmployeeFoodBenefitFlow() : base()
		{
			dbEmployeeFoodBenefit = new EmployeeFoodBenefitDB();
		}

		//		============================== Public Method ==============================
		public bool FillFoodBenefitList(ref EmployeeFoodBenefit value)
		{
			return dbEmployeeFoodBenefit.FillFoodBenefitList(ref value);
		}

		public bool FillFoodBenefitList(ref EmployeeFoodBenefit value, FoodBenefit aFoodBenefit)
		{
			return dbEmployeeFoodBenefit.FillFoodBenefitList(ref value, aFoodBenefit);
		}

		public bool InsertFoodBenefit(FoodBenefit value, Employee aEmployee)
		{
			return dbEmployeeFoodBenefit.InsertFoodBenefit(value, aEmployee);
		}

		public bool UpdateFoodBenefit(FoodBenefit value, Employee aEmployee)
		{
			return dbEmployeeFoodBenefit.UpdateFoodBenefit(value, aEmployee);	
		}
		
		public bool DeleteFoodBenefit(FoodBenefit value, Employee aEmployee)
		{
			return dbEmployeeFoodBenefit.DeleteFoodBenefit(value, aEmployee);		
		}
	}
}
