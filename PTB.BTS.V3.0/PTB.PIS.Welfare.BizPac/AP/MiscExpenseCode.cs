using System;
using System.Collections.Generic;
using System.Text;

namespace PTB.PIS.Welfare.BizPac.AP {
    internal class MiscExpenseCode {

        private string code;
        public string Code {
            get { return code; }
            set { code = value; }
        }

        private string name;
        public string Name {
            get { return name; }
            set { name = value; }
        }

        public MiscExpenseCode() {

        }

        public MiscExpenseCode(string code, string name) {
            this.code = code;
            this.name = name;
        }

        //public static MiscExpenseCode GetMiscCodeByBizSec(string bizCode) {
        //    switch (bizCode.Trim()) {
        //        case "01": return new MiscExpenseCode("MED001", "Medical-01");
        //        case "02": return new MiscExpenseCode("MED002", "Medical-02");
        //        //case "03": return new MiscExpenseCode("MED003", "Medical-05");
        //        //    break;
        //        //case "04": return new MiscExpenseCode("MED004", "Medical-01");
        //        //    break;
        //        case "05": return new MiscExpenseCode("MED003", "Medical-05");
        //        case "06": return new MiscExpenseCode("MED004", "Medical-06");
        //        case "06A": return new MiscExpenseCode("MED005", "Medical-06A");
        //        case "AC": return new MiscExpenseCode("OMED01", "Medical-AC");
        //        case "GA": return new MiscExpenseCode("OMED02", "Medical-GA");
        //        case "PN": return new MiscExpenseCode("OMED03", "Medical-PN");
        //        default: throw new Exception(string.Format("Cant mapping MiscExpense code with SectionCode {0}",bizCode.Trim()));
        //    }
        //}

        // Kriangkrai A. 18/2/2018
        public static MiscExpenseCode GetSAPMiscCodeByBizSec(string bizCode)
        {
            switch (bizCode.Trim())
            {
                case "01": return new MiscExpenseCode("MEDX01", "Medical-Dept 01");
                case "02": return new MiscExpenseCode("MEDX02", "Medical-Dept 02");
                case "03": return new MiscExpenseCode("MEDX03", "Medical-Dept 03");
                case "05": return new MiscExpenseCode("MEDX03", "Medical-Dept 05");
                case "06": return new MiscExpenseCode("MEDX04", "Medical-Dept 06");
                case "AC": return new MiscExpenseCode("MEDXAC", "Medical-Dept AC");
                case "GA": return new MiscExpenseCode("MEDXGA", "Medical-Dept GA");
                case "PN": return new MiscExpenseCode("MEDXPN", "Medical-Dept PN");
                default: throw new Exception(string.Format("Cant mapping MiscExpense code with SectionCode {0}", bizCode.Trim()));
            }
        }
    }
}
