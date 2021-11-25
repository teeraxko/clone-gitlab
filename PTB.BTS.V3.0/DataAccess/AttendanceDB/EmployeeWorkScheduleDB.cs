using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.Time;

using Entity.AttendanceEntities;
using Entity.AttendanceEntities.BenefitEntities;
using Entity.CommonEntity;

using DataAccess.CommonDB;

using SystemFramework.AppConfig;

namespace DataAccess.AttendanceDB
{
	public class EmployeeWorkScheduleDB : DataAccessBase
	{
		#region - Constant -
		private const int FOR_DATE = 0;
		private const int DAY_TYPE = 1;
		private const int START_WORKING_TIME = 2;
		private const int END_WORKING_TIME = 3;
		private const int START_BREAK_TIME = 4;
		private const int END_BREAK_TIME = 5;
		#endregion

		#region - Private -
			private WorkSchedule objWorkSchedule;
			private bool disposed = false;
		#endregion

//		============================== Constructor ==============================
		public EmployeeWorkScheduleDB() : base()
		{
		}
//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
			return "SELECT For_Date, Day_Type, Start_Working_Time, End_Working_Time, Start_Break_Time, End_Break_Time FROM Employee_Work_Schedule ";
		}

		private string getSQLInsert(WorkSchedule value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder("INSERT INTO Employee_Work_Schedule (Company_Code, Employee_No, For_Date, Day_Type, Start_Working_Time, End_Working_Time, Start_Break_Time, End_Break_Time, Process_Date, Process_User) ");
			stringBuilder.Append("VALUES (");

			//Company_Code
			stringBuilder.Append(GetDB(aEmployee.Company.CompanyCode));
			stringBuilder.Append(", ");

			//Employee_No
			stringBuilder.Append(GetDB(aEmployee.EmployeeNo));
			stringBuilder.Append(", ");

			//For_Date
			stringBuilder.Append(GetDB(value.WorkDate));
			stringBuilder.Append(", ");

			//Day_Type
			stringBuilder.Append(GetDB(value.DayType));
			stringBuilder.Append(", ");

			//Start_Working_Time
			stringBuilder.Append(GetDB(value.AWorkingTime.From));
			stringBuilder.Append(", ");

			//End_Working_Time
			stringBuilder.Append(GetDB(value.AWorkingTime.To));
			stringBuilder.Append(", ");

			//Start_Break_Time
			stringBuilder.Append(GetDB(value.ABreakTime.From));
			stringBuilder.Append(", ");

			//End_Break_Time
			stringBuilder.Append(GetDB(value.ABreakTime.To));
			stringBuilder.Append(", ");

			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(")");

			return stringBuilder.ToString();			
		}

		private string getSQLUpdate(WorkSchedule value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder("UPDATE Employee_Work_Schedule SET ");
			
			stringBuilder.Append("Company_Code = ");
			stringBuilder.Append(GetDB(aEmployee.Company.CompanyCode));
			stringBuilder.Append(", ");

			stringBuilder.Append("Employee_No = ");
			stringBuilder.Append(GetDB(aEmployee.EmployeeNo));
			stringBuilder.Append(", ");

			stringBuilder.Append("For_Date = ");
			stringBuilder.Append(GetDB(value.WorkDate));
			stringBuilder.Append(", ");

			stringBuilder.Append("Day_Type = ");
			stringBuilder.Append(GetDB(value.DayType));
			stringBuilder.Append(", ");

			stringBuilder.Append("Start_Working_Time = ");
			stringBuilder.Append(GetDB(value.AWorkingTime.From));
			stringBuilder.Append(", ");

			stringBuilder.Append("End_Working_Time = ");
			stringBuilder.Append(GetDB(value.AWorkingTime.To));
			stringBuilder.Append(", ");

			stringBuilder.Append("Start_Break_Time = ");
			stringBuilder.Append(GetDB(value.ABreakTime.From));
			stringBuilder.Append(", ");

			stringBuilder.Append("End_Break_Time = ");
			stringBuilder.Append(GetDB(value.ABreakTime.To));
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
			return " DELETE FROM Employee_Work_Schedule ";
		}

		private string getListCondition(YearMonth value)
		{
			StringBuilder stringBuilder = new StringBuilder(" AND ");
			stringBuilder.Append(SqlFunction.GetYearMonthCondition("For_Date", value));
			return stringBuilder.ToString();
		}

		private string getKeyCondition(WorkSchedule value)
		{
			StringBuilder stringBuilder = new StringBuilder();

			if ((value != null)&&(IsNotNULL(value.WorkDate)))
			{
				stringBuilder.Append(" AND (For_Date = ");
				stringBuilder.Append(GetDB(value.WorkDate));
				stringBuilder.Append(")");
			}

			return stringBuilder.ToString();
		}

