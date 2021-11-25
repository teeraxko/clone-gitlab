using System;
using PTB.BTS.BTS2BizPacEntity;
using Entity.VehicleEntities;
using PTB.BTS.Common.Flow;
using Entity.Constants;

namespace PTB.BTS.BTS2BizPacFlow.VehicleDebitNoteCreateFlow
{
    public class VDNCreater1 : VDNCreaterBase
    {
        private AttachGroupStruct attachGroup3;
        private AttachGroupStruct attachGroup10;
        private VDNCreater0 VDNCreater0;
        private AgeFlow flowAge;

        public VDNCreater1()
        {
            attachGroup3 = new AttachGroupStruct();
            attachGroup3.CustomerCode = CustomerCodeValue.TIS;
            attachGroup3.GroupCode = 3;
            attachGroup3.GroupDescription = "รายการเรียกคืนภาษีได้ (3 ปีขึ้นไป)";

            attachGroup10 = new AttachGroupStruct();
            attachGroup10.CustomerCode = CustomerCodeValue.TIS;
            attachGroup10.GroupCode = 10;
            attachGroup10.GroupDescription = "รายการเรียกคืนภาษีได้ (น้อยกว่า 3 ปี)";

            flowAge = new AgeFlow();
        }

        protected override string getConditionName(IBTS2BizPacHeader data)
        {
            //Modify for support user request remark for vehicle contract period more than 3 year : woranai 10/10/2007
            VehicleContractChargeBP vehicleBP = (VehicleContractChargeBP)data;

            if (vehicleBP.ContinuousStatus || flowAge.DaysDiff(vehicleBP.APeriod.From, vehicleBP.APeriod.To.AddDays(1)).Years >= 3)
            {
                vehicleBP.ConContractSts = true;
                if (vehicleBP.AVehicleRoleList[0].AVehicle.VatStatus.Code == "R")
                {
                    vehicleBP.AttachGroup = attachGroup3.GroupCode;
                    //return vehicleContractChargeBP.AttachGroup.ToString();
                    return "TIS1";
                }
                else
                {
                    if (VDNCreater0 == null)
                    {
                        VDNCreater0 = new VDNCreater0(CustomerCodeValue.TIS);
                    }
                    //return VDNCreater0.GetCondition(vehicleContractChargeBP);
                    VDNCreater0.GetCondition(vehicleBP);
                    return "TIS2";
                }
            }
            else
            {
                vehicleBP.ConContractSts = false;
                if (vehicleBP.AVehicleRoleList[0].AVehicle.VatStatus.Code == "R")
                {
                    vehicleBP.AttachGroup = attachGroup10.GroupCode;
                    return "TIS3";
                }
                else
                {
                    if (VDNCreater0 == null)
                    {
                        VDNCreater0 = new VDNCreater0(CustomerCodeValue.TIS);
                    }
                    VDNCreater0.GetCondition(vehicleBP);
                    return "TIS4";
                }
            }
        }
    }
}
