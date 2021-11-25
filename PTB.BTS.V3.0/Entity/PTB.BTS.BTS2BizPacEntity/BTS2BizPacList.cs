using System;
using System.Collections.Generic;
using System.Text;

using ictus.SystemConnection.BizPac.Core;
using ictus.Common.Entity.General;

namespace PTB.BTS.BTS2BizPacEntity
{
    public class BTS2BizPacList : ictus.Common.Entity.General.ListBase
    {
        #region Property
        private DateTime connectDate = NullConstant.DATETIME;
        public DateTime ConnectDate
        {
            get { return connectDate; }
            set { connectDate = value; }
        }

        public DateTime DocDateDetail { get; set; } 
        #endregion
	
        #region Constructor
        public BTS2BizPacList()
            : base()
        { }
        #endregion

        #region Public Method
        public void Add(IBTS2BizPacHeader value)
        { base.Add(value); }

        public void Remove(IBTS2BizPacHeader value)
        { base.Remove(value); }

        public IBTS2BizPacHeader this[int index]
        {
            get { return (IBTS2BizPacHeader)base.BaseGet(index); }
            set { base.BaseSet(index, value); }
        }

        public IBTS2BizPacHeader this[String key]
        {
            get { return (IBTS2BizPacHeader)base.BaseGet(key); }
            set { base.BaseSet(key, value); }
        } 
        #endregion
    }
}
