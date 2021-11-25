using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.General;

using Entity.CommonEntity;
using Entity.AttendanceEntities;

using DataAccess.CommonDB;

using SystemFramework.AppConfig;
using SystemFramework.AppException;

namespace DataAccess.AttendanceDB
{
	public class OTPatternDB : DataAccessBase
	{
		#region - Constant -
		private const int PATTERN_CODE = 0;
		private const int PATTERN_NAME = 1;
		private const int DAY_TYPE = 2;
		private const int OT_PERIOD = 3;
		private const int IS_FIXED_HOUR = 4;
		private const int FIXED_HOUR = 5;
		private const int IS_MAX_HOUR_LIMIT = 6;
		private const int MAX_HOUR_LIMIT = 7;
		private const int IS_MIN_HOUR_LIMIT = 8;
		private const int MIN_HOUR_LIMIT = 9;
		private const int ADDITIONAL_MINUTES_REQUIRED = 10;
		private const int OT_RATE = 11;
		#endregion

		#region - Private -
			private bool disposed = false;
			private OTPattern objOTPattern;
		#endregion

//		============================== Constructor ==============================
		public OTPatternDB() : base()
		{
		}

//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
			return "SELECT Pattern_Code, Pattern_Name, Day_Type, OT_Period, Is_Fixed_Hour, Fixed_Hour, Is_Max_Hour_Limit, Max_HOur_Limit, Is_Min_Hour_Limit, Min_Hour_Limit, Additional_Minutes_Required, OT_Rate FROM Overtime_Pattern ";
		}
		private string getSQLInsert(OTPattern value, ictus.Common.Entity.Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder("INSERT INTO Overtime_Pattern (Company_Code, Pattern_Code, Pattern_Name, Day_Type, OT_Period,  Is_Fixed_Hour, Fixed_Hour, Is_Max_Hour_Limit, Max_Hour_Limit, Is_Min_Hour_Limit, Min_Hour_Limit, Additional_Minutes_Required, OT_Rate, Process_Date, Process_User) ");
			stringBuilder.Append("VALUES (");

			//Company_Code
			stringBuilder.Append(GetDB(aCompany.CompanyCode));
			stringBuilder.Append(", ");

			//Pattern_Id		
			stringBuilder.Append(GetDB(value.PatternId));
			stringBuilder.Append(", ");

			//Pattern_Name
			stringBuilder.Append(GetDB(value.PatternName));
			stringBuilder.Append(", ");

			//Day_Type
			stringBuilder.Append(GetDB(value.DayType));
			stringBuilder.Append(", ");

			//OT_Period
			stringBuilder.Append(GetDB(value.OTPeriod));
			stringBuilder.Append(", ");

			//Is_Fixed_Hour
			stringBuilder.Append(GetDB(value.IsFixedHour));
			stringBuilder.Append(", ");

			//Fixed_Hour
			stringBuilder.Append(GetDB(value.FixedHour));
			stringBuilder.Append(", ");

			//Is_Max_Hour_Limit
			stringBuilder.Append(GetDB(value.IsMaxHourLimit));
			stringBuilder.Append(", ");

			//Max_Hour_Limit
			stringBuilder.Append(GetDB(value.MaxHourLimit));
			stringBuilder.Append(", ");

			//Is_Min_Hour_Limit
			stringBuilder.Append(GetDB(value.IsMinHourLimit));
			stringBuilder.Append(", ");

			//Min_Hour_Limit
			stringBuilder.Append(GetDB(value.MinHourLimit));
			stringBuilder.Append(", ");

			//Additional_Minute
			stringBuilder.Append(GetDB(value.AdditionalMinute));
			stringBuilder.Append(", ");

			//OTRate
			stringBuilder.Append(GetDB(value.OTRate));
			stringBuilder.Append(", ");	
	
			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(")");

			return stringBuilder.ToString();
		}

        private string getSQLUpdate(OTPattern value, ictus.Common.Entity.Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder("UPDATE Overtime_Pattern SET ");
			stringBuilder.Append("Company_Code = ");
			stringBuilder.Append(GetDB(aCompany.CompanyCode));
			stringBuilder.Append(", ");

			stringBuilder.Append("Pattern_Code = ");
			stringBuilder.Append(GetDB(value.PatternId));
			stringBuilder.Append(", ");

			stringBuilder.Append("Pattern_Name = ");
			stringBuilder.Append(GetDB(value.PatternName));
			stringBuilder.Append(", ");
		
			stringBuilder.Append("Day_Type = ");
			stringBuilder.Append(GetDB(value.DayType));
			stringBuilder.Append(", ");

			stringBuilder.Append("OT_Period = ");
			stringBuilder.Append(GetDB(value.OTPeriod));
			stringBuilder.Append(", ");

			stringBuilder.Append("Is_Fixed_Hour = ");
			stringBuilder.Append(GetDB(value.IsFixedHour));
			stringBuilder.Append(", ");

			stringBuilder.Append("Fixed_Hour = ");
			stringBuilder.Append(GetDB(value.FixedHour));
			stringBuilder.Append(", ");

			stringBuilder.Append("Is_Max_Hour_Limit = ");
			stringBuilder.Append(GetDB(value.IsMaxHourLimit));
			stringBuilder.Append(", ");

			stringBuilder.Append("Max_Hour_Limit = ");
			stringBuilder.Append(GetDB(value.MaxHourLimit));
			stringBuilder.Append(", ");

			stringBuilder.Append("Is_Min_Hour_Limit = ");
			stringBuilder.Append(GetDB(value.IsMinHourLimit));
			stringBuilder.Append(", ");

			stringBuilder.Append("Min_Hour_Limit = ");
			stringBuilder.Append(GetDB(value.MinHourLimit));
			stringBuilder.Append(", ");

			stringBuilder.Append("Additional_Minutes_Required = ");
			stringBuilder.Append(GetDB(value.AdditionalMinute));
			stringBuilder.Append(", ");

			stringBuilder.Append("OT_Rate = ");
			stringBuilder.Append(GetDB(value.OTRate));
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
			return "DELETE FROM Overtime_Pattern ";
		}

