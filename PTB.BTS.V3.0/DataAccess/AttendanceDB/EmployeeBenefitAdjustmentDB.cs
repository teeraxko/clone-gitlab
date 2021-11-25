using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using ictus.Common.Entity.Time;
using ictus.PIS.PI.Entity;

using Entity.CommonEntity;
using Entity.AttendanceEntities;

using DataAccess.CommonDB;
using DataAccess.PiDB;
using DataAccess.ContractDB;

using SystemFramework.AppConfig;
using ictus.Common.Entity;

namespace DataAccess.AttendanceDB
{
	public class EmployeeBenefitAdjustmentDB : DataAccessBase
	{
		#region - Constant -
		private const int EMPLOYEE_NO = 0;
		private const int FOR_YEAR = 1;
		private const int FOR_MONTH = 2;
		private const int OT_A_HOUR = 3;
		private const int OT_B_HOUR = 4;
		private const int OT_C_HOUR = 5;
		private const int TAXI_TIMES = 6;
		private const int TAXI_AMOUNT = 7;
		private const int ONE_DAY_TRIP_FAR_TIMES = 8;
		private const int ONE_DAY_TRIP_FAR_AMOUNT = 9;
		private const int ONE_DAY_TRIP_NEAR_TIMES = 10;
		private const int ONE_DAY_TRIP_NEAR_AMOUNT = 11;
		private const int OVERNIGHT_TRIP_TIMES = 12;
		private const int OVERNIGHT_TRIP_AMOUNT = 13;
		private const int FOOD_TIMES = 14;
		private const int FOOD_AMOUNT = 15;
		private const int EXTRA_TIMES = 16;
		private const int EXTRA_AMOUNT = 17;
		private const int EXTRA_AGT_MONTHS = 18;
		private const int EXTRA_AGT_AMOUNT = 19;
		private const int ADD_AGT_DAYS = 20;
		private const int ADD_AGT_AMOUNT = 21;
		private const int TELEPHONE_AMOUNT = 22;
		private const int MISC_AMOUNT = 23;
        //private const int TAXI_AMOUNT_FOR_CHARGE = 24;
        //private const int ONE_DAY_TRIP_FAR_AMOUNT_FOR_CHARGE = 25;
        //private const int ONE_DAY_TRIP_NEAR_AMOUNT_FOR_CHARGE = 26;
        //private const int OVERNIGHT_TRIP_AMOUNT_FOR_CHARGE = 27;
        //private const int MISC_AMOUNT_FOR_CHARGE = 28;
		#endregion

		#region - Private -
		private BenefitAdjustment objBenefitAdjustment;
		private EmployeeDB dbEmployee;
		#endregion

//		============================== Constructor ==============================
		public EmployeeBenefitAdjustmentDB() : base()
		{
			dbEmployee = new EmployeeDB();
		}

//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
            return " SELECT Employee_No, For_Year, For_Month, OT_A_Hour, OT_B_Hour, OT_C_Hour, Taxi_Times, Taxi_Amount, One_Day_Trip_Far_Times, One_Day_Trip_Far_Amount, One_Day_Trip_Near_Times, One_Day_Trip_Near_Amount, Overnight_Trip_Times, Overnight_Trip_Amount, Food_Times, Food_Amount, Extra_Times, Extra_Amount, Extra_AGT_Months, Extra_AGT_Amount, Add_AGT_Days, Add_AGT_Amount, Telephone_Amount, Misc_Amount FROM Employee_Benefit_Adjustment ";
		}

