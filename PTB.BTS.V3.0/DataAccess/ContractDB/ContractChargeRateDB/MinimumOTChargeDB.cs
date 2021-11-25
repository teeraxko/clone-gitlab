using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

using DataAccess.CommonDB;

using SystemFramework.AppConfig;
using ictus.Common.Entity;
using PTB.BTS.ContractEntities.ContractChargeRate;

namespace DataAccess.ContractDB.ContractChargeRateDB
{
    public class MinimumOTChargeDB : DataAccessBase
    {
        #region - Constant -
        private const int DRIVER_ONLY_STATUS = 0;
        private const int MIN_OT_HOUR = 1;
        private const int MIN_OT_AMOUNT = 2;
        #endregion

        //		======================== Private Method=========================
        #region - getSQL -
        private string getSQLSelect()
        {
            return "SELECT Driver_Only_Status, Min_OT_Hour, Min_OT_Amount FROM Minimum_OT_Charge ";
        }

        private string getSQLInsert(MinimumOTCharge value, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder("INSERT INTO Minimum_OT_Charge (Company_Code, Driver_Only_Status, Min_OT_Hour, Min_OT_Amount, Process_Date, Process_User) ");
            stringBuilder.Append(" VALUES ( ");

            //Company_Code
            stringBuilder.Append(GetDB(aCompany.CompanyCode));
            stringBuilder.Append(", ");

            //Driver_Only_Status			
            stringBuilder.Append(GetDB(value.DriverOnlyStatus));
            stringBuilder.Append(", ");

            //Min_OT_Hour
            stringBuilder.Append(GetDB(value.MinOTHour));
            stringBuilder.Append(", ");

            //Min_OT_Amount
            stringBuilder.Append(GetDB(value.MinOTAmount));
            stringBuilder.Append(", ");

            //Process_Date
            stringBuilder.Append(GetDateDB());
            stringBuilder.Append(", ");

            //Process_User
            stringBuilder.Append(GetDB(UserProfile.UserID));
            stringBuilder.Append(")");

            return stringBuilder.ToString();
        }

        private string getSQLUpdate(MinimumOTCharge value, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder("UPDATE Minimum_OT_Charge SET ");
            stringBuilder.Append("Company_Code = ");
            stringBuilder.Append(GetDB(aCompany.CompanyCode));
            stringBuilder.Append(", ");

            stringBuilder.Append("Driver_Only_Status = ");
            stringBuilder.Append(GetDB(value.DriverOnlyStatus));
            stringBuilder.Append(", ");

            stringBuilder.Append("Min_OT_Hour = ");
            stringBuilder.Append(GetDB(value.MinOTHour));
            stringBuilder.Append(", ");

            stringBuilder.Append("Min_OT_Amount = ");
            stringBuilder.Append(GetDB(value.MinOTAmount));
            stringBuilder.Append(", ");

            stringBuilder.Append("Process_Date = ");
            stringBuilder.Append(GetDateDB());
            stringBuilder.Append(", ");

            stringBuilder.Append("Process_User = ");
            stringBuilder.Append(GetDB(UserProfile.UserID));

            return stringBuilder.ToString();
        }

        private string getSQLDelete()
        {
            return " DELETE FROM Minimum_OT_Charge ";
        }

        private string getKeyCondition(MinimumOTCharge value)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append(" AND (Driver_Only_Status = ");
            stringBuilder.Append(GetDB(value.DriverOnlyStatus));
            stringBuilder.Append(")");

            return stringBuilder.ToString();
        }
        #endregion

        #region - Fill -
        private void fillMinimumOTCharge(MinimumOTCharge value, SqlDataReader dataReader)
        {
            value.DriverOnlyStatus = GetBool((string)dataReader[DRIVER_ONLY_STATUS]);
            value.MinOTHour = dataReader.GetInt16(MIN_OT_HOUR);
            value.MinOTAmount = dataReader.GetDecimal(MIN_OT_AMOUNT);
        }

        private bool fillMinimumOTChargeList(MinimumOTChargeList value, string sql)
        {
            bool result = false;
            MinimumOTCharge minimumOTCharge;

            SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
            try
            {
                while (dataReader.Read())
                {
                    result = true;
                    minimumOTCharge = new MinimumOTCharge();
                    fillMinimumOTCharge(minimumOTCharge, dataReader);
                    value.Add(minimumOTCharge);
                }
                minimumOTCharge = null;
            }
            catch (IndexOutOfRangeException ein)
            { throw ein; }

            finally
            { tableAccess.CloseDataReader(); }
            return result;
        }

        private bool fillMinimumOTCharge(MinimumOTCharge value, string sql)
        {
            bool result;
            SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
            try
            {
                if (dataReader.Read())
                {
                    fillMinimumOTCharge(value, dataReader);
                    result = true;
                }
                else
                { result = false; }
            }
            catch (IndexOutOfRangeException ein)
            { throw ein; }

            finally
            { tableAccess.CloseDataReader(); }
            return result;
        }
        #endregion

        //============================== Public Method ==============================
        public bool FillMinimumOTCharge(MinimumOTCharge value, Company company)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(company));
            stringBuilder.Append(getKeyCondition(value));

            return fillMinimumOTCharge(value, stringBuilder.ToString());
        }

        public bool FillMinimumOTChargeList(MinimumOTChargeList value)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(value.Company));

            return fillMinimumOTChargeList(value , stringBuilder.ToString());
        }

        public bool InsertMinimumOTCharge(MinimumOTCharge value, Company aCompany)
        {
            return (tableAccess.ExecuteSQL(getSQLInsert(value, aCompany)) > 0);
        }

        public bool UpdateMinimumOTCharge(MinimumOTCharge value, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value, aCompany));
            stringBuilder.Append(getBaseCondition(aCompany));
            stringBuilder.Append(getKeyCondition(value));

            return (tableAccess.ExecuteSQL(stringBuilder.ToString()) > 0);
        }

        public bool DeleteMinimumOTCharge(MinimumOTCharge value, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
            stringBuilder.Append(getBaseCondition(aCompany));
            stringBuilder.Append(getKeyCondition(value));

            return (tableAccess.ExecuteSQL(stringBuilder.ToString()) > 0);
        }
    }
}
