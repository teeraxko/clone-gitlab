using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.CommonDB;
using Entity.VehicleEntities;
using SystemFramework.AppConfig;
using PTB.BTS.BTS2BizPacEntity;

namespace PTB.BTS.BTS2BizPacDB.BizPacReportDB
{
    public class TrCompulsoryExpenseDB : DataAccessBase
    {
        //============================== Constructor ==============================
        public TrCompulsoryExpenseDB() : base()
        {

        }

        //============================== Private Method ==============================
        private string getSQLInsert(CompulsoryExpense value)
        {
            StringBuilder stringBuilder = new StringBuilder(" INSERT INTO Tr_Compulsory_Expense ( Plate_No, BizPac_Vendor_Code, BizPac_Vendor_Name, BizPac_Reference_No, Policy_No, Tax_Invoice_No, Tax_Invoice_Date, Start_Date, End_Date, Compulsory_Amount, Revenue_Stamp_Fee, VAT_Amount, Total_Amount, Year1_Days, Year1_Amount, Year2_Days, Year2_Amount, Process_Date, Process_User) ");
            stringBuilder.Append(" VALUES ( ");

            //Plate_No
            if (value.AVehicle.PlateStatus == Entity.CommonEntity.PLATE_STATUS.R)
            {
                stringBuilder.Append(GetDB(value.AVehicle.ChassisNo));
                stringBuilder.Append(", ");
            }
            else
            {
                stringBuilder.Append(GetDB(value.AVehicle.PlateNumber));
                stringBuilder.Append(", ");
            }

            //BizPac_Vendor_Code
            stringBuilder.Append(GetDB(value.AInsuranceCompany.Code));
            stringBuilder.Append(", ");

            //BizPac_Vendor_Name
            stringBuilder.Append(GetDB(value.AInsuranceCompany.AName.English));
            stringBuilder.Append(", ");

            //BizPac_Reference_No
            stringBuilder.Append(GetDB(value.BizPacRefNo));
            stringBuilder.Append(", ");

            //Policy_No
            stringBuilder.Append(GetDB(value.PolicyNo));
            stringBuilder.Append(", ");

            //Tax_Invoice_No
            stringBuilder.Append(GetDB(value.TaxInvoiceNo));
            stringBuilder.Append(", ");

            //Tax_Invoice_Date
            stringBuilder.Append(GetDB(value.TaxInvoiceDate));
            stringBuilder.Append(", ");

            //Start_Date
            stringBuilder.Append(GetDB(value.APeriod.From));
            stringBuilder.Append(", ");

            //End_Date
            stringBuilder.Append(GetDB(value.APeriod.To));
            stringBuilder.Append(", ");

            //Compulsory_Amount
            stringBuilder.Append(GetDB(value.PremiumAmount));
            stringBuilder.Append(", ");

            //Revenue_Stamp_Fee
            stringBuilder.Append(GetDB(value.RevenueStampFee));
            stringBuilder.Append(", ");

            //VAT_Amount
            stringBuilder.Append(GetDB(value.VatAmount));
            stringBuilder.Append(", ");

            //Total_Amount
            stringBuilder.Append(GetDB(value.CompulsoryInsuranceAmount));
            stringBuilder.Append(", ");

            //Year1_Days
            stringBuilder.Append(GetDB(value.Year1Days));
            stringBuilder.Append(", ");

            //Year1_Amount
            stringBuilder.Append(GetDB(value.Year1Amount));
            stringBuilder.Append(", ");

            //Year2_Days
            stringBuilder.Append(GetDB(value.Year2Days));
            stringBuilder.Append(", ");

            //Year2_Amount
            stringBuilder.Append(GetDB(value.Year2Amount));
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
            return " DELETE FROM Tr_Compulsory_Expense ";
        }

        //		============================== Public Method ==============================
        public bool InsertTrCompulsoryExpense(BTS2BizPacList compulsoryExpenseList)
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < compulsoryExpenseList.Count; i++)
            {
                stringBuilder.Append(getSQLInsert((CompulsoryExpense)compulsoryExpenseList[i]));
            }

            return (tableAccess.ExecuteSQL(stringBuilder.ToString()) > 0);
        }

        public bool DeleteTrCompulsoryExpense()
        {
            return (tableAccess.ExecuteSQL(getSQLDelete()) > 0);
        }
    }
}
