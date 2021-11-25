using System;

using Entity.AttendanceEntities;
using ictus.PIS.PI.Entity;

using DataAccess.AttendanceDB;
using DataAccess.CommonDB;

using PTB.BTS.Common.Flow;

namespace Flow.AttendanceFlow
{
	public class EmployeeTelephoneBenefitFlow : FlowBase
	{
		#region - Private -
		private EmployeeTelephoneBenefitDB dbEmployeeTelephoneBenefit;
		#endregion - Private -

//		============================== Constructor ==============================
		public EmployeeTelephoneBenefitFlow()
		{
			dbEmployeeTelephoneBenefit = new EmployeeTelephoneBenefitDB();
		}

//		============================== Public Method ==============================
		public bool FillTelephoneBenefitList(ref EmployeeTelephoneBenefit value, TelephoneBenefit aTelephoneBenefit)
		{
			return dbEmployeeTelephoneBenefit.FillTelephoneBenefitList(ref value, aTelephoneBenefit);
		}

		public bool InsertTelephoneBenefit(TelephoneBenefit value, Employee aEmployee)
		{
			return dbEmployeeTelephoneBenefit.InsertTelephoneBenefit(value, aEmployee);
		}

		public bool UpdateTelephoneBenefit(TelephoneBenefit value, Employee aEmployee)
		{
			return dbEmployeeTelephoneBenefit.UpdateTelephoneBenefit(value, aEmployee);	
		}
		
		public bool DeleteTelephoneBenefit(TelephoneBenefit value, Employee aEmployee)
		{
			return dbEmployeeTelephoneBenefit.DeleteTelephoneBenefit(value, aEmployee);		
		}
	}
}
