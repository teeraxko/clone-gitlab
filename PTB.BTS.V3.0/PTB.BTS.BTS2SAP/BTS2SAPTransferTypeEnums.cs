using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTB.BTS.BTS2SAP
{
    public static class BTS2SAPTransferTypeEnums
    {
        public enum APTransferType
        {
            AP_CINSUR,
            AP_D_CHARGE,
            AP_EXCESS,
            AP_MEDATT,
            AP_REPAIR,
            AP_VINSUR,
            AP_V_CHARGE
        }

        public enum ARTransferType
        {
            AR_V_CHARGE
        }

        public enum GLTransferType
        {
            GL_LOAN,
            GL_MEDNAT,
            GL_WELFARE
        }
    }
}
