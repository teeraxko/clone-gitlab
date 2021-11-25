using System;
using PTB.BTS.BTS2BizPacEntity;

namespace PTB.BTS.BTS2BizPacFlow.ServiceStaffDebitNoteCreateFlow
{
    public class SDNCreater0 : SDNCreaterBase
    {
        private AttachGroupStruct attachGroup1;
        private AttachGroupStruct attachGroup2;
        private AttachGroupStruct attachGroup3;
        private AttachGroupStruct attachGroup9;

        public SDNCreater0()
        {
            attachGroup1 = new AttachGroupStruct();
            attachGroup1.GroupCode = 14;
            attachGroup1.DebitNote = "ALL";
            attachGroup1.GroupDescription = "General Service";

            attachGroup2 = new AttachGroupStruct();
            attachGroup2.GroupCode = 15;
            attachGroup2.DebitNote = "ALL";
            attachGroup2.GroupDescription = "General Service (safety)";

            attachGroup3 = new AttachGroupStruct();
            attachGroup3.GroupCode = 16;
            attachGroup3.DebitNote = "ALL";
            attachGroup3.GroupDescription = "Office Maintenance";

            attachGroup9 = new AttachGroupStruct();
            attachGroup9.GroupCode = 19;
            attachGroup9.DebitNote = "ALL";
            attachGroup9.GroupDescription = "Other";
        }

        public override AttachGroupStruct GetAttachGroup(ServiceStaffContractChargeBP serviceStaffContractChargeBP)
        {
            if (GetTypeOfService(serviceStaffContractChargeBP.ServiceStaffType) == TypeOfService.GeneralService)
            {
                serviceStaffContractChargeBP.AttachGroup = attachGroup1.GroupCode;
                return attachGroup1;
            }
            else if (GetTypeOfService(serviceStaffContractChargeBP.ServiceStaffType) == TypeOfService.GeneralService6A)
            {
                serviceStaffContractChargeBP.AttachGroup = attachGroup2.GroupCode;
                return attachGroup2;
            }
            else if (GetTypeOfService(serviceStaffContractChargeBP.ServiceStaffType) == TypeOfService.OfficeMaintenance)
            {
                serviceStaffContractChargeBP.AttachGroup = attachGroup3.GroupCode;
                return attachGroup3;
            }
            else
            {
                //other for error
                serviceStaffContractChargeBP.AttachGroup = attachGroup9.groupCode;
                return attachGroup9;
            }
        }
    }
}
