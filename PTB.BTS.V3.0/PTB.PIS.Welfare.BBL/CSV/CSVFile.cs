using System;
using System.Collections.Generic;
using System.Text;

namespace PTB.PIS.Welfare.BBL.CSV {
    class CSVFile {

        private CSVHeader header;
        public CSVHeader Header {
            get { return header; }
            set { header = value; }
        }

        private List<CSVDetail> details;
        public List<CSVDetail> Details {
            get { return details; }
            set { details = value; }
        }

        public List<string> lines = new List<string>();

        public CSVFile() {
            this.header = new CSVHeader();
            this.details = new List<CSVDetail>();
        }

        public decimal TotalAmount {
            get {
                Decimal result = 0M;
                foreach (CSVDetail detail in this.details) {
                    result += detail.Amount;
                }
                return result;
            }
        }

        public int DetailCount {
            get { return this.details.Count; }
        }



    }
}