        private string getSQLInsert(BenefitAdjustment value, Company aCompany)
		{
            StringBuilder stringBuilder = new StringBuilder("INSERT INTO Employee_Benefit_Adjustment (Company_Code, Employee_No, For_Year, For_Month, OT_A_Hour, OT_B_Hour, OT_C_Hour, Taxi_Times, Taxi_Amount, One_Day_Trip_Far_Times, One_Day_Trip_Far_Amount, One_Day_Trip_Near_Times, One_Day_Trip_Near_Amount, Overnight_Trip_Times, Overnight_Trip_Amount, Food_Times, Food_Amount, Extra_Times, Extra_Amount, Extra_AGT_Months, Extra_AGT_Amount, Add_AGT_Days, Add_AGT_Amount, Telephone_Amount, Misc_Amount, Process_Date, Process_User) ");
			stringBuilder.Append("VALUES (");

			//Company_Code
			stringBuilder.Append(GetDB(aCompany.CompanyCode));
			stringBuilder.Append(", ");

			//Employee_No
			stringBuilder.Append(GetDB(value.AEmployee.EmployeeNo));
			stringBuilder.Append(", ");

			//For_Year
			stringBuilder.Append(GetDB(value.AYearMonth.Year));
			stringBuilder.Append(", ");

			//For_Month
			stringBuilder.Append(GetDB(value.AYearMonth.Month));
			stringBuilder.Append(", ");

			//OT_A_Hour
			stringBuilder.Append(value.OTAHour.ToString());
			stringBuilder.Append(", ");

			//OT_B_Hour
			stringBuilder.Append(value.OTBHour.ToString());
			stringBuilder.Append(", ");

			//OT_C_Hour
			stringBuilder.Append(value.OTCHour.ToString());
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

			//Food_Times
			stringBuilder.Append(value.FoodTimes.ToString());
			stringBuilder.Append(", ");

			//Food_Amount
			stringBuilder.Append(value.FoodAmount.ToString());
			stringBuilder.Append(", ");

			//Extra_Times
			stringBuilder.Append(value.ExtraTimes.ToString());
			stringBuilder.Append(", ");

			//Extra_Amount
			stringBuilder.Append(value.ExtraAmount.ToString());
			stringBuilder.Append(", ");

			//Extra_AGT_Months
			stringBuilder.Append(value.ExtraAGTMonths.ToString());
			stringBuilder.Append(", ");

			//Extra_AGT_Amount
			stringBuilder.Append(value.ExtraAGTAmount.ToString());
			stringBuilder.Append(", ");

			//Add_AGT_Days
			stringBuilder.Append(value.AddAGTDays.ToString());
			stringBuilder.Append(", ");

			//Add_AGT_Amount
			stringBuilder.Append(value.AddAGTAmount.ToString());
			stringBuilder.Append(", ");

			//Telephone_Amount
			stringBuilder.Append(value.TelephoneAmount.ToString());
			stringBuilder.Append(", ");

			//Misc_Amount
			stringBuilder.Append(value.MiscAmount.ToString());
			stringBuilder.Append(", ");

            ////Taxi_Amount_For_Charge
            //stringBuilder.Append(value.TaxiAmountForCharge.ToString());
            //stringBuilder.Append(", ");

            ////One_Day_Trip_Far_Amount_For_Charge
            //stringBuilder.Append(value.OneDayTripFarAmountForCharge.ToString());
            //stringBuilder.Append(", ");

            ////One_Day_Trip_Near_Amount_For_Charge
            //stringBuilder.Append(value.OneDayTripNearAmountForCharge.ToString());
            //stringBuilder.Append(", ");

            ////Overnight_Trip_Amount_For_Charge
            //stringBuilder.Append(value.OvernightTripAmountForCharge.ToString());
            //stringBuilder.Append(", ");

            ////Misc_Amount_For_Charge
            //stringBuilder.Append(value.MiscAmountForCharge.ToString());
            //stringBuilder.Append(", ");

			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(")");

			return stringBuilder.ToString();
		}

