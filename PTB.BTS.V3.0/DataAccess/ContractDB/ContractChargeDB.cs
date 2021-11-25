using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using DataAccess.CommonDB;
using DataAccess.PiDB;

using Entity.ContractEntities;
using ictus.PIS.PI.Entity;
using Entity.CommonEntity;

using SystemFramework.AppConfig;

using ictus.Common.Entity;
using ictus.Common.Entity.Time;

namespace DataAccess.ContractDB
{
	public class ContractChargeDB : DataAccessBase
	{
		#region - Constant -
		private const int CONTRACT_NO = 0;
		private const int FROM_DATE = 1;
		private const int TO_DATE = 2;
		private const int UNIT_CHARGE_AMOUNT = 3;
		private const int FIRST_MONTH_CHARGE = 4;
		private const int MONTHLY_CHARGE = 5;
		private const int LAST_MONTH_CHARGE = 6;
		#endregion

		#region - Private -	
		private ContractCharge objContractCharge;
		private bool disposed = false;
		#endregion

//		============================== Constructor ==============================
		public ContractChargeDB() : base()
		{
		}

//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
			return "SELECT Contract_No, From_Date, To_Date, Unit_Charge_Amount, First_Month_Charge, Monthly_Charge, Last_Month_Charge FROM Contract_Charge ";
		}

		private string getSQLInsert(ContractCharge aContractCharge, ContractBase aContract, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(" INSERT INTO Contract_Charge (Company_Code, Contract_No, From_Date, To_Date, Unit_Charge_Amount, First_Month_Charge, Monthly_Charge, Last_Month_Charge, Process_Date, Process_User) ");
			stringBuilder.Append(" VALUES ( ");

			//Company_Code			
			stringBuilder.Append(GetDB(aCompany.CompanyCode));
			stringBuilder.Append(", ");

			//Contract_No
			stringBuilder.Append(GetDB(aContract.ContractNo.ToString()));
			stringBuilder.Append(", ");

			//From_Date
			stringBuilder.Append(GetDB(aContractCharge.APeriod.From));
			stringBuilder.Append(", ");

			//To_Date
			stringBuilder.Append(GetDB(aContractCharge.APeriod.To));
			stringBuilder.Append(", ");

			//Unit_Charge_Amount
			stringBuilder.Append(GetDB(aContractCharge.UnitChargeAmount));
			stringBuilder.Append(", ");

			//First_Month_Charge
			stringBuilder.Append(GetDB(aContractCharge.FirstMonthCharge));
			stringBuilder.Append(", ");

			//Monthly_Charge
			stringBuilder.Append(GetDB(aContractCharge.MonthlyCharge));
			stringBuilder.Append(", ");

			//Last_Month_Charge
			stringBuilder.Append(GetDB(aContractCharge.LastMonthCharge));
			stringBuilder.Append(", ");

			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(")");

			return stringBuilder.ToString();
		}

		private string getSQLUpdate(ContractCharge aContractCharge, ContractBase aContract, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder("UPDATE Contract_Charge SET ");
			stringBuilder.Append("Company_Code = ");
			stringBuilder.Append(GetDB(aCompany.CompanyCode));
			stringBuilder.Append(", ");

			stringBuilder.Append("Contract_No = ");
			stringBuilder.Append(GetDB(aContract.ContractNo.ToString()));
			stringBuilder.Append(", ");

			stringBuilder.Append("From_Date = ");
			stringBuilder.Append(GetDB(aContractCharge.APeriod.From));
			stringBuilder.Append(", ");

			stringBuilder.Append("To_Date = ");
			stringBuilder.Append(GetDB(aContractCharge.APeriod.To));
			stringBuilder.Append(", ");

			stringBuilder.Append("Unit_Charge_Amount = ");
			stringBuilder.Append(GetDB(aContractCharge.UnitChargeAmount));
			stringBuilder.Append(", ");

			stringBuilder.Append("First_Month_Charge = ");
			stringBuilder.Append(GetDB(aContractCharge.FirstMonthCharge));
			stringBuilder.Append(", ");

			stringBuilder.Append("Monthly_Charge = ");
			stringBuilder.Append(GetDB(aContractCharge.MonthlyCharge));
			stringBuilder.Append(", ");

			stringBuilder.Append("Last_Month_Charge = ");
			stringBuilder.Append(GetDB(aContractCharge.LastMonthCharge));
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
			return " DELETE FROM Contract_Charge ";
		}

		private string getKeyCondition(ContractBase value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (value != null)
			{
                stringBuilder.Append(getKeyCondition(value.ContractNo));
			}
			return stringBuilder.ToString();
		}

        private string getKeyCondition(DocumentNo documentNo)
        {
			StringBuilder stringBuilder = new StringBuilder();

            if (documentNo != null)
			{
				if(IsNotNULL(documentNo.Year) && IsNotNULL(documentNo.Month) && IsNotNULL(documentNo.No))
				{
					stringBuilder.Append(" AND (Contract_No = ");
					stringBuilder.Append(GetDB(documentNo.ToString()));
					stringBuilder.Append(")");
				}
				else
				{
					if(IsNotNULL(documentNo.Year))
					{
						stringBuilder.Append(" AND (SUBSTRING(Contract_No, 7, 2) = ");
						stringBuilder.Append(GetDB(documentNo.Year));
						stringBuilder.Append(")");					
					}

					if(IsNotNULL(documentNo.Month))
					{
						stringBuilder.Append(" AND (SUBSTRING(Contract_No, 9, 2) = ");
						stringBuilder.Append(GetDB(documentNo.Month));
						stringBuilder.Append(")");					
					}

					if(IsNotNULL(documentNo.No))
					{
						stringBuilder.Append(" AND (SUBSTRING(Contract_No, 11, 3) = ");
						stringBuilder.Append(GetDB(documentNo.No));
						stringBuilder.Append(")");
					}
				}
			}
			return stringBuilder.ToString();
        }

