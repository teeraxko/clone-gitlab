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
using PTB.BTS.Contract.Flow;

namespace Facade.ContractFacade
{
    public class AttachmentFacade : CommonPIFacadeBase
    {
        #region - Private -

        private ContractAttachmentFlow flowAttachment;

        #endregion

//        ============================== Property ==============================
		private Company aCompany;
        private CompanyInfo aCompanyInfo;

		private bool fill = false;       

//		============================== Constructor ==============================
        public AttachmentFacade()
            : base()
		{

            flowAttachment = new ContractAttachmentFlow();
		}

        public DocumentNo RetriveRunningNo(DOCUMENT_TYPE docType)
        {
            using (DocumentNoFlow flowAttachmentRunningNo = new DocumentNoFlow())
            {
                return flowAttachmentRunningNo.GetContractRunningNo(docType, GetCompany());
            }
        }

        public ContractAttachment RetriveContractAttachment(DocumentNo value)
        {
            return flowAttachment.RetriveContractAttachment(value, GetCompany());
        }

        public bool ModeInsertAttachment(ContractAttachment value)
        {            
            if (flowAttachment.InsertAttachment(value, GetCompany()))
            { return true; }
            else
            { return false; }
        }
       
    }
}
