using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PTB.BTS.Contract.Flow;
using Facade.PiFacade;
using Entity.ContractEntities;
using System.Collections;
using Flow.ContractFlow;
using Entity.CommonEntity;
using ictus.Common.Entity;
using PTB.BTS.PI.Flow;

namespace Facade.ContractFacade
{
    public class AttachmentFacade : CommonPIFacadeBase
    {
        #region - Private -
        CompanyFlow flowCompany;       
        #endregion

//        ============================== Property ==============================
		private Company aCompany;
        private CompanyInfo aCompanyInfo;

		private bool fill = false;       

//		============================== Constructor ==============================
        public AttachmentFacade()
            : base()
		{
			aCompany = new Company("12");
            aCompanyInfo = new CompanyInfo("12");

            flowCompany = new CompanyFlow();			
		}

        public ArrayList ModelTypeDataSourceName()
        {
            ArrayList result = new ArrayList();
            AttachmentFlow flowAttachment = new AttachmentFlow();
            result = flowAttachment.FillModelVehicleType();
            return result;
        }

        public DocumentNo RetriveRunningNo(DOCUMENT_TYPE docType)
        {
            using (DocumentNoFlow flowContractRunningNo = new DocumentNoFlow())
            {
                return flowContractRunningNo.GetContractRunningNo(docType, GetCompany());
            }
        }

        public Company GetCompany()
        {
            if (!fill)
            {
                fill = flowCompany.FillCompany(ref aCompany);
            }
            return aCompany;
        }
    }
}
