using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PTB.PIS.Welfare.BizPac.GL;
using System.Globalization;
using System.Threading;
using PTB.BTS.BTS2SAP;
using PTB.BTS.BTS2SAP.Entity;
using PTB.PIS.Welfare.BizPac.AP;

namespace PTB.PIS.Welfare.BizPac.PTB.BTS.BTS2SAP.Connection
{
    public class ConnectContribution2SAP
    {
        public string GetContributionSAPDataFile(GLJournal journal, DateTime postingDate)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");

            SAPConnectionBase sapConnectBase = new SAPConnectionBase();
            List<List<BTS2SAPModel>> preparedList = new List<List<BTS2SAPModel>>(); // Prepare Data into this data type to generate CSV File

            GLHeader header = journal.Header;

            List<BTS2SAPModel> templateList = new List<BTS2SAPModel>();
            List<BTS2SAPModel> dataList = new List<BTS2SAPModel>();

            List<GLitem> detailsData = journal.Debits;

            // Base function
            templateList = sapConnectBase.GetSAPTemplateFromDB(BTS2SAPTransferTypeEnums.GLTransferType.GL_WELFARE.ToString());

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
            foreach (GLDebit detailLine in detailsData)
            {
                BTS2SAPModel basAMT = templateList.Where(x => x.MiscItemCode.Trim().ToUpper().Equals(detailLine.MiscExpenseCode)).FirstOrDefault();

                basAMT.BizPacRefNo = header.RefNo;
                basAMT.AmountInDocumentCurrency = detailLine.Amount.ToString("F");
                basAMT.ItemText = basAMT.ItemText.Trim().Equals("1") ? detailLine.LineDescrEn : string.Empty;

                dataList.Add(basAMT);
            }

            preparedList.Add(dataList);

            // Base function
            sapConnectBase.RemoveAmtInDocCurrencyIsZeroData(ref preparedList);  // Remove data line which have "AmountInDocumentCurrency" value = 0 in each group
            sapConnectBase.SaveDataToTRSAPTransaction(preparedList);

            //string filename = "PTB_GL_" + DateTime.Now.ToString("yyMMddHHmmss") + ".csv";
            //string filename = "PTB_BTS_GL_" + DateTime.Now.ToString(BTS2SAPDateFormat.FileNameDateFormat(DateTime.Now)) + ".csv";

            //sapConnectBase.createCSV(filename, preparedList);
            string filename = "PTB_BTS_GL_" + DateTime.Now.ToString(BTS2SAPDateFormat.FileNameDateFormat(DateTime.Now)) + ".xlsx";
            filename = sapConnectBase.createXLSX(filename, preparedList);

            return filename;
        }
    }
}
