using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ictus.Framework.ASC.AppConfig;

namespace PTB.BTS.BTS2SAP
{
    public static class BTS2SAPConstances
    {
        public const int SAP_CSV_ITEM_TEXT_MAX_LENGTH = 50;
        public const int SAP_XLSX_COLUMN = 70;
        public const string FIND_TEMPLATE_QUERY_CMD =  @"select [Transfer_Type]
                                                      ,[MiscItemCode]
                                                      ,[DOC]
                                                      ,[Company_Code]
                                                      ,[Document_Type]
                                                      ,[Document_Date]
                                                      ,[Posting_Date]
                                                      ,[Posting_Period]
                                                      ,[Currency]
                                                      ,[Exchange_Rate]
                                                      ,[Reference]
                                                      ,[Doc_Header_Text]
                                                      ,[Branch]
                                                      ,[Translation_Date]
                                                      ,[Posting_Key]
                                                      ,[Account]
                                                      ,[Sp_GL]
                                                      ,[Alternative_GL_Account]
                                                      ,[Amount_in_Document_Currency]
                                                      ,[Amount_in_Local_Currency]
                                                      ,[Calc_Tax]
                                                      ,[Tax_Code]
                                                      ,[Business_Place]
                                                      ,[Tax_Base_Amount]
                                                      ,[Determine_Tax_Base]
                                                      ,[Pmt_Terms]
                                                      ,[Baseline_Date]
                                                      ,[Payment_Method]
                                                      ,[Payment_Block]
                                                      ,[Invoice_Reference]
                                                      ,[Indicator_Individual_Payee]
                                                      ,[Assignment]
                                                      ,[Item_Text]
                                                      ,[Reference_key_1]
                                                      ,[Reference_key_2]
                                                      ,[Business_Area]
                                                      ,[Cost_Center]
                                                      ,[Profit_Center]
                                                      ,[Internal_Order]
                                                      ,[Trading_Partner]
                                                      ,[Value_Date]
                                                      ,[Assignment_PA]
                                                      ,[PA_Material_Group]
                                                      ,[PA_Sales_Group]
                                                      ,[PA_Division]
                                                      ,[PA_Cost_Center]
                                                      ,[PA_Sales_Office]
                                                      ,[WHT_Code1]
                                                      ,[WHT_Base1]
                                                      ,[WHT_AMT1]
                                                      ,[WHT_Code2]
                                                      ,[WHT_Base2]
                                                      ,[WHT_AMT2]
                                                      ,[Name1]
                                                      ,[Name2]
                                                      ,[Name3]
                                                      ,[Name4]
                                                      ,[Street]
                                                      ,[City]
                                                      ,[PostalCode]
                                                      ,[Country_Key]
                                                      ,[Tax_Number1]
                                                      ,[Tax_Number2]
                                                      ,[Bank_Key]
                                                      ,[Bank_Country_Key]
                                                      ,[Bank_Account]
                                                      ,[Transaction_Type]
                                                      ,[Tax_Amount]
                                                      ,[Withholding_Tax_Type1]
                                                      ,[Withholding_Tax_Type2]
                                                      ,[Tax_Number3]
                                                      ,[Reference_key_3]
                                                from [SAP_Template] where [Transfer_Type] = '{0}'";