        private string getSQLUpdate(BenefitAdjustment value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder("UPDATE Employee_Benefit_Adjustment SET ");

			stringBuilder.Append(" Company_Code = ");
			stringBuilder.Append(GetDB(aCompany.CompanyCode));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Employee_No = ");
			stringBuilder.Append(GetDB(value.AEmployee.EmployeeNo));
			stringBuilder.Append(", ");

			stringBuilder.Append(" For_Year = ");
			stringBuilder.Append(GetDB(value.AYearMonth.Year));
			stringBuilder.Append(", ");

			stringBuilder.Append(" For_Month = ");
			stringBuilder.Append(GetDB(value.AYearMonth.Month));
			stringBuilder.Append(", ");

			stringBuilder.Append(" OT_A_Hour = ");
			stringBuilder.Append(value.OTAHour.ToString());
			stringBuilder.Append(", ");

			stringBuilder.Append(" OT_B_Hour = ");
			stringBuilder.Append(value.OTBHour.ToString());
			stringBuilder.Append(", ");

			stringBuilder.Append(" OT_C_Hour = ");
			stringBuilder.Append(value.OTCHour.ToString());
			stringBuilder.Append(", ");

			stringBuilder.Append(" Taxi_Times = ");
			stringBuilder.Append(value.TaxiTimes.ToString());
			stringBuilder.Append(", ");

			stringBuilder.Append(" Taxi_Amount = ");
			stringBuilder.Append(value.TaxiAmount.ToString());
			stringBuilder.Append(", ");

			stringBuilder.Append(" One_Day_Trip_Far_Times = ");
			stringBuilder.Append(value.OneDayTripFarTimes.ToString());
			stringBuilder.Append(", ");

			stringBuilder.Append(" One_Day_Trip_Far_Amount = ");
			stringBuilder.Append(value.OneDayTripFarAmount.ToString());
			stringBuilder.Append(", ");

			stringBuilder.Append(" One_Day_Trip_Near_Times = ");
			stringBuilder.Append(value.OneDayTripNearTimes.ToString());
			stringBuilder.Append(", ");

			stringBuilder.Append(" One_Day_Trip_Near_Amount = ");
			stringBuilder.Append(value.OneDayTripNearAmount.ToString());
			stringBuilder.Append(", ");

			stringBuilder.Append(" Overnight_Trip_Times = ");
			stringBuilder.Append(value.OvernightTripTimes.ToString());
			stringBuilder.Append(", ");

			stringBuilder.Append(" Overnight_Trip_Amount = ");
			stringBuilder.Append(value.OvernightTripAmount.ToString());
			stringBuilder.Append(", ");

			stringBuilder.Append(" Food_Times = ");
			stringBuilder.Append(value.FoodTimes.ToString());
			stringBuilder.Append(", ");

			stringBuilder.Append(" Food_Amount = ");
			stringBuilder.Append(value.FoodAmount.ToString());
			stringBuilder.Append(", ");

			stringBuilder.Append(" Extra_Times = ");
			stringBuilder.Append(value.ExtraTimes.ToString());
			stringBuilder.Append(", ");

			stringBuilder.Append(" Extra_Amount = ");
			stringBuilder.Append(value.ExtraAmount.ToString());
			stringBuilder.Append(", ");

			stringBuilder.Append(" Extra_AGT_Months = ");
			stringBuilder.Append(value.ExtraAGTMonths.ToString());
			stringBuilder.Append(", ");

			stringBuilder.Append(" Extra_AGT_Amount = ");
			stringBuilder.Append(value.ExtraAGTAmount.ToString());
			stringBuilder.Append(", ");

			stringBuilder.Append(" Add_AGT_Days = ");
			stringBuilder.Append(value.AddAGTDays.ToString());
			stringBuilder.Append(", ");

			stringBuilder.Append(" Add_AGT_Amount = ");
			stringBuilder.Append(value.AddAGTAmount.ToString());
			stringBuilder.Append(", ");

			stringBuilder.Append(" Telephone_Amount = ");
			stringBuilder.Append(value.TelephoneAmount.ToString());
			stringBuilder.Append(", ");

			stringBuilder.Append(" Misc_Amount = ");
			stringBuilder.Append(value.MiscAmount.ToString());
			stringBuilder.Append(", ");

            //stringBuilder.Append(" Taxi_Amount_For_Charge = ");
            //stringBuilder.Append(value.TaxiAmountForCharge.ToString());
            //stringBuilder.Append(", ");

            //stringBuilder.Append(" One_Day_Trip_Far_Amount_For_Charge = ");
            //stringBuilder.Append(value.OneDayTripFarAmountForCharge.ToString());
            //stringBuilder.Append(", ");

            //stringBuilder.Append(" One_Day_Trip_Near_Amount_For_Charge = ");
            //stringBuilder.Append(value.OneDayTripNearAmountForCharge.ToString());
            //stringBuilder.Append(", ");

            //stringBuilder.Append(" Overnight_Trip_Amount_For_Charge = ");
            //stringBuilder.Append(value.OvernightTripAmountForCharge.ToString());
            //stringBuilder.Append(", ");

            //stringBuilder.Append(" Misc_Amount_For_Charge = ");
            //stringBuilder.Append(value.MiscAmountForCharge.ToString());
            //stringBuilder.Append(", ");

			stringBuilder.Append(" Process_Date = ");
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			stringBuilder.Append(" Process_User = ");
			stringBuilder.Append(GetDB(UserProfile.UserID));
			
			return stringBuilder.ToString();
		}	

		private string getSQLDelete()
		{
			return " DELETE FROM Employee_Benefit_Adjustment ";
		}

		private string getKeyCondition(BenefitAdjustment value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if(IsNotNULL(value.AEmployee.EmployeeNo))
			{
				stringBuilder.Append(" AND (Employee_No = ");
				stringBuilder.Append(GetDB(value.AEmployee.EmployeeNo));
				stringBuilder.Append(")");
			}

			stringBuilder.Append(getKeyCondition(value.AYearMonth));
			return stringBuilder.ToString();
		}

		private string getKeyCondition(YearMonth value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if(IsNotNULL(value.Year))
			{
				stringBuilder.Append(" AND (For_Year = ");
				stringBuilder.Append(GetDB(value.Year));
				stringBuilder.Append(")");
			}
			if(IsNotNULL(value.Month))
			{
				stringBuilder.Append(" AND (For_Month = ");
				stringBuilder.Append(GetDB(value.Month));
				stringBuilder.Append(")");
			}
			return stringBuilder.ToString();
		}

		private string getOrderby()
		{
			return " ORDER BY Employee_No, For_Year, For_Month ";
		}
		#endregion

		#region - fill -
        private void fillBenefitAdjustment(BenefitAdjustment value, Company aCompany, SqlDataReader dataReader)
		{	
			value.AEmployee = dbEmployee.GetFormerlyEmployee((string)dataReader[EMPLOYEE_NO], aCompany);
			value.AYearMonth = new YearMonth(dataReader.GetInt32(FOR_YEAR), dataReader.GetByte(FOR_MONTH));
            fillBenefitAdjustment(value, dataReader);
		}

