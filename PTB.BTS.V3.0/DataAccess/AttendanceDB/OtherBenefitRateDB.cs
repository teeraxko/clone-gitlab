using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;
using Entity.AttendanceEntities;

using DataAccess.CommonDB;

using SystemFramework.AppConfig;
using SystemFramework.AppException;

using ictus.Common.Entity;

namespace DataAccess.AttendanceDB
{
	public class OtherBenefitRateDB : DataAccessBase
	{
		#region - Constant -
		private const int TAXI_RATE = 0;
		private const int FOOD_RATE = 1;
		private const int ONE_DAY_TRIP_RATE_FAR = 2;
		private const int ONE_DAY_TRIP_RATE_NEAR = 3;
		private const int OVERNIGHT_TRIP_RATE = 4;
		private const int EXTRA_RATE = 5;
		private const int EXTRA_AGT_RATE = 6;
		private const int DEDUCTION_AGT_PER_DAY = 7;
		private const int TAXI_RETE_FOR_CHARGE = 8;
        private const int MEAL_ALLOWANCE = 9;
		#endregion

		#region - Private -
		private OtherBenefitRate objOtherBenefitRate;
		#endregion

		//		============================== Constructor ==============================
		public OtherBenefitRateDB() : base()
		{
		}

		//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
            return "SELECT Taxi_Rate, Food_Rate, One_Day_Trip_Rate_Far, One_Day_Trip_Rate_Near, Overnight_Trip_Rate, Extra_Rate, Extra_AGT_Rate, Deduction_AGT_Per_Day, Taxi_Rate_For_Charge, Meal_Rate FROM Other_Benefit_Rate ";
		}

		private string getSQLInsert(OtherBenefitRate value, Company aCompany)
		{
            StringBuilder stringBuilder = new StringBuilder("INSERT INTO Other_Benefit_Rate (Company_Code, Taxi_Rate, Food_Rate, One_Day_Trip_Rate_Far, One_Day_Trip_Rate_Near, Overnight_Trip_Rate, Extra_Rate, Extra_AGT_Rate, Deduction_AGT_Per_Day, Taxi_Rate_For_Charge, Meal_Rate, Process_Date, Process_User) ");
			stringBuilder.Append("VALUES (");

			//Company_Code
			stringBuilder.Append(GetDB(aCompany.CompanyCode));
			stringBuilder.Append(", ");
			
			//Taxi_Rate		
			stringBuilder.Append(GetDB(value.TaxiRate));
			stringBuilder.Append(", ");

			//Food_Rate
			stringBuilder.Append(GetDB(value.FoodRate));
			stringBuilder.Append(", ");

			//One_Day_Trip_Rate_Far
			stringBuilder.Append(GetDB(value.OneDayTripRateFar));
			stringBuilder.Append(", ");

			//One_Day_Trip_Rate_Near
			stringBuilder.Append(GetDB(value.OneDayTripRateNear));
			stringBuilder.Append(", ");

			//Overnight_Trip_Rate
			stringBuilder.Append(GetDB(value.OvernightTripRate));
			stringBuilder.Append(", ");

			//Extra_Rate
			stringBuilder.Append(GetDB(value.ExtraRate));
			stringBuilder.Append(", ");

			//Extra_AGT_Rate
			stringBuilder.Append(GetDB(value.ExtraAGTRate));
			stringBuilder.Append(", ");

			//Deduction_AGT_Per_Day
			stringBuilder.Append(GetDB(value.DeductionAGTPerDay));
			stringBuilder.Append(", ");

			//Taxi_Rate_For_Charge
			stringBuilder.Append(GetDB(value.TaxiRateForCharge));
			stringBuilder.Append(", ");

            //Meal Allowance
            stringBuilder.Append(GetDB(value.MealAllowance));
            stringBuilder.Append(", ");
	
			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(")");

			return stringBuilder.ToString();
		}

