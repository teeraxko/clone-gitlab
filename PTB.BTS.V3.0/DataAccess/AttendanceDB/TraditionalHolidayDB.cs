using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using DataAccess.CommonDB;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.Time;

using Entity.CommonEntity;
using Entity.AttendanceEntities;

using SystemFramework.AppConfig;

using ictus.Common.Entity;

namespace DataAccess.AttendanceDB
{
	public class TraditionalHolidayDB : DataAccessBase
	{
		#region - Constant -
		private const int FOR_DATE = 0;
		private const int HOLIDAY_DESCRIPTION = 1;
		private const int PATTERN_CODE = 2;
		#endregion

		#region - Private -
			private TraditionalHoliday objTraditionalHoliday;
			private TraditionalHolidayPatternDB dbTraditionalHolidayPattern;
		#endregion

//		============================== Constructor ==============================
		public TraditionalHolidayDB() : base()
		{
			dbTraditionalHolidayPattern = new TraditionalHolidayPatternDB();
		}

//		=============================== Private Method===================
		#region - getSQL -
		private string getSQLSelect()
		{
			return "SELECT For_Date, Holiday_Description, Pattern_Code FROM Traditional_Holiday ";
		}

		private string getSQLInsert(TraditionalHolidayPattern aTraditionalHolidayPattern, TraditionalHoliday aTraditionalHoliday, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder("INSERT INTO Traditional_Holiday (Company_Code, For_Date, Holiday_Description, Pattern_Code, Process_Date, Process_User) ");
			stringBuilder.Append(" VALUES ( ");

			//Company_Code
			stringBuilder.Append(GetDB(aCompany.CompanyCode));
			stringBuilder.Append(", ");

			//For_Date			
			stringBuilder.Append(GetDB(aTraditionalHoliday.HolidayDate));
			stringBuilder.Append(", ");

			//Holiday_Description
			stringBuilder.Append(GetDB(aTraditionalHoliday.ADescription.Thai));
			stringBuilder.Append(", ");

			//Pattern_Code
			stringBuilder.Append(GetDB(aTraditionalHolidayPattern.Code));
			stringBuilder.Append(", ");

			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(")");
			return stringBuilder.ToString();
		}

		private string getSQLUpdate(TraditionalHolidayPattern aTraditionalHolidayPattern, TraditionalHoliday aTraditionalHoliday, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder("UPDATE Traditional_Holiday SET ");
			stringBuilder.Append("Company_Code = ");
			stringBuilder.Append(GetDB(aCompany.CompanyCode));
			stringBuilder.Append(", ");

			stringBuilder.Append("For_Date = ");
			stringBuilder.Append(GetDB(aTraditionalHoliday.HolidayDate));
			stringBuilder.Append(", ");

			stringBuilder.Append("Holiday_Description = ");
			stringBuilder.Append(GetDB(aTraditionalHoliday.ADescription.Thai));
			stringBuilder.Append(", ");
	
			stringBuilder.Append("Pattern_Code = ");
			stringBuilder.Append(GetDB(aTraditionalHolidayPattern.Code));
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
			return " DELETE FROM Traditional_Holiday ";
		}

		private string getListCondition(YearMonth forYear, TraditionalHolidayPattern aTraditionalHolidayPattern)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (IsNotNULL(aTraditionalHolidayPattern.Code))
			{
				stringBuilder.Append(" AND (Pattern_Code = ");
				stringBuilder.Append(GetDB(aTraditionalHolidayPattern.Code));
				stringBuilder.Append(" ) ");
			}
			if (IsNotNULL(forYear))
			{
				stringBuilder.Append(" AND ");
				stringBuilder.Append(SqlFunction.GetYearCondition("For_Date", forYear));
			}
			return stringBuilder.ToString();
		}

