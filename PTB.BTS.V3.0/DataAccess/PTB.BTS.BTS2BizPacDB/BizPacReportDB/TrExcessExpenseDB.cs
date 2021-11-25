using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.CommonDB;
using PTB.BTS.BTS2BizPacEntity;
using SystemFramework.AppConfig;

namespace PTB.BTS.BTS2BizPacDB.BizPacReportDB
{
    public class TrExcessExpenseDB : DataAccessBase
    {
        //============================== Constructor ==============================
        public TrExcessExpenseDB()
            : base()
        {}

        //============================== Private Method ==============================
        private string getSQLInsert(ExcessBP value)
        {
            StringBuilder stringBuilder = new StringBuilder(" INSERT INTO Tr_Excess_Expense ( Repairing_No, BizPac_Vendor_Code, Vendor_Name, BizPac_Reference_No, Plate_No, Insurance_Claim_No, Accident_Date, Insurance_Receipt_No, Insurance_Receipt_Date, Excess_Amount, Remark, Process_Date, Process_User) ");
            stringBuilder.Append(" VALUES ( ");

            //Repairing_No
            stringBuilder.Append(GetDB(value.RepairingNo));
            stringBuilder.Append(", ");

            //BizPac_Vendor_Code
            stringBuilder.Append(GetDB(value.PaidToCode));
            stringBuilder.Append(", ");

            //Vendor_Name
            stringBuilder.Append(GetDB(value.PaidTo));
            stringBuilder.Append(", ");

            //BizPac_Reference_No
            stringBuilder.Append(GetDB(value.BizPacRefNo));
            stringBuilder.Append(", ");

            //Plate_No
            stringBuilder.Append(GetDB(value.VehicleInfo.PlateNumber));
            stringBuilder.Append(", ");

            //Insurance_Claim_No
            stringBuilder.Append(GetDB(value.InsuranceClaimNo));
            stringBuilder.Append(", ");

            //Accident_Date
            stringBuilder.Append(GetDB(value.HappenTime));
            stringBuilder.Append(", ");

            //Insurance_Receipt_No
            stringBuilder.Append(GetDB(value.InsuranceReceiptNo));
            stringBuilder.Append(", ");

            //Insurance_Receipt_Date
            stringBuilder.Append(GetDB(value.InsuranceReceiptDate));
            stringBuilder.Append(", ");

            //Excess_Amount
            stringBuilder.Append(GetDB(value.ActualExcessAmount));
            stringBuilder.Append(", ");

            //Remark
            stringBuilder.Append(GetDB(value.Remark1));
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
            return " DELETE FROM Tr_Excess_Expense ";
        }

        //		============================== Public Method ==============================
        public bool InsertTrExcessExpense(BTS2BizPacList excessExpenseList)
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < excessExpenseList.Count; i++)
            {
                stringBuilder.Append(getSQLInsert((ExcessBP)excessExpenseList[i]));
            }

            return (tableAccess.ExecuteSQL(stringBuilder.ToString()) > 0);
        }

        public bool DeleteTrExcessExpense()
        {
            return (tableAccess.ExecuteSQL(getSQLDelete()) > 0);
        }
    }
}
