using System;
using ictus.Common.Entity.General;
using PTB.BTS.BTS2BizPacEntity;
using ictus.SystemConnection.BizPac.AR;
using PTB.BTS.BTS2BizPacFlow.DriverContractChargeFlow;

namespace PTB.BTS.BTS2BizPacFlow.DriverDebitNoteCreateFlow
{
    public class DDNCreaterManager
    {
        public static DriverContractChargeBPFlow RefFlow;
        public DDNCreaterManager()
        {
            commonList = new CommonList();
        }

        #region - Driver DN -
        private CommonList commonList;
        private BTS2BizPacList getDriverDN(IBTS2BizPacHeader header)
        {
            string customerCode = ((IARHeader)header).CustomerCode;
            if (commonList.Contain(customerCode))
            {
                return (BTS2BizPacList)commonList.BaseGet(customerCode);
            }
            else
            {
                BTS2BizPacList driverDN = new BTS2BizPacList();
                commonList.Add(customerCode, driverDN);
                return driverDN;
            }
        }

        DDNCreaterBase ddnCreater;
        DDNCreater0 ddnCreater0;
        DDNCreater1 ddnCreater1;
        DDNCreater2 ddnCreater2;
        DDNCreater3 ddnCreater3;
        DDNCreater4 ddnCreater4;
        DDNCreater5 ddnCreater5;

        private DDNCreaterBase getDDNCreater(IBTS2BizPacHeader header)
        {
            string customerCode = ((IARHeader)header).CustomerCode;
            switch (customerCode)
            {
                case "000001": //TIS
                    {
                        if (ddnCreater1 == null)
                        {
                            ddnCreater1 = new DDNCreater1();
                        }
                        return ddnCreater1;
                    }
                case "000014": //IMCT
                    {
                        if (ddnCreater2 == null)
                        {
                            ddnCreater2 = new DDNCreater2();
                        }
                        return ddnCreater2;
                    }
                case "000017": //TMNF
                    {
                        if (ddnCreater3 == null)
                        {
                            ddnCreater3 = new DDNCreater3();
                        }
                        return ddnCreater3;
                    }
                case "000024": //ThaiMC
                case "000028": //Thai Bridgestone
                    {
                        if (ddnCreater4 == null)
                        {
                            ddnCreater4 = new DDNCreater4();
                        }
                        return ddnCreater4;
                    }
                case "000005": //IOT
                    {
                        if (ddnCreater5 == null)
                        {
                            ddnCreater5 = new DDNCreater5();
                        }
                        return ddnCreater5;
                    }
                default:
                    //000026 //TID
                    //000022 //MIT
                    //Other
                    {
                        if (ddnCreater0 == null)
                        {
                            ddnCreater0 = new DDNCreater0("");
                        }
                        return ddnCreater0;
                    }
            }
        }
        #endregion

        public void Add(IBTS2BizPacHeader data)
        {
            ddnCreater = getDDNCreater(data);
            //ddnCreater.CalculateVAT(data);
            ddnCreater.Add(data, getDriverDN(data));
        }

        public void FillDriverDebitNote(BTS2BizPacList list)
        {
            BTS2BizPacList driverDN;
            for (int i = 0; i < commonList.Count; i++)
            {
                driverDN = (BTS2BizPacList)commonList.BaseGet(i);
                for (int j = 0; j < driverDN.Count; j++)
                {
                    list.Add(driverDN[j].BizPacRefNo, driverDN[j]);
                }
            }
            driverDN = null;
        }

    }
}
