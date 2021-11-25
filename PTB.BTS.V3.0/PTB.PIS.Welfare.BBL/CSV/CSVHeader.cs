using System;
using System.Collections.Generic;
using System.Text;

namespace PTB.PIS.Welfare.BBL.CSV {
    class CSVHeader {

        private string compCode = "12";
        public string CompCode {
            get { return compCode; }
            set { compCode = value; }
        }

        private string compName;
        public string CompName {
            get { return compName; }
            set { compName = value; }
        }

        private string compAccount = "1294074123"; //Change acc no (SR17053708),(old acc no : 1293088942)
        public string CompAccount {
            get { return compAccount; }
            set { compAccount = value; }
        }

        private DateTime dueDate;
        public DateTime DueDate {
            get { return dueDate; }
            set { dueDate = value; }
        }





    }

   

}
