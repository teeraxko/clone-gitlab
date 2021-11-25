using System;
using PTB.BTS.BTS2BizPacEntity;
using PTB.BTS.Common.Flow;

namespace PTB.BTS.BTS2BizPacFlow.VehicleDebitNoteCreateFlow
{
    public class VDNCreater3 : VDNCreaterBase
    {
        //for IMCT
        private const string CUSTOMER_CODE = "000014";
        private AttachGroupStruct attachGroup6;
        private AttachGroupStruct attachGroup13;
        private VDNCreater0 VDNCreater0;
        private AgeFlow flowAge;

        public VDNCreater3()
        {
            attachGroup6 = new AttachGroupStruct();
            attachGroup6.CustomerCode = CUSTOMER_CODE;
            attachGroup6.GroupCode = 6;
            attachGroup6.GroupDescription = "รายการที่เป็น Family car (3 ปีขึ้นไป)";

            attachGroup13 = new AttachGroupStruct();
            attachGroup13.CustomerCode = CUSTOMER_CODE;
            attachGroup13.GroupCode = 13;
            attachGroup13.GroupDescription = "รายการที่เป็น Family car (น้อยกว่า 3 ปี)";

            flowAge = new AgeFlow();
        }

        protected override string getConditionName(IBTS2BizPacHeader data)
        {
            //Modify for support user request remark for vehicle contract period more than 3 year : woranai 10/10/2007
            VehicleContractChargeBP vehicleBP = (VehicleContractChargeBP)data;

            if (vehicleBP.ContinuousStatus || flowAge.DaysDiff(vehicleBP.APeriod.From, vehicleBP.APeriod.To.AddDays(1)).Years >= 3)
            {
                vehicleBP.ConContractSts = true;
                if (vehicleBP.AVehicleRoleList[0].AKindOfVehicle.Code == "2")
                {
                    vehicleBP.AttachGroup = attachGroup6.GroupCode;
                    return vehicleBP.AttachGroup.ToString();
                }
                else
                {
                    if (VDNCreater0 == null)
                    {
                        VDNCreater0 = new VDNCreater0(CUSTOMER_CODE);
                    }
                    return VDNCreater0.GetCondition(vehicleBP);
                }
            }
            else
            {
                vehicleBP.ConContractSts = false;
                if (vehicleBP.AVehicleRoleList[0].AKindOfVehicle.Code == "2")
                {
                    vehicleBP.AttachGroup = attachGroup13.GroupCode;
                    return vehicleBP.AttachGroup.ToString();
                }
                else
                {
                    if (VDNCreater0 == null)
                    {
                        VDNCreater0 = new VDNCreater0(CUSTOMER_CODE);
                    }
                    return VDNCreater0.GetCondition(vehicleBP);
                }
            }
        }
    }
}
