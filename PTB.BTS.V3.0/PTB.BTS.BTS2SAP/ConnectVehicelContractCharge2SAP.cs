using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PTB.BTS.BTS2BizPacEntity;
using ictus.SystemConnection.BizPac.Core;
using PTB.BTS.BTS2SAP.Entity;
using System.Threading;
using System.Globalization;

namespace PTB.BTS.BTS2SAP
{
    public class ConnectVehicelContractCharge2SAP
    {
        public string GetVehicelContractChargeSAPDataFile(BTS2BizPacList resultList, string postingDate)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");

            SAPConnectionBase sapConnectBase = new SAPConnectionBase();
            List<List<BTS2SAPModel>> preparedList = new List<List<BTS2SAPModel>>();

            for (int i = 0; i < resultList.Count; i++)
            {
                List<BTS2SAPModel> dataList = new List<BTS2SAPModel>();

                VehicleContractChargeBP headData = (VehicleContractChargeBP)resultList[i];

                BTS2BizPacDetailAR detailAR = (BTS2BizPacDetailAR)headData.GetDetail(0);

                //Base function
                dataList = sapConnectBase.GetSAPTemplateFromDB("AR_V_CHARGE");

                // !! Fill data -- Change Here !!
                foreach (BTS2SAPModel line in dataList)
                {
                    if (detailAR.ItemDescription.Trim().Length > 50)
                    {
                        throw new Exception("Item_Text more than 50 digits");
                    }

                    switch (line.MiscItemCode.ToUpper())
                    {
                        case "NETAMT":
                            line.BizPacRefNo = headData.BizPacRefNo.Trim();
                            //line.DocumentDate = headData.TaxInvoiceDate.ToString("dd/MM/yyyy");
                            line.DocumentDate = postingDate.Trim();
                            line.PostingDate = postingDate.Trim(); // get date from list of AP: Posting_Date
                            line.Reference = headData.BizPacRefNo.Trim();
                            //((headData.TaxInvoiceNo != null) || !string.IsNullOrEmpty(headData.TaxInvoiceNo)) ? headData.TaxInvoiceNo : headData.BizPacRefNo;

                            line.Account = sapConnectBase.GetCustomerSAPCodeFromDB(headData.CustomerCode.Trim());
                            if (line.Account == "" || line.Account.Equals(string.Empty) || line.Account == null)
                            {
                                throw new Exception("ไม่พบรหัสบัญชี ลูกค้า : " + headData.CustomerName);
                            }

                            line.AmountInDocumentCurrency = (line.AmountInDocumentCurrency.Trim().Equals("1") ? headData.NetAmount.ToString("F") : string.Empty);
                            line.ItemText = (line.ItemText.Trim().Equals("1") ? detailAR.ItemDescription.Trim() : string.Empty);
                            line.WHTBase1 = (line.WHTBase1.Trim().Equals("1") ? headData.BaseAmount.ToString("F") : string.Empty);

                            decimal whtValue = sapConnectBase.GetWithHoldingTaxValueFromDB(line.WHTCode1);
                            line.WHTAMT1 = (line.WHTAMT1.Trim().Equals("1") ? (headData.BaseAmount * whtValue / 100).ToString("F") : string.Empty);

                            break;
                        case "BASAMT":
                            line.BizPacRefNo = headData.BizPacRefNo.Trim();
                            line.AmountInDocumentCurrency = headData.BaseAmount.ToString("F");
                            line.ItemText = (line.ItemText.Trim().Equals("1") ? detailAR.ItemDescription.Trim() : string.Empty);
                            break;
                        case "VATAMT":
                            line.BizPacRefNo = headData.BizPacRefNo.Trim();
                            line.AmountInDocumentCurrency = headData.VATAmount.ToString("F").Trim();
                            line.TaxBaseAmount = headData.BaseAmount.ToString("F");
                            line.ItemText = (line.ItemText.Trim().Equals("1") ? detailAR.ItemDescription.Trim() : string.Empty);
                            break;
                    }
                }

                preparedList.Add(dataList);
            }

            // Base function
            sapConnectBase.RemoveAmtInDocCurrencyIsZeroData(ref preparedList);  // Remove data line which have "AmountInDocumentCurrency" value = 0 in each group
            sapConnectBase.SaveDataToTRSAPTransaction(preparedList);

            //string filename = "PTB_BTS_AR_" + DateTime.Now.ToString(BTS2SAPDateFormat.FileNameDateFormat(DateTime.Now)) + ".csv";
            //sapConnectBase.createCSV(filename, preparedList);

            string filename = "PTB_BTS_AR_" + DateTime.Now.ToString(BTS2SAPDateFormat.FileNameDateFormat(DateTime.Now)) + ".xlsx";
            filename = sapConnectBase.createXLSX(filename, preparedList);

            return filename;
        }
    }
}
