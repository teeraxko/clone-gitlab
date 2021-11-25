using System;
using PTB.BTS.Contract.Flow;
using ictus.SystemConnection.BizPac.Core;
using ictus.Common.Entity;
using PTB.BTS.BTS2BizPacEntity;
using PTB.BTS.Vehicle.Flow;

namespace PTB.BTS.BTS2BizPacFlow.DriverDebitNoteCreateFlow
{
    public abstract class DDNCreaterBase
    {
        #region - private -
        private void markBizPacRef(IAccountHeader value)
        {
            DDNCreaterManager.RefFlow.MarkBizPacRef(value);
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

        private DriverContractChargeBP createNewBP(DriverContractChargeBP data)
        {
            markBizPacRef(data);

            DriverContractChargeBP cloneData = new DriverContractChargeBP(new Company("12"));
            cloneData.AttachGroup = data.AttachGroup;
            cloneData.AContractType = data.AContractType;
            cloneData.ACustomer = data.ACustomer;
            cloneData.ACustomerDepartment = data.ACustomerDepartment;
            cloneData.AKindOfContract = data.AKindOfContract;

            cloneData.BizPacReference = data.BizPacReference;

            cloneData.BaseAmount = data.Amount;
            cloneData.VATAmount = data.VATAmount;
            cloneData.NetAmount = data.Total;

            return cloneData;
        }

        private void add(DriverContractChargeBP data, DriverContractChargeBP exist)
        {
            data.BizPacRefNo = exist.BizPacRefNo;
            data.BizPacRefDate = exist.BizPacRefDate;
            exist.BaseAmount += data.Amount;
            exist.VATAmount += data.VATAmount;
            exist.NetAmount += data.Total;
        }
        #endregion

        protected DriverContractChargeBP createNewBP(IBTS2BizPacHeader data)
        {
            return createNewBP((DriverContractChargeBP)data);
        }

        protected void add(IBTS2BizPacHeader data, IBTS2BizPacHeader exist)
        {
            add((DriverContractChargeBP)data, (DriverContractChargeBP)exist);
        }

        public void CalculateVAT(IBTS2BizPacHeader data)
        {
            ((DriverContractChargeBP)data).VATAmount = Math.Round(calculateVAT(((DriverContractChargeBP)data).Amount), 2);
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
