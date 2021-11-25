using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using DataAccess.CommonDB;

using Entity.ContractEntities;

using Entity.CommonEntity;

using SystemFramework.AppConfig;

using ictus.Common.Entity;
using ictus.Common.Entity.Time;
using ictus.PIS.PI.Entity;

namespace DataAccess.ContractDB
{
    public class ContractChargeDetailDB : DataAccessBase, DataAccess.CommonDB.ITableName
    {
        #region - Constant -
        private const int CONTRACT_NO = 0;
        private const int FOR_YEAR = 1;
        private const int FOR_MONTH = 2;
        private const int CHARGE_AMOUNT = 3;
        #endregion

        #region - Private -
        private ContractChargeDetail objContractChargeDetail;
        private bool disposed = false;
        #endregion

        //		============================== Constructor ==============================
        public ContractChargeDetailDB() : base()
        {
        }

        //		============================== Private Method ==============================
        #region - getSQL -
        private string getSQLSelect()
        {
            return "SELECT Contract_No, For_Year, For_Month, Charge_Amount FROM Contract_Charge_Detail ";
        }

        private string getSQLInsert(ContractChargeDetail aContractChargeDetail, ContractBase aContract, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder(" INSERT INTO Contract_Charge_Detail (Company_Code, Contract_No, For_Year, For_Month, Charge_Amount, Process_Date, Process_User) ");
            stringBuilder.Append(" VALUES ( ");

            //Company_Code			
            stringBuilder.Append(GetDB(aCompany.CompanyCode));
            stringBuilder.Append(", ");

            //Contract_No
            stringBuilder.Append(GetDB(aContract.ContractNo.ToString()));
            stringBuilder.Append(", ");

            //For_Year
            stringBuilder.Append(GetDB(aContractChargeDetail.YearMonth.Year));
            stringBuilder.Append(", ");

            //For_Month
            stringBuilder.Append(GetDB(aContractChargeDetail.YearMonth.Month));
            stringBuilder.Append(", ");

            //Charge_Amount
            stringBuilder.Append(GetDB(aContractChargeDetail.ChargeAmount));
            stringBuilder.Append(", ");

            //Process_Date
            stringBuilder.Append(GetDateDB());
            stringBuilder.Append(", ");

            //Process_User
            stringBuilder.Append(GetDB(UserProfile.UserID));
            stringBuilder.Append(")");

            return stringBuilder.ToString();
        }

        private string getSpecificSQLUpdate(ContractChargeDetail aContractChargeDetail)
        {
            StringBuilder stringBuilder = new StringBuilder("UPDATE Contract_Charge_Detail SET ");

            stringBuilder.Append("Charge_Amount = ");
            stringBuilder.Append(GetDB(aContractChargeDetail.ChargeAmount));
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
            return " DELETE FROM Contract_Charge_Detail ";
        }

        private string getKeyCondition(DocumentNo contractNo)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (contractNo != null)
            {
                if (IsNotNULL(contractNo.Year) && IsNotNULL(contractNo.Month) && IsNotNULL(contractNo.No))
                {
                    stringBuilder.Append(" AND (Contract_No = ");
                    stringBuilder.Append(GetDB(contractNo.ToString()));
                    stringBuilder.Append(")");
                }
                else
                {
                    if (IsNotNULL(contractNo.Year))
                    {
                        stringBuilder.Append(" AND (SUBSTRING(Contract_No, 7, 2) = ");
                        stringBuilder.Append(GetDB(contractNo.Year));
                        stringBuilder.Append(")");
                    }

                    if (IsNotNULL(contractNo.Month))
                    {
                        stringBuilder.Append(" AND (SUBSTRING(Contract_No, 9, 2) = ");
                        stringBuilder.Append(GetDB(contractNo.Month));
                        stringBuilder.Append(")");
                    }

                    if (IsNotNULL(contractNo.No))
                    {
                        stringBuilder.Append(" AND (SUBSTRING(Contract_No, 11, 3) = ");
                        stringBuilder.Append(GetDB(contractNo.No));
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
        private void fillContractChargeDetail(ref ContractChargeDetail value, SqlDataReader dataReader)
        {
            value.YearMonth = new YearMonth(dataReader.GetInt16(FOR_YEAR), dataReader.GetByte(FOR_MONTH));
            value.ChargeAmount = dataReader.GetDecimal(CHARGE_AMOUNT);
        }

        protected virtual ContractChargeDetail getNewContractChargeDetail()
        {
            return new ContractChargeDetail();
        }

        private bool fillContractChargeDetailList(ref ContractChargeDetailList value, string sql)
        {
            bool result = false;
            SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
            try
            {
                while (dataReader.Read())
                {
                    result = true;
                    objContractChargeDetail = getNewContractChargeDetail();
                    fillContractChargeDetail(ref objContractChargeDetail, dataReader);
                    value.Add(objContractChargeDetail);
                }
                objContractChargeDetail = null;
            }
            catch (IndexOutOfRangeException ein)
            { throw ein; }
            finally
            { tableAccess.CloseDataReader(); }
            return result;
        }
        #endregion

        //============================== Public Method ==============================
        public bool FillContractChargeDetailList(ref ContractChargeDetailList value)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(value.Company));
            stringBuilder.Append(getKeyCondition(value.AContract.ContractNo));
            stringBuilder.Append(getOrderby());

            return fillContractChargeDetailList(ref value, stringBuilder.ToString());
        }

        public bool FillContractChargeDetailNoneBPNoList(ContractChargeDetailList value)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(value.Company));
            stringBuilder.Append(getKeyCondition(value.AContract.ContractNo));
            stringBuilder.Append(" AND (BizPac_Reference_No <> '') ");
            stringBuilder.Append(" ORDER BY For_Year, For_Month ");