        private void fillBenefitAdjustment(BenefitAdjustment value, SqlDataReader dataReader)
        { 
            value.OTAHour = dataReader.GetDecimal(OT_A_HOUR);
			value.OTBHour = dataReader.GetDecimal(OT_B_HOUR);
			value.OTCHour = dataReader.GetDecimal(OT_C_HOUR);
			value.TaxiTimes = dataReader.GetInt16(TAXI_TIMES);
			value.TaxiAmount = dataReader.GetDecimal(TAXI_AMOUNT);
			value.OneDayTripFarTimes = dataReader.GetInt16(ONE_DAY_TRIP_FAR_TIMES);
			value.OneDayTripFarAmount = dataReader.GetDecimal(ONE_DAY_TRIP_FAR_AMOUNT);
			value.OneDayTripNearTimes = dataReader.GetInt16(ONE_DAY_TRIP_NEAR_TIMES);
			value.OneDayTripNearAmount = dataReader.GetDecimal(ONE_DAY_TRIP_NEAR_AMOUNT);
			value.OvernightTripTimes = dataReader.GetInt16(OVERNIGHT_TRIP_TIMES);
			value.OvernightTripAmount = dataReader.GetDecimal(OVERNIGHT_TRIP_AMOUNT);
			value.FoodTimes = dataReader.GetInt16(FOOD_TIMES);
			value.FoodAmount = dataReader.GetDecimal(FOOD_AMOUNT);
			value.ExtraTimes = dataReader.GetInt16(EXTRA_TIMES);
			value.ExtraAmount = dataReader.GetDecimal(EXTRA_AMOUNT);
			value.ExtraAGTMonths = dataReader.GetInt16(EXTRA_AGT_MONTHS);
			value.ExtraAGTAmount = dataReader.GetDecimal(EXTRA_AGT_AMOUNT);
			value.AddAGTDays = dataReader.GetInt16(ADD_AGT_DAYS);
			value.AddAGTAmount = dataReader.GetDecimal(ADD_AGT_AMOUNT);
			value.TelephoneAmount = dataReader.GetDecimal(TELEPHONE_AMOUNT);
			value.MiscAmount = dataReader.GetDecimal(MISC_AMOUNT);
            //value.TaxiAmountForCharge = dataReader.GetDecimal(TAXI_AMOUNT_FOR_CHARGE);
            //value.OneDayTripFarAmountForCharge = dataReader.GetDecimal(ONE_DAY_TRIP_FAR_AMOUNT_FOR_CHARGE);
            //value.OneDayTripNearAmountForCharge = dataReader.GetDecimal(ONE_DAY_TRIP_NEAR_AMOUNT_FOR_CHARGE);
            //value.OvernightTripAmountForCharge = dataReader.GetDecimal(OVERNIGHT_TRIP_AMOUNT_FOR_CHARGE);
            //value.MiscAmountForCharge = dataReader.GetDecimal(MISC_AMOUNT_FOR_CHARGE);
        }

		private bool fillEmployeeBenefitAdjustment(ref EmployeeBenefitAdjustment value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				while (dataReader.Read())
				{
					result = true;
					objBenefitAdjustment = new BenefitAdjustment();
					fillBenefitAdjustment(objBenefitAdjustment, value.Company, dataReader);
					value.Add(objBenefitAdjustment);
				}
				objBenefitAdjustment = null;
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

        private bool fillBenefitAdjustment(BenefitAdjustment value, string sql)
        {
            bool result;
            SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
            try
            {
                if (dataReader.Read())
                {
                    fillBenefitAdjustment(value, dataReader);
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

//		============================== Public Method ==============================
		public bool FillEmployeeBenefitAdjustment(ref EmployeeBenefitAdjustment value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Company));
			stringBuilder.Append(getKeyCondition(value.AYearMonth));
			stringBuilder.Append(getOrderby());

			return fillEmployeeBenefitAdjustment(ref value, stringBuilder.ToString());
		}

        public bool FillBenefitAdjustment(BenefitAdjustment value, Company company)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(company));
            stringBuilder.Append(getKeyCondition(value));

            return fillBenefitAdjustment(value, stringBuilder.ToString());
        }

        public bool InsertBenefitAdjustment(BenefitAdjustment value, Company aCompany)
		{
			if (tableAccess.ExecuteSQL(getSQLInsert(value, aCompany))>0)
			{return true;}
			else
			{return false;}	
		}

        public bool UpdateBenefitAdjustment(BenefitAdjustment value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value, aCompany));
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

        public bool DeleteBenefitAdjustment(BenefitAdjustment value, Company aCompany)
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
