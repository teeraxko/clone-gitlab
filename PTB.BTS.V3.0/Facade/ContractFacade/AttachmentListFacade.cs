﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Facade.PiFacade;
using Entity.ContractEntities;
using PTB.BTS.Contract.Flow;
using Entity.VehicleEntities;

namespace Facade.ContractFacade
{
    public class AttachmentListFacade : CommonPIFacadeBase
    {
        #region - Private -
        private ContractAttachmentFlow flowAttachment;
        #endregion

        #region Property
        private List<ContractAttachment> objAttachmentList;
        public List<ContractAttachment> ObjAttachmentList
        {
            get { return objAttachmentList; }
        }        

        #endregion

        #region Constructor
        public AttachmentListFacade()
        {
            flowAttachment = new ContractAttachmentFlow();           
        } 
        #endregion

        #region Public Method
        /// <summary>
        /// Search Contract Attachment
        /// </summary>
        /// <param name="attachmentNo"></param>
        /// <param name="customer"></param>
        /// <param name="modelType"></param>
        /// <returns></returns>
        public List<ContractAttachment> SearchAttachment(DocumentNo attachmentNo, Customer customer, ModelType modelType)
        {
            objAttachmentList = flowAttachment.GetContractAttachmentList(attachmentNo, customer, modelType, GetCompany());
            return objAttachmentList;
        }
        #endregion

    }
}
