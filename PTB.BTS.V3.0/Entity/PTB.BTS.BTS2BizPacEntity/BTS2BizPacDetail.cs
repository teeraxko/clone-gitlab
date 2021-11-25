using System;

using ictus.SystemConnection.BizPac.Core;
using ictus.Common.Entity.General;

namespace PTB.BTS.BTS2BizPacEntity
{
    public class BTS2BizPacDetail : IAccountDetail
    {
        #region IAccountDetail Members
        private decimal amount = NullConstant.DECIMAL;
        public decimal Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        private string businessUnit = NullConstant.STRING;
        public string BusinessUnit
        {
            get { return businessUnit; }
            set { businessUnit = value; }
        }

        private string itemDescription = NullConstant.STRING;
        public string ItemDescription
        {
            get { return itemDescription; }
            set { itemDescription = value; }
        }

        private string miscItemCode = NullConstant.STRING;
        public string MiscItemCode
        {
            get { return miscItemCode; }
            set { miscItemCode = value; }
        }

        private decimal price = NullConstant.DECIMAL;
        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        private decimal quantity = NullConstant.DECIMAL;
        public decimal Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        private int seqNo = NullConstant.INT;
        public int SeqNo
        {
            get { return seqNo; }
            set { seqNo = value; }
        }

        private string bizPacRemar2 = string.Empty;
        public string BizPacRemark2
        {
            get { return bizPacRemar2; }
            set { bizPacRemar2 = value; }
        }
        #endregion

        #region IKey Members

        public string EntityKey
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        #endregion
    }
}
