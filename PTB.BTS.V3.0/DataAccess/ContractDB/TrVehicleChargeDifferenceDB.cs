using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.CommonDB;
using Entity.ContractEntities;

namespace DataAccess.ContractDB
{
    public class TrVehicleChargeDifferenceDB : DataAccessBase
    {
        #region -Constant-
        private const int VEHICLE_NO = 0;
        private const int CUSTOMER_CODE = 1;
        private const int VEHICLE_DESCRIPTION = 2;
        private const int CHARGE_AMOUNT_PREVIOUS = 3;
        private const int CHARGE_AMOUNT_CURRENT = 4;
        private const int CHARGE_AMOUNT_DIFFERENCE = 5;
        private const int ASSIGNMENT_PREVIOUS_FROM = 6;
        private const int ASSIGNMENT_PREVIOUS_TO = 7;
        private const int ASSIGNMENT_PREVIOUS_COUNT = 8;
        private const int ASSIGNMENT_CURRENT_FROM = 9;
        private const int ASSIGNMENT_CURRENT_TO = 10;
        private const int ASSIGNMENT_CURRENT_COUNT = 11;
        private const int DIFFERENCE_STATUS = 12;
        #endregion

        //		============================== Private Method ==============================
        #region - getSQL -
        private string getSQLSelect()
        {
            return "SELECT  Vehicle_No, Customer_Code, Vehicle_Description, Charge_Amount_Previous, Charge_Amount_Current, Charge_Amount_Difference, Assignment_Previous_From, Assignment_Previous_To, Assignment_Previous_Count, Assignment_Current_From, Assignment_Current_To, Assignment_Current_Count, Difference_Status FROM Tr_Vehicle_Charge_Difference ";
        }

        private string getSQLInsert(VehicleChargeDiff value)
        {
            StringBuilder stringBuilder = new StringBuilder(" INSERT INTO Tr_Vehicle_Charge_Difference (Vehicle_No, Customer_Code, Vehicle_Description, Charge_Amount_Previous, Charge_Amount_Current, Charge_Amount_Difference, Assignment_Previous_From, Assignment_Previous_To, Assignment_Previous_Count, Assignment_Current_From, Assignment_Current_To, Assignment_Current_Count, Difference_Status) ");
            stringBuilder.Append(" VALUES ( ");

            //Vehicle_No
            stringBuilder.Append(GetDB(value.VehicleNo));
            stringBuilder.Append(", ");

            //Customer_Code
            stringBuilder.Append(GetDB(value.CustomerCode));
            stringBuilder.Append(", ");

            //Vehicle_Description
            stringBuilder.Append(GetDB(value.Description));
            stringBuilder.Append(", ");

            //Charge_Amount_Previous
            stringBuilder.Append(GetDB(value.ChargePrevious));
            stringBuilder.Append(", ");

            //Charge_Amount_Current
            stringBuilder.Append(GetDB(value.ChargeCurrent));
            stringBuilder.Append(", ");

            //Charge_Amount_Difference
            stringBuilder.Append(GetDB(value.ChargeDiff));
            stringBuilder.Append(", ");
            
            //Assignment_Previous_From
            stringBuilder.Append(GetDB(value.AssignPrevious.From));
            stringBuilder.Append(", ");

            //Assignment_Previous_To
            stringBuilder.Append(GetDB(value.AssignPrevious.To));
            stringBuilder.Append(", ");

            //Assignment_Previous_Count
            stringBuilder.Append(GetDB(value.AssignmentPreviousCount));
            stringBuilder.Append(", ");

            //Assignment_Current_From
            stringBuilder.Append(GetDB(value.AssignCurrent.From));
            stringBuilder.Append(", ");

            //Assignment_Current_To
            stringBuilder.Append(GetDB(value.AssignCurrent.To));
            stringBuilder.Append(", ");

            //Assignment_Current_Count
            stringBuilder.Append(GetDB(value.AssignmentCurrentCount));
            stringBuilder.Append(", ");

            //Difference_Status
            stringBuilder.Append(GetDB(value.DifferenceStatus));
            stringBuilder.Append(")");

            return stringBuilder.ToString();
        }

        private string getSQLDelete()
        {
            return " DELETE FROM Tr_Vehicle_Charge_Difference ";
        }

        private string getKeyCondition(VehicleChargeDiff value)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (IsNotNULL(value.VehicleNo))
            {
                stringBuilder.Append(" AND (Vehicle_No = ");
                stringBuilder.Append(GetDB(value.VehicleNo));
                stringBuilder.Append(")");
            }
         
            if (IsNotNULL(value.CustomerCode))
            {
                stringBuilder.Append(" AND (Customer_Code = ");
                stringBuilder.Append(GetDB(value.CustomerCode));
                stringBuilder.Append(")");
            }
            return stringBuilder.ToString();
        }

        private string getOrderby()
        {
            return " ORDER BY Customer_Code, Vehicle_Description, Vehicle_No ";
        }
        #endregion

        //============================== Public Method ==============================
        public bool InsertTrVehicleChargeDifference(VehicleChargeDiffList vehicleChargeDiffList)
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < vehicleChargeDiffList.Count; i++)
            {
                stringBuilder.Append(getSQLInsert(vehicleChargeDiffList[i]));
            }

            return (tableAccess.ExecuteSQL(stringBuilder.ToString()) > 0);
        }

        public string CommandInsertTrVehicleChargeDifference(VehicleChargeDiff vehicleChargeDiff)
        {
            return getSQLInsert(vehicleChargeDiff);
        }

        public bool DeleteTrVehicleChargeDifference()
        {
            return (tableAccess.ExecuteSQL(getSQLDelete()) > 0);
        }

        public bool ExecuteCommand(string strCommand)
        {
            return tableAccess.ExecuteSQL(strCommand) > 0;
        }
    }
}
