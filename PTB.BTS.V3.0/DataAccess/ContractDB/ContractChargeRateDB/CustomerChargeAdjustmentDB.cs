using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using DataAccess.PiDB;
using DataAccess.CommonDB;

using Entity.ContractEntities;
using ictus.Common.Entity.Time;
using ictus.Common.Entity;
using ictus.PIS.PI.Entity;
using PTB.BTS.ContractEntities.ContractChargeRate;
using SystemFramework.AppConfig;

namespace DataAccess.ContractDB.ContractChargeRateDB
{
    public class CustomerChargeAdjustmentDB : DataAccessBase
    {
        #region - Constant -
        private const int FOR_YEAR = 0;
        private const int FOR_MONTH = 1;
        private const int CONTRACT_NO = 2;
        private const int EMPLOYEE_NO = 3;
        private const int OT_A_HOUR = 4;
        private const int OT_A_AMOUNT = 5;
        private const int OT_B_HOUR = 6;
        private const int OT_B_AMOUNT = 7;
        private const int OT_C_HOUR = 8;
        private const int OT_C_AMOUNT = 9;
        private const int HOLIDAY = 10;
        private const int HOLIDAY_AMOUNT = 11;
        private const int TAXI_TIMES = 12;
        private const int TAXI_AMOUNT = 13;
        private const int ONE_DAY_TRIP_FAR_TIMES = 14;
        private const int ONE_DAY_TRIP_FAR_AMOUNT = 15;
        private const int ONE_DAY_TRIP_NEAR_TIMES = 16;
        private const int ONE_DAY_TRIP_NEAR_AMOUNT = 17;
        private const int OVERNIGHT_TRIP_TIMES = 18;
        private const int OVERNIGHT_TRIP_AMOUNT = 19;
        private const int DEDUCT = 20;
        private const int DEDUCT_AMOUNT = 21;
        private const int SPECIAL_AMOUNT = 22;
        private const int REASON = 23;
        private const int CUSTOMER_DEPARTMENT_CODE = 24;
        #endregion

        #region - Private -
        private EmployeeDB dbEmployee;
        private ContractDB dbContract;
        private CustomerDepartmentDB dbCustomerDepartment;
        #endregion

        #region Constructor
        public CustomerChargeAdjustmentDB()
            : base()
        {
            dbEmployee = new EmployeeDB();
            dbContract = new ContractDB();
            dbCustomerDepartment = new CustomerDepartmentDB();
        } 
        #endregion

        #region Private Method
        #region - getSQL -
        private string getSQLSelect()
        {
            return "SELECT For_Year, For_Month, Contract_No, Employee_No, OT_A_Hour, OT_A_Amount, OT_B_Hour, OT_B_Amount, OT_C_Hour, OT_C_Amount, Holiday, Holiday_Amount, Taxi_Times, Taxi_Amount, One_Day_Trip_Far_Times, One_Day_Trip_Far_Amount, One_Day_Trip_Near_Times, One_Day_Trip_Near_Amount, Overnight_Trip_Times, Overnight_Trip_Amount, Deduct, Deduct_Amount, Special_Amount, Reason, Customer_Department_Code FROM Customer_Charge_Adjustment ";
        }

