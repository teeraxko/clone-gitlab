using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PTB.BTS.Common.Flow;
using DataAccess.ContractDB;
using System.Collections;
using Entity.ContractEntities;

namespace Flow.ContractFlow
{
    public class AttachmentFlow : FlowBase
    {
        public ArrayList FillModelVehicleType()
        {
            AttachmentDB dbAttachment = new AttachmentDB();

            return dbAttachment.GetModelVehicleType();
        }

        //public bool FillAttachment(ref AttachmentList value, string customerCode, string ModelType)
        //{
        //    return dbAttachment.FillAttachmentList(ref value, customerCode, ModelType);
        //}
    }
}