        private string getConditionForTheYearMonth(string fieldName, DateTime value)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(" ( ");
            stringBuilder.Append(" Month( ");
            stringBuilder.Append(fieldName);
            stringBuilder.Append(" )= ");
            stringBuilder.Append(value.Month.ToString());
            stringBuilder.Append(" AND ");
            stringBuilder.Append(" Year( ");
            stringBuilder.Append(fieldName);
            stringBuilder.Append(" )= ");
            stringBuilder.Append(value.Year.ToString());
            stringBuilder.Append(" ) ");

            return stringBuilder.ToString();
        }

		private string getOrderby()
		{
			return " ORDER BY Contract_No ";
		}
		#endregion

		#region - Fill -
		private void fillContractCharge(ref ContractCharge value, SqlDataReader dataReader)
		{
			value.APeriod.From = dataReader.GetDateTime(FROM_DATE);
			value.APeriod.To = dataReader.GetDateTime(TO_DATE);
			value.UnitChargeAmount = dataReader.GetDecimal(UNIT_CHARGE_AMOUNT);
			value.FirstMonthCharge = dataReader.GetDecimal(FIRST_MONTH_CHARGE);
			value.MonthlyCharge = dataReader.GetDecimal(MONTHLY_CHARGE);
			value.LastMonthCharge = dataReader.GetDecimal(LAST_MONTH_CHARGE);
		}

		private bool fillContractChargeList(ref ContractChargeList value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				while (dataReader.Read())
				{
					result = true;
					objContractCharge = new ContractCharge();
					fillContractCharge(ref objContractCharge, dataReader);
					value.Add(objContractCharge);
				}
				objContractCharge = null;
			}
			catch(IndexOutOfRangeException ein)
			{throw ein;}
			finally
			{tableAccess.CloseDataReader();}
			return result;
		}

        private bool fillContractCharge(ContractCharge value, Company aCompany, string sql)
        {
            bool result = false;
            SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
            try
            {
                if (dataReader.Read())
                {
                    fillContractCharge(ref value, dataReader);
                    result = true;                    
                }
            }
            catch (IndexOutOfRangeException ein)
            { throw ein; }

            finally
            { tableAccess.CloseDataReader(); }
            return result;
        }

		#endregion

//		============================== Public Method ==============================
        public ContractCharge GetContractCharge(DocumentNo contractNo, Company company)
        {
            objContractCharge = new ContractCharge();

            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(company));
            stringBuilder.Append(getKeyCondition(contractNo));

            if (fillContractCharge(objContractCharge, company, stringBuilder.ToString()))
            {
                return objContractCharge;
            }
            else
            {
                objContractCharge = null;
                return null;
            }
        }

        public ContractCharge GetContractChargeInPeriod(DocumentNo contractNo, YearMonth yearMonth, Company company)
        {
            objContractCharge = new ContractCharge();

            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(company));
            stringBuilder.Append(getKeyCondition(contractNo));

            stringBuilder.Append(" AND ((From_Date <= ");
            stringBuilder.Append(GetDB(yearMonth.MinDateOfMonth));
            stringBuilder.Append(") AND (To_Date >= ");
            stringBuilder.Append(GetDB(yearMonth.MaxDateOfMonth));
            stringBuilder.Append(" ) OR ");
            stringBuilder.Append(getConditionForTheYearMonth("From_Date", yearMonth.MinDateOfMonth));
            stringBuilder.Append(" OR ");
            stringBuilder.Append(getConditionForTheYearMonth("To_Date", yearMonth.MaxDateOfMonth));
            stringBuilder.Append(" ) ");

            if (fillContractCharge(objContractCharge, company, stringBuilder.ToString()))
            {
                return objContractCharge;
            }
            else
            {
                objContractCharge = null;
                return null;
            }
        }


		public bool FillContractChargeList(ref ContractChargeList value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Company));
			stringBuilder.Append(getKeyCondition(value.AContract));
			stringBuilder.Append(getOrderby());

			return fillContractChargeList(ref value, stringBuilder.ToString());
		}

		public bool MaintainContractCharge(ContractChargeList value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(value.Company));
			stringBuilder.Append(getKeyCondition(value.AContract));

			for(int i=0; i<value.Count; i++)
			{
				stringBuilder.Append(getSQLInsert(value[i], value.AContract, value.Company));		
			}

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}	
		
		}

		public bool DeleteContractCharge(ContractChargeList value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(value.Company));
			stringBuilder.Append(getKeyCondition(value.AContract));
			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}	
		}

		#region IDisposable Members
		protected override void Dispose(bool disposing)
		{
			if(!this.disposed)
			{
				try
				{
					if(disposing)
					{
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
	}
}
