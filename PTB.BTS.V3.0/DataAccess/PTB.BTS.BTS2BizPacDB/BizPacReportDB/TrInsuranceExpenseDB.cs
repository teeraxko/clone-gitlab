using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.CommonDB;
using SystemFramework.AppConfig;
using PTB.BTS.BTS2BizPacEntity;

namespace PTB.BTS.BTS2BizPacDB.BizPacReportDB
{
    public class TrInsuranceExpenseDB : DataAccessBase
    {
        //============================== Constructor ==============================
        public TrInsuranceExpenseDB()
            : base()
        {}

        //============================== Private Method ==============================
        private string getSQLInsert(InsuranceTypeOneBP value)
        {
            StringBuilder stringBuilder = new StringBuilder(" INSERT INTO Tr_Insurance_Expense ( Policy_No, BizPac_Vendor_Code, BizPac_Vendor_Name, BizPac_Reference_No, Start_Date, End_Date, Tax_Invoice_No, Tax_Invoice_Date, Premiun_Amount, Revenue_Stamp_Fee, VAT_Amount, Total_Amount, Month1_Amount, Month2_Amount, Month3_Amount, Month4_Amount, Month5_Amount, Month6_Amount, Month7_Amount, Month8_Amount, Month9_Amount, Month10_Amount, Month11_Amount, Month12_Amount, Process_Date, Process_User) ");
            stringBuilder.Append(" VALUES ( ");

            //Policy_No
            stringBuilder.Append(GetDB(value.PolicyNo));
            stringBuilder.Append(", ");

            //BizPac_Vendor_Code
            stringBuilder.Append(GetDB(value.AInsuranceCompany.Code));
            stringBuilder.Append(", ");

            //BizPac_Vendor_Name
            stringBuilder.Append(GetDB(value.AInsuranceCompany.AName.English));
            stringBuilder.Append(", ");

            //BizPac_Reference_No
            stringBuilder.Append(GetDB(value.BizPacRefNo));
            stringBuilder.Append(", ");

            //Start_Date
            stringBuilder.Append(GetDB(value.APeriod.From));
            stringBuilder.Append(", ");

            //End_Date
            stringBuilder.Append(GetDB(value.APeriod.To));
            stringBuilder.Append(", ");

            //Tax_Invoice_No
            stringBuilder.Append(GetDB(value.TaxInvoiceNo));
            stringBuilder.Append(", ");

            //Tax_Invoice_Date
            stringBuilder.Append(GetDB(value.TaxInvoiceDate));
            stringBuilder.Append(", ");

            //Premiun_Amount
            stringBuilder.Append(GetDB(value.PremiumAmount));
            stringBuilder.Append(", ");

            //Revenue_Stamp_Fee
            stringBuilder.Append(GetDB(value.RevenueStampFee));
            stringBuilder.Append(", ");

            //VAT_Amount
            stringBuilder.Append(GetDB(value.VatAmount));
            stringBuilder.Append(", ");

            //Total_Amount
            stringBuilder.Append(GetDB(value.Amount));
            stringBuilder.Append(", ");

            //Month1_Amount
            stringBuilder.Append(GetDB(value.Month1Amount));
            stringBuilder.Append(", ");

            //Month2_Amount
            stringBuilder.Append(GetDB(value.Month2Amount));
            stringBuilder.Append(", ");

            //Month3_Amount
            stringBuilder.Append(GetDB(value.Month3Amount));
            stringBuilder.Append(", ");

            //Month4_Amount
            stringBuilder.Append(GetDB(value.Month4Amount));
            stringBuilder.Append(", ");

            //Month5_Amount
            stringBuilder.Append(GetDB(value.Month5Amount));
            stringBuilder.Append(", ");

            //Month6_Amount
            stringBuilder.Append(GetDB(value.Month6Amount));
            stringBuilder.Append(", ");

            //Month7_Amount
            stringBuilder.Append(GetDB(value.Month7Amount));
            stringBuilder.Append(", ");

            //Month8_Amount
            stringBuilder.Append(GetDB(value.Month8Amount));
            stringBuilder.Append(", ");

            //Month9_Amount
            stringBuilder.Append(GetDB(value.Month9Amount));
            stringBuilder.Append(", ");

            //Month10_Amount
            stringBuilder.Append(GetDB(value.Month10Amount));
            stringBuilder.Append(", ");

            //Month11_Amount
            stringBuilder.Append(GetDB(value.Month11Amount));
            stringBuilder.Append(", ");

            //Month12_Amount
            stringBuilder.Append(GetDB(value.Month12Amount));
            stringBuilder.Append(", ");

            //Process_Date
            stringBuilder.Append(GetDateDB());
            stringBuilder.Append(", ");

            //Process_User
            stringBuilder.Append(GetDB(UserProfile.UserID));
            stringBuilder.Append(")");

            return stringBuilder.ToString();
        }

        private string getSQLDelete()
        {
            return " DELETE FROM Tr_Insurance_Expense ";
        }

        //		============================== Public Method ==============================
        public bool InsertTrInsuranceExpense(BTS2BizPacList insuranceExpenseList)
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < insuranceExpenseList.Count; i++)
            {
                stringBuilder.Append(getSQLInsert((InsuranceTypeOneBP)insuranceExpenseList[i]));
            }

            return (tableAccess.ExecuteSQL(stringBuilder.ToString()) > 0);
        }

        public bool DeleteTrInsuranceExpense()
        {
            return (tableAccess.ExecuteSQL(getSQLDelete()) > 0);
        }
    }
}
