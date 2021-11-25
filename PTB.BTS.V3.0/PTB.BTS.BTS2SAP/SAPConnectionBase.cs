using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using PTB.BTS.BTS2BizPacEntity;
using System.Data;
using ictus.Framework.ASC.AppConfig;
using System.IO;
using PTB.BTS.BTS2SAP.Entity;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using Microsoft.Office.Interop.Excel;

namespace PTB.BTS.BTS2SAP
{
    public class SAPConnectionBase
    {
        //private string DB_CONNECTION = string.Format(@"Data Source={0};Initial Catalog=BTSDB;Persist Security Info=True;User ID=bts;Password=bts", ApplicationProfile.SERVER_NAME);
        private string DB_CONNECTION;

        public SAPConnectionBase()
        {
            StringBuilder stringBuilder = new StringBuilder("Data Source=");
            stringBuilder.Append(ApplicationProfile.SERVER_NAME);
            stringBuilder.Append("; Initial Catalog=");
            stringBuilder.Append(ApplicationProfile.DB_NAME);
            stringBuilder.Append("; User ID=");
            stringBuilder.Append(ApplicationProfile.DB_USER_NAME);
            stringBuilder.Append("; Password=");
            stringBuilder.Append(ApplicationProfile.DB_USER_PASSWORD);

            DB_CONNECTION = stringBuilder.ToString();
        }

        // Base function
        public List<BTS2SAPModel> GetSAPTemplateFromDB(string transferType)
        {
            List<BTS2SAPModel> dataList = new List<BTS2SAPModel>();

            SqlConnection connection = new SqlConnection(DB_CONNECTION);
            SqlCommand cmd = new SqlCommand();

            connection.Open();

            cmd.Connection = connection;
            cmd.CommandText = string.Format(BTS2SAPConstances.FIND_TEMPLATE_QUERY_CMD, transferType);
            cmd.CommandType = CommandType.Text;

            cmd.ExecuteNonQuery();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    BTS2SAPModel dataLine = new BTS2SAPModel()
                    {
                        TransferType = reader[0].ToString(),
                        MiscItemCode = reader[1].ToString(),
                        Doc = reader[2].ToString(),
                        CompanyCode = reader[3].ToString(),
                        DocumentType = reader[4].ToString(),
                        DocumentDate = reader[5].ToString(),
                        PostingDate = reader[6].ToString(),
                        PostingPeriod = reader[7].ToString(),
                        Currency = reader[8].ToString(),
                        ExchangeRate = reader[9].ToString(),
                        Reference = reader[10].ToString(),
                        DocHeaderText = reader[11].ToString(),
                        Branch = reader[12].ToString(),
                        TransactionDate = reader[13].ToString(),
                        PostingKey = reader[14].ToString(),
                        Account = reader[15].ToString(),
                        SpGl = reader[16].ToString(),
                        AlternativeGLAccount = reader[17].ToString(),
                        AmountInDocumentCurrency = reader[18].ToString(),
                        AmountInLocalCurrency = reader[19].ToString(),
                        CalcTax = reader[20].ToString(),
                        TaxCode = reader[21].ToString(),
                        BusinessPlace = reader[22].ToString(),
                        TaxBaseAmount = reader[23].ToString(),
                        DetermineTaxBase = reader[24].ToString(),
                        PmtTerms = reader[25].ToString(),
                        BaselineDate = reader[26].ToString(),
                        PaymentMethod = reader[27].ToString(),
                        PaymentBlock = reader[28].ToString(),
                        InvoiceReference = reader[29].ToString(),
                        IndicatorIndividualPayee = reader[30].ToString(),
                        Assignment = reader[31].ToString(),
                        ItemText = reader[32].ToString(),
                        RefKey1 = reader[33].ToString(),
                        RefKey2 = reader[34].ToString(),
                        BusinessArea = reader[35].ToString(),
                        CostCenter = reader[36].ToString(),
                        ProfitCenter = reader[37].ToString(),
                        InternalOrder = reader[38].ToString(),
                        TradingPartner = reader[39].ToString(),
                        ValueDate = reader[40].ToString(),
                        AssignmentPA = reader[41].ToString(),
                        PAMaterialGroup = reader[42].ToString(),
                        PASalesGroup = reader[43].ToString(),
                        PADivision = reader[44].ToString(),
                        PACostCenter = reader[45].ToString(),
                        PASalesOffice = reader[46].ToString(),
                        WHTCode1 = reader[47].ToString(),
                        WHTBase1 = reader[48].ToString(),
                        WHTAMT1 = reader[49].ToString(),
                        WHTCode2 = reader[50].ToString(),
                        WHTBase2 = reader[51].ToString(),
                        WHTAMT2 = reader[52].ToString(),
                        Name1 = reader[53].ToString(),
                        Name2 = reader[54].ToString(),
                        Name3 = reader[55].ToString(),
                        Name4 = reader[56].ToString(),
                        Street = reader[57].ToString(),
                        City = reader[58].ToString(),
                        PostalCode = reader[59].ToString(),
                        CountryKey = reader[60].ToString(),
                        TaxNumber1 = reader[61].ToString(),
                        TaxNumber2 = reader[62].ToString(),
                        BankKey = reader[63].ToString(),
                        BankCountryKey = reader[64].ToString(),
                        BankAccount = reader[65].ToString(),
                        TransactionType = reader[66].ToString(),
                        TaxAmount = reader[67].ToString(),
                        WithholdingTaxType1 = reader[68].ToString(),
                        WithholdingTaxType2 = reader[69].ToString(),
                        TaxNumber3 = reader[70].ToString(),
                        ReferenceKey3 = reader[71].ToString()
                    };
                    dataList.Add(dataLine);
                }
            }

