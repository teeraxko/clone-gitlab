using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Facade.PiFacade;
using Flow.ContractFlow;
using Entity.ContractEntities;

namespace Facade.ContractFacade
{
    public class AttachmentListFacade : CommonPIFacadeBase
    {
        #region - Private -
        private AttachmentFlow flowAttachment;
        #endregion

        #region Property
        private AttachmentList objAttachmentList;
        public AttachmentList ObjAttachmentList
        {
            get { return objAttachmentList; }
        }

        #endregion

        #region Constructor
        public AttachmentListFacade()
        {
            flowAttachment = new AttachmentFlow();           
        } 
        #endregion

        //public bool DisplayAttachment(string customerCode, string modelType)
        //{
        //    return flowAttachment.FillAttachment(ref objAttachmentList, customerCode, modelType);
        //}

    }
}
