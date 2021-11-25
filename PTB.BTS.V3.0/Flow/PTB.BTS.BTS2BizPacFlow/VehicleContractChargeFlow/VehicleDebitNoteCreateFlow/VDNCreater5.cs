using System;
using System.Collections.Generic;
using System.Text;
using PTB.BTS.BTS2BizPacEntity;
using PTB.BTS.Common.Flow;

namespace PTB.BTS.BTS2BizPacFlow.VehicleDebitNoteCreateFlow
{
    public class VDNCreater5 : VDNCreaterBase
    {
        //for IMCT
        private const string CUSTOMER_CODE = "000024";
        private AttachGroupStruct attachGroup7;
        private AttachGroupStruct attachGroup14;
        private VDNCreater0 VDNCreater0;
        private AgeFlow flowAge;

        public VDNCreater5()
        {
            attachGroup7 = new AttachGroupStruct();
            attachGroup7.CustomerCode = CUSTOMER_CODE;
            attachGroup7.GroupCode = 7;
            attachGroup7.GroupDescription = "รายการที่เป็น Office car (3 ปีขึ้นไป)";

            attachGroup14 = new AttachGroupStruct();
            attachGroup14.CustomerCode = CUSTOMER_CODE;
            attachGroup14.GroupCode = 14;
            attachGroup14.GroupDescription = "รายการที่เป็น Office car (น้อยกว่า 3 ปี)";

            flowAge = new AgeFlow();
        }

        protected override string getConditionName(IBTS2BizPacHeader data)
        {
            //Modify for support user request remark for vehicle contract period more than 3 year : woranai 10/10/2007
            VehicleContractChargeBP vehicleBP = (VehicleContractChargeBP)data;

            if (vehicleBP.ContinuousStatus || flowAge.DaysDiff(vehicleBP.APeriod.From, vehicleBP.APeriod.To.AddDays(1)).Years >= 3)
            {
                vehicleBP.ConContractSts = true;
                if (vehicleBP.AVehicleRoleList[0].AKindOfVehicle.Code == "1")
                {
                    vehicleBP.AttachGroup = attachGroup7.GroupCode;
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
                if (vehicleBP.AVehicleRoleList[0].AKindOfVehicle.Code == "1")
                {
                    vehicleBP.AttachGroup = attachGroup14.GroupCode;
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
