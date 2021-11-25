using System;
using PTB.BTS.BTS2BizPacFlow.ServiceStaffContractChargeFlow;
using ictus.Common.Entity.General;
using PTB.BTS.BTS2BizPacEntity;
using ictus.SystemConnection.BizPac.AR;
using Entity.PTB.BTS.BTS2BizPacEntity;
using ictus.Common.Entity;
using ictus.SystemConnection.BizPac.Core;

namespace PTB.BTS.BTS2BizPacFlow.ServiceStaffDebitNoteCreateFlow
{
    public class SDNCreaterManager
    {
        public static ServiceStaffContractChargeBPFlow RefFlow;
        public SDNCreaterManager()
        {
            commonList = new CommonList();
        }

        #region - ServiceStaffDN -
        private CommonList commonList;
        private BTS2BizPacList getServiceStaffDN(IBTS2BizPacHeader header)
        {
            string customerCode = ((IARHeader)header).CustomerCode;
            if (commonList.Contain(customerCode))
            {
                return (BTS2BizPacList)commonList.BaseGet(customerCode);
            }
            else
            {
                BTS2BizPacList serviceStaffDN = new BTS2BizPacList();
                commonList.Add(customerCode, serviceStaffDN);
                return serviceStaffDN;
            }
        }

        SDNCreaterBase sdnCreater;
        SDNCreater0 sdnCreater0;
        SDNCreater1 sdnCreater1;
        private SDNCreaterBase getSDNCreater(IBTS2BizPacHeader header)
        {
            string customerCode = ((IARHeader)header).CustomerCode;
            switch (customerCode)
            {
                case "000001": //TIS
                    {
                        if (sdnCreater1 == null)
                        {
                            sdnCreater1 = new SDNCreater1();
                        }
                        return sdnCreater1;
                    }
                default:
                    {
                        if (sdnCreater0 == null)
                        {
                            sdnCreater0 = new SDNCreater0();
                        }
                        return sdnCreater0;
                    }
            }
        }
        #endregion
        private BTS2BizPacDetailAR getDeatail(int groupCode, ServiceStaffContractChargeBP data)
        {
            int seq = 1;
            if (data.Details != null)
            {
                seq = data.Details.Count + 1;
            }

            BTS2BizPacDetailAR detailAR = new BTS2BizPacDetailAR();
            switch (groupCode)
            {
                case 11 :
                    {
                        detailAR.Amount = data.Amount;
                        detailAR.BusinessUnit = "06";
                        detailAR.ItemDescription = "General Service Fee in " + BTS2BizPacCommon.StringBackMonthYear;
                        detailAR.MiscItemCode = "GS0001";
                        detailAR.Price = 0;
                        detailAR.Quantity = 0;
                        detailAR.SeqNo = seq;
                        return detailAR;
                    }
                case 12:
                    {
                        detailAR.Amount = data.Amount;
                        detailAR.BusinessUnit = "06A";
                        detailAR.ItemDescription = "General Service Fee in " + BTS2BizPacCommon.StringBackMonthYear;
                        detailAR.MiscItemCode = "GS0001";
                        detailAR.Price = 0;
                        detailAR.Quantity = 0;
                        detailAR.SeqNo = seq;
                        return detailAR;
                    }
                case 13:
                    {
                        detailAR.Amount = data.Amount;
                        detailAR.BusinessUnit = "05";
                        detailAR.ItemDescription = "Office Maintenance Fee in " + BTS2BizPacCommon.StringBackMonthYear;
                        detailAR.MiscItemCode = "OM0001";
                        detailAR.Price = 0;
                        detailAR.Quantity = 0;
                        detailAR.SeqNo = seq;
                        return detailAR;
                    }
                case 14 :
                    {
                        goto case 11;
                    }
                case 15 :
                    {
                        goto case 12;
                    }
                case 16 :
                    {
                        goto case 13;
                    }
                case 17:
                    {
                        goto case 11;
                    }
                default:
                    {
                        goto case 11;
                    }
            }
        }

        private void markBizPacRef(IAccountHeader value)
        {
            RefFlow.MarkBizPacRef(value);
        }

        private void copyBizPacRef(IAccountHeader from, IAccountHeader to)
        {
            to.BizPacRefNo = from.BizPacRefNo;
            to.BizPacRefDate = from.BizPacRefDate;
        }

        private ServiceStaffContractChargeBP createNewBP(ServiceStaffContractChargeBP data)
        {
            markBizPacRef(data);

            ServiceStaffContractChargeBP cloneData = new ServiceStaffContractChargeBP(new Company("12"));
            cloneData.AttachGroup = data.AttachGroup;
            cloneData.AContractType = data.AContractType;
            cloneData.ACustomer = data.ACustomer;
            cloneData.ACustomerDepartment = data.ACustomerDepartment;
            cloneData.AKindOfContract = data.AKindOfContract;

            cloneData.BizPacRefDate = data.BizPacRefDate;
            cloneData.BizPacRefNo = data.BizPacRefNo;

            cloneData.BaseAmount = data.Amount;
            cloneData.VATAmount = data.VATAmount;

            return cloneData;
        }

        private void add(ServiceStaffContractChargeBP data, ServiceStaffContractChargeBP exist)
        {
            copyBizPacRef(exist, data);

            exist.BaseAmount += data.Amount;
            exist.VATAmount += data.VATAmount;
        }

        public void Add(ServiceStaffContractChargeBP data)
        {
            sdnCreater = getSDNCreater(data);
            BTS2BizPacList serviceStaffDN = getServiceStaffDN((IBTS2BizPacHeader)data);
            AttachGroupStruct attachGroup = sdnCreater.GetAttachGroup(data);

            BTS2BizPacDetailAR detail;
            ServiceStaffContractChargeBP serviceStaffContractChargeBP;
            string keyDN = attachGroup.DebitNote;
            string keyDetail = attachGroup.GroupCode.ToString();

            if (serviceStaffDN.Contain(keyDN))
            {
                serviceStaffContractChargeBP = (ServiceStaffContractChargeBP)serviceStaffDN.BaseGet(keyDN);
                add(data, serviceStaffContractChargeBP);

                if (serviceStaffContractChargeBP.Details.Contain(keyDetail))
                {
                    detail = (BTS2BizPacDetailAR)serviceStaffContractChargeBP.Details.BaseGet(keyDetail);
                    detail.Amount += data.Amount;
                }
                else
                { 
                    detail = getDeatail(attachGroup.GroupCode, data);
                    serviceStaffContractChargeBP.Details.Add(keyDetail, detail);
                }
            }
            else
            {
                serviceStaffContractChargeBP = createNewBP(data);

                serviceStaffContractChargeBP.Details = new BTS2BizPacDetailList();
                detail = getDeatail(attachGroup.GroupCode, data);
                serviceStaffContractChargeBP.Details.Add(keyDetail, detail);

                serviceStaffDN.Add(keyDN, serviceStaffContractChargeBP);
            }
        }

        public void FillServiceStaffDebitNote(BTS2BizPacList list)
        {
            BTS2BizPacList serviceStaffDN;
            for (int i = 0; i < commonList.Count; i++)
            {
                serviceStaffDN = (BTS2BizPacList)commonList.BaseGet(i);
                for (int j = 0; j < serviceStaffDN.Count; j++)
                {
                    list.Add(serviceStaffDN[j].BizPacRefNo, serviceStaffDN[j]);
                }
            }
            serviceStaffDN = null;
        }

    }
}
