using PTB.BTS.BTS2BizPacEntity;
using Entity.Constants;

namespace PTB.BTS.BTS2BizPacFlow.DriverDebitNoteCreateFlow
{
    public class DDNCreater5 : DDNCreaterBase
    {
        //for IOT
        private AttachGroupStruct attachGroup1;
        private DDNCreater0 ddnCreater0;


        public DDNCreater5()
        {
            attachGroup1 = new AttachGroupStruct();
            attachGroup1.CustomerCode = CustomerCodeValue.IOT;
            attachGroup1.GroupCode = 21;
            attachGroup1.GroupDescription = "For Temporary Driver";
        }

        protected override string getConditionName(IBTS2BizPacHeader data)
        {
            DriverContractChargeBP driverContractChargeBP = (DriverContractChargeBP)data;

            if (driverContractChargeBP.ACustomerDepartment.Code.Equals(CustomerDepartmentCodeValue.IOT_TEMP))
            {
                driverContractChargeBP.AttachGroup = attachGroup1.GroupCode;
                return driverContractChargeBP.AttachGroup.ToString();
            }
            else
            {
                if (ddnCreater0 == null)
                {
                    ddnCreater0 = new DDNCreater0(CustomerCodeValue.TIS);
                }
                return ddnCreater0.GetCondition(driverContractChargeBP);
            }
        }
    }
}
