using System;
using System.Collections.Generic;
using System.Text;

namespace PTB.PIS.Welfare.BBL.CSV {
    class CSVDetail {
        private string status;

        public string Status {
            get { return status; }
            set { status = value; }
        }


        private string deptCode;
        public string DeptCode {
            get { return deptCode; }
            set { deptCode = value; }
        }


        private string empNo;
        public string EmpNo {
            get { return empNo; }
            set { empNo = value; }
        }


        private string empFullName;
        public string EmpFullName {
            get { return empFullName; }
            set { empFullName = value; }
        }


        private string bankAccCode;
        public string BankAccCode {
            get { return bankAccCode; }
            set { bankAccCode = value; }
        }

        private decimal amount;
        public decimal Amount {
            get { return amount; }
            set { amount = value; }
        }


        private string filler;
        public string Filler {
            get { return filler; }
            set { filler = value; }
        }

        private string transCode;
        public string TransCode {
            get { return transCode; }
            set { transCode = value; }
        }

        private string spare;
        public string Spare {
            get { return spare; }
            set { spare = value; }
        }


    }
}
