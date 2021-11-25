using System;
using System.Collections.Generic;
using System.Text;

namespace PTB.PIS.Welfare.BizPac.AP {
    public class APItem {
        private int seq;

        public int Seq {
            get { return seq; }
            set { seq = value; }
        }

        private string miscExpenseCode;

        public string MiscExpenseCode {
            get { return miscExpenseCode; }
            set { miscExpenseCode = value; }
        }


        private string itemDescr;

        public string ItemDescr {
            get { return itemDescr; }
            set { itemDescr = value; }
        }


        private int quantity;

        public int Quantity {
            get { return quantity; }
            set { quantity = value; }
        }

        private decimal price;

        public decimal Price {
            get { return price; }
            set { price = value; }
        }
        
        private decimal amount;
        public decimal Amount {
            get { return amount; }
            set { amount = value; }
        }


        private string businessUnitCode;
        public string BusinessUnitCode {
            get { return businessUnitCode; }
            set { businessUnitCode = value; }
        }



    }
}
