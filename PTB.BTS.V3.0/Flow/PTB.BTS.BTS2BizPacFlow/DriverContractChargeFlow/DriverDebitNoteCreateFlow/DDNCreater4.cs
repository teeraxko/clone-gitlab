using System;
using PTB.BTS.BTS2BizPacEntity;

namespace PTB.BTS.BTS2BizPacFlow.DriverDebitNoteCreateFlow
{
    public class DDNCreater4 : DDNCreaterBase
    {
        //for Thai MC
        private AttachGroupStruct attachGroup1;
        private AttachGroupStruct attachGroup2;

        public DDNCreater4()
        {
            attachGroup1 = new AttachGroupStruct();
            attachGroup1.GroupCode = 1;
            attachGroup1.GroupDescription = "For Position Car Driver";

            attachGroup2 = new AttachGroupStruct();
            attachGroup2.GroupCode = 2;
            attachGroup2.GroupDescription = "For Family Car Driver";
        }

        public string GetCondition(DriverContractChargeBP data)
        {
            if (data.ALatestServiceStaffRoleList[0].AServiceStaffType.Type == "281")
            {
                data.AttachGroup = attachGroup1.GroupCode;
            }
            else
            {
                data.AttachGroup = attachGroup2.GroupCode;
            }
            return data.AttachGroup.ToString();
        }

        protected override string getConditionName(IBTS2BizPacHeader data)
        {
            return GetCondition((DriverContractChargeBP)data);
        }
    }
}
