using System;
using System.Collections.Generic;
using System.Text;

namespace PTB.PIS.Welfare.BizPac.BizPacEntities {
    public class BizSectionMap {

        private string btsDeptCode;
        public string BTSDeptCode {
            get { return btsDeptCode; }
            set { btsDeptCode = value; }
        }

        private string btsSecCode;
        public string BTSSecCode {
            get { return btsSecCode; }
            set { btsSecCode = value; }
        }

        private string bizSecCode;
        public string BizSecCode {
            get { return bizSecCode; }
            set { bizSecCode = value; }
        }

        public BizSectionMap(string btsDeptCode, string btsSecCode, string bizSecCode) {
            this.btsDeptCode = btsDeptCode;
            this.btsSecCode = btsSecCode;
            this.bizSecCode = bizSecCode;
        }

    }
}
