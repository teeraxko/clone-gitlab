using System;
using System.Collections.Generic;
using System.Text;

namespace PTB.PIS.Welfare.BizPac.BizPacEntities {

    /// <summary>
    /// class is result of connect bizpac
    /// </summary>
    public class ConnectBizPacResult {

        private string fileName;
        public string FileName {
            get { return fileName; }
            set { fileName = value; }
        }

        private DateTime connectDateTime;
        public DateTime ConnectDateTime {
            get { return connectDateTime; }
            set { connectDateTime = value; }
        }


        private List<string> listOfRefNo;
        public List<string> ListOfRefNo {
            get { return listOfRefNo; }
            set { listOfRefNo = value; }
        }

        private DateTime postingDate;
        public DateTime PostingDate
        {
            get { return postingDate; }
            set { postingDate = value; }
        }
    }
}
