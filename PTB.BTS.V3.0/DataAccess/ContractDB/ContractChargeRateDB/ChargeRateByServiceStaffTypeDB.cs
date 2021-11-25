using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using DataAccess.CommonDB;

using SystemFramework.AppConfig;
using ictus.Common.Entity;
using PTB.BTS.ContractEntities.ContractChargeRate;

namespace DataAccess.ContractDB.ContractChargeRateDB
{
    public class ChargeRateByServiceStaffTypeDB : DataAccessBase
    {
        private ServiceStaffTypeDB dbServiceStaffType;
        private CustomerDB dbCustomer;

        #region - Constant -
        private const int SERVICE_STAFF_TYPE = 0;
        private const int CUSTOMER_CODE = 1;
        private const int DRIVER_ONLY_STATUS = 2;
        private const int OT_A_RATE = 3;
        private const int OT_B_RATE = 4;
        private const int OT_C_RATE = 5;
        private const int BASIC_CHARGE_AMOUNT = 6;
        private const int ABSENCE_DEDUCTION_PER_DAY = 7;
        private const int ONE_DAY_TRIP_RATE_FAR = 8;
        private const int ONE_DAY_TRIP_RATE_NEAR = 9;
        private const int OVERNIGHT_TRIP_RATE = 10;
        private const int TAXI_RATE = 11;
        private const int MIN_LEAVE_DAYS = 12;
        private const int MIN_HOLIDAY_AMOUNT = 13;
        #endregion

        //======================== Constructor =========================
        public ChargeRateByServiceStaffTypeDB() : base()
        {
            dbCustomer = new CustomerDB();
            dbServiceStaffType = new ServiceStaffTypeDB();
        }

        //======================== Private Method=========================
        #region - getSQL -
        private string getSQLSelect()
        {
            return "SELECT Service_Staff_Type, Customer_Code, Driver_Only_Status, OT_A_Rate, OT_B_Rate, OT_C_Rate, Basic_Charge_Amount, Absence_Deduction_Per_Day, One_Day_Trip_Rate_Far, One_Day_Trip_Rate_Near, Overnight_Trip_Rate, Taxi_Rate, Min_Leave_Days, Min_Holiday_Amount FROM Service_Staff_Charge_Rate ";
        }

        private string getSQLInsert(ChargeRateByServiceStaffType value, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder("INSERT INTO Service_Staff_Charge_Rate (Company_Code, Service_Staff_Type, Customer_Code, Driver_Only_Status, OT_A_Rate, OT_B_Rate, OT_C_Rate, Basic_Charge_Amount, Absence_Deduction_Per_Day, One_Day_Trip_Rate_Far, One_Day_Trip_Rate_Near, Overnight_Trip_Rate, Taxi_Rate, Min_Leave_Days, Min_Holiday_Amount, Process_Date, Process_User) ");
            stringBuilder.Append(" VALUES ( ");

            //Company_Code
            stringBuilder.Append(GetDB(aCompany.CompanyCode));
            stringBuilder.Append(", ");

            //Service_Staff_Type			
            stringBuilder.Append(GetDB(value.ServiceStaffType.Type));
            stringBuilder.Append(", ");

            //Customer_Code
            stringBuilder.Append(GetDB(value.Customer.Code));
            stringBuilder.Append(", ");

            //Driver_Only_Status
            stringBuilder.Append(GetDB(value.DriverOnlyStatus));
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

        private string getSQLUpdate(ChargeRateByServiceStaffType value, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder("UPDATE Service_Staff_Charge_Rate SET ");
            stringBuilder.Append("Company_Code = ");
            stringBuilder.Append(GetDB(aCompany.CompanyCode));
            stringBuilder.Append(", ");

            stringBuilder.Append("Service_Staff_Type = ");
            stringBuilder.Append(GetDB(value.ServiceStaffType.Type));
            stringBuilder.Append(", ");

            stringBuilder.Append("Customer_Code = ");
            stringBuilder.Append(GetDB(value.Customer.Code));
            stringBuilder.Append(", ");

            stringBuilder.Append("Driver_Only_Status = ");
            stringBuilder.Append(GetDB(value.DriverOnlyStatus));
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
            return " DELETE FROM Service_Staff_Charge_Rate ";
        }

        private string getKeyCondition(ChargeRateByServiceStaffType value)
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (value.ServiceStaffType != null && IsNotNULL(value.ServiceStaffType.Type))
            {
                stringBuilder.Append(" AND (Service_Staff_Type = ");
                stringBuilder.Append(GetDB(value.ServiceStaffType.Type));
                stringBuilder.Append(")");
            }
            if (value.Customer != null && IsNotNULL(value.Customer.Code))
            {
                stringBuilder.Append(" AND (Customer_Code = ");
                stringBuilder.Append(GetDB(value.Customer.Code));
                stringBuilder.Append(")");
            }

            stringBuilder.Append(" AND (Driver_Only_Status = ");
            stringBuilder.Append(GetDB(value.DriverOnlyStatus));
            stringBuilder.Append(")");

            return stringBuilder.ToString();
        }

