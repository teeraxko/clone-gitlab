using System;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

using Entity.CommonEntity;
using Entity.ContractEntities;

using DataAccess.ContractDB;

using PTB.BTS.Common.Flow;

namespace PTB.BTS.Contract.Flow
{
	public class DocumentNoFlow : FlowBase
	{
		#region - Private -
		private DocumentNoDB dbRunningNoContract;
		private DocumentNo objContractNo;
        private Company company;
		#endregion

//		============================== Constructor ==============================
		public DocumentNoFlow() : base()
		{
			dbRunningNoContract = new DocumentNoDB();
		}

		public DocumentNo GetContractRunningNo(DOCUMENT_TYPE value, Company aCompany)
		{		
			objContractNo = dbRunningNoContract.GetContractRunningNo(value, aCompany);
			return objContractNo;
		}

        public string GetBizPacRefNo()
        {
            if(company == null)
            {
                company = new Company("12");
            }
            objContractNo = dbRunningNoContract.GetContractRunningNo(DOCUMENT_TYPE.BIZPAC_REF_NO, company);
            return objContractNo.ToString();
        }

        public string GetRunningNo(DOCUMENT_TYPE value)
        {
            if (company == null)
            {
                company = new Company("12");
            }
            objContractNo = dbRunningNoContract.GetContractRunningNo(value, company);
            return objContractNo.ToString();
        }
	}
}
