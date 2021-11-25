using System;
using System.Collections.Generic;
using System.Text;

namespace PTB.PIS.Welfare.BizPac.AP {
    public class APJournal {

        public APJournal() {
            this.header = new APHeader();
            this.items = new List<APItem>();
        }

        private APHeader header;
        public APHeader Header {
            get { return header; }
            set { header = value; }
        }

        private List<APItem> items;
        public List<APItem> Items {
            get { return items; }
            set { items = value; }
        }


        public Decimal BaseAmount {
            get { 
                Decimal baseAmount = 0M;
                foreach (APItem item in this.items) {
                    baseAmount += item.Amount;
                }
                
                return baseAmount; }
        }

        private Decimal vatAmount = 0M;
        public Decimal VatAmount {
            get { return vatAmount; }
            set { vatAmount = value; }
        }

        public decimal NetAmount {
            get { return this.BaseAmount + vatAmount; }
        }

        public bool CheckVendorCodeInvoice(string vendorCode, string invoiceNo) {
            bool result = (vendorCode == this.header.VenderCode) && (invoiceNo == this.header.VendorInvoice);
            return result;
        }

        public bool CheckDeptCodeInvoice(string deptCode, string invoiceNo)
        {
            bool result = (deptCode == this.header.DeptCode) && (invoiceNo == this.header.VendorInvoice);
            return result;
        }
    }


}
