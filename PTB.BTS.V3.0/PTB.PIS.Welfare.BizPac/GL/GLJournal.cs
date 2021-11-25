using System;
using System.Collections.Generic;
using System.Text;

namespace PTB.PIS.Welfare.BizPac.GL {
    public class GLJournal {
        public const string CASH_ACC_CODE = "101101";

        public GLJournal() {
            this.header = new GLHeader();
            this.debits = new List<GLitem>();
            this.credits = new List<GLitem>();
        }

        private GLHeader header;

        public GLHeader Header {
            get { return header; }
            set { header = value; }
        }

        private List<GLitem> debits;

        public List<GLitem> Debits {
            get { return debits; }
            set { debits = value; }
        }


        private List<GLitem> credits;

        public List<GLitem> Credits {
            get { return credits; }
            set { credits = value; }
        }

        public Decimal TotalAmount {
            get {
                decimal result = 0M;
                foreach (GLDebit debitItem in this.debits) {
                    result += debitItem.Amount;
                }
                return result;
            }
        }

        public int LinesCount {
            get { return this.debits.Count + this.credits.Count; }
        }

        public void SortDebitData() {
            JournalItemComparer cm = new JournalItemComparer();
            debits.Sort(cm);
            debits.Reverse();
        }

        public void SortCreditData() {
            JournalItemComparer cm = new JournalItemComparer();
            credits.Sort(cm);
            credits.Reverse();
        }

        public void ReSeq() {
            int indexRow = 0;
            foreach (GLDebit item in this.debits) {
                indexRow++;
                item.Seq = indexRow;
            }
            foreach (GLCredit item in this.credits) {
                indexRow++;
                item.Seq = indexRow;
            }
        }


    }
}