        private string getSQLInsert(CustomerChargeAdjustment value, Company company)
        {
            StringBuilder stringBuilder = new StringBuilder(" INSERT INTO Customer_Charge_Adjustment (Company_Code, For_Year, For_Month, Contract_No, Employee_No, OT_A_Hour, OT_A_Amount, OT_B_Hour, OT_B_Amount, OT_C_Hour, OT_C_Amount, Holiday, Holiday_Amount, Taxi_Times, Taxi_Amount, One_Day_Trip_Far_Times, One_Day_Trip_Far_Amount, One_Day_Trip_Near_Times, One_Day_Trip_Near_Amount, Overnight_Trip_Times, Overnight_Trip_Amount, Deduct, Deduct_Amount, Special_Amount, Reason, Process_Date, Process_User, Customer_Department_Code) ");
            stringBuilder.Append(" VALUES ( ");
            //Company_Code
            stringBuilder.Append(GetDB(company.CompanyCode));
            stringBuilder.Append(", ");

            //For_Year			
            stringBuilder.Append(GetDB(value.ForYearMonth.Year));
            stringBuilder.Append(", ");

            //For_Month
            stringBuilder.Append(GetDB(value.ForYearMonth.Month));
            stringBuilder.Append(", ");

            //Contract_No
            stringBuilder.Append(GetDB(value.Contract.ContractNo.ToString()));
            stringBuilder.Append(", ");

            //Employee_No
            stringBuilder.Append(GetDB(value.Employee.EmployeeNo));
            stringBuilder.Append(", ");

            //OT_A_Hour
            stringBuilder.Append(value.OTAHour.ToString());
            stringBuilder.Append(", ");

            //OT_A_Amount
            stringBuilder.Append(value.OTAAmount.ToString());
            stringBuilder.Append(", ");

            //OT_B_Hour
            stringBuilder.Append(value.OTBHour.ToString());
            stringBuilder.Append(", ");

            //OT_B_Amount
            stringBuilder.Append(value.OTBAmount.ToString());
            stringBuilder.Append(", ");

            //OT_C_Hour
            stringBuilder.Append(value.OTCHour.ToString());
            stringBuilder.Append(", ");

            //OT_C_Amount
            stringBuilder.Append(value.OTCAmount.ToString());
            stringBuilder.Append(", ");

            //Holiday
            stringBuilder.Append(value.Holiday.ToString());
            stringBuilder.Append(", ");

            //Holiday_Amount
            stringBuilder.Append(value.HolidayAmount.ToString());
            stringBuilder.Append(", ");

            //Taxi_Times
            stringBuilder.Append(value.TaxiTimes.ToString());
            stringBuilder.Append(", ");

            //Taxi_Amount
            stringBuilder.Append(value.TaxiAmount.ToString());
            stringBuilder.Append(", ");

            //One_Day_Trip_Far_Times
            stringBuilder.Append(value.OneDayTripFarTimes.ToString());
            stringBuilder.Append(", ");

            //One_Day_Trip_Far_Amount
            stringBuilder.Append(value.OneDayTripFarAmount.ToString());
            stringBuilder.Append(", ");

            //One_Day_Trip_Near_Times
            stringBuilder.Append(value.OneDayTripNearTimes.ToString());
            stringBuilder.Append(", ");

            //One_Day_Trip_Near_Amount
            stringBuilder.Append(value.OneDayTripNearAmount.ToString());
            stringBuilder.Append(", ");

            //Overnight_Trip_Times
            stringBuilder.Append(value.OvernightTripTimes.ToString());
            stringBuilder.Append(", ");

            //Overnight_Trip_Amount
            stringBuilder.Append(value.OvernightTripAmount.ToString());
            stringBuilder.Append(", ");

            //Deduct
            stringBuilder.Append(value.Deduct.ToString());
            stringBuilder.Append(", ");

            //Deduct_Amount
            stringBuilder.Append(value.DeductAmount.ToString());
            stringBuilder.Append(", ");

            //Special_Amount
            stringBuilder.Append(value.OtherAmount.ToString());
            stringBuilder.Append(", ");

            //Reason
            stringBuilder.Append(GetDB(value.Reason));
            stringBuilder.Append(", ");

            //Process_Date
            stringBuilder.Append(GetDateDB());
            stringBuilder.Append(", ");

            //Process_User
            stringBuilder.Append(GetDB(UserProfile.UserID));
            stringBuilder.Append(", ");

            //Customer_Department_Code
            stringBuilder.Append(GetDB(value.AssignDepartment.Code));
            stringBuilder.Append(")");

            return stringBuilder.ToString();
        }

