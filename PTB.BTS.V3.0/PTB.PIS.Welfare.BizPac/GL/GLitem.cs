using System;
using System.Collections.Generic;
using System.Text;

namespace PTB.PIS.Welfare.BizPac.GL {
    public class GLitem {

        protected int seq;

        public int Seq {
            get { return seq; }
            set { seq = value; }
        }
	
        protected string accountCode;

        public string AccountCode {
            get { return accountCode; }
            set { accountCode = value; }
        }

        protected decimal amount;
        public decimal Amount {
            get { return amount; }
            set { amount = value; }
        }

        protected string businessUnitCode;
        public string BusinessUnitCode {
            get { return businessUnitCode; }
            set { businessUnitCode = value; }
        }

        protected string lineDescrEn;
        public string LineDescrEn {
            get { return lineDescrEn; }
            set { lineDescrEn = value; }
        }

        protected string lineDescrTh;
        public string LineDescrTh {
            get { return lineDescrTh; }
            set { lineDescrTh = value; }
        }

        protected string businessPartnerTypeCode;
        public string BusinessPartnerTypeCode {
            get { return businessPartnerTypeCode; }
            set { businessPartnerTypeCode = value; }
        }

        protected string businessPartnerCode;
        public string BusinessPartnerCode {
            get { return businessPartnerCode; }
            set { businessPartnerCode = value; }
        }

        protected string ref1;
        public string Ref1 {
            get { return ref1; }
            set { ref1 = value; }
        }

        protected string ref2;
        public string Ref2 {
            get { return ref2; }
            set { ref2 = value; }
        }


        protected string ref3;
        public string Ref3 {
            get { return ref3; }
            set { ref3 = value; }
        }

        protected DateTime refDate1;
        public DateTime RefDate1 {
            get { return refDate1; }
            set { refDate1 = value; }
        }

        protected DateTime refDate2;
        public DateTime RefDate2 {
            get { return refDate2; }
            set { refDate2 = value; }
        }

        protected DateTime refDate3;
        public DateTime RefDate3 {
            get { return refDate3; }
            set { refDate3 = value; }
        }

        protected string notes;
        public string Notes {
            get { return notes; }
            set { notes = value; }
        }

        protected string vatCode;
        public string VatCode {
            get { return vatCode; }
            set { vatCode = value; }
        }


        protected string vatDescr;
        public string VatDescr {
            get { return vatDescr; }
            set { vatDescr = value; }
        }


        protected decimal vatAmount;
        public decimal VatAmount {
            get { return vatAmount; }
            set { vatAmount = value; }
        }

        protected decimal vatBaseAmount;
        public decimal VatBaseAmount {
            get { return vatBaseAmount; }
            set { vatBaseAmount = value; }
        }

        protected string taxInvoiceNo;
        public string TaxInvoiceNo {
            get { return taxInvoiceNo; }
            set { taxInvoiceNo = value; }
        }

        protected DateTime taxInvoiceDate;
        public DateTime TaxInvoiceDate {
            get { return taxInvoiceDate; }
            set { taxInvoiceDate = value; }
        }

        // Kriangkrai A.
        private string miscExpenseCode;

        public string MiscExpenseCode
        {
            get { return miscExpenseCode; }
            set { miscExpenseCode = value; }
        }
    }

    internal class JournalItemComparer: IComparer<GLitem> {
        #region IComparer<GLitem> Members

        public int Compare(GLitem x, GLitem y) {
            return x.Amount.CompareTo(y.Amount);
        }

        #endregion
    }
}
