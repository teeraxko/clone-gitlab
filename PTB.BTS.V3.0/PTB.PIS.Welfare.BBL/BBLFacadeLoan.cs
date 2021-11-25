using System;
using System.Collections.Generic;
using System.Text;
using PTB.PIS.Welfare.BBL.Transformers;
using ictus.PIS.Welfare.Entity.LoanEntities;

namespace PTB.PIS.Welfare.BBL {
    public class BBLFacadeLoan {
        public static bool GenDataBBL(DateTime connectDateTime,List<LoanApplication> apps) {
            BBLTransformerLoan transformer = new BBLTransformerLoan(connectDateTime, apps);
            transformer.Tranform();
            return true;
        }
    }
}
