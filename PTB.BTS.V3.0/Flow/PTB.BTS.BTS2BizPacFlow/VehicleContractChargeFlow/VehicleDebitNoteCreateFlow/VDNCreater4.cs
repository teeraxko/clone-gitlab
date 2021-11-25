using System;
using PTB.BTS.BTS2BizPacEntity;
using PTB.BTS.Common.Flow;

namespace PTB.BTS.BTS2BizPacFlow.VehicleDebitNoteCreateFlow
{
    public class VDNCreater4 : VDNCreaterBase
    {
        //for BSTL
        private const string CUSTOMER_CODE = "000010";
        private AttachGroupStruct attachGroup4;
        private AttachGroupStruct attachGroup5;
        private AttachGroupStruct attachGroup11;
        private AttachGroupStruct attachGroup12;
        private AgeFlow flowAge;

        public VDNCreater4()
        {
            attachGroup4 = new AttachGroupStruct();
            attachGroup4.CustomerCode = CUSTOMER_CODE;
            attachGroup4.GroupCode = 4;
            attachGroup4.GroupDescription = "รายการที่เป็นรถกระบะ (3 ปีขึ้นไป)";

            attachGroup5 = new AttachGroupStruct();
            attachGroup5.CustomerCode = CUSTOMER_CODE;
            attachGroup5.GroupCode = 5;
            attachGroup5.GroupDescription = "รถยนต์นั่งส่วนบุคคล (3 ปีขึ้นไป)";

            attachGroup11 = new AttachGroupStruct();
            attachGroup11.CustomerCode = CUSTOMER_CODE;
            attachGroup11.GroupCode = 11;
            attachGroup11.GroupDescription = "รายการที่เป็นรถกระบะ (น้อยกว่า 3 ปี)";

            attachGroup12 = new AttachGroupStruct();
            attachGroup12.CustomerCode = CUSTOMER_CODE;
            attachGroup12.GroupCode = 12;
            attachGroup12.GroupDescription = "รถยนต์นั่งส่วนบุคคล (น้อยกว่า 3 ปี)";

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
                }
                else
                {
                    vehicleBP.AttachGroup = attachGroup5.GroupCode;
                }
                return vehicleBP.AttachGroup.ToString();
            }
            else
            {
                vehicleBP.ConContractSts = false;
                if (vehicleBP.AVehicleRoleList[0].AVehicle.AModel.AModelType.Code == "2")
                {
                    vehicleBP.AttachGroup = attachGroup11.GroupCode;
                }
                else
                {
                    vehicleBP.AttachGroup = attachGroup12.GroupCode;
                }
                return vehicleBP.AttachGroup.ToString();
            }
        }
    }
}
