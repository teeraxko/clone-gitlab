using System;
using System.Collections.Generic;
using System.Text;

namespace PTB.PIS.Welfare.BizPac.AP {
    public class APHeader {

        private string docType = "P2";
        public string DocType {
            get { return docType; }
            set { docType = value; }
        }

        private string docNo;
        public string DocNo {
            get { return docNo; }
            set { docNo = value; }
        }

        private DateTime docDate;
        public DateTime DocDate {
            get { return docDate; }
            set { docDate = value; }
        }

        private string vendorCode;
        public string VenderCode {
            get { return vendorCode; }
            set { vendorCode = value; }
        }

        private string vendorName;
        public string VenderName {
            get { return vendorName; }
            set { vendorName = value; }
        }

        private string vendorInvoice;
        public string VendorInvoice {
            get { return vendorInvoice; }
            set { vendorInvoice = value; }
        }

        private DateTime vendorInvoiceDate;

        public DateTime VendorInvoiceDate {
            get { return vendorInvoiceDate; }
            set { vendorInvoiceDate = value; }
        }

        private string vatCode = "VX";
        public string VatCode {
            get { return vatCode; }
            set { vatCode = value; }
        }

        private string vatType = "N";
        public string VatType {
            get { return vatType; }
            set { vatType = value; }
        }

        private string vatCalType = "E";
        public string VatCalType {
            get { return vatCalType; }
            set { vatCalType = value; }
        }

        private DateTime dueDate;
        public DateTime DueDate {
            get { return dueDate; }
            set { dueDate = value; }
        }

        private string businessPlace = "0000";
        public string BusinessPlace {
            get { return businessPlace; }
            set { businessPlace = value; }
        }

        private string remark;
        public string Remark {
            get { return remark; }
            set { remark = value; }
        }

        private string invoiceType = "S";
        public string InvoiceType {
            get { return invoiceType; }
            set { invoiceType = value; }
        }

        // Kriangkrai A.
        private string deptCode;
        public string DeptCode
        {
            get { return deptCode; }
            set { deptCode = value; }
        }
    }
}
