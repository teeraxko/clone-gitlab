using System;
using ictus.Common.Entity.General;

namespace PTB.BTS.BTS2BizPacEntity
{
    public class BizPacReference
    {
        private string bizPacRefNo = NullConstant.STRING;
        public string BizPacRefNo
        {
            get
            {
                return bizPacRefNo;
            }
            set
            {
                bizPacRefNo = value.Trim();
            }
        }

        private DateTime bizPacRefDate;
        public DateTime BizPacRefDate
        {
            get
            {
                return bizPacRefDate;
            }
            set
            {
                bizPacRefDate = value;
            }
        }
    }
}
