using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using DataAccess.CommonDB;

using SystemFramework.AppConfig;
using ictus.Common.Entity;
using PTB.BTS.ContractEntities.ContractChargeRate;
using Entity.ContractEntities;

namespace DataAccess.ContractDB.ContractChargeRateDB
{
    public class ChargeRateByContractDB : DataAccessBase
    {
        private ContractDB dbContract;

        #region - Constant -
        private const int CONTRACT_NO = 0;
        private const int OT_A_RATE = 1;
        private const int OT_B_RATE = 2;
        private const int OT_C_RATE = 3;
        private const int BASIC_CHARGE_AMOUNT = 4;
        private const int ABSENCE_DEDUCTION_PER_DAY = 5;
        private const int ONE_DAY_TRIP_RATE_FAR = 6;
        private const int ONE_DAY_TRIP_RATE_NEAR = 7;
        private const int OVERNIGHT_TRIP_RATE = 8;
        private const int TAXI_RATE = 9;
        private const int MIN_LEAVE_DAYS = 10;
        private const int MIN_HOLIDAY_AMOUNT = 11;
        #endregion

        //======================== Constructor =========================
        public ChargeRateByContractDB() : base()
        {
            dbContract = new ContractDB();
        }

        //======================== Private Method=========================
        #region - getSQL -
        private string getSQLSelect()
        {
            return "SELECT Contract_No, OT_A_Rate, OT_B_Rate, OT_C_Rate, Basic_Charge_Amount, Absence_Deduction_Per_Day, One_Day_Trip_Rate_Far, One_Day_Trip_Rate_Near, Overnight_Trip_Rate, Taxi_Rate, Min_Leave_Days, Min_Holiday_Amount FROM Service_Staff_Charge_Rate_By_Contract ";
        }

        private string getSQLInsert(ChargeRateByContract value, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder("INSERT INTO Service_Staff_Charge_Rate_By_Contract (Company_Code, Contract_No, OT_A_Rate, OT_B_Rate, OT_C_Rate, Basic_Charge_Amount, Absence_Deduction_Per_Day, One_Day_Trip_Rate_Far, One_Day_Trip_Rate_Near, Overnight_Trip_Rate, Taxi_Rate, Min_Leave_Days, Min_Holiday_Amount, Process_Date, Process_User) ");
            stringBuilder.Append(" VALUES ( ");

            //Company_Code
            stringBuilder.Append(GetDB(aCompany.CompanyCode));
            stringBuilder.Append(", ");

            //Contract_No
            stringBuilder.Append(GetDB(value.ContractBase.ContractNo.ToString()));
            stringBuilder.Append(", ");

            //OT_A_Rate			
            stringBuilder.Append(GetDB(value.ChargeRate.OTARate));
            stringBuilder.Append(", ");

            //OT_B_Rate
            stringBuilder.Append(GetDB(value.ChargeRate.OTBRate));
            stringBuilder.Append(", ");

            //OT_C_Rate
            stringBuilder.Append(GetDB(value.ChargeRate.OTCRate));
            stringBuilder.Append(", ");

            //Basic_Charge_Amount			
            stringBuilder.Append(GetDB(value.ChargeRate.BasicChargeAmount));
            stringBuilder.Append(", ");

            //Absence_Deduction_Per_Day
            stringBuilder.Append(GetDB(value.ChargeRate.AbsenceDeduction));
            stringBuilder.Append(", ");

            //One_Day_Trip_Rate_Far
            stringBuilder.Append(GetDB(value.ChargeRate.OneDayTripRateFar));
            stringBuilder.Append(", ");

            //One_Day_Trip_Rate_Near			
            stringBuilder.Append(GetDB(value.ChargeRate.OneDayTripRateNear));
            stringBuilder.Append(", ");

            //Overnight_Trip_Rate
            stringBuilder.Append(GetDB(value.ChargeRate.OvernightTripRate));
            stringBuilder.Append(", ");

            //Taxi_Rate
            stringBuilder.Append(GetDB(value.ChargeRate.TaxiRate));
            stringBuilder.Append(", ");

            //Min_Leave_Days
            stringBuilder.Append(GetDB(value.ChargeRate.MinLeaveDays));
            stringBuilder.Append(", ");

            //Min_Holiday_Amount
            stringBuilder.Append(GetDB(value.ChargeRate.MinHolidayAmount));
            stringBuilder.Append(", ");

            //Process_Date
            stringBuilder.Append(GetDateDB());
            stringBuilder.Append(", ");

            //Process_User
            stringBuilder.Append(GetDB(UserProfile.UserID));
            stringBuilder.Append(")");

            return stringBuilder.ToString();
        }

