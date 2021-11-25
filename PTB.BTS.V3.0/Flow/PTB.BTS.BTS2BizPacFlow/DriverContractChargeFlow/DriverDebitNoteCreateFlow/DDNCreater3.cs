using System;
using PTB.BTS.BTS2BizPacEntity;

namespace PTB.BTS.BTS2BizPacFlow.DriverDebitNoteCreateFlow
{
    public class DDNCreater3 : DDNCreaterBase
    {
        //for TMNF
        private const string CUSTOMER_CODE = "000017";
        private AttachGroupStruct attachGroup;

        public DDNCreater3()
        {
            attachGroup = new AttachGroupStruct();
            attachGroup.CustomerCode = CUSTOMER_CODE;
            attachGroup.GroupCode = 6;
            attachGroup.GroupDescription = "TMNF";
        }

        protected override string getConditionName(IBTS2BizPacHeader data)
        {
            DriverContractChargeBP driverContractChargeBP = (DriverContractChargeBP)data;
            driverContractChargeBP.AttachGroup = attachGroup.GroupCode;
            driverContractChargeBP.OTAAmountAllow = driverContractChargeBP.OTAHourAllow * driverContractChargeBP.OTARate;
            driverContractChargeBP.OTACharge -= driverContractChargeBP.OTAHourAllow;

            return driverContractChargeBP.AttachGroup.ToString();
        }
    }
}
