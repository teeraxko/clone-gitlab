using System;

using Entity.AttendanceEntities;
using ictus.PIS.PI.Entity;

using DataAccess.AttendanceDB;
using DataAccess.CommonDB;

using PTB.BTS.Common.Flow;

namespace Flow.AttendanceFlow
{
	public class EmployeeMiscBenefitFlow : FlowBase
	{
		#region - Private -
		protected EmployeeMiscDBBase dbEmployeeMisc;
		#endregion - Private -

//		============================== Constructor ==============================
		public EmployeeMiscBenefitFlow() : base()
		{
			dbEmployeeMisc = new EmployeeMiscBenefitDB();
		}

//		============================== Public Method ==============================
		public bool FillMiscellaneousBenefitList(ref EmployeeMiscBenefit value, MiscBenefit aMiscBenefit)
		{
			return dbEmployeeMisc.FillMiscBenefitList(ref value, aMiscBenefit);
		}

		public bool InsertMiscellaneousBenefit(MiscBenefit value, Employee aEmployee)
		{
			return dbEmployeeMisc.InsertMiscBenefit(value, aEmployee);
		}

		public bool UpdateMiscellaneousBenefit(MiscBenefit value, Employee aEmployee)
		{
			return dbEmployeeMisc.UpdateMisceBenefit(value, aEmployee);	
		}
		
		public bool DeleteMiscellaneousBenefit(MiscBenefit value, Employee aEmployee)
		{
			return dbEmployeeMisc.DeleteMiscBenefit(value, aEmployee);		
		}
	}
}
