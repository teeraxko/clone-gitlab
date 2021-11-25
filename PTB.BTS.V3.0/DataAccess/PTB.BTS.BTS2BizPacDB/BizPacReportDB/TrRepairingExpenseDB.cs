using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.CommonDB;
using PTB.BTS.BTS2BizPacEntity;
using SystemFramework.AppConfig;

namespace PTB.BTS.BTS2BizPacDB.BizPacReportDB
{
    public class TrRepairingExpenseDB : DataAccessBase
    {
        //============================== Constructor ==============================
        public TrRepairingExpenseDB()
            : base()
        {
        }

        //============================== Private Method ==============================
        private string getSQLInsert(RepairingBP value)
        {
            StringBuilder stringBuilder = new StringBuilder(" INSERT INTO Tr_Repairing_Expense ( Repairing_No, BizPac_Vendor_Code, Vendor_Name, BizPac_Expense_Code, BizPac_Expense_Name, BizPac_Reference_No, Plate_No, Tax_Invoice_No, Tax_Invoice_Date, Repairing_Amount, VAT_Amount, Total_Amount, Process_Date, Process_User) ");
            stringBuilder.Append(" VALUES ( ");

            //Repairing_No
            stringBuilder.Append(GetDB(value.RepairingNo));
            stringBuilder.Append(", ");

            //BizPac_Vendor_Code
            stringBuilder.Append(GetDB(value.Garage.BizPacVendorCode));
            stringBuilder.Append(", ");

            //Vendor_Name
            stringBuilder.Append(GetDB(value.Garage.AName.English));
            stringBuilder.Append(", ");

            //BizPac_Expense_Code
            stringBuilder.Append(GetDB(value.Garage.BizPacExpenseCode));
            stringBuilder.Append(", ");

            //BizPac_Expense_Name
            stringBuilder.Append(GetDB(value.Garage.BizPacExpenseName));
            stringBuilder.Append(", ");

            //BizPac_Reference_No
            stringBuilder.Append(GetDB(value.BizPacRefNo));
            stringBuilder.Append(", ");

            //Plate_No
            stringBuilder.Append(GetDB(value.VehicleInfo.PlateNumber));
            stringBuilder.Append(", ");

            //Tax_Invoice_No
            stringBuilder.Append(GetDB(value.TaxInvoiceNo));
            stringBuilder.Append(", ");

            //Tax_Invoice_Date
            stringBuilder.Append(GetDB(value.TaxInvoiceDate));
            stringBuilder.Append(", ");

            //Repairing_Amount
            stringBuilder.Append(GetDB(value.MaintenanceAmount));
            stringBuilder.Append(", ");

            //VAT_Amount
            stringBuilder.Append(GetDB(value.VatAmount));
            stringBuilder.Append(", ");

            //Total_Amount
            stringBuilder.Append(GetDB(value.TotalAmount));
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
            return " DELETE FROM Tr_Repairing_Expense ";
        }

        //============================== Public Method ==============================
        public bool InsertTrRepairingExpense(BTS2BizPacList repairingExpenseList)
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < repairingExpenseList.Count; i++)
            {
                stringBuilder.Append(getSQLInsert((RepairingBP)repairingExpenseList[i]));
            }

            return (tableAccess.ExecuteSQL(stringBuilder.ToString()) > 0);
        }

        public bool DeleteTrRepairingExpense()
        {
            return (tableAccess.ExecuteSQL(getSQLDelete()) > 0);
        }
    }
}
