using System;
using PTB.BTS.BTS2BizPacEntity;
using PTB.BTS.Common.Flow;

namespace PTB.BTS.BTS2BizPacFlow.VehicleDebitNoteCreateFlow
{
    public class VDNCreater2 : VDNCreaterBase
    {
        //for TAS
        private const string CUSTOMER_CODE = "000009";
        private AttachGroupStruct attachGroup4;
        private AttachGroupStruct attachGroup11;
        private VDNCreater0 VDNCreater0;
        private AgeFlow flowAge;

        public VDNCreater2()
        {
            attachGroup4 = new AttachGroupStruct();
            attachGroup4.CustomerCode = CUSTOMER_CODE;
            attachGroup4.GroupCode = 4;
            attachGroup4.GroupDescription = "รายการที่เป็นรถกระบะ (3 ปีขึ้นไป)";

            attachGroup11 = new AttachGroupStruct();
            attachGroup11.CustomerCode = CUSTOMER_CODE;
            attachGroup11.GroupCode = 11;
            attachGroup11.GroupDescription = "รายการที่เป็นรถกระบะ (น้อยกว่า 3 ปี)";

            flowAge = new AgeFlow();
        }

        protected override string getConditionName(IBTS2BizPacHeader data)
        {
            //Modify for support user request remark for vehicle contract period more than 3 year : woranai 10/10/2007
            VehicleContractChargeBP vehicleBP = (VehicleContractChargeBP)data;

            if (vehicleBP.ContinuousStatus || flowAge.DaysDiff(vehicleBP.APeriod.From, vehicleBP.APeriod.To.AddDays(1)).Years >= 3)
            {
                vehicleBP.ConContractSts = true;
                if (vehicleBP.AVehicleRoleList[0].AVehicle.AModel.AModelType.Code == "2")
                {
                    vehicleBP.AttachGroup = attachGroup4.GroupCode;
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
                if (vehicleBP.AVehicleRoleList[0].AVehicle.AModel.AModelType.Code == "2")
                {
                    vehicleBP.AttachGroup = attachGroup11.GroupCode;
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
