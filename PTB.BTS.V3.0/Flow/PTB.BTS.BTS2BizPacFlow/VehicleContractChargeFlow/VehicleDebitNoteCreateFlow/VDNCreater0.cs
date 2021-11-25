using System;
using PTB.BTS.BTS2BizPacEntity;
using PTB.BTS.Common.Flow;

namespace PTB.BTS.BTS2BizPacFlow.VehicleDebitNoteCreateFlow
{
    public class VDNCreater0 : VDNCreaterBase
    {
        private AttachGroupStruct attachGroup1;
        private AttachGroupStruct attachGroup2;
        private AttachGroupStruct attachGroup8;
        private AttachGroupStruct attachGroup9;
        private AgeFlow flowAge;

        public VDNCreater0(string customerCode)
        {
            attachGroup1 = new AttachGroupStruct();
            attachGroup1.CustomerCode = customerCode;
            attachGroup1.GroupCode = 1;
            attachGroup1.GroupDescription = "รายการที่ค่าเช่ามากกว่าหรือเท่ากับ 36,000 บาท (3 ปีขึ้นไป)";

            attachGroup2 = new AttachGroupStruct();
            attachGroup2.CustomerCode = customerCode;
            attachGroup2.GroupCode = 2;
            attachGroup2.GroupDescription = "รายการที่ค่าเช่าน้อยกว่า 36,000 บาท (3 ปีขึ้นไป)";

            attachGroup8 = new AttachGroupStruct();
            attachGroup8.CustomerCode = customerCode;
            attachGroup8.GroupCode = 8;
            attachGroup8.GroupDescription = "รายการที่ค่าเช่ามากกว่าหรือเท่ากับ 36,000 บาท (น้อยกว่า 3 ปี)";

            attachGroup9 = new AttachGroupStruct();
            attachGroup9.CustomerCode = customerCode;
            attachGroup9.GroupCode = 9;
            attachGroup9.GroupDescription = "รายการที่ค่าเช่าน้อยกว่า 36,000 บาท (น้อยกว่า 3 ปี)";

            flowAge = new AgeFlow();
        }

        public string GetCondition(VehicleContractChargeBP data)
        {
            //Modify for support user request remark for vehicle contract period more than 3 year : woranai 10/10/2007
            if (data.ContinuousStatus || flowAge.DaysDiff(data.APeriod.From, data.APeriod.To.AddDays(1)).Years >= 3)
            {
                data.ConContractSts = true;

                if (data.ContractCharge.UnitChargeAmount >= 36000)
                {
                    data.AttachGroup = attachGroup1.GroupCode;
                }
                else
                {
                    data.AttachGroup = attachGroup2.GroupCode;
                }
            }
            else
            {
                data.ConContractSts = false;

                if (data.ContractCharge.UnitChargeAmount >= 36000)
                {
                    data.AttachGroup = attachGroup8.GroupCode;
                }
                else
                {
                    data.AttachGroup = attachGroup9.GroupCode;
                }
            }

            return data.AttachGroup.ToString();
        }

        protected override string getConditionName(IBTS2BizPacHeader data)
        {
            return GetCondition((VehicleContractChargeBP)data);
        }
    }
}
