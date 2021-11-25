using System;

using ictus.SystemConnection.BizPac.AR;

namespace PTB.BTS.BTS2BizPacEntity
{
    public class BTS2BizPacDetailAR : IARDetail
    {
        #region IAccountDetail Members
        private decimal amount;
        public decimal Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        private string businessUnit;
        public string BusinessUnit
        {
            get { return businessUnit; }
            set { businessUnit = value; }
        }

        private string itemDescription;
        public string ItemDescription
        {
            get { return itemDescription; }
            set { itemDescription = value; }
        }

        private string miscItemCode;
        public string MiscItemCode
        {
            get { return miscItemCode; }
            set { miscItemCode = value; }
        }

        private decimal price;
        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        private decimal quantity;
        public decimal Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        private int seqNo;
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
            get { return seqNo.ToString(); }
        }

        #endregion
    }
}
