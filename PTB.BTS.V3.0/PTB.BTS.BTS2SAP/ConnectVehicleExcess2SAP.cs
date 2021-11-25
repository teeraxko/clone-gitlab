using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PTB.BTS.BTS2BizPacEntity;
using System.Globalization;
using System.Threading;
using Entity.CommonEntity;
using PTB.BTS.BTS2SAP.Entity;

namespace PTB.BTS.BTS2SAP
{
    public class ConnectVehicleExcess2SAP
    {
        public string GetVehicleExcessSAPDataFile(BTS2BizPacList resultList, DateTime postingDate)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");

            SAPConnectionBase sapConnectBase = new SAPConnectionBase();
            List<List<BTS2SAPModel>> preparedList = new List<List<BTS2SAPModel>>();

            for (int i = 0; i < resultList.Count; i++)
            {
                List<BTS2SAPModel> templateList = new List<BTS2SAPModel>();
                List<BTS2SAPModel> dataList = new List<BTS2SAPModel>();

                ExcessBP headData = (ExcessBP)resultList[i];

                //BTS2BizPacDetailAP detailAP = (BTS2BizPacDetailAP)headData.GetDetail(0);

                // Base function
                templateList = sapConnectBase.GetSAPTemplateFromDB(BTS2SAPTransferTypeEnums.APTransferType.AP_EXCESS.ToString());

                // Insert NETAMT
                BTS2SAPModel netAMT = templateList.Where(x => x.MiscItemCode.Trim().Equals("NETAMT")).FirstOrDefault();
                netAMT.BizPacRefNo = headData.BizPacRefNo;
                netAMT.DocumentDate = postingDate.ToString(BTS2SAPDateFormat.SAPCSVDateFormat()).Trim();
                netAMT.PostingDate = postingDate.ToString(BTS2SAPDateFormat.SAPCSVDateFormat()).Trim(); // get date from list of AP: Posting_Date
                netAMT.Reference = ((!string.IsNullOrEmpty(headData.TaxInvoiceNo)) ? headData.TaxInvoiceNo : headData.BizPacRefNo);

                if (netAMT.PostingKey.Trim().Equals("31"))
                {
                    netAMT.Account = sapConnectBase.GetInsuranceCompanySAPCodeFromDB("12", headData.VendorCode.ToString());
                }

                netAMT.AmountInDocumentCurrency = (netAMT.AmountInDocumentCurrency.Trim().Equals("1") ? headData.BaseAmount.ToString("F") : string.Empty);
                netAMT.ItemText = (netAMT.ItemText.Trim().Equals("1") ? headData.BizPacRemark1 : string.Empty);
                // End Insert NETAMT

                dataList.Add(netAMT);

                for (int j = 0; j < headData.Details.Count; j++)
                {
                    BTS2BizPacDetailAP detailAP = (BTS2BizPacDetailAP)headData.GetDetail(j);

                    BTS2SAPModel templateLine = new BTS2SAPModel();

                    switch (detailAP.MiscItemCode)
                    {
                        case "OTH001":
                            templateLine = templateList.Where(x => x.MiscItemCode.Trim().Equals("OTH001")).FirstOrDefault();

                            templateLine.BizPacRefNo = headData.BizPacRefNo;
                            templateLine.AmountInDocumentCurrency = detailAP.Amount.ToString("F");
                            templateLine.ItemText = (templateLine.ItemText.Trim().Equals("1") ? detailAP.ItemDescription : string.Empty);
                            break;
                        case "DEP001":
                            templateLine = templateList.Where(x => x.MiscItemCode.Trim().Equals("DEP001")).FirstOrDefault();

                            templateLine.BizPacRefNo = headData.BizPacRefNo;
                            templateLine.AmountInDocumentCurrency = detailAP.Amount.ToString("F");
                            templateLine.ItemText = (templateLine.ItemText.Trim().Equals("1") ? detailAP.ItemDescription : string.Empty);
                            break;
                        case "PART03":
                            templateLine = templateList.Where(x => x.MiscItemCode.Trim().Equals("PART03")).FirstOrDefault();

                            templateLine.BizPacRefNo = headData.BizPacRefNo;
                            templateLine.AmountInDocumentCurrency = detailAP.Amount.ToString("F");
                            templateLine.ItemText = (templateLine.ItemText.Trim().Equals("1") ? detailAP.ItemDescription : string.Empty);
                            break;
                    }

                    dataList.Add(templateLine);
                }

                //List<BTS2SAPModel> removeLinesData = new List<BTS2SAPModel>();

                //// Find OTH001 or DEP001 or PART03
                //// OTH001 : Customer
                //// DEP001 : EMPLOYEE
                //// PART03 : PTB
                //if (detailAP.MiscItemCode.Equals("OTH001"))
                //{
                //    removeLinesData = dataList.Where(x => !x.MiscItemCode.Trim().Equals("OTH001") && !x.MiscItemCode.Trim().Equals("NETAMT")).ToList();
                //}
                //else if (detailAP.MiscItemCode.Equals("DEP001"))
                //{
                //    removeLinesData = dataList.Where(x => !x.MiscItemCode.Trim().Equals("DEP001") && !x.MiscItemCode.Trim().Equals("NETAMT")).ToList();
                //}
                //else
                //{
                //    removeLinesData = dataList.Where(x => !x.MiscItemCode.Trim().Equals("PART03") && !x.MiscItemCode.Trim().Equals("NETAMT")).ToList();
                //}

                //// Remove unuse template record
                //foreach (BTS2SAPModel removeLine in removeLinesData)
                //{
                //    dataList.Remove(removeLine);
                //}

                //sapConnectBase.ReOrderSAPCSVTransaction(ref dataList);

                // !! Fill data -- Change Here !!
                //foreach (BTS2SAPModel line in dataList)
                //{
                //    switch (line.MiscItemCode.ToUpper())
                //    {
                //        case "NETAMT":
                //            line.BizPacRefNo = headData.BizPacRefNo;
                //            line.DocumentDate = postingDate.ToString(BTS2SAPDateFormat.SAPCSVDateFormat()).Trim();
                //            line.PostingDate = postingDate.ToString(BTS2SAPDateFormat.SAPCSVDateFormat()).Trim(); // get date from list of AP: Posting_Date
                //            line.Reference = ((!string.IsNullOrEmpty(headData.TaxInvoiceNo)) ? headData.TaxInvoiceNo : headData.BizPacRefNo);

                //            if (line.PostingKey.Trim().Equals("31"))
                //            {
                //                line.Account = sapConnectBase.GetInsuranceCompanySAPCodeFromDB("12", headData.VendorCode.ToString());
                //            }

                //            line.AmountInDocumentCurrency = (line.AmountInDocumentCurrency.Trim().Equals("1") ? headData.BTSAmount.ToString("F") : string.Empty);
                //            line.ItemText = (line.ItemText.Trim().Equals("1") ? headData.BizPacRemark1 : string.Empty);
                //            //line.WHTBase1 = (line.WHTBase1.Trim().Equals("1") ? headData.BaseAmount.ToString() : string.Empty);

                //            //int whtValue = sapConnectBase.GetWithHoldingTaxValueFromDB(line.WHTCode1);
                //            //line.WHTAMT1 = (line.WHTAMT1.Trim().Equals("1") ? (headData.BaseAmount * whtValue / 100).ToString("F") : string.Empty);

                //            break;
                //        case "OTH001":
                //            line.BizPacRefNo = headData.BizPacRefNo;
                //            line.AmountInDocumentCurrency = headData.BaseAmount.ToString("F");
                //            line.ItemText = (line.ItemText.Trim().Equals("1") ? detailAP.ItemDescription : string.Empty);
                //            break;
                //        case "DEP001":
                //            line.BizPacRefNo = headData.BizPacRefNo;
                //            line.AmountInDocumentCurrency = headData.BaseAmount.ToString("F");
                //            line.ItemText = (line.ItemText.Trim().Equals("1") ? detailAP.ItemDescription : string.Empty);
                //            break;
                //        case "PART03":
                //            line.BizPacRefNo = headData.BizPacRefNo;
                //            line.AmountInDocumentCurrency = headData.BaseAmount.ToString("F");
                //            line.ItemText = (line.ItemText.Trim().Equals("1") ? detailAP.ItemDescription : string.Empty);
                //            break;
                //    }
                //}

                preparedList.Add(dataList);
            }

            // Base function
            sapConnectBase.RemoveAmtInDocCurrencyIsZeroData(ref preparedList);  // Remove data line which have "AmountInDocumentCurrency" value = 0 in each group
            sapConnectBase.SaveDataToTRSAPTransaction(preparedList);

            //string filename = "PTB_AP_" + DateTime.Now.ToString("yyMMddHHmmss") + ".csv";
            //string filename = "PTB_BTS_AP_" + DateTime.Now.ToString(BTS2SAPDateFormat.FileNameDateFormat(DateTime.Now)) + ".csv";
            //sapConnectBase.createCSV(filename, preparedList);

            string filename = "PTB_BTS_AP_" + DateTime.Now.ToString(BTS2SAPDateFormat.FileNameDateFormat(DateTime.Now)) + ".xlsx";
            filename = sapConnectBase.createXLSX(filename, preparedList);

            return filename;
        }
    }
}
