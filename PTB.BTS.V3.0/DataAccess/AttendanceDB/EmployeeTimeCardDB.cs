using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.Time;

using Entity.AttendanceEntities;
using Entity.CommonEntity;

using DataAccess.CommonDB;

using SystemFramework.AppConfig;

using ictus.Common.Entity;

namespace DataAccess.AttendanceDB
{
	public class EmployeeTimeCardDB : DataAccessBase
	{
		#region - Constant -
		private const int EMPLOYEE_NO = 0;
		private const int FOR_DATE = 1;
		private const int DAY_TYPE = 2;
		private const int TIME_IN = 3;
		private const int TIME_OUT = 4;
		private const int BEFORE_BREAK_STATUS = 5;
		private const int AFTER_BREAK_STATUS = 6;
		#endregion

		#region - Private -
		private TimeCard objTimeCard;
		private AttendanceStatusDB dbAttendanceStatus;
		private bool disposed = false;
		#endregion

//		============================== Constructor ==============================
		public EmployeeTimeCardDB() : base()
		{
			dbAttendanceStatus = new AttendanceStatusDB();
		}

//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
			return "SELECT  Employee_No, For_Date, Day_Type, Time_In, Time_Out, Before_Break_Status, After_Break_Status FROM Employee_Time_Card ";
		}

		private string getSQLInsert(TimeCard value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder("INSERT INTO Employee_Time_Card (Company_Code, Employee_No, For_Date, Day_Type, Time_In, Time_Out, Before_Break_Status, After_Break_Status, Process_Date, Process_User) ");
			stringBuilder.Append("VALUES (");

			//Company_Code
			stringBuilder.Append(GetDB(aEmployee.Company.CompanyCode));
			stringBuilder.Append(", ");

			//Employee_No
			stringBuilder.Append(GetDB(aEmployee.EmployeeNo));
			stringBuilder.Append(", ");

			//For_Date
			stringBuilder.Append(GetDB(value.CardDate));
			stringBuilder.Append(", ");

			//Day_Type
			stringBuilder.Append(GetDB(value.DayType));
			stringBuilder.Append(", ");

			//Time_In
			stringBuilder.Append(GetDB(value.ATimePeriod.From));
			stringBuilder.Append(", ");

			//Time_Out
			stringBuilder.Append(GetDB(value.ATimePeriod.To));
			stringBuilder.Append(", ");

			//Before_Break_Status
			stringBuilder.Append(GetDB(value.ABeforeBreakStatus.Code));
			stringBuilder.Append(", ");

			//After_Break_Status
			stringBuilder.Append(GetDB(value.AAfterBreakStatus.Code));
			stringBuilder.Append(", ");

			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(")");

			return stringBuilder.ToString();			
		}

		private string getSQLUpdate(TimeCard value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder("UPDATE Employee_Time_Card SET ");
			
			stringBuilder.Append("Company_Code = ");
			stringBuilder.Append(GetDB(aEmployee.Company.CompanyCode));
			stringBuilder.Append(", ");

			stringBuilder.Append("Employee_No = ");
			stringBuilder.Append(GetDB(aEmployee.EmployeeNo));
			stringBuilder.Append(", ");

			stringBuilder.Append("For_Date = ");
			stringBuilder.Append(GetDB(value.CardDate));
			stringBuilder.Append(", ");

			stringBuilder.Append("Day_Type = ");
			stringBuilder.Append(GetDB(value.DayType));
			stringBuilder.Append(", ");

			stringBuilder.Append("Time_In = ");
			stringBuilder.Append(GetDB(value.ATimePeriod.From));
			stringBuilder.Append(", ");

			stringBuilder.Append("Time_Out = ");
			stringBuilder.Append(GetDB(value.ATimePeriod.To));
			stringBuilder.Append(", ");

			stringBuilder.Append("Before_Break_Status = ");
			stringBuilder.Append(GetDB(value.ABeforeBreakStatus.Code));
			stringBuilder.Append(", ");

			stringBuilder.Append("After_Break_Status = ");
			stringBuilder.Append(GetDB(value.AAfterBreakStatus.Code));
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
			return " DELETE FROM Employee_Time_Card ";
		}

		private string getListCondition(YearMonth value)
		{
			StringBuilder stringBuilder = new StringBuilder(" AND ");
			stringBuilder.Append(SqlFunction.GetYearMonthCondition("For_Date", value));
			return stringBuilder.ToString();
		}

		private string getKeyCondition(TimeCard value)
		{
			StringBuilder stringBuilder = new StringBuilder();

			if ((value != null)&&(IsNotNULL(value.CardDate)))
			{
				stringBuilder.Append(" AND (For_Date = ");
				stringBuilder.Append(GetDB(value.CardDate));
				stringBuilder.Append(")");
			}

			return stringBuilder.ToString();
		}

		private string getBenefitCondition()
		{
			return " AND ((Before_Break_Status NOT IN ('WK', 'L1', 'L2', 'H1', '', 'F1')) OR (After_Break_Status NOT IN ('WK', 'L1', 'L2', 'H1','', 'F1'))) ";
		}

		private string getOrderby()
		{
			return " ORDER BY Employee_No, For_Date ";
		}
		#endregion

