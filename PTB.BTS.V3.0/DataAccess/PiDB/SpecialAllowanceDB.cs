using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Entity.CommonEntity;

using DataAccess.CommonDB;

using SystemFramework.AppConfig;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.General;
using ictus.Common.Entity;

namespace DataAccess.PiDB
{
	public class SpecialAllowanceDB : DataAccessBase
	{
		#region - Constant -
		private const int SPECIAL_ALLOWANCE_CODE = 0;
		private const int THAI_DESCRIPTION = 1;
		private const int ENGLISH_DESCRIPTION = 2;
		private const int SPECIAL_ALLOWANCE_AMOUNT = 3;
		#endregion

		#region - Private -
		private SpecialAllowance objSpecialAllowance;
		private bool disposed = false;
		#endregion

//		============================== Constructor ==============================
		public SpecialAllowanceDB() : base()
		{
		}

//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
			return " SELECT Special_Allowance_Code, Thai_Description, English_Description, Special_Allowance_Amount FROM Special_Allowance ";
		}

        private string getSQLInsert(SpecialAllowance specialAllowance, Company company)
        {
            StringBuilder stringBuilder = new StringBuilder("INSERT INTO Special_Allowance (Company_Code, Special_Allowance_Code, Thai_Description, English_Description, Special_Allowance_Amount, Process_Date, Process_User) ");
            stringBuilder.Append(" VALUES ( ");

            //Company_Code
            stringBuilder.Append(GetDB(company.CompanyCode));
            stringBuilder.Append(", ");

            //Special_Allowance_Code
            stringBuilder.Append(GetDB(specialAllowance.Code));
            stringBuilder.Append(", ");

            //Thai_Description			
            stringBuilder.Append(GetDB(specialAllowance.AName.Thai));
            stringBuilder.Append(", ");

            //English_Description
            stringBuilder.Append(GetDB(specialAllowance.AName.English));
            stringBuilder.Append(", ");

            //Special_Allowance_Amount
            stringBuilder.Append(GetDB(specialAllowance.Amount));
            stringBuilder.Append(", ");

            //Process_Date
            stringBuilder.Append(GetDateDB());
            stringBuilder.Append(", ");

            //Process_User
            stringBuilder.Append(GetDB(UserProfile.UserID));
            stringBuilder.Append(")");

            return stringBuilder.ToString();
        }

        private string getSQLUpdate(SpecialAllowance specialAllowance, Company aCompany)
        {
            StringBuilder stringBuilder = new StringBuilder("UPDATE Special_Allowance SET ");
            stringBuilder.Append("Company_Code = ");
            stringBuilder.Append(GetDB(aCompany.CompanyCode));
            stringBuilder.Append(", ");

            stringBuilder.Append("Special_Allowance_Code = ");
            stringBuilder.Append(GetDB(specialAllowance.Code));
            stringBuilder.Append(", ");

            stringBuilder.Append("Thai_Description = ");
            stringBuilder.Append(GetDB(specialAllowance.AName.Thai));
            stringBuilder.Append(", ");

            stringBuilder.Append("English_Description = ");
            stringBuilder.Append(GetDB(specialAllowance.AName.English));
            stringBuilder.Append(", ");

            stringBuilder.Append("Special_Allowance_Amount = ");
            stringBuilder.Append(GetDB(specialAllowance.Amount));
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
            return " DELETE FROM Special_Allowance ";
        }

		private string getKeyCondition(SpecialAllowance value)
		{
			StringBuilder stringBuilder = new StringBuilder();

			if(IsNotNULL(value.Code))
			{
				stringBuilder.Append(" AND (Special_Allowance_Code = ");
				stringBuilder.Append(GetDB(value.Code));
				stringBuilder.Append(")");			
			}

			return stringBuilder.ToString();
		}
		
		private string getOrderby()
		{
			return " ORDER BY Special_Allowance_Code ";
		}
		#endregion

		#region - Fill -
		private void fillSpecialAllowance(SpecialAllowance value, SqlDataReader dataReader)
		{
			value.Code = (string)dataReader[SPECIAL_ALLOWANCE_CODE];
			value.AName.Thai = (string)dataReader[THAI_DESCRIPTION];
			value.AName.English = (string)dataReader[ENGLISH_DESCRIPTION];
			value.Amount = dataReader.GetDecimal(SPECIAL_ALLOWANCE_AMOUNT);
		}

		private bool fillSpecialAllowanceList(SpecialAllowanceList value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				while (dataReader.Read())
				{
					result = true;
					objSpecialAllowance = new SpecialAllowance();
					fillSpecialAllowance(objSpecialAllowance, dataReader);
					value.Add(objSpecialAllowance);
				}
				objSpecialAllowance = null;
			}
			catch(IndexOutOfRangeException ein)
			{throw ein;}

			finally
			{tableAccess.CloseDataReader();}
			return result;		
		}

		private bool fillSpecialAllowance(SpecialAllowance aSpecialAllowance, string sql)
		{
			bool result;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				if (dataReader.Read())
				{					
					fillSpecialAllowance(aSpecialAllowance, dataReader);
					result = true;
				}
				else
				{result = false;}
			}
			catch (IndexOutOfRangeException ein)
			{throw ein;}

			finally
			{tableAccess.CloseDataReader();}
			return result;
		}
		#endregion

//		============================== Public Method ==============================
        public SpecialAllowance GetSpecialAllowance(string specialAllowanceCode, ictus.Common.Entity.Company value)
		{
			objSpecialAllowance = new SpecialAllowance();
			objSpecialAllowance.Code = specialAllowanceCode;
			if(FillSpecialAllowance(objSpecialAllowance, value))
			{
				return objSpecialAllowance;
			}
			else
			{
				objSpecialAllowance = null;
				return null;
			}			
		}

        internal SpecialAllowance GetDBSpecialAllowance(string specialAllowanceCode, ictus.Common.Entity.Company value)
		{
			objSpecialAllowance = new SpecialAllowance();
			objSpecialAllowance.Code = specialAllowanceCode;
			if(FillSpecialAllowance(objSpecialAllowance, value))
			{
				return objSpecialAllowance;
			}
			else
			{
				objSpecialAllowance.Code = NullConstant.STRING;
				return objSpecialAllowance;
			}			
		}

        public bool FillSpecialAllowance(SpecialAllowance value, ictus.Common.Entity.Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(value));

			return fillSpecialAllowance(value, stringBuilder.ToString());
		}

		public bool FillSpecialAllowanceList(SpecialAllowanceList value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Company));
			stringBuilder.Append(getOrderby());

			return fillSpecialAllowanceList(value, stringBuilder.ToString());
		}

        public bool InsertSpecialAllowance(SpecialAllowance aSpecialAllowance, Company company)
		{
            return tableAccess.ExecuteSQL(getSQLInsert(aSpecialAllowance, company)) > 0;
		}

        public bool UpdateSpecialAllowance(SpecialAllowance aSpecialAllowance, Company company)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(aSpecialAllowance, company));
			stringBuilder.Append(getBaseCondition(company));
			stringBuilder.Append(getKeyCondition(aSpecialAllowance));

            return tableAccess.ExecuteSQL(stringBuilder.ToString()) > 0;
		}

        public bool DeleteSpecialAllowance(SpecialAllowance aSpecialAllowance, Company company)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(company));
			stringBuilder.Append(getKeyCondition(aSpecialAllowance));

            return tableAccess.ExecuteSQL(stringBuilder.ToString()) > 0;
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