		private string getKeyCondition(OTPattern value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (IsNotNULL(value.PatternId))
			{
				stringBuilder.Append(" AND (Pattern_Code = ");
				stringBuilder.Append(GetDB(value.PatternId));
				stringBuilder.Append(")");	
			}

			return stringBuilder.ToString();
		}

		private string getEntityCondition(OTPattern value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (IsNotNULL(value.PatternName))
			{
				stringBuilder.Append(" AND (Pattern_Name = ");
				stringBuilder.Append(GetDB(value.PatternName));
				stringBuilder.Append(")");	
			}

			return stringBuilder.ToString();
		}

		private string getOrderby()
		{
			return " ORDER BY Pattern_Code ";
		}
		#endregion

		#region - Fill -
		private void fillOTPattern(ref OTPattern value, SqlDataReader dataReader)
		{
			value.PatternId  = (string)dataReader[PATTERN_CODE];
			value.PatternName = (string)dataReader[PATTERN_NAME];
			value.DayType = CTFunction.GetDayType((string)dataReader[DAY_TYPE]);
			value.OTPeriod = CTFunction.GetPeriodType((string)dataReader[OT_PERIOD]);

			if (dataReader[IS_FIXED_HOUR].ToString() == "Y")
			{
				value.IsFixedHour = true;
				if (dataReader.IsDBNull(FIXED_HOUR))
				{
					value.FixedHour = NullConstant.DECIMAL;
				}
				else
				{
					value.FixedHour = dataReader.GetDecimal(FIXED_HOUR);
				}
			}
			else
			{
				value.IsFixedHour = false;
			}

			if (dataReader[IS_MAX_HOUR_LIMIT].ToString() == "Y")
			{
				value.IsMaxHourLimit = true;
				if (dataReader.IsDBNull(MAX_HOUR_LIMIT))
				{
					value.MaxHourLimit = NullConstant.DECIMAL;
				}
				else
				{
					value.MaxHourLimit = dataReader.GetDecimal(MAX_HOUR_LIMIT);
				}

			}
			else
			{
				value.IsMaxHourLimit = false;
			}

			if (dataReader[IS_MIN_HOUR_LIMIT].ToString() == "Y")
			{
				value.IsMinHourLimit = true;
				if(dataReader.IsDBNull(MIN_HOUR_LIMIT))
				{
					value.MinHourLimit = NullConstant.DECIMAL;
				}
				else
				{
					value.MinHourLimit = dataReader.GetDecimal(MIN_HOUR_LIMIT);
				}
			}
			else
			{
				value.IsMinHourLimit = false;
			}
			value.AdditionalMinute = dataReader.GetInt32(ADDITIONAL_MINUTES_REQUIRED);
			value.OTRate = CTFunction.GetRateType((string)dataReader[OT_RATE]);
		}

		private bool fillOTPatternList(ref OTPatternList value, string sql)
		{
			bool result = false;

			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);		
			try
			{
				while (dataReader.Read())
				{
					result = true;
					objOTPattern = new OTPattern();
					fillOTPattern(ref objOTPattern, dataReader);
					value.Add(objOTPattern);
				}
				objOTPattern = null;
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

		private bool fillOTPattern(ref OTPattern value, string sql)
		{
			bool result;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				if (dataReader.Read())
				{
					fillOTPattern(ref value, dataReader);
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
        public OTPattern GetOTPattern(string patternId, ictus.Common.Entity.Company aCompany)
		{
			objOTPattern = new OTPattern();
			objOTPattern.PatternId = patternId;
			if(FillOTPattern(ref objOTPattern, aCompany))
			{
				return objOTPattern;			
			}
			else
			{
				objOTPattern = null;
				return null;
			}		
		}

        public bool FillOTPattern(ref OTPattern value, ictus.Common.Entity.Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(value));
			stringBuilder.Append(getEntityCondition(value));
			return fillOTPattern(ref value, stringBuilder.ToString());		
		}

		public bool FillOTPatternList(ref OTPatternList value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Company));
			stringBuilder.Append(getOrderby());
			return fillOTPatternList(ref value, stringBuilder.ToString());
		}

		public bool FillOTPatternList(ref OTPatternList aOTPatternList, OTPattern aOTPattern)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(aOTPatternList.Company));
			stringBuilder.Append(getKeyCondition(aOTPattern));
			stringBuilder.Append(getOrderby());
			return fillOTPatternList(ref aOTPatternList, stringBuilder.ToString());
		}

        public bool InsertOTPattern(OTPattern value, ictus.Common.Entity.Company aCompany)
		{
			if (tableAccess.ExecuteSQL(getSQLInsert(value, aCompany))>0)
			{return true;}
			else
			{return false;}	
		}

        public bool UpdateOTPattern(OTPattern value, ictus.Common.Entity.Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value, aCompany));
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

        public bool DeleteOTPattern(OTPattern value, ictus.Common.Entity.Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(value));

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
						objOTPattern = null;
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