		#region - Fill -
		private void fillTimeCard(ref TimeCard value, Company aCompany, SqlDataReader dataReader)
		{
			value.CardDate = dataReader.GetDateTime(FOR_DATE);
			value.DayType = CTFunction.GetDayType((string)dataReader[DAY_TYPE]);
			value.ATimePeriod.From = dataReader.GetDateTime(TIME_IN);
			value.ATimePeriod.To = dataReader.GetDateTime(TIME_OUT);
			value.ABeforeBreakStatus = (AttendanceStatus)dbAttendanceStatus.GetDBDualField((string)dataReader[BEFORE_BREAK_STATUS], aCompany);
			value.AAfterBreakStatus = (AttendanceStatus)dbAttendanceStatus.GetDBDualField((string)dataReader[AFTER_BREAK_STATUS], aCompany);
		}

		private void fillTimeCardDB(ref TimeCard value, Company aCompany, SqlDataReader dataReader)
		{
			value.ABeforeBreakStatus = (AttendanceStatus)dbAttendanceStatus.GetDBDualField((string)dataReader[BEFORE_BREAK_STATUS], aCompany);
			value.AAfterBreakStatus = (AttendanceStatus)dbAttendanceStatus.GetDBDualField((string)dataReader[AFTER_BREAK_STATUS], aCompany);
			fillTimeCard(ref value, aCompany, dataReader);
		}
		
		private bool fillTimeCardList(ref EmployeeTimeCard value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			AttendanceStatusList listAttendanceStatus = new AttendanceStatusList(value.Company);
			dbAttendanceStatus.FillMTBList(listAttendanceStatus);

			try
			{
				while (dataReader.Read())
				{
					result = true;
					objTimeCard = new TimeCard();
					objTimeCard.ABeforeBreakStatus = listAttendanceStatus[(string)dataReader[BEFORE_BREAK_STATUS]];
					objTimeCard.AAfterBreakStatus = listAttendanceStatus[(string)dataReader[AFTER_BREAK_STATUS]];
					fillTimeCard(ref objTimeCard, value.Company, dataReader);
					value.Add(objTimeCard);
				}
				objTimeCard = null;
			}
			catch (IndexOutOfRangeException ein)
			{throw ein;}

			finally
			{
				tableAccess.CloseDataReader();
				listAttendanceStatus = null;
				dataReader = null;
			}			
			return result;				
		}

		private bool fillTimeCard(ref TimeCard value, Company aCompany, string sql)
		{
			bool result;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				if (dataReader.Read())
				{					
					fillTimeCardDB(ref value, aCompany, dataReader);
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
		public TimeCard GetTimeCard(DateTime cardDate, Employee aEmployee)
		{
			objTimeCard = new TimeCard();
			objTimeCard.CardDate = cardDate;
			if(FillTimeCard(ref objTimeCard, aEmployee))
			{
				return objTimeCard;
			}
			else
			{
				objTimeCard = null;
				return null;
			}
		}

		public bool FillTimeCardList(ref EmployeeTimeCard value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Employee));
			stringBuilder.Append(getListCondition(value.AYearMonth));
			stringBuilder.Append(getOrderby());
			return fillTimeCardList(ref value, stringBuilder.ToString());
		}

		public bool FillTimeCardBenefitList(ref EmployeeTimeCard value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Employee));
			stringBuilder.Append(getListCondition(value.AYearMonth));
			stringBuilder.Append(getBenefitCondition());
			stringBuilder.Append(getOrderby());
			return fillTimeCardList(ref value, stringBuilder.ToString());
		}

		public bool FillTimeCard(ref TimeCard value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(aEmployee));
			stringBuilder.Append(getKeyCondition(value));
			return fillTimeCard(ref value, aEmployee.Company, stringBuilder.ToString());
		}

		
		public bool InsertTimeCard(TimeCard value, Employee aEmployee)
		{
			if (tableAccess.ExecuteSQL(getSQLInsert(value, aEmployee))>0)
			{return true;}
			else
			{return false;}	
		}

		public bool InsertTimeCard(EmployeeTimeCard value)
		{
			StringBuilder stringBuilder = new StringBuilder("BEGIN ");
			for(int i=0; i<value.Count; i++)
			{				
				stringBuilder.Append(getSQLInsert(value[i], value.Employee));
				stringBuilder.Append(";");
			}
			stringBuilder.Append(" END;");
	
			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}	
		}

		public bool UpdateTimeCard(TimeCard value, Employee employee)
		{
			StringBuilder stringBuilder = new StringBuilder("BEGIN ");

			stringBuilder.Append(getSQLDelete());
			stringBuilder.Append(getBaseCondition(employee));
			stringBuilder.Append(getKeyCondition(value));
			stringBuilder.Append(";");

			stringBuilder.Append(getSQLInsert(value, employee));
			stringBuilder.Append(";");

			stringBuilder.Append(" END;");

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool UpdateEmployeeTimeCard(EmployeeTimeCard value)
		{
			StringBuilder stringBuilder = new StringBuilder("BEGIN ");
			for(int i=0; i<value.Count; i++)
			{
				stringBuilder.Append(getSQLDelete());
				stringBuilder.Append(getBaseCondition(value.Employee));
				stringBuilder.Append(getKeyCondition(value[i]));
				stringBuilder.Append(";");

				stringBuilder.Append(getSQLInsert(value[i], value.Employee));
				stringBuilder.Append(";");
			}
			stringBuilder.Append(" END;");
				
			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool DeleteTimeCard(TimeCard value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(aEmployee));
			stringBuilder.Append(getKeyCondition(value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}


		public bool DeleteTimeCard(Employee aEmployee, YearMonth aYearMonth)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(aEmployee));
			stringBuilder.Append(getListCondition(aYearMonth));
	
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