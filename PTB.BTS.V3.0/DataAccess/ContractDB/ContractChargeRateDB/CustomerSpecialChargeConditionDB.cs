using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using DataAccess.CommonDB;
using Entity.ContractEntities;
using ictus.Common.Entity;
using SystemFramework.AppConfig;
using PTB.BTS.ContractEntities.ContractChargeRate;

namespace DataAccess.ContractDB.ContractChargeRateDB
{
    public class CustomerSpecialChargeConditionDB : DataAccessBase
    {
        #region - Constant -
        private const int CONTRACT_NO = 0;
        private const int SPECIAL_AMOUNT_PER_PERSON = 1;
        private const int TELEPHONE_AMOUNT_PER_PERSON = 2;
        private const int CUSTOMER_DEPARTMENT_CODE = 3;
        #endregion

        private ContractDB dbContract;
        private CustomerDepartmentDB dbCustomerDepartment;
        //============================== Constructor ==============================
        public CustomerSpecialChargeConditionDB()
            : base()
        {
            dbContract = new ContractDB();
            dbCustomerDepartment = new CustomerDepartmentDB();
        }

        //============================== Private Method ==============================
        #region - getSQL -
        private string getSQLSelect()
        {
            return "SELECT Contract_No, Special_Amount_Per_Person, Telephone_Amount_Per_Person,Customer_Department_Code FROM Customer_Special_Charge_Condition ";
        }

        private string getSQLInsert(CustomerSpecialChargeCondition value, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder(" INSERT INTO Customer_Special_Charge_Condition (Company_Code, Contract_No, Special_Amount_Per_Person, Telephone_Amount_Per_Person, Process_Date, Process_User,Customer_Department_Code) ");
            stringBuilder.Append(" VALUES ( ");

            //Company_Code
            stringBuilder.Append(GetDB(aCompany.CompanyCode));
            stringBuilder.Append(", ");

            //Contract_No
            stringBuilder.Append(GetDB(value.Contract.ContractNo.ToString()));
            stringBuilder.Append(", ");

            //Special_Amount_Per_Person
            stringBuilder.Append(GetDB(value.SpecialAmount));
            stringBuilder.Append(", ");

            //Telephone_Amount_Per_Person
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

        private string getSQLUpdate(CustomerSpecialChargeCondition value, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder("UPDATE Customer_Special_Charge_Condition SET ");
            stringBuilder.Append("Company_Code = ");
            stringBuilder.Append(GetDB(aCompany.CompanyCode));
            stringBuilder.Append(", ");

            stringBuilder.Append("Contract_No = ");
            stringBuilder.Append(GetDB(value.Contract.ContractNo.ToString()));
            stringBuilder.Append(", ");

            stringBuilder.Append("Special_Amount_Per_Person = ");
            stringBuilder.Append(GetDB(value.SpecialAmount));
            stringBuilder.Append(", ");

            stringBuilder.Append("Telephone_Amount_Per_Person = ");
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
            return " DELETE FROM Customer_Special_Charge_Condition ";
        }

        private string getKeyCondition(DocumentNo contractNo)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (contractNo != null && IsNotNULL(contractNo.ToString()))
            {
                stringBuilder.Append(" AND (Contract_No = ");
                stringBuilder.Append(GetDB(contractNo.ToString()));
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

        private string getOrderBy()
        {
            return " ORDER BY Contract_No ";
        }

        #endregion

        #region - Fill -
        private void fillCustomerSpecialChargeCondition(CustomerSpecialChargeCondition value, Company company, SqlDataReader dataReader)
        {
            value.Contract = dbContract.GetAllContract(new DocumentNo((string)dataReader[CONTRACT_NO]), company);
            value.SpecialAmount = dataReader.GetDecimal(SPECIAL_AMOUNT_PER_PERSON);
            value.TelephoneAmount = dataReader.GetDecimal(TELEPHONE_AMOUNT_PER_PERSON);
            value.AssignDepartment = dbCustomerDepartment.GetDBCustomerDepartment((string)dataReader[CUSTOMER_DEPARTMENT_CODE], value.Contract.ACustomer.Code, company);
        }

        private bool fillCustomerSpecialChargeCondition(CustomerSpecialChargeCondition value, Company company, string sql)
        {
            bool result;
            SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
            try
            {
                if (dataReader.Read())
                {
                    fillCustomerSpecialChargeCondition(value, company, dataReader);
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

        private bool fillCustomerSpecialChargeConditionList(CustomerSpecialChargeConditionList value, string sql)
        {
            bool result = false;
            CustomerSpecialChargeCondition charge;

            SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
            try
            {
                while (dataReader.Read())
                {
                    result = true;
                    charge = new CustomerSpecialChargeCondition();
                    fillCustomerSpecialChargeCondition(charge, value.Company, dataReader);
                    value.Add(charge);
                }
                charge = null;
            }
            catch (IndexOutOfRangeException ein)
            { throw ein; }

            finally
            { tableAccess.CloseDataReader(); }
            return result;
        }
        #endregion

        //============================== Public Method ==============================
        public bool FillCustomerSpecialChargeCondition(CustomerSpecialChargeCondition value, Company company)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(company));
            stringBuilder.Append(getKeyCondition(value.Contract.ContractNo));

            return fillCustomerSpecialChargeCondition(value, company, stringBuilder.ToString());
        }

        public bool FillCustomerSpecialChargeCondition(CustomerSpecialChargeCondition value, Company company, CustomerDepartment customerDepartment)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(company));
            stringBuilder.Append(getKeyCondition(value.Contract.ContractNo));
            stringBuilder.Append(getSpecialKeyCondition(customerDepartment));

            return fillCustomerSpecialChargeCondition(value, company, stringBuilder.ToString());
        }

        public bool FillCustomerSpecialChargeConditionList(CustomerSpecialChargeConditionList value)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(value.Company));
            stringBuilder.Append(getOrderBy());

            return fillCustomerSpecialChargeConditionList(value, stringBuilder.ToString());
        }

        public bool InsertCustomerSpecialChargeCondition(CustomerSpecialChargeCondition value, Company aCompany)
        {
            return (tableAccess.ExecuteSQL(getSQLInsert(value, aCompany)) > 0);
        }

        public bool UpdateCustomerSpecialChargeCondition(CustomerSpecialChargeCondition value, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value, aCompany));
            stringBuilder.Append(getBaseCondition(aCompany));
            stringBuilder.Append(getKeyCondition(value.Contract.ContractNo));
            stringBuilder.Append(getSpecialKeyCondition(value.AssignDepartment));

            return (tableAccess.ExecuteSQL(stringBuilder.ToString()) > 0) ;
        }

        public bool DeleteCustomerSpecialChargeCondition(CustomerSpecialChargeCondition value, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
            stringBuilder.Append(getBaseCondition(aCompany));
            stringBuilder.Append(getKeyCondition(value.Contract.ContractNo));
            stringBuilder.Append(getSpecialKeyCondition(value.AssignDepartment));

            return (tableAccess.ExecuteSQL(stringBuilder.ToString()) > 0);
        }
    }
}