		private string getSQLUpdate(OtherBenefitRate value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder("UPDATE Other_Benefit_Rate SET ");
			stringBuilder.Append("Company_Code = ");
			stringBuilder.Append(GetDB(aCompany.CompanyCode));
			stringBuilder.Append(", ");

			stringBuilder.Append("Taxi_Rate = ");
			stringBuilder.Append(GetDB(value.TaxiRate));
			stringBuilder.Append(", ");

			stringBuilder.Append("Food_Rate = ");
			stringBuilder.Append(GetDB(value.FoodRate));
			stringBuilder.Append(", ");

			stringBuilder.Append("One_Day_Trip_Rate_Far = ");
			stringBuilder.Append(GetDB(value.OneDayTripRateFar));
			stringBuilder.Append(", ");

			stringBuilder.Append("One_Day_Trip_Rate_Near = ");
			stringBuilder.Append(GetDB(value.OneDayTripRateNear));
			stringBuilder.Append(", ");

			stringBuilder.Append("Overnight_Trip_Rate = ");
			stringBuilder.Append(GetDB(value.OvernightTripRate));
			stringBuilder.Append(", ");

			stringBuilder.Append("Extra_Rate = ");
			stringBuilder.Append(GetDB(value.ExtraRate));
			stringBuilder.Append(", ");

			stringBuilder.Append("Extra_AGT_Rate = ");
			stringBuilder.Append(GetDB(value.ExtraAGTRate));
			stringBuilder.Append(", ");

			stringBuilder.Append("Deduction_AGT_Per_Day = ");
			stringBuilder.Append(GetDB(value.DeductionAGTPerDay));
			stringBuilder.Append(", ");

			stringBuilder.Append("Taxi_Rate_For_Charge = ");
			stringBuilder.Append(GetDB(value.TaxiRateForCharge));
			stringBuilder.Append(", ");

            stringBuilder.Append("Meal_Rate = ");
            stringBuilder.Append(GetDB(value.MealAllowance));
            stringBuilder.Append(", ");

			stringBuilder.Append("Process_Date = ");
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			stringBuilder.Append("Process_User = ");
			stringBuilder.Append(GetDB(UserProfile.UserID));
			
			return stringBuilder.ToString();
		}
		#endregion

		#region - Fill -
		private void fillOtherBenefitRate(ref OtherBenefitRate value, SqlDataReader dataReader)
		{
			value.TaxiRate = dataReader.GetInt16(TAXI_RATE);
			value.FoodRate = dataReader.GetInt16(FOOD_RATE);
			value.OneDayTripRateFar = dataReader.GetInt16(ONE_DAY_TRIP_RATE_FAR);
			value.OneDayTripRateNear = dataReader.GetInt16(ONE_DAY_TRIP_RATE_NEAR);
			value.OvernightTripRate = dataReader.GetInt16(OVERNIGHT_TRIP_RATE);
			value.ExtraRate = dataReader.GetInt16(EXTRA_RATE);
			value.ExtraAGTRate = dataReader.GetInt16(EXTRA_AGT_RATE);
			value.DeductionAGTPerDay = dataReader.GetInt16(DEDUCTION_AGT_PER_DAY);
			value.TaxiRateForCharge = dataReader.GetInt16(TAXI_RETE_FOR_CHARGE);
            value.MealAllowance = dataReader.GetInt16(MEAL_ALLOWANCE);
		}

		private bool fillOtherBenefitRate(ref OtherBenefitRate value, string sql)
		{
			bool result;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				if (dataReader.Read())
				{
					fillOtherBenefitRate(ref value, dataReader);
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
		public OtherBenefitRate GetOtherBenefitRate(Company value)
		{
			objOtherBenefitRate = new OtherBenefitRate();
			if(FillOtherBenefitRate(ref objOtherBenefitRate, value))
			{
				return objOtherBenefitRate;
			}
			else
			{
				objOtherBenefitRate = null;
				return null;
			}
		}

		public bool FillOtherBenefitRate(ref OtherBenefitRate value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(aCompany));
			return fillOtherBenefitRate(ref value, stringBuilder.ToString());		
		}

		public bool InsertOtherBenefitRate(OtherBenefitRate value, Company aCompany)
		{
			if (tableAccess.ExecuteSQL(getSQLInsert(value, aCompany))>0)
			{return true;}
			else
			{return false;}	
		}

		public bool UpdateOtherBenefitRate(OtherBenefitRate value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value, aCompany));
			stringBuilder.Append(getBaseCondition(aCompany));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}
	}
}