        private string getSQLUpdate(CustomerChargeAdjustment value, Company company)
        {
            StringBuilder stringBuilder = new StringBuilder("UPDATE Customer_Charge_Adjustment SET ");
            stringBuilder.Append("Company_Code = ");
            stringBuilder.Append(GetDB(company.CompanyCode));
            stringBuilder.Append(", ");

            stringBuilder.Append("For_Year = ");
            stringBuilder.Append(GetDB(value.ForYearMonth.Year));
            stringBuilder.Append(", ");

            stringBuilder.Append("For_Month = ");
            stringBuilder.Append(GetDB(value.ForYearMonth.Month));
            stringBuilder.Append(", ");

            stringBuilder.Append("Contract_No = ");
            stringBuilder.Append(GetDB(value.Contract.ContractNo.ToString()));
            stringBuilder.Append(", ");

            stringBuilder.Append("Employee_No = ");
            stringBuilder.Append(GetDB(value.Employee.EmployeeNo));
            stringBuilder.Append(", ");

            stringBuilder.Append("OT_A_Hour = ");
            stringBuilder.Append(value.OTAHour.ToString());
            stringBuilder.Append(", ");

            stringBuilder.Append("OT_A_Amount = ");
            stringBuilder.Append(value.OTAAmount.ToString());
            stringBuilder.Append(", ");

            stringBuilder.Append("OT_B_Hour = ");
            stringBuilder.Append(value.OTBHour.ToString());
            stringBuilder.Append(", ");

            stringBuilder.Append("OT_B_Amount = ");
            stringBuilder.Append(value.OTBAmount.ToString());
            stringBuilder.Append(", ");

            stringBuilder.Append("OT_C_Hour = ");
            stringBuilder.Append(value.OTCHour.ToString());
            stringBuilder.Append(", ");

            stringBuilder.Append("OT_C_Amount = ");
            stringBuilder.Append(value.OTCAmount.ToString());
            stringBuilder.Append(", ");

            stringBuilder.Append("Holiday = ");
            stringBuilder.Append(value.Holiday.ToString());
            stringBuilder.Append(", ");

            stringBuilder.Append("Holiday_Amount = ");
            stringBuilder.Append(value.HolidayAmount.ToString());
            stringBuilder.Append(", ");

            stringBuilder.Append("Taxi_Times = ");
            stringBuilder.Append(value.TaxiTimes.ToString());
            stringBuilder.Append(", ");

            stringBuilder.Append("Taxi_Amount = ");
            stringBuilder.Append(value.TaxiAmount.ToString());
            stringBuilder.Append(", ");

            stringBuilder.Append("One_Day_Trip_Far_Times = ");
            stringBuilder.Append(value.OneDayTripFarTimes.ToString());
            stringBuilder.Append(", ");

            stringBuilder.Append("One_Day_Trip_Far_Amount = ");
            stringBuilder.Append(value.OneDayTripFarAmount.ToString());
            stringBuilder.Append(", ");

            stringBuilder.Append("One_Day_Trip_Near_Times = ");
            stringBuilder.Append(value.OneDayTripNearTimes.ToString());
            stringBuilder.Append(", ");

            stringBuilder.Append("One_Day_Trip_Near_Amount = ");
            stringBuilder.Append(value.OneDayTripNearAmount.ToString());
            stringBuilder.Append(", ");

            stringBuilder.Append("Overnight_Trip_Times = ");
            stringBuilder.Append(value.OvernightTripTimes.ToString());
            stringBuilder.Append(", ");

            stringBuilder.Append("Overnight_Trip_Amount = ");
            stringBuilder.Append(value.OvernightTripAmount.ToString());
            stringBuilder.Append(", ");

            stringBuilder.Append("Deduct = ");
            stringBuilder.Append(value.Deduct.ToString());
            stringBuilder.Append(", ");

            stringBuilder.Append("Deduct_Amount = ");
            stringBuilder.Append(value.DeductAmount.ToString());
            stringBuilder.Append(", ");

            stringBuilder.Append("Special_Amount = ");
            stringBuilder.Append(value.OtherAmount.ToString());
            stringBuilder.Append(", ");

            stringBuilder.Append("Reason = ");
            stringBuilder.Append(GetDB(value.Reason));
            stringBuilder.Append(", ");

            stringBuilder.Append("Process_Date = ");
            stringBuilder.Append(GetDateDB());
            stringBuilder.Append(", ");

            stringBuilder.Append("Process_User = ");
            stringBuilder.Append(GetDB(UserProfile.UserID));
            stringBuilder.Append(", ");

            stringBuilder.Append("Customer_Department_Code = ");
            stringBuilder.Append(GetDB(value.AssignDepartment.Code));            

            return stringBuilder.ToString();
        }

        private string getSQLDelete()
        {
            return " DELETE FROM Customer_Charge_Adjustment ";
        }

