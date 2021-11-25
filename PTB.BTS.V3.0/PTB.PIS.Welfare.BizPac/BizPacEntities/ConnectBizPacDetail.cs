using System;
using System.Collections.Generic;
using System.Text;

namespace PTB.PIS.Welfare.BizPac.BizPacEntities {
    public class ConnectBizPacDetail {
        private string refNo;
        public string RefNo {
            get { return refNo; }
            set { refNo = value; }
        }

        private DateTime connectDateTime;
        public DateTime ConnectDateTime {
            get { return connectDateTime; }
            set { connectDateTime = value; }
        }


    }
}
