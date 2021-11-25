using System;
using System.Collections.Generic;
using System.Text;

using DataAccess.CommonDB;
using Entity.ContractEntities;
using ictus.Common.Entity;
using SystemFramework.AppConfig;
using PTB.BTS.ContractEntities.ContractChargeRate;
using System.Data.SqlClient;

namespace DataAccess.ContractDB.ContractChargeRateDB
{
    public class CustomerSpecialChargeDB : DataAccessBase
    {

        //============================== Constructor ==============================
        public CustomerSpecialChargeDB()
            : base()
        {
        }

        //============================== Private Method ==============================
        #region - getSQL -
        private string getSQLSelect()
        {
            return "SELECT Special_Amount, Telephone_Amount, Customer_Department_Code FROM Customer_Special_Charge ";
        }

        private string getSQLInsert(CustomerSpecialCharge value, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder(" INSERT INTO Customer_Special_Charge (Company_Code, For_Year, For_Month, Contract_No, Employee_No, Special_Amount, Telephone_Amount, Process_Date, Process_User, Customer_Department_Code) ");
            stringBuilder.Append(" VALUES ( ");

            //Company_Code
            stringBuilder.Append(GetDB(aCompany.CompanyCode));
            stringBuilder.Append(", ");

            //For_Year
            stringBuilder.Append(GetDB(value.YearMonth.Year));
            stringBuilder.Append(", ");

            //For_Month
            stringBuilder.Append(GetDB(value.YearMonth.Month));
            stringBuilder.Append(", ");

            //Contract_No
            stringBuilder.Append(GetDB(value.Contract.ContractNo.ToString()));
            stringBuilder.Append(", ");

            //Employee_No
            stringBuilder.Append(GetDB(value.EmployeeNo));
            stringBuilder.Append(", ");

            //Special_Amount
            stringBuilder.Append(GetDB(value.SpecialAmount));
            stringBuilder.Append(", ");

            //Telephone_Amount
            stringBuilder.Append(GetDB(value.TelephoneAmount));
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

        private string getSQLUpdate(CustomerSpecialCharge value, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder("UPDATE Customer_Special_Charge SET ");
            stringBuilder.Append("Company_Code = ");
            stringBuilder.Append(GetDB(aCompany.CompanyCode));
            stringBuilder.Append(", ");

            stringBuilder.Append("For_Year = ");
            stringBuilder.Append(GetDB(value.YearMonth.Year));
            stringBuilder.Append(", ");

            stringBuilder.Append("For_Month = ");
            stringBuilder.Append(GetDB(value.YearMonth.Month));
            stringBuilder.Append(", ");

            stringBuilder.Append("Contract_No = ");
            stringBuilder.Append(GetDB(value.Contract.ContractNo.ToString()));
            stringBuilder.Append(", ");

            stringBuilder.Append("Employee_No = ");
            stringBuilder.Append(GetDB(value.EmployeeNo));
            stringBuilder.Append(", ");

            stringBuilder.Append("Special_Amount = ");
            stringBuilder.Append(GetDB(value.SpecialAmount));
            stringBuilder.Append(", ");

            stringBuilder.Append("Telephone_Amount = ");
            stringBuilder.Append(GetDB(value.TelephoneAmount));
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
            return " DELETE FROM Customer_Special_Charge ";
        }

        private string getKeyCondition(CustomerSpecialCharge value)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (IsNotNULL(value.YearMonth.Year))
            {
                stringBuilder.Append(" AND (For_Year = ");
                stringBuilder.Append(GetDB(value.YearMonth.Year));
                stringBuilder.Append(")");
            }
            if (IsNotNULL(value.YearMonth.Month))
            {
                stringBuilder.Append(" AND (For_Month = ");
                stringBuilder.Append(GetDB(value.YearMonth.Month));
                stringBuilder.Append(")");
            }
            if (value.Contract != null && value.Contract.ContractNo != null && IsNotNULL(value.Contract.ContractNo.ToString()))
            {
                stringBuilder.Append(" AND (Contract_No = ");
                stringBuilder.Append(GetDB(value.Contract.ContractNo.ToString()));
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

        #endregion

        #region - Fill -
        private void fillCustomerSpecialCharge(CustomerSpecialCharge value, SqlDataReader dataReader)
        {
            value.SpecialAmount = dataReader.GetDecimal(0);
            value.TelephoneAmount = dataReader.GetDecimal(1);
        }

        private bool fillCustomerSpecialCharge(CustomerSpecialCharge value, string sql)
        {
            bool result;
            SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
            try
            {
                if (dataReader.Read())
                {
                    fillCustomerSpecialCharge(value, dataReader);
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
        public bool FillCustomerSpecialCharge(CustomerSpecialCharge value, Company company)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(company));
            stringBuilder.Append(getKeyCondition(value));

            return fillCustomerSpecialCharge(value, stringBuilder.ToString());
        }

        public bool FillCustomerSpecialCharge(CustomerSpecialCharge value, Company company, CustomerDepartment customerDepartment)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(company));
            stringBuilder.Append(getKeyCondition(value));
            stringBuilder.Append(getSpecialKeyCondition(customerDepartment));

            return fillCustomerSpecialCharge(value, stringBuilder.ToString());
        }

        public string CommandInsertCustomerSpecialCharge(CustomerSpecialCharge value, Company aCompany)
        {
            return getSQLInsert(value, aCompany);
        }

        public string CommandDeleteCustomerSpecialCharge(CustomerSpecialCharge value, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
            stringBuilder.Append(getBaseCondition(aCompany));
            stringBuilder.Append(getKeyCondition(value));
            stringBuilder.Append(getSpecialKeyCondition(value.AssignDepartment));

            return stringBuilder.ToString();
        }       
    }
}
