using System;
using ictus.SystemConnection.BizPac.Core;
using PTB.BTS.BTS2BizPacEntity;
using ictus.Common.Entity;
using PTB.BTS.Vehicle.Flow;

namespace PTB.BTS.BTS2BizPacFlow.ServiceStaffDebitNoteCreateFlow
{
    public abstract class SDNCreaterBase
    {
        #region - private -
            private void markBizPacRef(IAccountHeader value)
            {
                SDNCreaterManager.RefFlow.MarkBizPacRef(value);
            }

            private void copyBizPacRef(IAccountHeader from, IAccountHeader to)
            {
                to.BizPacRefNo = from.BizPacRefNo;
                to.BizPacRefDate = from.BizPacRefDate;
            }

            VATRate vat;

        private decimal calculateVAT(decimal amount)
        {
            if (vat == null)
            {
                vat = VehicleFunction.GetVATRate();
            }
            return amount * vat.Rate / 100m;
        }

        protected ServiceStaffContractChargeBP createNewBP(IBTS2BizPacHeader data)
        {
            return createNewBP((ServiceStaffContractChargeBP)data);
        }

        protected void add(IBTS2BizPacHeader data, IBTS2BizPacHeader exist)
        {
            add((ServiceStaffContractChargeBP)data, (ServiceStaffContractChargeBP)exist);
        }

        public abstract AttachGroupStruct GetAttachGroup(ServiceStaffContractChargeBP data);
        #endregion

        public enum TypeOfService
        { 
            GeneralService,
            GeneralService6A,
            OfficeMaintenance,
            Other
        }

        protected TypeOfService GetTypeOfService(string serviceStaffType)
        {
            switch (serviceStaffType)
            {
                case "111" :
                case "711":
                case "721":
                case "731":
                case "781":
                case "791":
                case "801":
                case "831":
                    return TypeOfService.GeneralService;

                case "361" :
                case "681":
                    return TypeOfService.GeneralService6A;

                case "131":
                case "132":
                case "141":
                case "241":
                case "501":
                case "521":
                    return TypeOfService.OfficeMaintenance;
                default :
                    return TypeOfService.Other;
            }
        }

    }
}
