using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PTB.BTS.BTS2BizPacEntity;
using System.Globalization;
using System.Threading;
using PTB.BTS.BTS2SAP.Entity;

namespace PTB.BTS.BTS2SAP
{
    public class ConnectVehicleRepairing2SAP
    {
        public string GetVehicleRepairingSAPDataFile(BTS2BizPacList resultList, DateTime postingDate)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");

            SAPConnectionBase sapConnectBase = new SAPConnectionBase();
            List<List<BTS2SAPModel>> preparedList = new List<List<BTS2SAPModel>>();

            //List<RepairingBP> listdata = new List<RepairingBP>();
            //for (int i = 0; i < resultList.Count; i++)
            //{
            //    listdata.Add(((RepairingBP)resultList[i]));
            //}

            for (int i = 0; i < resultList.Count; i++)
            {
                List<BTS2SAPModel> dataList = new List<BTS2SAPModel>();

                RepairingBP headData = (RepairingBP)resultList[i];

                //BTS2BizPacDetailAP detailAP = (BTS2BizPacDetailAP)headData.GetDetail(0);

                // Base function
                dataList = sapConnectBase.GetSAPTemplateFromDB(BTS2SAPTransferTypeEnums.APTransferType.AP_REPAIR.ToString());

                int removeIndex = -1;

                // Find PURVAT or UNDVAT
                if (headData.InvoiceType.Trim().Equals("G")) // InvoiceType = "G" -> PURVAT ("V7")
                {
                    removeIndex = dataList.FindIndex(x => x.MiscItemCode.Trim().Equals("VATAMT") && !x.TaxCode.Trim().Equals("V7"));
                }
                else // InvoiceType = "S" -> UNDVAT ("D7")
                {
                    removeIndex = dataList.FindIndex(x => x.MiscItemCode.Trim().Equals("VATAMT") && !x.TaxCode.Trim().Equals("D7"));
                }

                // Remove unuse template record
                dataList.RemoveAt(removeIndex);

                // !! Fill data -- Change Here !!
                foreach (BTS2SAPModel line in dataList)
                {
                    switch (line.MiscItemCode.ToUpper())
                    {
                        case "NETAMT":
                            line.BizPacRefNo = headData.BizPacRefNo;
                            line.DocumentDate = headData.TaxInvoiceDate.ToString(BTS2SAPDateFormat.SAPCSVDateFormat()).Trim();
                            line.PostingDate = postingDate.ToString(BTS2SAPDateFormat.SAPCSVDateFormat()).Trim(); // get date from list of AP: Posting_Date
                            line.Reference = ((headData.TaxInvoiceNo != null) || !string.IsNullOrEmpty(headData.TaxInvoiceNo)) ? headData.TaxInvoiceNo : headData.BizPacRefNo;

                            if (line.PostingKey.Trim().Equals("31"))
                            {
                                line.Account = sapConnectBase.GetGarageSAPCodeFromDB("12", headData.VendorCode.ToString(), headData.GetDetail(0).MiscItemCode);
                            }

                            line.AmountInDocumentCurrency = (line.AmountInDocumentCurrency.Trim().Equals("1") ? headData.NetAmount.ToString("F") : string.Empty);
                            line.ItemText = (line.ItemText.Trim().Equals("1") ? headData.BizPacRemark1 : string.Empty);
                            line.WHTCode1 = (headData.VATAmount != 0) ? line.WHTCode1 : string.Empty;
                            line.WHTBase1 = ((line.WHTBase1.Trim().Equals("1") && (headData.VATAmount != 0)) ? headData.BaseAmount.ToString() : string.Empty);
                            decimal whtValue = sapConnectBase.GetWithHoldingTaxValueFromDB(line.WHTCode1);
                            line.WHTAMT1 = ((line.WHTAMT1.Trim().Equals("1") && (headData.VATAmount != 0)) ? (headData.BaseAmount * whtValue / 100).ToString("F") : string.Empty);
                            line.WithholdingTaxType1 = (headData.VATAmount != 0) ? line.WithholdingTaxType1 : string.Empty;
                            break;
                        case "BASAMT":
                            line.BizPacRefNo = headData.BizPacRefNo;
                            line.AmountInDocumentCurrency = headData.BaseAmount.ToString("F");
                            line.ItemText = (line.ItemText.Trim().Equals("1") ? headData.BizPacRemark1 : string.Empty);
                            line.Assignment = (line.Assignment.Trim().Equals("1") ? headData.VehicleInfo.PlateNumber : string.Empty);
                            break;
                        case "VATAMT":
                            line.BizPacRefNo = headData.BizPacRefNo;
                            line.AmountInDocumentCurrency = headData.VATAmount.ToString("F");
                            line.ItemText = (line.ItemText.Trim().Equals("1") ? headData.BizPacRemark1 : string.Empty);
                            line.TaxBaseAmount = headData.BaseAmount.ToString();
                            break;
                    }
                }

                //sapConnectBase.ReOrderSAPCSVTransaction(ref dataList);
                preparedList.Add(dataList);
            }

            // Base function
            sapConnectBase.RemoveAmtInDocCurrencyIsZeroData(ref preparedList);  // Remove data line which have "AmountInDocumentCurrency" value = 0 in each group
            sapConnectBase.SaveDataToTRSAPTransaction(preparedList);

            //string filename = "PTB_BTS_AP_" + DateTime.Now.ToString("yyMMddHHmmss") + ".csv";
            //string filename = "VehicleRepairing_" + DateTime.Now.ToString("yyMMddHHmmss") + ".csv";
            //sapConnectBase.createCSV(filename, preparedList);

            string filename = "PTB_BTS_AP_" + DateTime.Now.ToString(BTS2SAPDateFormat.FileNameDateFormat(DateTime.Now)) + ".xlsx";
            filename = sapConnectBase.createXLSX(filename, preparedList);

            return filename;
        }
    }
}