        private string getKeyCondition(ContractBase value)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (value != null && value.ContractNo != null)
            {
                if (IsNotNULL(value.ContractNo.Year) && IsNotNULL(value.ContractNo.Month) && IsNotNULL(value.ContractNo.No))
                {
                    stringBuilder.Append(" AND (Contract_No = ");
                    stringBuilder.Append(GetDB(value.ContractNo.ToString()));
                    stringBuilder.Append(")");
                }
                else
                {
                    if (IsNotNULL(value.ContractNo.Year))
                    {
                        stringBuilder.Append(" AND (SUBSTRING(Contract_No, 7, 2) = ");
                        stringBuilder.Append(GetDB(value.ContractNo.Year));
                        stringBuilder.Append(")");
                    }

                    if (IsNotNULL(value.ContractNo.Month))
                    {
                        stringBuilder.Append(" AND (SUBSTRING(Contract_No, 9, 2) = ");
                        stringBuilder.Append(GetDB(value.ContractNo.Month));
                        stringBuilder.Append(")");
                    }

                    if (IsNotNULL(value.ContractNo.No))
                    {
                        stringBuilder.Append(" AND (SUBSTRING(Contract_No, 11, 3) = ");
                        stringBuilder.Append(GetDB(value.ContractNo.No));
                        stringBuilder.Append(")");
                    }
                }
            }
            return stringBuilder.ToString();
        }

        private string getKeyCondition(CustomerChargeAdjustment value)
        {
            StringBuilder stringBuilder = new StringBuilder(getKeyCondition(value.Contract));
            stringBuilder.Append(getKeyCondition(value.ForYearMonth));
            stringBuilder.Append(getKeyCondition(value.Employee));
            return stringBuilder.ToString();
        }

