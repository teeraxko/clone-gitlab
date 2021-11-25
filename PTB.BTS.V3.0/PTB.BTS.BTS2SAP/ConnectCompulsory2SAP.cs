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
    public class ConnectCompulsory2SAP
    {
        public string GetCompulsorySAPDataFile(BTS2BizPacList resultList, DateTime postingDate)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");

            SAPConnectionBase sapConnectBase = new SAPConnectionBase();
            List<List<BTS2SAPModel>> preparedList = new List<List<BTS2SAPModel>>();

            for (int i = 0; i < resultList.Count; i++)
            {
                List<BTS2SAPModel> dataList = new List<BTS2SAPModel>();

                CompulsoryInsuranceBP headData = (CompulsoryInsuranceBP)resultList[i];

                BTS2BizPacDetailAP detailAP = (BTS2BizPacDetailAP)headData.Details[0];

                // Base function
                dataList = sapConnectBase.GetSAPTemplateFromDB(BTS2SAPTransferTypeEnums.APTransferType.AP_CINSUR.ToString());

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
                                line.Account = sapConnectBase.GetInsuranceCompanySAPCodeFromDB("12", headData.VendorCode.ToString());
                            }

                            line.AmountInDocumentCurrency = (line.AmountInDocumentCurrency.Trim().Equals("1") ? headData.NetAmount.ToString("F") : string.Empty);
                            line.ItemText = (line.ItemText.Trim().Equals("1") ? headData.Details[0].ItemDescription : string.Empty);
                            line.WHTBase1 = (line.WHTBase1.Trim().Equals("1") ? headData.BaseAmount.ToString() : string.Empty);

                            decimal whtValue = sapConnectBase.GetWithHoldingTaxValueFromDB(line.WHTCode1);
                            line.WHTAMT1 = (line.WHTAMT1.Trim().Equals("1") ? (headData.BaseAmount * whtValue / 100).ToString("F") : string.Empty);

                            break;
                        case "CINSUR":
                            line.BizPacRefNo = headData.BizPacRefNo;
                            line.AmountInDocumentCurrency = headData.Year1Amount.ToString("F");
                            line.ItemText = (line.ItemText.Trim().Equals("1") ? headData.Details[0].ItemDescription : string.Empty);
                            break;
                        case "PREP01":
                            line.BizPacRefNo = headData.BizPacRefNo;
                            line.AmountInDocumentCurrency = headData.Year2Amount.ToString("F");
                            line.ItemText = (line.ItemText.Trim().Equals("1") ? headData.Details[0].ItemDescription : string.Empty);
                            break;
                        case "VATAMT":
                            line.BizPacRefNo = headData.BizPacRefNo;
                            line.AmountInDocumentCurrency = headData.VatAmount.ToString("F");
                            line.TaxBaseAmount = headData.BaseAmount.ToString();
                            line.ItemText = (line.ItemText.Trim().Equals("1") ? headData.Details[0].ItemDescription : string.Empty);
                            break;
                    }
                }

                preparedList.Add(dataList);
            }

            // Base function
            sapConnectBase.RemoveAmtInDocCurrencyIsZeroData(ref preparedList);  // Remove data line which have "AmountInDocumentCurrency" value = 0 in each group
            sapConnectBase.SaveDataToTRSAPTransaction(preparedList);

            //string filename = "PTB_BTS_AP_" + DateTime.Now.ToString("yyMMddHHmmss") + ".csv";
            //sapConnectBase.createCSV(filename, preparedList);

            string filename = "PTB_BTS_AP_" + DateTime.Now.ToString(BTS2SAPDateFormat.FileNameDateFormat(DateTime.Now)) + ".xlsx";
            filename = sapConnectBase.createXLSX(filename, preparedList);

            return filename;
        }
    }
}
