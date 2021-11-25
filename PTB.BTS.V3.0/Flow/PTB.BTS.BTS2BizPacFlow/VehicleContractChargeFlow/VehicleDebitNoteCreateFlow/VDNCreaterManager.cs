using System;
using System.Collections;
using ictus.Common.Entity.General;
using PTB.BTS.BTS2BizPacEntity;
using Entity.ContractEntities;
using ictus.SystemConnection.BizPac.AR;
using PTB.BTS.BTS2BizPacFlow.VehicleContractChargeFlow;

namespace PTB.BTS.BTS2BizPacFlow.VehicleDebitNoteCreateFlow
{
    public class VDNCreaterManager
    {
        public static VehicleContractChargeBPFlow RefFlow;
        public VDNCreaterManager()
        {
            commonList = new CommonList();
        }

        #region - VehicleDN -
        private CommonList commonList;
        private BTS2BizPacList getVehicleDN(IBTS2BizPacHeader header)
        {
            string customerCode = ((IARHeader)header).CustomerCode;
            if (commonList.Contain(customerCode))
            {
                return (BTS2BizPacList)commonList.BaseGet(customerCode);
            }
            else
            {
                BTS2BizPacList vehicleDN = new BTS2BizPacList();
                commonList.Add(customerCode, vehicleDN);
                return vehicleDN;
            }
        }

        VDNCreaterBase vdnCreater;
        VDNCreater0 vdnCreater0;
        VDNCreater1 vdnCreater1;
        VDNCreater2 vdnCreater2;
        VDNCreater3 vdnCreater3;
        VDNCreater4 vdnCreater4;
        VDNCreater5 vdnCreater5;

        private VDNCreaterBase getVDNCreater(IBTS2BizPacHeader header)
            {
                string customerCode = ((IARHeader)header).CustomerCode;
                switch (customerCode)
                {
                    case "000001": //TIS
                        {
                            if (vdnCreater1 == null)
                            {
                                vdnCreater1 = new VDNCreater1();
                            }
                            return vdnCreater1;
                        }
                    case "000009": //TAS
                        {
                            if (vdnCreater2 == null)
                            {
                                vdnCreater2 = new VDNCreater2();
                            }
                            return vdnCreater2;
                        }
                    case "000014": //IMCT
                        {
                            if (vdnCreater3 == null)
                            {
                                vdnCreater3 = new VDNCreater3();
                            }
                            return vdnCreater3;
                        }
                    case "000010": //BSTL
                        {
                            if (vdnCreater4 == null)
                            {
                                vdnCreater4 = new VDNCreater4();
                            }
                            return vdnCreater4;
                        }
                    case "000024": //THAI-MC
                        {
                            if (vdnCreater5 == null)
                            {
                                vdnCreater5 = new VDNCreater5();
                            }
                            return vdnCreater5;
                        }
                    default:
                        {
                            if (vdnCreater0 == null)
                            {
                                vdnCreater0 = new VDNCreater0("");
                            }
                            return vdnCreater0;
                        }
                }
            }
        #endregion

        public void Add(IBTS2BizPacHeader data)
        {
            vdnCreater = getVDNCreater(data);
            vdnCreater.CalculateVAT(data);
            vdnCreater.Add(data, getVehicleDN(data));
        }

        public void FillVehicleDebitNote(BTS2BizPacList list)
        {
            BTS2BizPacList vehicleDN;
            for (int i = 0; i < commonList.Count; i++)
            {
                vehicleDN = (BTS2BizPacList)commonList.BaseGet(i);
                for (int j = 0; j < vehicleDN.Count; j++)
                {
                    list.Add(vehicleDN[j].BizPacRefNo, vehicleDN[j]);
                }
            }
            vehicleDN = null;
        }
    }
}
