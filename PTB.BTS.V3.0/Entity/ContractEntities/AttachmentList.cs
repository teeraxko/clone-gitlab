using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ictus.Framework.ASC.Entity.DNF20;
using ictus.Common.Entity.General;

namespace Entity.ContractEntities
{
    public class AttachmentList : ictus.Common.Entity.CompanyStuffBase
    {
        public AttachmentList(ictus.Common.Entity.Company aCompany) : base(aCompany) { }

        public void Add(ContractAttachment value)
        { base.Add(value); }

        public void Remove(ContractAttachment value)
        { base.Remove(value); }

        public ContractAttachment this[int index]
        {
            get { return (ContractAttachment)base.BaseGet(index); }
            set { base.BaseSet(index, value); }
        }

        public ContractAttachment this[String key]
        {
            get { return (ContractAttachment)base.BaseGet(key); }
            set { base.BaseSet(key, value); }
        }

    }
}
