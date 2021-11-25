using System;
using PTB.BTS.BTS2BizPacEntity;
using PTB.BTS.Contract.Flow;
using ictus.SystemConnection.BizPac.Core;
using ictus.Common.Entity;
using PTB.BTS.Vehicle.Flow;

namespace PTB.BTS.BTS2BizPacFlow.VehicleDebitNoteCreateFlow
{
    public abstract class VDNCreaterBase
    {
        #region - private -
        private void markBizPacRef(IAccountHeader value)
        {
            VDNCreaterManager.RefFlow.MarkBizPacRef(value);
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

        private VehicleContractChargeBP createNewBP(VehicleContractChargeBP data)
        {
            markBizPacRef(data);

            VehicleContractChargeBP cloneData = new VehicleContractChargeBP(new Company("12"));
            cloneData.AttachGroup = data.AttachGroup;
            cloneData.AContractType = data.AContractType;
            cloneData.ACustomer = data.ACustomer;
            cloneData.ACustomerDepartment = data.ACustomerDepartment;
            cloneData.AKindOfContract = data.AKindOfContract;

            cloneData.BizPacRefDate = data.BizPacRefDate;
            cloneData.BizPacRefNo = data.BizPacRefNo;
            cloneData.ChargeAmount = data.ChargeAmount;

            cloneData.ChargeAmount = data.ChargeAmount;
            cloneData.VATAmount = data.VATAmount;
            cloneData.ConContractSts = data.ConContractSts;
            return cloneData;
        }

        private void add(VehicleContractChargeBP data, VehicleContractChargeBP exist)
        {
            copyBizPacRef(exist, data);

            exist.ChargeAmount += data.ChargeAmount;
            exist.VATAmount += data.VATAmount;
        }
        #endregion

        protected VehicleContractChargeBP createNewBP(IBTS2BizPacHeader data)
        {
            return createNewBP((VehicleContractChargeBP)data);
        }

        protected void add(IBTS2BizPacHeader data, IBTS2BizPacHeader exist)
        {
            add((VehicleContractChargeBP)data, (VehicleContractChargeBP)exist);
        }

        public void CalculateVAT(IBTS2BizPacHeader data)
        {
            ((VehicleContractChargeBP)data).VATAmount = calculateVAT(((VehicleContractChargeBP)data).ChargeAmount);
        }

        protected abstract string getConditionName(IBTS2BizPacHeader data);

        public void Add(IBTS2BizPacHeader data, BTS2BizPacList lists)
        {
            string condition = getConditionName(data);
            if (lists.Contain(condition))
            {
                add(data, lists[condition]);
            }
            else
            {
                IBTS2BizPacHeader bpData = createNewBP(data);
                lists.Add(condition, bpData);
                bpData = null;
            }
        }
    }
}
