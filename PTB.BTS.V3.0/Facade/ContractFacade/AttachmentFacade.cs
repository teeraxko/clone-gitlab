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
    /// <summary>
    /// Contract Attachment Head
    /// </summary>
    public class AttachmentFacade : CommonPIFacadeBase
    {
        #region - Private -

        private ContractAttachmentFlow flowAttachment;
		private Company aCompany;
        private CompanyInfo aCompanyInfo;
		private bool fill = false;

        #endregion

        #region Constructor 
        public AttachmentFacade()
            : base()
		{

            flowAttachment = new ContractAttachmentFlow();
        }

        #endregion

        #region Public Method
        /// <summary>
        /// Retrive new contract attachment number.
        /// </summary>
        /// <param name="docType"></param>
        /// <returns></returns>
        public DocumentNo RetriveRunningNo(DOCUMENT_TYPE docType)
        {
            using (DocumentNoFlow flowAttachmentRunningNo = new DocumentNoFlow())
            {
                return flowAttachmentRunningNo.GetContractRunningNo(docType, GetCompany());
            }
        }

        /// <summary>
        /// Retrive contract attachment by no.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ContractAttachment RetriveContractAttachment(DocumentNo value)
        {
            return flowAttachment.RetriveContractAttachment(value, GetCompany());
        }

        /// <summary>
        /// Insert new contract attachment
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool ModeInsertAttachment(ContractAttachment value)
        {            
            if (flowAttachment.InsertAttachment(value, GetCompany()))
            { return true; }
            else
            { return false; }
        }
        #endregion

    }
}
