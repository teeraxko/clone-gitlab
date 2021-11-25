using System;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

using PTB.BTS.PI.Flow;

using Facade.CommonFacade;

namespace Facade.PiFacade
{
	public class CommonPIFacadeBase : FacadeBase
	{
		#region - Private - 
			CompanyFlow flowCompany;
			EmployeeFlow flowEmployee;
		#endregion

//		============================== Property ==============================
		private Company aCompany;
        private CompanyInfo aCompanyInfo;

		private bool fill = false;
        private bool fillInfo = false;

//		============================== Constructor ==============================
		protected CommonPIFacadeBase() : base()
		{
			aCompany = new Company("12");
            aCompanyInfo = new CompanyInfo("12");

            flowCompany = new CompanyFlow();
			flowEmployee = new EmployeeFlow();
		}

//		============================== Public Method ==============================
		public Employee GetEmployee(string employeeNo)
		{
			return flowEmployee.GetFormerlyEmployee(employeeNo, GetCompany());
		}

		public Company GetCompany()
		{
			if(!fill)
			{
				fill = flowCompany.FillCompany(ref aCompany);
			}
			return aCompany;
		}

        public CompanyInfo GetCompanyInfo()
        {
            if (!fillInfo)
            {
                fillInfo = flowCompany.FillCompany(ref aCompanyInfo);
            }
            return aCompanyInfo;
        }
	}
}