        private string getOrderby()
        {
            return " ORDER BY Service_Staff_Type, Customer_Code, Driver_Only_Status ";
        }
        #endregion

        #region - Fill -
        private void fillChargeRateByServiceStaffType(ChargeRateByServiceStaffType value, Company company, SqlDataReader dataReader)
        {
            value.ServiceStaffType = dbServiceStaffType.GetDBServiceStaffType((string)dataReader[SERVICE_STAFF_TYPE], company);
            value.Customer = dbCustomer.GetDBCustomer((string)dataReader[CUSTOMER_CODE], company);
            value.DriverOnlyStatus = GetBool((string)dataReader[DRIVER_ONLY_STATUS]);
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

        private bool fillChargeRateByServiceStaffTypeList(ChargeRateByServiceStaffTypeList value, string sql)
        {
            bool result = false;
            ChargeRateByServiceStaffType objCharge;

            SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
            try
            {
                while (dataReader.Read())
                {
                    result = true;
                    objCharge = new ChargeRateByServiceStaffType();
                    fillChargeRateByServiceStaffType(objCharge, value.Company, dataReader);
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

        private bool fillChargeRateByServiceStaffType(ChargeRateByServiceStaffType value, Company company, string sql)
        {
            bool result;
            SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
            try
            {
                if (dataReader.Read())
                {
                    fillChargeRateByServiceStaffType(value, company, dataReader);
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
        public bool FillChargeRateByServiceStaffTypeList(ChargeRateByServiceStaffTypeList value)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(value.Company));
            stringBuilder.Append(getOrderby());

            return fillChargeRateByServiceStaffTypeList(value, stringBuilder.ToString());
        }

        public bool FillChargeRateByServiceStaffType(ChargeRateByServiceStaffType value, Company company)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(company));
            stringBuilder.Append(getKeyCondition(value));

            return fillChargeRateByServiceStaffType(value, company, stringBuilder.ToString());
        }

        public bool InsertChargeRateByServiceStaffType(ChargeRateByServiceStaffType value, Company aCompany)
        {
            return (tableAccess.ExecuteSQL(getSQLInsert(value, aCompany)) > 0);
        }

        public bool UpdateChargeRateByServiceStaffType(ChargeRateByServiceStaffType value, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value, aCompany));
            stringBuilder.Append(getBaseCondition(aCompany));
            stringBuilder.Append(getKeyCondition(value));

            return (tableAccess.ExecuteSQL(stringBuilder.ToString()) > 0);
        }

        public bool DeleteChargeRateByServiceStaffType(ChargeRateByServiceStaffType value, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
            stringBuilder.Append(getBaseCondition(aCompany));
            stringBuilder.Append(getKeyCondition(value));

            return (tableAccess.ExecuteSQL(stringBuilder.ToString()) > 0);
        }
    }
}