        private string getSQLUpdate(ChargeRateByContract value, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder("UPDATE Service_Staff_Charge_Rate_By_Contract SET ");
            stringBuilder.Append("Company_Code = ");
            stringBuilder.Append(GetDB(aCompany.CompanyCode));
            stringBuilder.Append(", ");

            stringBuilder.Append("Contract_No = ");
            stringBuilder.Append(GetDB(value.ContractBase.ContractNo.ToString()));
            stringBuilder.Append(", ");

            stringBuilder.Append("OT_A_Rate = ");
            stringBuilder.Append(GetDB(value.ChargeRate.OTARate));
            stringBuilder.Append(", ");

            stringBuilder.Append("OT_B_Rate = ");
            stringBuilder.Append(GetDB(value.ChargeRate.OTBRate));
            stringBuilder.Append(", ");

            stringBuilder.Append("OT_C_Rate = ");
            stringBuilder.Append(GetDB(value.ChargeRate.OTCRate));
            stringBuilder.Append(", ");

            stringBuilder.Append("Basic_Charge_Amount = ");
            stringBuilder.Append(GetDB(value.ChargeRate.BasicChargeAmount));
            stringBuilder.Append(", ");

            stringBuilder.Append("Absence_Deduction_Per_Day = ");
            stringBuilder.Append(GetDB(value.ChargeRate.AbsenceDeduction));
            stringBuilder.Append(", ");

            stringBuilder.Append("One_Day_Trip_Rate_Far = ");
            stringBuilder.Append(GetDB(value.ChargeRate.OneDayTripRateFar));
            stringBuilder.Append(", ");

            stringBuilder.Append("One_Day_Trip_Rate_Near = ");
            stringBuilder.Append(GetDB(value.ChargeRate.OneDayTripRateNear));
            stringBuilder.Append(", ");

            stringBuilder.Append("Overnight_Trip_Rate = ");
            stringBuilder.Append(GetDB(value.ChargeRate.OvernightTripRate));
            stringBuilder.Append(", ");

            stringBuilder.Append("Taxi_Rate = ");
            stringBuilder.Append(GetDB(value.ChargeRate.TaxiRate));
            stringBuilder.Append(", ");

            stringBuilder.Append("Min_Leave_Days = ");
            stringBuilder.Append(GetDB(value.ChargeRate.MinLeaveDays));
            stringBuilder.Append(", ");

            stringBuilder.Append("Min_Holiday_Amount = ");
            stringBuilder.Append(GetDB(value.ChargeRate.MinHolidayAmount));
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
            return " DELETE FROM Service_Staff_Charge_Rate_By_Contract ";
        }

        private string getKeyCondition(DocumentNo value)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (value != null)
            {
                if (IsNotNULL(value.Year) && IsNotNULL(value.Month) && IsNotNULL(value.No))
                {
                    stringBuilder.Append(" AND (Contract_No = ");
                    stringBuilder.Append(GetDB(value.ToString()));
                    stringBuilder.Append(")");
                }
                else
                {
                    if (IsNotNULL(value.Year))
                    {
                        stringBuilder.Append(" AND (SUBSTRING(Contract_No, 7, 2) = ");
                        stringBuilder.Append(GetDB(value.Year));
                        stringBuilder.Append(")");
                    }

                    if (IsNotNULL(value.Month))
                    {
                        stringBuilder.Append(" AND (SUBSTRING(Contract_No, 9, 2) = ");
                        stringBuilder.Append(GetDB(value.Month));
                        stringBuilder.Append(")");
                    }

                    if (IsNotNULL(value.No))
                    {
                        stringBuilder.Append(" AND (SUBSTRING(Contract_No, 11, 3) = ");
                        stringBuilder.Append(GetDB(value.No));
                        stringBuilder.Append(")");
                    }
                }
            }
            return stringBuilder.ToString();
        }

