using System;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

using PTB.BTS.PI.Flow;

using Facade.CommonFacade;

namespace Facade.PiFacade
{
	public class CompanyFacade : FacadeBase
	{
		#region - Private -
			private CompanyFlow flowCompany;
		#endregion

//		============================== Constructor ==============================
		public CompanyFacade()
		{
			flowCompany = new CompanyFlow();
		} 

//		============================== Public Method ==============================
		public bool FillCompany(ref Company value)
		{
			return flowCompany.FillCompany(ref value);
		}

        public bool FillCompany(ref CompanyInfo value)
        {
            return flowCompany.FillCompany(ref value);
        }

		public bool InsertCompany(CompanyInfo value)
		{
			return flowCompany.InsertCompany(value);
		}

        public bool UpdateCompany(CompanyInfo value)
		{
			return flowCompany.UpdateCompany(value);
		}

	}
} 
