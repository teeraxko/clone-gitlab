using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading;
using PTB.BTS.BTS2SAP.Entity;
using PTB.PIS.Welfare.BizPac.AP;
using PTB.BTS.BTS2SAP;
using PTB.PIS.Welfare.BizPac.GL;

namespace PTB.PIS.Welfare.BizPac.PTB.BTS.BTS2SAP.Connection
{
    public class ConnectMedicalAid2SAP
    {
        public string GetMedicalAidAttSAPDataFile(List<APJournalForMedicalAid> resultList, DateTime postingDate)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");

            SAPConnectionBase sapConnectBase = new SAPConnectionBase();
            List<List<BTS2SAPModel>> preparedList = new List<List<BTS2SAPModel>>(); // Prepare Data into this data type to generate CSV File

            foreach (APJournalForMedicalAid lineData in resultList)
            {
                List<BTS2SAPModel> templateList = new List<BTS2SAPModel>();
                List<BTS2SAPModel> dataList = new List<BTS2SAPModel>();

                List<APItem> detailsData = lineData.Items;

                string MiscExpenseCode = detailsData[0].MiscExpenseCode;

                // Base function
                templateList = sapConnectBase.GetSAPTemplateFromDB(BTS2SAPTransferTypeEnums.APTransferType.AP_MEDATT.ToString());

                // Insert NETAMT
                BTS2SAPModel netAMT = templateList.Where(x => x.MiscItemCode.Trim().Equals("NETAMT")).FirstOrDefault();
                netAMT.BizPacRefNo = lineData.Header.DocNo;
                netAMT.DocumentDate = lineData.Header.DocDate.ToString(BTS2SAPDateFormat.SAPCSVDateFormat()).Trim();
                netAMT.PostingDate = postingDate.ToString(BTS2SAPDateFormat.SAPCSVDateFormat()).Trim();
                netAMT.Reference = lineData.Header.DocNo; // BIZPAC Ref. NO.
                netAMT.Account = netAMT.PostingKey.Trim().Equals("31") ? sapConnectBase.GetHospitalSAPCodeFromDB(lineData.Header.VenderCode).ToString() : string.Empty;
                netAMT.AmountInDocumentCurrency = netAMT.AmountInDocumentCurrency.Trim().Equals("1") ? lineData.NetAmount.ToString("F") : string.Empty;
                netAMT.ItemText = netAMT.ItemText.Trim().Equals("1") ? lineData.Header.Remark : string.Empty;
                // End Insert NETAMT

                dataList.Add(netAMT);

                // Get Details template by MiscCode
                foreach (APItem detailLine in detailsData)
                {
                    // Kriangkrai A. for tuning performance
                    //// Check line detail which have amount = 0 or not if amount = 0 skip to write line
                    //if (detailLine.Amount == 0)
                    //{
                    //    continue;
                    //}

                    BTS2SAPModel medEXP = templateList.Where(x => x.MiscItemCode.Trim().Equals(detailLine.MiscExpenseCode.Trim())).FirstOrDefault();

                    medEXP.BizPacRefNo = lineData.Header.DocNo;
                    medEXP.AmountInDocumentCurrency = detailLine.Amount.ToString("F");
                    medEXP.ItemText = medEXP.ItemText.Trim().Equals("1") ? detailLine.ItemDescr : string.Empty;

                    dataList.Add(medEXP);
                }

                preparedList.Add(dataList);
            }

            // Base function
            sapConnectBase.RemoveAmtInDocCurrencyIsZeroData(ref preparedList);  // Remove data line which have "AmountInDocumentCurrency" value = 0 in each group
            sapConnectBase.SaveDataToTRSAPTransaction(preparedList);

            //string filename = "PTB_BTS_AP_" + DateTime.Now.ToString("yyMMddHHmmss") + ".csv";
            //string filename = "MedicalAidAtt_" + DateTime.Now.ToString("yyMMddHHmmss") + ".csv";

            //sapConnectBase.createCSV(filename, preparedList);
            string filename = "PTB_BTS_AP_" + DateTime.Now.ToString(BTS2SAPDateFormat.FileNameDateFormat(DateTime.Now)) + ".xlsx";
            filename = sapConnectBase.createXLSX(filename, preparedList);

            return filename;
        }

        public string GetMedicalAidNoAttSAPDataFile(GLJournal journal, DateTime postingDate)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");

            SAPConnectionBase sapConnectBase = new SAPConnectionBase();
            List<List<BTS2SAPModel>> preparedList = new List<List<BTS2SAPModel>>(); // Prepare Data into this data type to generate CSV File

            GLHeader header = journal.Header;

            List<BTS2SAPModel> templateList = new List<BTS2SAPModel>();
            List<BTS2SAPModel> dataList = new List<BTS2SAPModel>();

            List<GLitem> detailsData = journal.Debits;

            // Base function
            templateList = sapConnectBase.GetSAPTemplateFromDB(BTS2SAPTransferTypeEnums.GLTransferType.GL_MEDNAT.ToString());

            // Insert NETAMT
            BTS2SAPModel netAMT = templateList.Where(x => x.MiscItemCode.Trim().Equals("NETAMT")).FirstOrDefault();
            netAMT.BizPacRefNo = header.RefNo;
            netAMT.DocumentDate = header.DocDate.ToString(BTS2SAPDateFormat.SAPCSVDateFormat()).Trim();
            netAMT.PostingDate = postingDate.ToString(BTS2SAPDateFormat.SAPCSVDateFormat()).Trim();
            netAMT.Reference = header.RefNo; // BIZPAC Ref. NO.
            //netAMT.Account = netAMT.PostingKey.Trim().Equals("31") ? sapConnectBase.GetHospitalSAPCodeFromDB(lineData.Header.VenderCode).ToString() : string.Empty;
            netAMT.AmountInDocumentCurrency = netAMT.AmountInDocumentCurrency.Trim().Equals("1") ? journal.TotalAmount.ToString("F") : string.Empty;
            netAMT.ItemText = netAMT.ItemText.Trim().Equals("1") ? header.Descr : string.Empty;
            // End Insert NETAMT

            dataList.Add(netAMT);

            // Get Details template by MiscCode (by Dept)
            foreach (GLitem detailLine in detailsData)
            {
                BTS2SAPModel basAMT = templateList.Where(x => x.MiscItemCode.Trim().ToUpper().Equals(detailLine.MiscExpenseCode)).FirstOrDefault();

                basAMT.BizPacRefNo = header.RefNo;
                basAMT.AmountInDocumentCurrency = detailLine.Amount.ToString("F");
                basAMT.ItemText = basAMT.ItemText.Trim().Equals("1") ? header.Descr : string.Empty;

                dataList.Add(basAMT);
            }

            preparedList.Add(dataList);

            // Base function
            sapConnectBase.RemoveAmtInDocCurrencyIsZeroData(ref preparedList);  // Remove data line which have "AmountInDocumentCurrency" value = 0 in each group
            sapConnectBase.SaveDataToTRSAPTransaction(preparedList);

            //string filename = "MedAid" + DateTime.Now.ToString("yyMMddHHmmss") + ".csv";
            //string filename = "PTB_BTS_GL_" + DateTime.Now.ToString(BTS2SAPDateFormat.FileNameDateFormat(DateTime.Now)) + ".csv";

            //sapConnectBase.createCSV(filename, preparedList);
            string filename = "PTB_BTS_GL_" + DateTime.Now.ToString(BTS2SAPDateFormat.FileNameDateFormat(DateTime.Now)) + ".xlsx";
            filename = sapConnectBase.createXLSX(filename, preparedList);

            return filename;
        }
    }
}
