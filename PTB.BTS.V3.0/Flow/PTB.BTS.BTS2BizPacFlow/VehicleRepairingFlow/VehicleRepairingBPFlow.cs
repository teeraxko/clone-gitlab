using System;

using ictus.Common.Entity.General;

using ictus.SystemConnection.BizPac.AP;

using PTB.BTS.BTS2BizPacDB;
using PTB.BTS.BTS2BizPacDB.BizPacImplementDB;
using PTB.BTS.BTS2BizPacEntity;
using DataAccess.CommonDB;
using ictus.Common.Entity;
using PTB.BTS.BTS2BizPacDB.BizPacReportDB;
using ictus.SystemConnection.BizPac.Core;
using ictus.Common.Entity.Time;
using PTB.BTS.Contract.Flow;
using PTB.BTS.BTS2SAP;

namespace PTB.BTS.BTS2BizPacFlow.VehicleRepairingFlow
{
    public class VehicleRepairingBPFlow : BTS2BizPacConnectFlow
    {
        //============================== Constructor ==============================
        public VehicleRepairingBPFlow() : base()
        {
            dbConnect = new VehicleRepairingHistoryBPDB();
        }

        protected override void markBizPacRef(IAccountHeader value)
        {
            if (flowDocumentNo == null)
            {
                flowDocumentNo = new DocumentNoFlow();
            }
            value.BizPacRefNo = flowDocumentNo.GetBizPacRefNo();
        }

        //============================== Private method ==============================
        private void generateTRRepairingExpense(BTS2BizPacList listBP, BTS2BizPacList repairingExpenseList)
        {
            repairingExpenseList.Clear();

            RepairingBP repairingBP;
            RepairingBP repairingExpense;

            for (int i = 0; i < listBP.Count; i++)
            {
                repairingExpense = new RepairingBP();
                repairingBP = (RepairingBP)listBP[i];

                repairingExpense.RepairingNo = repairingBP.RepairingNo;
                repairingExpense.Garage = repairingBP.Garage;
                repairingExpense.BizPacRefNo = repairingBP.BizPacRefNo;
                repairingExpense.VehicleInfo = repairingBP.VehicleInfo;
                repairingExpense.TaxInvoiceNo = repairingBP.TaxInvoiceNo;
                repairingExpense.TaxInvoiceDate = repairingBP.TaxInvoiceDate;
                repairingExpense.MaintenanceAmount = repairingBP.MaintenanceAmount;
                repairingExpense.VatAmount = repairingBP.VatAmount;
                repairingExpense.TotalAmount = repairingBP.TotalAmount;

                repairingExpenseList.Add(repairingExpense);
            }
            repairingExpense = null;
            repairingBP = null;
        }

        private bool sumByVendorCode(BTS2BizPacList list, BTS2BizPacList btsResults, BTS2BizPacList bizpacResult)
        {
            CommonList temps = new CommonList();
            RepairingBP data;
            RepairingBP dataTemp;
            for (int i = 0; i < list.Count; i++)
            {
                data = (RepairingBP)list[i];
                if (temps.Contain(data.VendorCode))
                {
                    dataTemp = (RepairingBP)temps.BaseGet(data.VendorCode);
                    dataTemp.Add(data);
                    copyBizPacRef(dataTemp, data);

                    btsResults.Add(data);
                }
                else
                {
                    markBizPacRef(data);
                    //Special case for connection date : Update by woranai 16/11/2006
                    data.BizPacRefDate = list.ConnectDate;

                    dataTemp = data.Clone();
                    temps.Add(dataTemp.VendorCode, dataTemp);

                    btsResults.Add(data);
                    bizpacResult.Add(dataTemp);
                }
            }

            list.Clear();
            return true;
        }

        //============================== Protected method ==============================
        protected override void markBizPacRefByTaxInvoice(BTS2BizPacList list, BTS2BizPacList btsResults, BTS2BizPacList bizpacResults)
        {
            CommonList taxCheckList = new CommonList();
            IBTS2BizPacHeader data;
            RepairingBP existData;
            IAPHeader tempHead;
            string identifyCode;

            for (int i = 0; i < list.Count; i++)
            {
                data = list[i];
                tempHead = (IAPHeader)data;
                identifyCode = ((RepairingBP)tempHead).Garage.Code + tempHead.TaxInvoiceNo;
                if (tempHead.HaveTaxInvoice)
                {
                    if (taxCheckList.Contain(identifyCode))
                    {
                        existData = (RepairingBP)taxCheckList.BaseGet(identifyCode);
                        existData.Add((RepairingBP)data);
                        copyBizPacRef(existData, data);
                        btsResults.Add(data);
                    }
                    else
                    {
                        markBizPacRef(data);
                        //Special case for connection date : Update by woranai 16/11/2006
                        data.BizPacRefDate = list.ConnectDate;

                        RepairingBP cloneRepairingBP = ((RepairingBP)data).Clone();

                        taxCheckList.Add(identifyCode, cloneRepairingBP);

                        btsResults.Add(data);
                        bizpacResults.Add(cloneRepairingBP);                    
                    }
                }
            }            

            BTS2BizPacList tempResult = new BTS2BizPacList();
            for (int i = 0; i < list.Count; i++)
            {
                data = list[i];
                if (!((IAPHeader)data).HaveTaxInvoice)
                {
                    tempResult.Add(list[i]);
                }
            }
            list.Clear();
            for (int i = 0; i < tempResult.Count; i++)
            {
                list.Add(tempResult[i]);
            }

            data = null;
            tempResult = null;
        }

        protected override bool SpecificConnect(BTS2BizPacList listBP, BTS2BizPacList resultListBTS, BTS2BizPacList resultListBP)
        {
            markBizPacRefByTaxInvoice(listBP, resultListBTS, resultListBP);
            return sumByVendorCode(listBP, resultListBTS, resultListBP);
        }

        protected override bool TRConnect(BTS2BizPacList listBP, TableAccess tableAccess, Company company)
        {
            bool result = false;
            BTS2BizPacList repairingExpenseList = new BTS2BizPacList();
            TrRepairingExpenseDB dbTrrepairingExpense = new TrRepairingExpenseDB();

            generateTRRepairingExpense(listBP, repairingExpenseList);

            dbTrrepairingExpense.TableAccess = tableAccess;
            dbTrrepairingExpense.DeleteTrRepairingExpense();
            result = dbTrrepairingExpense.InsertTrRepairingExpense(repairingExpenseList);

            return result;
        }

        // [TODO] Kriangkrai A. 14/2/2018
        protected override string GenerateCSV2SAP(BTS2BizPacList listBP, DateTime connectDate)
        {
            ConnectVehicleRepairing2SAP sapConnection = new ConnectVehicleRepairing2SAP();
            string filename = sapConnection.GetVehicleRepairingSAPDataFile(listBP, connectDate);

            return filename;
        }
    }
}