            return fillContractChargeDetailList(ref value, stringBuilder.ToString());
        }

        public bool MaintainContractChargeDetail(ContractChargeDetailList value)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
            stringBuilder.Append(getBaseCondition(value.Company));
            stringBuilder.Append(getKeyCondition(value.AContract.ContractNo));

            for (int i = 0; i < value.Count; i++)
            {
                stringBuilder.Append(getSQLInsert(value[i], value.AContract, value.Company));
            }

            return (tableAccess.ExecuteSQL(stringBuilder.ToString()) > 0);
        }

        public bool DeleteContractChargeDetail(ContractBase value, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
            stringBuilder.Append(getBaseCondition(aCompany));
            stringBuilder.Append(getKeyCondition(value.ContractNo));
            return (tableAccess.ExecuteSQL(stringBuilder.ToString()) > 0);
        }

        //============================== Specific Method ==============================
        public bool UpdateSpecificContractChargeDetail(ContractChargeDetailList listCharge)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (ContractChargeDetail charge in listCharge)
            {
                stringBuilder.Append(getSpecificSQLUpdate(charge));
                stringBuilder.Append(getBaseCondition(listCharge.Company));
                stringBuilder.Append(getKeyCondition(listCharge.AContract.ContractNo));
                stringBuilder.Append(" AND (For_Year = ");
                stringBuilder.Append(GetDB(charge.YearMonth.Year));
                stringBuilder.Append(")");
                stringBuilder.Append(" AND (For_Month = ");
                stringBuilder.Append(GetDB(charge.YearMonth.Month));
                stringBuilder.Append(")");
                stringBuilder.Append(" AND (BizPac_Reference_No = '') ");
            }

            return (tableAccess.ExecuteSQL(stringBuilder.ToString()) > 0);
        }

        public string InsertSpecificChargeDetail(ContractChargeDetail detail, ContractBase contract, Company company)
        {
            return getSQLInsert(detail, contract, company);
        }

        public bool ExecuteSpecific(string command)
        {
            return (tableAccess.ExecuteSQL(command) > 0);
        }

        public bool DeleteSpecificChargeDetail(DocumentNo contractNo, Company company)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
            stringBuilder.Append(getBaseCondition(company));
            stringBuilder.Append(getKeyCondition(contractNo));
            stringBuilder.Append(" AND (BizPac_Reference_No = '') ");

            return (tableAccess.ExecuteSQL(stringBuilder.ToString()) > 0);
        }

        #region IDisposable Members
        protected override void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                try
                {
                    if (disposing)
                    {
                        objContractChargeDetail = null;
                    }
                    this.disposed = true;
                }
                finally
                {
                    base.Dispose(disposing);
                }
            }
        }
        #endregion

        #region ITableName Members

        public string TableName
        {
            get { return "Contract_Charge_Detail"; }
        }

        #endregion
    }
}