		private string getOrderby()
		{
			return " ORDER BY Employee_No, For_Date ";
		}
		#endregion

		#region - Fill -
		private void fillWorkSchedule(WorkSchedule value, SqlDataReader dataReader)
		{
			//			value.WorkDate = dataReader.GetDateTime(FOR_DATE);
			//			value.DayType = CTFunction.GetDayType((string)dataReader[DAY_TYPE]);
			//			TimeConstant DTConst = new TimeConstant();
			//			value.AWorkingTime.From = DTConst.ChangeHourMinute(dataReader.GetDateTime(START_WORKING_TIME));
			//			value.AWorkingTime.To = DTConst.ChangeHourMinute(dataReader.GetDateTime(END_WORKING_TIME));
			//			value.ABreakTime.From = DTConst.ChangeHourMinute(dataReader.GetDateTime(START_BREAK_TIME));
			//			value.ABreakTime.To = DTConst.ChangeHourMinute(dataReader.GetDateTime(END_BREAK_TIME));			

			value.WorkDate = dataReader.GetDateTime(FOR_DATE);
			value.DayType = CTFunction.GetDayType((string)dataReader[DAY_TYPE]);
			value.AWorkingTime.From = dataReader.GetDateTime(START_WORKING_TIME);
			value.AWorkingTime.To = dataReader.GetDateTime(END_WORKING_TIME);
			value.ABreakTime.From = dataReader.GetDateTime(START_BREAK_TIME);
			value.ABreakTime.To = dataReader.GetDateTime(END_BREAK_TIME);
		}

		private bool fillBenefitWorkInfoList(WorkInfoList value, string sql)
		{
			bool result = false;
			WorkSchedule workSchedule;
			WorkInfo workInfo;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				while (dataReader.Read())
				{
					result = true;
					workSchedule = new WorkSchedule();
					fillWorkSchedule(workSchedule, dataReader);
					workInfo = new WorkInfo(workSchedule);
					value.Add(workInfo);
				}
			}
			catch (IndexOutOfRangeException ein)
			{throw ein;}

			finally
			{tableAccess.CloseDataReader();}			
			return result;				
		}
		
		private bool fillWorkScheduleList(ref EmployeeWorkSchedule value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				while (dataReader.Read())
				{
					result = true;
					objWorkSchedule = new WorkSchedule();
					fillWorkSchedule(objWorkSchedule, dataReader);
					value.Add(objWorkSchedule);
				}
			}
			catch (IndexOutOfRangeException ein)
			{throw ein;}

			finally
			{tableAccess.CloseDataReader();}			
			return result;				
		}

		private bool fillWorkSchedule(ref WorkSchedule value, string sql)
		{
			bool result;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				if (dataReader.Read())
				{					
					fillWorkSchedule(value, dataReader);
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
		public WorkSchedule GetWorkSchedule(Employee aEmployee, DateTime forDate)
		{
			objWorkSchedule = new WorkSchedule();
			objWorkSchedule.WorkDate = forDate;
			if(FillWorkSchedule(ref objWorkSchedule, aEmployee))
			{
				return objWorkSchedule;
			}
			else
			{
				objWorkSchedule = null;
				return null;
			}
		}

		public bool FillWorkSchedule(ref WorkSchedule value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(aEmployee));
			stringBuilder.Append(getKeyCondition(value));
			return fillWorkSchedule(ref value, stringBuilder.ToString());
		}

		public bool FillWorkScheduleList(ref EmployeeWorkSchedule value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Employee));
			stringBuilder.Append(getListCondition(value.ForYearMonth));
			stringBuilder.Append(getOrderby());
			return fillWorkScheduleList(ref value, stringBuilder.ToString());
		}

		public bool FillBenefitWorkInfoList(WorkInfoList value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Employee));
			stringBuilder.Append(getListCondition(value.ForMonth));
			stringBuilder.Append(getOrderby());
			return fillBenefitWorkInfoList(value, stringBuilder.ToString());
		}
		
		public bool InsertWorkSchedule(WorkSchedule aWorkSchedule, Employee aEmployee)
		{
			if (tableAccess.ExecuteSQL(getSQLInsert(aWorkSchedule, aEmployee))>0)
			{return true;}
			else
			{return false;}	
		}

		public bool InsertWorkSchedule(EmployeeWorkSchedule value)
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

		public bool UpdateWorkSchedule(WorkSchedule value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value, aEmployee));
			stringBuilder.Append(getBaseCondition(aEmployee));
			stringBuilder.Append(getKeyCondition(value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}


		public bool DeleteWorkSchedule(WorkSchedule value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(aEmployee));
			stringBuilder.Append(getKeyCondition(value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}


		public bool DeleteWorkSchedule(Employee aEmployee, YearMonth aYearMonth)
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
						objWorkSchedule = null;
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