            connection.Close();

            return dataList;
        }

        public decimal GetWithHoldingTaxValueFromDB(string whtcode)
        {
            decimal withHoldingTaxValue = 0;

            SqlConnection connection = new SqlConnection(DB_CONNECTION);
            SqlCommand cmd = new SqlCommand();

            connection.Open();

            cmd.Connection = connection;
            cmd.CommandText = string.Format(BTS2SAPConstances.FIND_WITHHOLDINGTAX_VALUE_BY_CODE, whtcode);
            cmd.CommandType = CommandType.Text;

            cmd.ExecuteNonQuery();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    withHoldingTaxValue = reader.GetDecimal(0);
                }
            }

            connection.Close();

            return withHoldingTaxValue;
        }

        // Remove item which have "AmountInDocumentCurrency" equal to "0" & Re order data in each group to get "NETAMT" line to first order in the group
        public void RemoveAmtInDocCurrencyIsZeroData(ref List<List<BTS2SAPModel>> transactionList)
        {
            foreach (List<BTS2SAPModel> transactionLineList in transactionList)
            {
                int zeroValue = 0;
                //List<BTS2SAPModel> removeDataList = new List<BTS2SAPModel>();
                //removeDataList = transactionLineList.Where(x => !x.MiscItemCode.Equals("NETAMT") && x.AmountInDocumentCurrency.Equals("0")).ToList();

                transactionLineList.RemoveAll(x => !x.MiscItemCode.Equals("NETAMT") && x.AmountInDocumentCurrency.Equals(zeroValue.ToString("F")));

                //ReOrderSAPCSVTransaction(ref transactionLineList);

                // Re order to get "NETAMT" line in the first line of each transaction item group
                BTS2SAPModel netAMTItem = transactionLineList.Where(x => x.MiscItemCode.Equals("NETAMT")).FirstOrDefault();

                transactionLineList.Remove(netAMTItem);

                transactionLineList.Insert(0, netAMTItem);
            }
        }

        //private void ReOrderSAPCSVTransaction(ref List<BTS2SAPModel> transactionLineList)
        //{
        //    BTS2SAPModel netAMTItem = transactionLineList.Where(x => x.MiscItemCode.Equals("NETAMT")).FirstOrDefault();

        //    transactionLineList.Remove(netAMTItem);

        //    transactionLineList.Insert(0, netAMTItem);
        //}

        #region Get SAP Mapping Code from DB
        public string GetInsuranceCompanySAPCodeFromDB(string companyCode, string insuranceCompanyCode)
        {
            if (string.IsNullOrEmpty(insuranceCompanyCode))
            {
                throw new Exception("ไม่พบรหัสบัญชี ลูกค้า : " + insuranceCompanyCode);
            }

            string insuranceCompanySAPCode = string.Empty;
            string insuranceCompanyEngName = string.Empty;

            SqlConnection connection = new SqlConnection(DB_CONNECTION);
            SqlCommand cmd = new SqlCommand();

            connection.Open();

            cmd.Connection = connection;
            cmd.CommandText = string.Format(BTS2SAPConstances.FIND_INSURANCE_COMPANY_SAP_CODE, companyCode, insuranceCompanyCode);
            cmd.CommandType = CommandType.Text;

            cmd.ExecuteNonQuery();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    insuranceCompanySAPCode = reader[0].ToString();
                }
            }

            connection.Close();

            if (string.IsNullOrEmpty(insuranceCompanySAPCode.Trim()))
            {
                throw new Exception("ไม่พบรหัสบัญชี ลูกค้า : " + insuranceCompanyEngName);
            }

            return insuranceCompanySAPCode;
        }

        public string GetGarageSAPCodeFromDB(string companyCode, string garageCompanyCode, string expenseCode)
        {
            if (string.IsNullOrEmpty(expenseCode))
            {
                throw new Exception("ไม่พบรหัสบัญชี ลูกค้า : " + expenseCode);
            }

            string garageCompanySAPCode = string.Empty;
            string garageCompanyEngName = string.Empty;

            SqlConnection connection = new SqlConnection(DB_CONNECTION);
            SqlCommand cmd = new SqlCommand();

            connection.Open();

            cmd.Connection = connection;
            cmd.CommandText = string.Format(BTS2SAPConstances.FIND_GARAGE_COMPANY_SAP_CODE, companyCode, garageCompanyCode, expenseCode);
            cmd.CommandType = CommandType.Text;

            cmd.ExecuteNonQuery();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    garageCompanySAPCode = reader[0].ToString();
                    garageCompanyEngName = reader[1].ToString();
                }
            }

            connection.Close();

            if (string.IsNullOrEmpty(garageCompanySAPCode.Trim()))
            {
                throw new Exception("ไม่พบรหัสบัญชี ลูกค้า : " + garageCompanyEngName);
            }

            return garageCompanySAPCode;
        }

        //Napat C.
        public string GetCustomerSAPCodeFromDB(string customerCode)
        {
            if (string.IsNullOrEmpty(customerCode))
            {
                throw new Exception("ไม่พบรหัสบัญชี ลูกค้า : " + customerCode);
            }

            string customerSAPCode = string.Empty;

            SqlConnection connection = new SqlConnection(DB_CONNECTION);
            SqlCommand cmd = new SqlCommand();

            connection.Open();

            cmd.Connection = connection;
            cmd.CommandText = string.Format(BTS2SAPConstances.FIND_CUSTOMER_SAP_CODE, customerCode);
            cmd.CommandType = CommandType.Text;

            cmd.ExecuteNonQuery();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int sapCodeCheck = reader.GetOrdinal("SAP_Code");
                    customerSAPCode = reader.IsDBNull(sapCodeCheck) ? "" : reader.GetString(0).ToString().Trim();
                }
            }

            connection.Close();

            return customerSAPCode;
        }

        public string GetHospitalSAPCodeFromDB(string hospitalCode)
        {
            if (string.IsNullOrEmpty(hospitalCode))
            {
                throw new Exception("ไม่พบรหัสบัญชี ลูกค้า : " + hospitalCode);
            }

            string hospitalSAPCode = string.Empty;
            string hospitalEngName = string.Empty;

            SqlConnection connection = new SqlConnection(DB_CONNECTION);
            SqlCommand cmd = new SqlCommand();

            connection.Open();

            cmd.Connection = connection;
            cmd.CommandText = string.Format(BTS2SAPConstances.FIND_HOSPITAL_SAP_CODE, hospitalCode);
            cmd.CommandType = CommandType.Text;

            cmd.ExecuteNonQuery();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    hospitalSAPCode = reader[0].ToString();
                    hospitalEngName = reader[1].ToString();
                }
            }

            connection.Close();

            if (string.IsNullOrEmpty(hospitalSAPCode.Trim()))
            {
                throw new Exception("ไม่พบรหัสบัญชี ลูกค้า : " + hospitalEngName);
            }

            return hospitalSAPCode;
        }
        #endregion

        public bool createCSV(string fileName, List<List<BTS2SAPModel>> datalist)
        {
            bool result = false;

            using (StreamWriter writeSm = new StreamWriter(fileName))
            {
                writeSm.Flush();

                // Write Header
                writeSm.WriteLine(BTS2SAPConstances.CSV_HEADER);

                // Write Details
                foreach (List<BTS2SAPModel> item in datalist)
                {
                    foreach (BTS2SAPModel line in item)
                    {
                        string sth = line.ToString();
                        writeSm.WriteLine(line);
                        result = true;
                    }
                }

                writeSm.Close();
            }

            return result;
        }

        public string createXLSX(string fileName, List<List<BTS2SAPModel>> detailList)
        {
            string currDir = System.IO.Directory.GetCurrentDirectory();
            //string reportTemplatePath = currDir + "\\Template\\SAP_Interface_Template.xlsx";
            string reportTemplatePath = currDir + "\\Template\\SAP_Interface_Template.xlsx";

            bool isExists = File.Exists(reportTemplatePath);

            if (!isExists)
            {
                throw new Exception("Cannot find Excel Template File.");
            }

            //fileName = string.Concat(currDir, "\\", fileName);
            string reportFileName = string.Concat(BTS2SAPConstances.SAP_XLSX_REPORT_PATH, fileName);

            isExists = System.IO.Directory.Exists(BTS2SAPConstances.SAP_XLSX_REPORT_PATH);

            if (!isExists)
            {
                System.IO.Directory.CreateDirectory(BTS2SAPConstances.SAP_XLSX_REPORT_PATH);
            }

            // Find total Row to write in excel
            int totalRows = 0;

            foreach (List<BTS2SAPModel> sublist in detailList)
            {
                totalRows += sublist.Count;
            }

            // prepare 2d array data before painting to Excel
            string[,] reportData = new string[totalRows, BTS2SAPConstances.SAP_XLSX_COLUMN];

            ConvertBTS2SAPModel2Array(detailList, ref reportData);

            Excel.Application excelApp = new Excel.Application();

            try
            {
                // Write to Excel File
                Excel.Worksheet workSheet = (Excel.Worksheet)excelApp.Workbooks.Open(reportTemplatePath,
                                                                                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                                                                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                                                                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                                                                    Type.Missing, Type.Missing).ActiveSheet;

                excelApp.Visible = false;

                // Excel Row&Col start with [1,1]
                int iCol = 1;
                int iRow = 2;

                // Insert value
                var startRange = workSheet.Cells[iRow, iCol];
                var endRange = workSheet.Cells[totalRows + 1, BTS2SAPConstances.SAP_XLSX_COLUMN];   // Row +1 because excel start at 1
                Excel.Range selectRange = (Excel.Range)excelApp.get_Range(startRange, endRange);

                // Paste data value to excel
                selectRange.Value2 = reportData;

                // Autofit Cell
                selectRange = workSheet.UsedRange;

                selectRange.Columns.AutoFit();

                //Save & Exit
                //workSheet.SaveAs(fileName, XlFileFormat.xlOpenXMLWorkbook, Type.Missing, Type.Missing, true, false, Excel.XlSaveAsAccessMode.xlNoChange, Excel.XlSaveConflictResolution.xlLocalSessionChanges, Type.Missing, Type.Missing);
                workSheet.SaveAs(reportFileName, XlFileFormat.xlOpenXMLWorkbook, Type.Missing, Type.Missing, true, false, Excel.XlSaveAsAccessMode.xlNoChange, Excel.XlSaveConflictResolution.xlLocalSessionChanges, Type.Missing, Type.Missing);
            }
            catch (Exception ex)
            {
                throw ex;
                //errorList.AddMessageLine(ex);
            }
            finally
            {
                excelApp.Workbooks.Close();
                excelApp.Quit();

                ExcelUtil.KillExcelProcess(excelApp);
            }

            return fileName;
        }

        //private void ConvertBTS2SAPModel2Array(List<BTS2SAPModel> detailItems, ref string[,] reportData, ref int lastRowIndex)
        private void ConvertBTS2SAPModel2Array(List<List<BTS2SAPModel>> detailList, ref string[,] reportData)
        {
            int lastRowIndex = 0;

            for (int i = 0; i < detailList.Count(); i++)
            {
                for (int j = 0; j < detailList[i].Count(); j++)
                {
                    reportData[lastRowIndex, 0] = detailList[i][j].Doc;
                    reportData[lastRowIndex, 1] = detailList[i][j].CompanyCode;
                    reportData[lastRowIndex, 2] = detailList[i][j].DocumentType;
                    reportData[lastRowIndex, 3] = detailList[i][j].DocumentDate;
                    reportData[lastRowIndex, 4] = detailList[i][j].PostingDate;
                    reportData[lastRowIndex, 5] = detailList[i][j].PostingPeriod;
                    reportData[lastRowIndex, 6] = detailList[i][j].Currency;
                    reportData[lastRowIndex, 7] = detailList[i][j].ExchangeRate;
                    reportData[lastRowIndex, 8] = detailList[i][j].Reference;
                    reportData[lastRowIndex, 9] = detailList[i][j].DocHeaderText;
                    reportData[lastRowIndex, 10] = detailList[i][j].Branch;
                    reportData[lastRowIndex, 11] = detailList[i][j].TransactionDate;
                    reportData[lastRowIndex, 12] = detailList[i][j].PostingKey;
                    reportData[lastRowIndex, 13] = detailList[i][j].Account;
                    reportData[lastRowIndex, 14] = detailList[i][j].SpGl;
                    reportData[lastRowIndex, 15] = detailList[i][j].AlternativeGLAccount;
                    reportData[lastRowIndex, 16] = detailList[i][j].AmountInDocumentCurrency;
                    reportData[lastRowIndex, 17] = detailList[i][j].AmountInLocalCurrency;
                    reportData[lastRowIndex, 18] = detailList[i][j].CalcTax;
                    reportData[lastRowIndex, 19] = detailList[i][j].TaxCode;
                    reportData[lastRowIndex, 20] = detailList[i][j].BusinessPlace;
                    reportData[lastRowIndex, 21] = detailList[i][j].TaxBaseAmount;
                    reportData[lastRowIndex, 22] = detailList[i][j].DetermineTaxBase;
                    reportData[lastRowIndex, 23] = detailList[i][j].PmtTerms;
                    reportData[lastRowIndex, 24] = detailList[i][j].BaselineDate;
                    reportData[lastRowIndex, 25] = detailList[i][j].PaymentMethod;
                    reportData[lastRowIndex, 26] = detailList[i][j].PaymentBlock;
                    reportData[lastRowIndex, 27] = detailList[i][j].InvoiceReference;
                    reportData[lastRowIndex, 28] = detailList[i][j].IndicatorIndividualPayee;
                    reportData[lastRowIndex, 29] = detailList[i][j].Assignment;
                    reportData[lastRowIndex, 30] = ((detailList[i][j].ItemText.Length > BTS2SAPConstances.SAP_CSV_ITEM_TEXT_MAX_LENGTH) ? detailList[i][j].ItemText.Substring(0, BTS2SAPConstances.SAP_CSV_ITEM_TEXT_MAX_LENGTH) : detailList[i][j].ItemText);
                    reportData[lastRowIndex, 31] = detailList[i][j].RefKey1;
                    reportData[lastRowIndex, 32] = detailList[i][j].RefKey2;
                    reportData[lastRowIndex, 33] = detailList[i][j].BusinessArea;
                    reportData[lastRowIndex, 34] = detailList[i][j].CostCenter;
                    reportData[lastRowIndex, 35] = detailList[i][j].ProfitCenter;
                    reportData[lastRowIndex, 36] = detailList[i][j].InternalOrder;
                    reportData[lastRowIndex, 37] = detailList[i][j].TradingPartner;
                    reportData[lastRowIndex, 38] = detailList[i][j].ValueDate;
                    reportData[lastRowIndex, 39] = detailList[i][j].AssignmentPA;
                    reportData[lastRowIndex, 40] = detailList[i][j].PAMaterialGroup;
                    reportData[lastRowIndex, 41] = detailList[i][j].PASalesGroup;
                    reportData[lastRowIndex, 42] = detailList[i][j].PADivision;
                    reportData[lastRowIndex, 43] = detailList[i][j].PACostCenter;
                    reportData[lastRowIndex, 44] = detailList[i][j].PASalesOffice;
                    reportData[lastRowIndex, 45] = detailList[i][j].WHTCode1;
                    reportData[lastRowIndex, 46] = detailList[i][j].WHTBase1;
                    reportData[lastRowIndex, 47] = detailList[i][j].WHTAMT1;
                    reportData[lastRowIndex, 48] = detailList[i][j].WHTCode2;
                    reportData[lastRowIndex, 49] = detailList[i][j].WHTBase2;
                    reportData[lastRowIndex, 50] = detailList[i][j].WHTAMT2;
                    reportData[lastRowIndex, 51] = detailList[i][j].Name1;
                    reportData[lastRowIndex, 52] = detailList[i][j].Name2;
                    reportData[lastRowIndex, 53] = detailList[i][j].Name3;
                    reportData[lastRowIndex, 54] = detailList[i][j].Name4;
                    reportData[lastRowIndex, 55] = detailList[i][j].Street;
                    reportData[lastRowIndex, 56] = detailList[i][j].City;
                    reportData[lastRowIndex, 57] = detailList[i][j].PostalCode;
                    reportData[lastRowIndex, 58] = detailList[i][j].CountryKey;
                    reportData[lastRowIndex, 59] = detailList[i][j].TaxNumber1;
                    reportData[lastRowIndex, 60] = detailList[i][j].TaxNumber2;
                    reportData[lastRowIndex, 61] = detailList[i][j].BankKey;
                    reportData[lastRowIndex, 62] = detailList[i][j].BankCountryKey;
                    reportData[lastRowIndex, 63] = detailList[i][j].BankAccount;
                    reportData[lastRowIndex, 64] = detailList[i][j].TransactionType;
                    reportData[lastRowIndex, 65] = detailList[i][j].TaxAmount;
                    reportData[lastRowIndex, 66] = detailList[i][j].WithholdingTaxType1;
                    reportData[lastRowIndex, 67] = detailList[i][j].WithholdingTaxType2;
                    reportData[lastRowIndex, 68] = detailList[i][j].TaxNumber3;
                    reportData[lastRowIndex, 69] = detailList[i][j].ReferenceKey3;

                    lastRowIndex++;
                }
            }
        }

        public void SaveDataToTRSAPTransaction(List<List<BTS2SAPModel>> datalist)
        {
            SqlConnection connection = new SqlConnection(DB_CONNECTION);
            connection.Open();

            SqlCommand cmd = new SqlCommand();

            try
            {
                Guid persistenceId = Guid.NewGuid();

                foreach (List<BTS2SAPModel> item in datalist)
                {
                    foreach (BTS2SAPModel line in item)
                    {
                        line.PersistenceId = persistenceId.ToString(); //Generate Unique Key in table

                        cmd.Connection = connection;
                        cmd.CommandText = string.Format(BTS2SAPConstances.INSERT_TR_SAP_TEMPLATE_QUERY_CMD, line.ToInsertSQLValues());
                        cmd.CommandType = CommandType.Text;

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.CommandText = null;
                connection.Close();
            }
        }

        // Kriangkrai Not use because back to use old framework to do cancelation
        //public void CancelConnect2SAP(string referenceKey)
        //{
        //    SqlConnection connection = new SqlConnection(DB_CONNECTION);
        //    connection.Open();

        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand();

        //        cmd.Connection = connection;
        //        cmd.CommandText = string.Format(BTS2SAPConstances.CANCEL_CONNECT_TRSAP_QUERY_CMD, UserProfile.UserID.Trim(), referenceKey);
        //        cmd.CommandType = CommandType.Text;

        //        cmd.ExecuteNonQuery();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }
        //}
    }
}