        public const string INSERT_TR_SAP_TEMPLATE_QUERY_CMD = @"INSERT INTO [TR_SAP_Transaction]
                                                                         ([Reference_No]
                                                                         ,[Transfer_Type]
                                                                         ,[MiscItemCode]
                                                                         ,[DOC]
                                                                         ,[Company_Code]
                                                                         ,[Document_Type]
                                                                         ,[Document_Date]
                                                                         ,[Posting_Date]
                                                                         ,[Posting_Period]
                                                                         ,[Currency]
                                                                         ,[Exchange_Rate]
                                                                         ,[Reference]
                                                                         ,[Doc_Header_Text]
                                                                         ,[Branch]
                                                                         ,[Translation_Date]
                                                                         ,[Posting_Key]
                                                                         ,[Account]
                                                                         ,[Sp_GL]
                                                                         ,[Alternative_GL_Account]
                                                                         ,[Amount_in_Document_Currency]
                                                                         ,[Amount_in_Local_Currency]
                                                                         ,[Calc_Tax]
                                                                         ,[Tax_Code]
                                                                         ,[Business_Place]
                                                                         ,[Tax_Base_Amount]
                                                                         ,[Determine_Tax_Base]
                                                                         ,[Pmt_Terms]
                                                                         ,[Baseline_Date]
                                                                         ,[Payment_Method]
                                                                         ,[Payment_Block]
                                                                         ,[Invoice_Reference]
                                                                         ,[Indicator_Individual_Payee]
                                                                         ,[Assignment]
                                                                         ,[Item_Text]
                                                                         ,[Reference_key_1]
                                                                         ,[Reference_key_2]
                                                                         ,[Business_Area]
                                                                         ,[Cost_Center]
                                                                         ,[Profit_Center]
                                                                         ,[Internal_Order]
                                                                         ,[Trading_Partner]
                                                                         ,[Value_Date]
                                                                         ,[Assignment_PA]
                                                                         ,[PA_Material_Group]
                                                                         ,[PA_Sales_Group]
                                                                         ,[PA_Division]
                                                                         ,[PA_Cost_Center]
                                                                         ,[PA_Sales_Office]
                                                                         ,[WHT_Code1]
                                                                         ,[WHT_Base1]
                                                                         ,[WHT_AMT1]
                                                                         ,[WHT_Code2]
                                                                         ,[WHT_Base2]
                                                                         ,[WHT_AMT2]
                                                                         ,[Name1]
                                                                         ,[Name2]
                                                                         ,[Name3]
                                                                         ,[Name4]
                                                                         ,[Street]
                                                                         ,[City]
                                                                         ,[PostalCode]
                                                                         ,[Country_Key]
                                                                         ,[Tax_Number1]
                                                                         ,[Tax_Number2]
                                                                         ,[Bank_Key]
                                                                         ,[Bank_Country_Key]
                                                                         ,[Bank_Account]
                                                                         ,[Transaction_Type]
                                                                         ,[Tax_Amount]
                                                                         ,[Withholding_Tax_Type1]
                                                                         ,[Withholding_Tax_Type2]
                                                                         ,[Tax_Number3]
                                                                         ,[Reference_key_3]
                                                                         ,[Process_Date]
                                                                         ,[Process_User]
                                                                         ,[IsDelete]
                                                                         ,[PersistenceId])
                                                             VALUES({0})";

//        public const string CANCEL_CONNECT_TRSAP_QUERY_CMD = @"UPDATE [TR_SAP_Transaction]
//                                                               SET [IsDelete] = 1
//                                                                  ,[Process_Date] = getdate()
//                                                               where [Reference] = '{0}' AND [Process_User] like '%{1}%' AND [IsDelete] = 0" ;

        public const string CANCEL_CONNECT_TRSAP_QUERY_CMD = @"UPDATE [TR_SAP_Transaction]
                                                               SET [IsDelete] = 1
                                                                  ,[Cancel_Date] = getdate()
                                                                  ,[Cancel_User] = '{0}'
                                                               FROM (select [Reference_No] as ref, [PersistenceId] as persistence 
                                                                     from [TR_SAP_Transaction] 
                                                                     where [Reference_No] = '{1}' AND [Process_User]  like '%{0}%' AND [IsDelete] = 0) a
                                                               WHERE  [Reference_No] = a.ref and [PersistenceId] = a.persistence";