        private string getKeyCondition(Employee value)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (value != null && IsNotNULL(value.EmployeeNo))
            {
                stringBuilder.Append(" AND (Employee_No = ");
                stringBuilder.Append(GetDB(value.EmployeeNo));
                stringBuilder.Append(")");
            }
            return stringBuilder.ToString();
        }

        private string getKeyCondition(YearMonth yearMonth)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (IsNotNULL(yearMonth.Year))
            {
                stringBuilder.Append(" AND (For_Year = ");
                stringBuilder.Append(GetDB(yearMonth.Year));
                stringBuilder.Append(")");
            }
            if (IsNotNULL(yearMonth.Month))
            {
                stringBuilder.Append(" AND (For_Month = ");
                stringBuilder.Append(GetDB(yearMonth.Month));
                stringBuilder.Append(")");
            }
            return stringBuilder.ToString();
        }

        private string getSpecialKeyCondition(CustomerDepartment customerDepartment)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (customerDepartment != null && IsNotNULL(customerDepartment.Code))
            {
                stringBuilder.Append(" AND (Customer_Department_Code = ");
                stringBuilder.Append(GetDB(customerDepartment.Code));
                stringBuilder.Append(")");
            }
            return stringBuilder.ToString();
        }

        private string getOrderby()
        {
            return " ORDER BY For_Year, For_Month ";
        }
        #endregion

        #region - Fill -
        private void fillCustomerChargeAdjustment(CustomerChargeAdjustment value, Company company, SqlDataReader dataReader)
        {
            value.ForYearMonth = new YearMonth(dataReader.GetInt16(FOR_YEAR), dataReader.GetByte(FOR_MONTH));
            value.Contract = dbContract.GetAllContract(new DocumentNo((string)dataReader[CONTRACT_NO]), company);
            value.Employee = dbEmployee.GetFormerlyEmployee((string)dataReader[EMPLOYEE_NO], company);
            value.OTAHour = dataReader.GetDecimal(OT_A_HOUR);
            value.OTAAmount = dataReader.GetDecimal(OT_A_AMOUNT);
            value.OTBHour = dataReader.GetDecimal(OT_B_HOUR);
            value.OTBAmount = dataReader.GetDecimal(OT_B_AMOUNT);
            value.OTCHour = dataReader.GetDecimal(OT_C_HOUR);
            value.OTCAmount = dataReader.GetDecimal(OT_C_AMOUNT);
            value.Holiday = dataReader.GetInt16(HOLIDAY);
            value.HolidayAmount = dataReader.GetDecimal(HOLIDAY_AMOUNT);
            value.TaxiTimes = dataReader.GetInt16(TAXI_TIMES);
            value.TaxiAmount = dataReader.GetDecimal(TAXI_AMOUNT);
            value.OneDayTripFarTimes = dataReader.GetInt16(ONE_DAY_TRIP_FAR_TIMES);
            value.OneDayTripFarAmount = dataReader.GetDecimal(ONE_DAY_TRIP_FAR_AMOUNT);
            value.OneDayTripNearTimes = dataReader.GetInt16(ONE_DAY_TRIP_NEAR_TIMES);
            value.OneDayTripNearAmount = dataReader.GetDecimal(ONE_DAY_TRIP_NEAR_AMOUNT);
            value.OvernightTripTimes = dataReader.GetInt16(OVERNIGHT_TRIP_TIMES);
            value.OvernightTripAmount = dataReader.GetDecimal(OVERNIGHT_TRIP_AMOUNT);
            value.Deduct = dataReader.GetDecimal(DEDUCT);
            value.DeductAmount = dataReader.GetDecimal(DEDUCT_AMOUNT);
            value.OtherAmount = dataReader.GetDecimal(SPECIAL_AMOUNT);
            value.Reason = (string)dataReader[REASON];
            value.AssignDepartment = dbCustomerDepartment.GetDBCustomerDepartment((string)dataReader[CUSTOMER_DEPARTMENT_CODE], value.Contract.ACustomer.Code, company);
        }

        private bool fillCustomerChargeAdjustmentList(CustomerChargeAdjustmentList value, string sql)
        {
            bool result = false;
            CustomerChargeAdjustment customerChargeAdjustment;
            SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);

            try
            {
                while (dataReader.Read())
                {
                    result = true;
                    customerChargeAdjustment = new CustomerChargeAdjustment();
                    fillCustomerChargeAdjustment(customerChargeAdjustment, value.Company, dataReader);
                    value.Add(customerChargeAdjustment);
                }
                customerChargeAdjustment = null;
            }
            catch (IndexOutOfRangeException ein)
            { throw ein; }
            finally
            { tableAccess.CloseDataReader(); }
            return result;
        }

        private bool fillCustomerChargeAdjustment(CustomerChargeAdjustment value, Company company, string sql)
        {
            bool result;
            SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
            try
            {
                if (dataReader.Read())
                {
                    fillCustomerChargeAdjustment(value, company, dataReader);
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch (IndexOutOfRangeException ein)
            { throw ein; }
            finally
            { tableAccess.CloseDataReader(); }
            return result;
        }
        #endregion 
        #endregion

        #region Public Method        

        public bool FillCustomerChargeAdjustmentList(CustomerChargeAdjustmentList value, YearMonth yearMonth)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(value.Company));
            stringBuilder.Append(getKeyCondition(yearMonth));
            stringBuilder.Append(getOrderby());

            return fillCustomerChargeAdjustmentList(value, stringBuilder.ToString());
        }

        public bool FillCustomerChargeAdjustmentList(CustomerChargeAdjustmentList value, ContractBase contract, YearMonth yearMonth)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(value.Company));
            stringBuilder.Append(getKeyCondition(contract));
            stringBuilder.Append(getKeyCondition(yearMonth));
            stringBuilder.Append(getOrderby());

            return fillCustomerChargeAdjustmentList(value, stringBuilder.ToString());
        }
        public bool FillCustomerChargeAdjustmentList(CustomerChargeAdjustmentList value, ContractBase contract, YearMonth yearMonth, CustomerDepartment customerDepartment)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(value.Company));
            stringBuilder.Append(getKeyCondition(contract));
            stringBuilder.Append(getKeyCondition(yearMonth));
            stringBuilder.Append(getSpecialKeyCondition(customerDepartment));
            stringBuilder.Append(getOrderby());

            return fillCustomerChargeAdjustmentList(value, stringBuilder.ToString());
        }

        public bool InsertCustomerChargeAdjustment(CustomerChargeAdjustment value, Company company)
        {
            if (tableAccess.ExecuteSQL(getSQLInsert(value, company)) > 0)
            { return true; }
            else
            { return false; }
        }

        public bool UpdateCustomerChargeAdjustment(CustomerChargeAdjustment value, Company company)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value, company));
            stringBuilder.Append(getBaseCondition(company));
            stringBuilder.Append(getKeyCondition(value));
            stringBuilder.Append(getSpecialKeyCondition(value.AssignDepartment));

            return (tableAccess.ExecuteSQL(stringBuilder.ToString()) > 0);
        }

        public bool DeleteCustomerChargeAdjustment(CustomerChargeAdjustment value, Company company)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
            stringBuilder.Append(getBaseCondition(company));
            stringBuilder.Append(getKeyCondition(value));
            stringBuilder.Append(getSpecialKeyCondition(value.AssignDepartment));

            return (tableAccess.ExecuteSQL(stringBuilder.ToString()) > 0);
        } 
        #endregion
    }
}
