using System;

using Entity.VehicleEntities;

using ictus.Common.Entity;
using ictus.PIS.PI.Entity;

using DataAccess.VehicleDB;

using PTB.BTS.Common.Flow;

namespace PTB.BTS.Vehicle.Flow
{
	public class InsuranceCompanyFlow : FlowBase
	{
		#region - Private -	
			private InsuranceCompanyDB dbInsuranceCompany;
		#endregion

		//====================================Constructor================
		public InsuranceCompanyFlow() : base()
		{
			dbInsuranceCompany = new InsuranceCompanyDB();
		}

		//====================================Public Method================
		public bool FillInsuranceCompanyList(ref InsuranceCompanyList value)
		{
			return dbInsuranceCompany.FillInsuranceCompanyList(ref value);
		}
		public bool InsertInsuranceCompany(InsuranceCompany value, Company aCompany)
		{
			return dbInsuranceCompany.InsertInsuranceCompany(value, aCompany);
		}
		public bool UpdateInsuranceCompany(InsuranceCompany value, Company aCompany)
		{
			return dbInsuranceCompany.UpdateInsuranceCompany(value, aCompany);
		}
		public bool DeleteInsuranceCompany(InsuranceCompany value, Company aCompany)
		{
			return dbInsuranceCompany.DeleteInsuranceCompany(value, aCompany);
		}
	}
}
