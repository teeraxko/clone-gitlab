using System;
using PTB.BTS.BTS2BizPacEntity;

namespace PTB.BTS.BTS2BizPacFlow.ServiceStaffDebitNoteCreateFlow
{
    public class SDNCreater1 : SDNCreaterBase
    {
        private AttachGroupStruct attachGroup1;
        private AttachGroupStruct attachGroup2;
        private AttachGroupStruct attachGroup3;
        private AttachGroupStruct attachGroup4;
        private AttachGroupStruct attachGroup5;
        private AttachGroupStruct attachGroup9;

        public SDNCreater1()
        {
            attachGroup1 = new AttachGroupStruct();
            attachGroup1.GroupCode = 11;
            attachGroup1.DebitNote = "HRM";
            attachGroup1.GroupDescription = "HRM/General Service";

            attachGroup2 = new AttachGroupStruct();
            attachGroup2.GroupCode = 12;
            attachGroup2.DebitNote = "CAD";
            attachGroup2.GroupDescription = "CAD/General Service(CCTV)";

            attachGroup3 = new AttachGroupStruct();
            attachGroup3.GroupCode = 13;
            attachGroup3.DebitNote = "CAD";
            attachGroup3.GroupDescription = "CAD/Office Maintenance";

            attachGroup4 = new AttachGroupStruct();
            attachGroup4.GroupCode = 16;
            attachGroup4.DebitNote = "MAID";
            attachGroup4.GroupDescription = "Office Maintenance";

            attachGroup5 = new AttachGroupStruct();
            attachGroup5.GroupCode = 17;
            attachGroup5.DebitNote = "HRM(SSP)";
            attachGroup5.GroupDescription = "HRM/General Service (SSP)";

            attachGroup9 = new AttachGroupStruct();
            attachGroup9.GroupCode = 19;
            attachGroup9.DebitNote = "Other";
            attachGroup9.GroupDescription = "Other";
        }

        //For TIS
        public override AttachGroupStruct GetAttachGroup(ServiceStaffContractChargeBP serviceStaffContractChargeBP)
        {
            switch (serviceStaffContractChargeBP.ServiceStaffType)
            {
                case "111":
                case "711":
                case "721":
                case "731":
                case "781":
                case "791":
                case "801":
                case "831":
                    //17/07/2007
                    //For special case Store worker : woranai
                    if (serviceStaffContractChargeBP.CustomerDepartmentCode.Equals("044"))
                    {
                        serviceStaffContractChargeBP.AttachGroup = attachGroup5.GroupCode;
                        return attachGroup5;
                    }
                    else
                    {
                        serviceStaffContractChargeBP.AttachGroup = attachGroup1.GroupCode;
                        return attachGroup1;
                    }

                case "361":
                case "681":
                    serviceStaffContractChargeBP.AttachGroup = attachGroup2.GroupCode;
                    return attachGroup2;

                case "141":
                case "241":
                case "501":
                case "521":
                    serviceStaffContractChargeBP.AttachGroup = attachGroup3.GroupCode;
                    return attachGroup3;

                case "131":
                case "132":
                    serviceStaffContractChargeBP.AttachGroup = attachGroup4.GroupCode;
                    return attachGroup4;

                default:
                    serviceStaffContractChargeBP.AttachGroup = 19;
                    return attachGroup9;
            }
        }
    }
}