		private string getKeyCondition(TraditionalHoliday aTraditionalHoliday, TraditionalHolidayPattern aTraditionalHolidayPattern)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (IsNotNULL(aTraditionalHoliday.HolidayDate))
			{
				stringBuilder.Append(" AND (For_Date = ");
				stringBuilder.Append(GetDB(aTraditionalHoliday.HolidayDate));
				stringBuilder.Append(")");
			}
			if (IsNotNULL(aTraditionalHolidayPattern.Code))
			{
				stringBuilder.Append(" AND (Pattern_Code = ");
				stringBuilder.Append(GetDB(aTraditionalHolidayPattern.Code));
				stringBuilder.Append(")");
			}
			return stringBuilder.ToString();
		}

		private string getKeyCondition(TraditionalHoliday value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (IsNotNULL(value.HolidayDate))
			{
				stringBuilder.Append(" AND (For_Date = ");
				stringBuilder.Append(GetDB(value.HolidayDate));
				stringBuilder.Append(")");
			}
			return stringBuilder.ToString();
		}

		private string getEntityCondition(TraditionalHoliday value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (IsNotNULL(value.ADescription.Thai))
			{
				stringBuilder.Append(" AND (Holiday_Description = ");
				stringBuilder.Append(GetDB(value.ADescription.Thai));
				stringBuilder.Append(")");
			}
			return stringBuilder.ToString();
		}

		private string getOrderby()
		{
			return " ORDER BY For_Date ";
		}
		#endregion

		#region - Fill -
		private void fillTraditionalHoliday(ref TraditionalHoliday value, Company aCompany, SqlDataReader dataReader)
		{
			value.HolidayDate = dataReader.GetDateTime(FOR_DATE);
			value.ADescription.Thai = (string)dataReader[HOLIDAY_DESCRIPTION];	
			value.ATraditionalHolidayPattern = (TraditionalHolidayPattern)dbTraditionalHolidayPattern.GetDBDualField((string)dataReader[PATTERN_CODE], aCompany);
		}

		private bool fillTraditionalHolidayList(ref TraditionalHolidayList value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				while (dataReader.Read())
				{
					result = true;
					objTraditionalHoliday = new TraditionalHoliday();
					fillTraditionalHoliday(ref objTraditionalHoliday, value.Company, dataReader);
					value.Add(objTraditionalHoliday);
				}
				objTraditionalHoliday = null;
			}
			catch(IndexOutOfRangeException ein)
			{
				throw ein;
			}
			finally
			{
				tableAccess.CloseDataReader();				
			}
			return result;		
		}

		private bool fillTraditionalHoliday(ref TraditionalHoliday value, Company aCompany, string sql)
		{
			bool result;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				if (dataReader.Read())
				{
					fillTraditionalHoliday(ref value, aCompany, dataReader);
					result = true;
				}
				else
				{
					result = false;
				}
			}
			catch (IndexOutOfRangeException ein)
			{
				throw ein;
			}
			finally
			{
				tableAccess.CloseDataReader();
			}			
			return result;				
		}
		#endregion
//		============================== Public Method ==============================
		public bool FillTraditionalHolidayList(ref TraditionalHolidayList value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Company));
			stringBuilder.Append(getListCondition(value.AYearMonth, value.ATraditionalHolidayPattern));
			stringBuilder.Append(getOrderby());

			return fillTraditionalHolidayList(ref value, stringBuilder.ToString());
		}

		public bool FillTraditionalHoliday(ref TraditionalHoliday aTraditionalHoliday, TraditionalHolidayPattern aTraditionalHolidayPattern, YearMonth yearMonth, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getListCondition(yearMonth, aTraditionalHolidayPattern));
			stringBuilder.Append(getEntityCondition(aTraditionalHoliday));

			return fillTraditionalHoliday(ref aTraditionalHoliday, aCompany, stringBuilder.ToString());			
		}

		public bool FillTraditionalHoliday(ref TraditionalHoliday value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(value));

			return fillTraditionalHoliday(ref value, aCompany, stringBuilder.ToString());	
		}

		public bool InsertTraditionalHoliday(TraditionalHolidayList aTraditionalHolidayList, TraditionalHoliday aTraditionalHoliday)
		{
			if (tableAccess.ExecuteSQL(getSQLInsert(aTraditionalHolidayList.ATraditionalHolidayPattern, aTraditionalHoliday, aTraditionalHolidayList.Company))>0)
			{return true;}
			else
			{return false;}	
		}

		public bool UpdateTraditionalHoliday(TraditionalHolidayList aTraditionalHolidayList, TraditionalHoliday aTraditionalHoliday)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(aTraditionalHolidayList.ATraditionalHolidayPattern, aTraditionalHoliday, aTraditionalHolidayList.Company));
			stringBuilder.Append(getBaseCondition(aTraditionalHolidayList.Company));
			stringBuilder.Append(getKeyCondition(aTraditionalHoliday, aTraditionalHolidayList.ATraditionalHolidayPattern));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool DeleteTraditionalHoliday(TraditionalHolidayList aTraditionalHolidayList, TraditionalHoliday aTraditionalHoliday)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(aTraditionalHolidayList.Company));
			stringBuilder.Append(getKeyCondition(aTraditionalHoliday, aTraditionalHolidayList.ATraditionalHolidayPattern));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}
	}
}