        private string getOrderby()
        {
            return " ORDER BY Contract_No ";
        }

        #endregion

        #region - Fill -
        private void fillChargeRateByContract(ChargeRateByContract value, Company company, SqlDataReader dataReader)
        {
            value.ContractBase = dbContract.GetAllContract(new DocumentNo((string)dataReader[CONTRACT_NO]), company);
            value.ChargeRate.OTARate = dataReader.GetDecimal(OT_A_RATE);
            value.ChargeRate.OTBRate = dataReader.GetDecimal(OT_B_RATE);
            value.ChargeRate.OTCRate = dataReader.GetDecimal(OT_C_RATE);
            value.ChargeRate.BasicChargeAmount = dataReader.GetInt16(BASIC_CHARGE_AMOUNT);
            value.ChargeRate.AbsenceDeduction = dataReader.GetInt16(ABSENCE_DEDUCTION_PER_DAY);
            value.ChargeRate.OneDayTripRateFar = dataReader.GetInt16(ONE_DAY_TRIP_RATE_FAR);
            value.ChargeRate.OneDayTripRateNear = dataReader.GetInt16(ONE_DAY_TRIP_RATE_NEAR);
            value.ChargeRate.OvernightTripRate = dataReader.GetInt16(OVERNIGHT_TRIP_RATE);
            value.ChargeRate.TaxiRate = dataReader.GetInt16(TAXI_RATE);
            value.ChargeRate.MinLeaveDays = dataReader.GetByte(MIN_LEAVE_DAYS);
            value.ChargeRate.MinHolidayAmount = dataReader.GetDecimal(MIN_HOLIDAY_AMOUNT);
        }

        private bool fillChargeRateByContractList(ChargeRateByContractList value, string sql)
        {
            bool result = false;
            ChargeRateByContract objCharge;

            SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
            try
            {
                while (dataReader.Read())
                {
                    result = true;
                    objCharge = new ChargeRateByContract();
                    fillChargeRateByContract(objCharge, value.Company, dataReader);
                    value.Add(objCharge);
                }
                objCharge = null;
            }
            catch (IndexOutOfRangeException ein)
            { throw ein; }

            finally
            { tableAccess.CloseDataReader(); }
            return result;
        }

        private bool fillChargeRateByContract(ChargeRateByContract value, Company company, string sql)
        {
            bool result;
            SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
            try
            {
                if (dataReader.Read())
                {
                    fillChargeRateByContract(value, company, dataReader);
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
        public bool FillChargeRateByContractList(ChargeRateByContractList value)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(value.Company));
            stringBuilder.Append(getOrderby());

            return fillChargeRateByContractList(value, stringBuilder.ToString());
        }

        public bool FillChargeRateByContract(ChargeRateByContract value, Company company)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(company));
            stringBuilder.Append(getKeyCondition(value.ContractBase.ContractNo));

            return fillChargeRateByContract(value, company, stringBuilder.ToString());
        }

        public bool InsertChargeRateByContract(ChargeRateByContract value, Company aCompany)
        {
            return (tableAccess.ExecuteSQL(getSQLInsert(value, aCompany)) > 0);
        }

        public bool UpdateChargeRateByContract(ChargeRateByContract value, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value, aCompany));
            stringBuilder.Append(getBaseCondition(aCompany));
            stringBuilder.Append(getKeyCondition(value.ContractBase.ContractNo));

            return (tableAccess.ExecuteSQL(stringBuilder.ToString()) > 0);
        }

        public bool DeleteChargeRateByContract(ChargeRateByContract value, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
            stringBuilder.Append(getBaseCondition(aCompany));
            stringBuilder.Append(getKeyCondition(value.ContractBase.ContractNo));

            return (tableAccess.ExecuteSQL(stringBuilder.ToString()) > 0);
        }

    }
}
