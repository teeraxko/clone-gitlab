using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ictus.Framework.ASC.Entity.DNF20;
using ictus.Common.Entity.General;

namespace Entity.ContractEntities
{
    public class AttachmentDetailList : ictus.Common.Entity.CompanyStuffBase
    {
        //		============================== Property ==============================
        protected ContractAttachment aContractAttachment;
        public ContractAttachment AContractAttachment
        {
            get { return aContractAttachment; }
            set { aContractAttachment = value; }
        }

        public AttachmentDetailList(ictus.Common.Entity.Company aCompany) : base(aCompany) { }

        public void Add(AttachmentDetail value)
        { base.Add(value); }

        public void Remove(AttachmentDetail value)
        { base.Remove(value); }

        public AttachmentDetail this[int index]
        {
            get { return (AttachmentDetail)base.BaseGet(index); }
            set { base.BaseSet(index, value); }
        }

        public AttachmentDetail this[String key]
        {
            get { return (AttachmentDetail)base.BaseGet(key); }
            set { base.BaseSet(key, value); }
        }
    }
}
