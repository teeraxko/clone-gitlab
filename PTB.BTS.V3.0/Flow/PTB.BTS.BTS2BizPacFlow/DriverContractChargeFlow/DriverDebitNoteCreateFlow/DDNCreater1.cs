using System;
using PTB.BTS.BTS2BizPacEntity;
using Entity.Constants;

namespace PTB.BTS.BTS2BizPacFlow.DriverDebitNoteCreateFlow
{
    public class DDNCreater1 : DDNCreaterBase
    {
        private AttachGroupStruct attachGroup3;
        private AttachGroupStruct attachGroup4;
        private AttachGroupStruct attachGroup7;
        private AttachGroupStruct attachGroup8;
        private AttachGroupStruct attachGroup9;
        private AttachGroupStruct attachGroup10;
        private AttachGroupStruct attachGroup20;
        
        //prepare group code 5X for PPO group
        private AttachGroupStruct attachGroup51;
        private AttachGroupStruct attachGroup52;

        private DDNCreater0 ddnCreater0;

        public DDNCreater1()
        {
            attachGroup3 = new AttachGroupStruct();
            attachGroup3.CustomerCode = CustomerCodeValue.TIS;
            attachGroup3.GroupCode = 3;
            attachGroup3.GroupDescription = "For PPO1";

            attachGroup4 = new AttachGroupStruct();
            attachGroup4.CustomerCode = CustomerCodeValue.TIS;
            attachGroup4.GroupCode = 4;
            attachGroup4.GroupDescription = "For Bus Driver";

            attachGroup7 = new AttachGroupStruct();
            attachGroup7.CustomerCode = CustomerCodeValue.TIS;
            attachGroup7.GroupCode = 7;
            attachGroup7.GroupDescription = "For PPO2";

            attachGroup8 = new AttachGroupStruct();
            attachGroup8.CustomerCode = CustomerCodeValue.TIS;
            attachGroup8.GroupCode = 8;
            attachGroup8.GroupDescription = "For PPO3";

            attachGroup9 = new AttachGroupStruct();
            attachGroup9.CustomerCode = CustomerCodeValue.TIS;
            attachGroup9.GroupCode = 9;
            attachGroup9.GroupDescription = "For PPO4";

            attachGroup10 = new AttachGroupStruct();
            attachGroup10.CustomerCode = CustomerCodeValue.TIS;
            attachGroup10.GroupCode = 10;
            attachGroup10.GroupDescription = "For PPO5";

            attachGroup20 = new AttachGroupStruct();
            attachGroup20.customerCode = CustomerCodeValue.TIS;
            attachGroup20.groupCode = 20;
            attachGroup20.groupDescription = "For PPO-6D & PPO-6N";

            attachGroup51 = new AttachGroupStruct();
            attachGroup51.customerCode = CustomerCodeValue.TIS;
            attachGroup51.groupCode = 51;
            attachGroup51.groupDescription = "For PPOCH";

            attachGroup52= new AttachGroupStruct();
            attachGroup52.customerCode = CustomerCodeValue.TIS;
            attachGroup52.groupCode = 52;
            attachGroup52.groupDescription = "For PPOBA";

        }

        private bool isBUS(DriverContractChargeBP data)
        {
            return false;
        }

        protected override string getConditionName(IBTS2BizPacHeader data)
        {
            DriverContractChargeBP driverContractChargeBP = (DriverContractChargeBP)data;

            //For PPO-1
            if (driverContractChargeBP.ACustomerDepartment.Code.Equals(CustomerDepartmentCodeValue.TIS_PPO1))
            {
                driverContractChargeBP.AttachGroup = attachGroup3.GroupCode;
                return driverContractChargeBP.AttachGroup.ToString();
            }
            //For PPO-2
            else if (driverContractChargeBP.ACustomerDepartment.Code.Equals(CustomerDepartmentCodeValue.TIS_PPO2))
            {
                driverContractChargeBP.AttachGroup = attachGroup7.GroupCode;
                return driverContractChargeBP.AttachGroup.ToString();
            }
            //For PPO-3
            else if (driverContractChargeBP.ACustomerDepartment.Code.Equals(CustomerDepartmentCodeValue.TIS_PPO3))
            {
                driverContractChargeBP.AttachGroup = attachGroup8.GroupCode;
                return driverContractChargeBP.AttachGroup.ToString();
            }
            //For PPO-4
            else if (driverContractChargeBP.ACustomerDepartment.Code.Equals(CustomerDepartmentCodeValue.TIS_PPO4))
            {
                driverContractChargeBP.AttachGroup = attachGroup9.GroupCode;
                return driverContractChargeBP.AttachGroup.ToString();
            }
            //For PPO-5
            else if (driverContractChargeBP.ACustomerDepartment.Code.Equals(CustomerDepartmentCodeValue.TIS_PPO5))
            {
                driverContractChargeBP.AttachGroup = attachGroup10.GroupCode;
                return driverContractChargeBP.AttachGroup.ToString();
            }
            else if (driverContractChargeBP.ACustomerDepartment.Code.Equals(CustomerDepartmentCodeValue.TIS_PPOCH))
            {
                driverContractChargeBP.AttachGroup = attachGroup51.GroupCode;
                return driverContractChargeBP.AttachGroup.ToString();
            }
            else if (driverContractChargeBP.ACustomerDepartment.Code.Equals(CustomerDepartmentCodeValue.TIS_PPOBA))
            {
                driverContractChargeBP.AttachGroup = attachGroup52.GroupCode;
                return driverContractChargeBP.AttachGroup.ToString();
            }
            //For PPO-6 D & N
            else if (driverContractChargeBP.ACustomerDepartment.Code.Equals(CustomerDepartmentCodeValue.TIS_PPO6D)
                || driverContractChargeBP.ACustomerDepartment.Code.Equals(CustomerDepartmentCodeValue.TIS_PPO6N))
            {
                driverContractChargeBP.AttachGroup = attachGroup20.GroupCode;
                return driverContractChargeBP.AttachGroup.ToString();
            }
            else if (isBUS(driverContractChargeBP))
            {
                driverContractChargeBP.AttachGroup = attachGroup4.GroupCode;
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