        //public const string CSV_HEADER = @"DOC, Company_Code, Document_Type, Document_Date, Posting_Date, Posting_Period, Currency, Exchange_Rate, Reference, Doc_Header_Text, Branch, Translation_Date, Posting_Key, Account, Sp_GL, Alternative_GL_Account, Amount_in_Document_Currency, Amount_in_Local_Currency, Calc_Tax, Tax_Code, Business_Place, Tax_Base_Amount, Determine_Tax_Base, Pmt_Terms, Baseline_Date, Payment_Method, Payment_Block, Invoice_Reference, Indicator_Individual_Payee, Assignment, Item_Text, Reference_key_1, Reference_key_2, Business_Area, Cost_Center, Profit_Center, Internal_Order, Trading_Partner, Value_Date, Assignment_PA,PA_Material_Group, PA_Sales_Group, PA_Division, PA_Cost_Center, PA_Sales_Office, WHT_Code1, WHT_Base1, WHT_AMT1, WHT_Code2, WHT_Base2, WHT_AMT2, Name1, Name2, Name3, Name4, Street, City, PostalCode, Country_Key, Tax_Number1, Tax_Number2, Bank_Key, Bank_Country_Key, Bank_Account, Transaction_Type, Tax_Amount, Withholding_Tax_Type1, Withholding_Tax_Type2, Tax_Number3, Reference_key_3";
        public const string CSV_HEADER = @"DOC,Company_Code,Document_Type,Document_Date,Posting_Date,Posting_Period,Currency,Exchange_Rate,Reference,Doc_Header_Text,Branch,Translation_Date,Posting_Key,Account,Sp_GL,Alternative_GL_Account,Amount_in_Document_Currency,Amount_in_Local_Currency,Calc_Tax,Tax_Code,Business_Place,Tax_Base_Amount,Determine_Tax_Base,Pmt_Terms,Baseline_Date,Payment_Method,Payment_Block,Invoice_Reference,Indicator_Individual_Payee,Assignment,Item_Text,Reference_key_1,Reference_key_2,Business_Area,Cost_Center,Profit_Center,Internal_Order,Trading_Partner,Value_Date,Assignment_PA,PA_Material_Group,PA_Sales_Group,PA_Division,PA_Cost_Center,PA_Sales_Office,WHT_Code1,WHT_Base1,WHT_AMT1,WHT_Code2,WHT_Base2,WHT_AMT2,Name1,Name2,Name3,Name4,Street,City,PostalCode,Country_Key,Tax_Number1,Tax_Number2,Bank_Key,Bank_Country_Key,Bank_Account,Transaction_Type,Tax_Amount,Withholding_Tax_Type1,Withholding_Tax_Type2,Tax_Number3,Reference_key_3";

        public const string FIND_WITHHOLDINGTAX_VALUE_BY_CODE = @"select top 1 WHT_VALUE from [WithHoldingTax] where [WHT_CODE] = '{0}'";

        public const string FIND_INSURANCE_COMPANY_SAP_CODE = @"select top 1 [SAP_Code],[English_Name] from [Insurance_Company] where [Company_Code] = '{0}' and [Insurance_Company_Code] = '{1}'";
        public const string FIND_GARAGE_COMPANY_SAP_CODE = @"select top 1 [SAP_Code],[English_Name] from [Garage] where [Company_Code] = '{0}' and [BizPac_Vendor_Code] = '{1}' and [BizPac_Expense_Code] = '{2}'";
        public const string FIND_CUSTOMER_SAP_CODE = @"select [SAP_Code],[English_Name] from [Customer] where [Customer_Code] = '{0}' ";
        public const string FIND_HOSPITAL_SAP_CODE = @"select top 1 [SAP_Code],[English_Hospital_Name] from [Hospital] where [Hospital_Code] = '{0}'";

        public const string SQL_CASTING_SAP_CSV_2_DATETIME = @"cast(right('{0}', 4)+substring('{0}', 3, 2)+left('{0}', 2) as datetime)";

        public const string SAP_XLSX_REPORT_TEMPLATE = "SAP_Interface_Template.xlsx";

        public const string SAP_XLSX_REPORT_PATH = @"D:\BTS\";
    }
}
