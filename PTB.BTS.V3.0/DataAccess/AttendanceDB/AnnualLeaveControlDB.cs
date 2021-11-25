using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;
using Entity.AttendanceEntities;

using DataAccess.PiDB;
using DataAccess.CommonDB;
using DataAccess.ContractDB;

using SystemFramework.AppConfig;

using ictus.Common.Entity;
namespace DataAccess.AttendanceDB
{
	public class AnnualLeaveControlDB : DataAccessBase
	{
		#region - Constant -
		private const int FOR_YEAR = 0;
		private const int CREATE_DATE = 1;
		private const int VALID_FROM_DATE = 2;
		private const int VALID_TO_DATE = 3;
		private const int SALE_DATE = 4;		
		#endregion

		#region - Private -
		private AnnualLeaveControl objAnnualLeaveControl;
		#endregion

//		============================== Constructor ==============================
		public AnnualLeaveControlDB() : base()
		{
		}

//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
			return " SELECT For_Year, Create_Date, Valid_From_Date, Valid_To_Date, Sale_Date FROM Annual_Leave_Control ";
		}

		private string getSQLInsert(AnnualLeaveControl value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder("INSERT INTO Annual_Leave_Control (Company_Code, For_Year, Create_Date, Valid_From_Date, Valid_To_Date, Sale_Date, Process_Date, Process_User) ");
			stringBuilder.Append("VALUES (");

			//Company_Code
			stringBuilder.Append(GetDB(aCompany.CompanyCode));
			stringBuilder.Append(", ");

			//For_Year
			stringBuilder.Append(GetDB(value.ForYear));
			stringBuilder.Append(", ");

			//Create_Date
			stringBuilder.Append(GetDB(value.CreateDate));
			stringBuilder.Append(", ");

			//Valid_From_Date
			stringBuilder.Append(GetDB(value.ValidPeriod.From));
			stringBuilder.Append(", ");

			//Valid_To_Date
			stringBuilder.Append(GetDB(value.ValidPeriod.To));
			stringBuilder.Append(", ");

			//Sale_Date
			stringBuilder.Append(GetDB(value.SaleDate));
			stringBuilder.Append(", ");

			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(")");

			return stringBuilder.ToString();
		}

		private string getSQLUpdate(AnnualLeaveControl value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder("UPDATE Annual_Leave_Control SET ");

			stringBuilder.Append(" Company_Code = ");
			stringBuilder.Append(GetDB(aCompany.CompanyCode));
			stringBuilder.Append(", ");

			stringBuilder.Append(" For_Year = ");
			stringBuilder.Append(GetDB(value.ForYear));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Create_Date = ");
			stringBuilder.Append(GetDB(value.CreateDate));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Valid_From_Date = ");
			stringBuilder.Append(GetDB(value.ValidPeriod.From));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Valid_To_Date = ");
			stringBuilder.Append(GetDB(value.ValidPeriod.To));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Sale_Date = ");
			stringBuilder.Append(GetDB(value.SaleDate));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Process_Date = ");
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			stringBuilder.Append(" Process_User = ");
			stringBuilder.Append(GetDB(UserProfile.UserID));
			
			return stringBuilder.ToString();
		}	

		private string getSQLDelete()
		{
			return " DELETE FROM Annual_Leave_Control ";
		}

		private string getKeyCondition(AnnualLeaveControl value)
		{
			StringBuilder stringBuilder = new StringBuilder();

			stringBuilder.Append(" AND (For_Year = ");
			stringBuilder.Append(GetDB(value.ForYear));
			stringBuilder.Append(")");

			return stringBuilder.ToString();
		}

		private string getOrderby()
		{
			return " ORDER BY For_Year ";
		}
		#endregion

		#region - fill -
		private void fillAnnualLeaveControl(ref AnnualLeaveControl value, SqlDataReader dataReader)
		{		
			value.CreateDate = dataReader.GetDateTime(CREATE_DATE);
			value.ValidPeriod.From = dataReader.GetDateTime(VALID_FROM_DATE);
			value.ValidPeriod.To = dataReader.GetDateTime(VALID_TO_DATE);
			if(!dataReader.IsDBNull(SALE_DATE))
			{
				value.SaleDate = dataReader.GetDateTime(SALE_DATE);
			}
		}

		private bool fillAnnualLeaveControl(ref AnnualLeaveControl value, string sql)
		{
			bool result;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				if (dataReader.Read())
				{					
					fillAnnualLeaveControl(ref value, dataReader);
					result = true;
				}
				else
				{
					result = false;
				}
			}
			catch (IndexOutOfRangeException ein)
			{throw ein;}
			finally
			{tableAccess.CloseDataReader();}
			return result;
		}
		#endregion

//		============================== Public Method ==============================
		public AnnualLeaveControl GetAnnualLeaveControl(int forYear, Company aCompany)
		{
			objAnnualLeaveControl = new AnnualLeaveControl(forYear);
			if(FillAnnualLeaveControl(ref objAnnualLeaveControl, aCompany))
			{
				return objAnnualLeaveControl;
			}
			else
			{
				objAnnualLeaveControl = null;
				return null;
			}
		}

		public bool FillAnnualLeaveControl(ref AnnualLeaveControl value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(value));

			return fillAnnualLeaveControl(ref value, stringBuilder.ToString());
		}

		public bool InsertAnnualLeaveControl(AnnualLeaveControl value, Company aCompany)
		{
			if (tableAccess.ExecuteSQL(getSQLInsert(value, aCompany))>0)
			{return true;}
			else
			{return false;}	
		}

		public bool UpdateAnnualLeaveControl(AnnualLeaveControl value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(value));

			stringBuilder.Append(getSQLInsert(value, aCompany));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool DeleteAnnualLeaveControl(AnnualLeaveControl value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}
	}
}