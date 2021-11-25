using System;
using System.Collections.Generic;
using System.Text;
using ictus.Common.Entity.General;
using ictus.SystemConnection.BizPac.Core;

namespace Entity.PTB.BTS.BTS2BizPacEntity
{
    public class BTS2BizPacDetailList : ListBase
    {
        //============================== Constructor ==============================
        public BTS2BizPacDetailList()
            : base()
        { }

        //============================== Public Method ==============================
        public void Add(string key, IAccountDetail value)
        { base.Add(key, value); }

        public void Remove(IAccountDetail value)
        { base.Remove(value); }

        public IAccountDetail this[int index]
        {
            get { return (IAccountDetail)base.BaseGet(index); }
            set { base.BaseSet(index, value); }
        }

        public IAccountDetail this[String key]
        {
            get { return (IAccountDetail)base.BaseGet(key); }
            set { base.BaseSet(key, value); }
        }
    }
}
