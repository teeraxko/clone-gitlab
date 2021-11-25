using System;
using System.Collections.Generic;
using System.Text;

namespace PTB.PIS.Welfare.BizPac.GL {
    public class GLHeader {

        private string docTypeCode;
        public string DocTypeCode {
            get { return docTypeCode; }
            set { docTypeCode = value; }
        }

        private DateTime docDate;
        public DateTime DocDate {
            get { return docDate; }
            set { docDate = value; }
        }

        private DateTime postDate;
        public DateTime PostDate {
            get { return postDate; }
            set { postDate = value; }
        }

        private string businessPlaceCode = "0000";
        public string BusinessPlaceCode {
            get { return businessPlaceCode; }
            set { businessPlaceCode = value; }
        }

        private string descr;
        public string Descr {
            get { return descr; }
            set { descr = value; }
        }

        private string currCode = "THB";
        public string CurrCode {
            get { return currCode; }
            set { currCode = value; }
        }

        private decimal exchangeRate = 1M;
        public decimal ExchangeRate {
            get { return exchangeRate; }
            set { exchangeRate = value; }
        }

        private string refNo;
        public string RefNo {
            get { return refNo; }
            set { refNo = value; }
        }
    }
}
