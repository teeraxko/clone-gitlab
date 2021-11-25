using System;
using PTB.BTS.BTS2BizPacEntity;

namespace PTB.BTS.BTS2BizPacFlow.DriverDebitNoteCreateFlow
{
    public class DDNCreater2 : DDNCreaterBase
    {
        //for IMCT
        private const string CUSTOMER_CODE = "000014";
        private AttachGroupStruct attachGroup;
        //private DDNCreater0 ddnCreater0;
        private DDNCreater4 ddnCreater4;

        public DDNCreater2()
        {
            attachGroup = new AttachGroupStruct();
            attachGroup.CustomerCode = CUSTOMER_CODE;
            attachGroup.GroupCode = 5;
            attachGroup.GroupDescription = "For 89085";
        }

        protected override string getConditionName(IBTS2BizPacHeader data)
        {
            DriverContractChargeBP driverContractChargeBP = (DriverContractChargeBP)data;
            if (driverContractChargeBP.ALatestServiceStaffRoleList[0].AServiceStaff.EmployeeNo == "89085")
            {
                driverContractChargeBP.AttachGroup = attachGroup.GroupCode;
                return "1";
            }
            else
            {
                if (ddnCreater4 == null)
                {
                    ddnCreater4 = new DDNCreater4();
                }
                return ddnCreater4.GetCondition(driverContractChargeBP);
            }
        }
    }
}
