using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Entity.AttendanceEntities;
using Entity.AttendanceEntities.BenefitEntities;
using Entity.CommonEntity;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.Time;
using ictus.Common.Entity.General;

using DataAccess.CommonDB;
using DataAccess.PiDB;

using SystemFramework.AppConfig;

namespace DataAccess.AttendanceDB
{
	public class EmployeeOvertimeHourDB: DataAccessBase
	{
		#region - Constant -
			private const int OT_DATE = 0;
			private const int BEFORE_HOUR_FROM_TIME = 1;
			private const int BEFORE_HOUR_TO_TIME = 2;
			private const int DURING_HOUR_FROM_TIME = 3;
			private const int DURING_HOUR_TO_TIME = 4;
			private const int BREAK_HOUR_FROM_TIME = 5;
			private const int BREAK_HOUR_TO_TIME = 6;
			private const int AFTER_HOUR_FROM_TIME = 7;
			private const int AFTER_HOUR_TO_TIME = 8;
			private const int OT_A_HOUR = 9;
			private const int OT_B_HOUR = 10;
			private const int OT_C_HOUR = 11;
			private const int OT_A_HOUR_FOR_CHARGE = 12;
			private const int OT_B_HOUR_FOR_CHARGE = 13;
			private const int OT_C_HOUR_FOR_CHARGE = 14;
			private const int OT_REASON = 15;
		#endregion

		#region - Private -
		private OvertimeHour objOvertimeHour;
		#endregion

		//============================== Constructor ==============================
		public EmployeeOvertimeHourDB() : base()
		{}

		//============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
			return " SELECT OT_Date, Before_Hour_From_Time, Before_Hour_To_Time, During_Hour_From_Time, During_Hour_To_Time, Break_Hour_From_Time, Break_Hour_To_Time, After_Hour_From_Time, After_Hour_To_Time, OT_A_Hour, OT_B_Hour, OT_C_Hour, OT_A_Hour_For_Charge, OT_B_Hour_For_Charge, OT_C_Hour_For_Charge, OT_Reason FROM Employee_Overtime_Hour ";
		}

		private string getSQLInsert(OvertimeHour value, Employee employee)
		{
			StringBuilder stringBuilder = new StringBuilder("INSERT INTO Employee_Overtime_Hour (Company_Code, Employee_No, OT_Date, Before_Hour_From_Time, Before_Hour_To_Time, During_Hour_From_Time, During_Hour_To_Time, Break_Hour_From_Time, Break_Hour_To_Time, After_Hour_From_Time, After_Hour_To_Time, OT_A_Hour, OT_B_Hour, OT_C_Hour, OT_A_Hour_For_Charge, OT_B_Hour_For_Charge, OT_C_Hour_For_Charge, OT_Reason, Process_Date, Process_User) ");
			stringBuilder.Append("VALUES (");

			//Company_Code
			stringBuilder.Append(GetDB(employee.Company.CompanyCode));
			stringBuilder.Append(", ");
			
			//Employee_No
			stringBuilder.Append(GetDB(employee.EmployeeNo));
			stringBuilder.Append(", ");

			//OT_Date
			stringBuilder.Append(GetDB(value.OtDate));
			stringBuilder.Append(", ");

			//Before_Hour_From_Time
			stringBuilder.Append(GetDB(value.ABeforeTimePeriod.From));
			stringBuilder.Append(", ");

			//Before_Hour_To_Time
			stringBuilder.Append(GetDB(value.ABeforeTimePeriod.To));
			stringBuilder.Append(", ");

			//During_Hour_From_Time
			stringBuilder.Append(GetDB(value.ADuringTimePeriod.From));
			stringBuilder.Append(", ");

			//During_Hour_To_Time
			stringBuilder.Append(GetDB(value.ADuringTimePeriod.To));
			stringBuilder.Append(", ");

			//Break_Hour_From_Time
			stringBuilder.Append(GetDB(value.ABreakTimePeriod.From));
			stringBuilder.Append(", ");

			//Break_Hour_To_Time
			stringBuilder.Append(GetDB(value.ABreakTimePeriod.To));
			stringBuilder.Append(", ");

			//After_Hour_From_Time
			stringBuilder.Append(GetDB(value.AAfterTimePeriod.From));
			stringBuilder.Append(", ");

			//After_Hour_To_Time
			stringBuilder.Append(GetDB(value.AAfterTimePeriod.To));
			stringBuilder.Append(", ");

			//OT_A_Hour
			stringBuilder.Append(GetDB(value.AOTRate.OtAHour));
			stringBuilder.Append(", ");

			//OT_B_Hour
			stringBuilder.Append(GetDB(value.AOTRate.OtBHour));
			stringBuilder.Append(", ");

			//OT_C_Hour
			stringBuilder.Append(GetDB(value.AOTRate.OtCHour));
			stringBuilder.Append(", ");

			//OT_A_Hour_For_Charge
			stringBuilder.Append(GetDB(value.AOTRateForCharge.OtAHour));
			stringBuilder.Append(", ");
			
			//OT_B_Hour_For_Charge
			stringBuilder.Append(GetDB(value.AOTRateForCharge.OtBHour));
			stringBuilder.Append(", ");
			
			//OT_C_Hour_For_Charge
			stringBuilder.Append(GetDB(value.AOTRateForCharge.OtCHour));
			stringBuilder.Append(", ");

			//OT_Reason
			stringBuilder.Append(GetDB(value.OtReason));
			stringBuilder.Append(", ");

			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(")");

			return stringBuilder.ToString();
		}

		private string getSQLDelete()
		{
			return " DELETE FROM Employee_Overtime_Hour ";
		}

		private string getKeyCondition(OvertimeHour value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if(IsNotNULL(value.OtDate))
			{
				stringBuilder.Append(" AND (OT_Date = ");
				stringBuilder.Append(GetDB(value.OtDate));
				stringBuilder.Append(")");
			}
			return stringBuilder.ToString();
		}
		
		private string getListCondition(YearMonth value)
		{
			return " AND " +  SqlFunction.GetYearMonthCondition("OT_Date", value);
		}

		private string getOrderby()
		{
			return " ORDER BY Employee_No, OT_Date ";
		}
		#endregion

		#region - Fill -
		private void fillOvertimeHour(ref OvertimeHour value, SqlDataReader dataReader)
		{
			value.OtDate = dataReader.GetDateTime(OT_DATE);
			if (dataReader.IsDBNull(BEFORE_HOUR_FROM_TIME))
			{
				value.ABeforeTimePeriod.From = NullConstant.DATETIME;
			}
			else
			{
				value.ABeforeTimePeriod.From = dataReader.GetDateTime(BEFORE_HOUR_FROM_TIME);
			}
			if (dataReader.IsDBNull(BEFORE_HOUR_TO_TIME))
			{
				value.ABeforeTimePeriod.To = NullConstant.DATETIME;
			}
			else
			{
				value.ABeforeTimePeriod.To = dataReader.GetDateTime(BEFORE_HOUR_TO_TIME);
			}
			if (dataReader.IsDBNull(DURING_HOUR_FROM_TIME))
			{
				value.ADuringTimePeriod.From = NullConstant.DATETIME;
			}
			else
			{
				value.ADuringTimePeriod.From = dataReader.GetDateTime(DURING_HOUR_FROM_TIME);
			}
			if (dataReader.IsDBNull(DURING_HOUR_TO_TIME))
			{
				value.ADuringTimePeriod.To = NullConstant.DATETIME;
			}
			else
			{
				value.ADuringTimePeriod.To = dataReader.GetDateTime(DURING_HOUR_TO_TIME);
			}			
			if (dataReader.IsDBNull(BREAK_HOUR_FROM_TIME))
			{
				value.ABreakTimePeriod.From = NullConstant.DATETIME;
			}
			else
			{
				value.ABreakTimePeriod.From = dataReader.GetDateTime(BREAK_HOUR_FROM_TIME);
			}			
			if (dataReader.IsDBNull(BREAK_HOUR_TO_TIME))
			{
				value.ABreakTimePeriod.To = NullConstant.DATETIME;
			}
			else
			{
				value.ABreakTimePeriod.To = dataReader.GetDateTime(BREAK_HOUR_TO_TIME);
			}
			if (dataReader.IsDBNull(AFTER_HOUR_FROM_TIME))
			{
				value.AAfterTimePeriod.From = NullConstant.DATETIME;
			}
			else
			{
				value.AAfterTimePeriod.From = dataReader.GetDateTime(AFTER_HOUR_FROM_TIME);
			}			
			if (dataReader.IsDBNull(AFTER_HOUR_TO_TIME))
			{
				value.AAfterTimePeriod.To = NullConstant.DATETIME;
			}
			else
			{
				value.AAfterTimePeriod.To = dataReader.GetDateTime(AFTER_HOUR_TO_TIME);
			}			
			value.AOTRate.OtAHour = dataReader.GetDecimal(OT_A_HOUR);
			value.AOTRate.OtBHour = dataReader.GetDecimal(OT_B_HOUR);
			value.AOTRate.OtCHour = dataReader.GetDecimal(OT_C_HOUR);
			value.AOTRateForCharge.OtAHour = dataReader.GetDecimal(OT_A_HOUR_FOR_CHARGE);
			value.AOTRateForCharge.OtBHour = dataReader.GetDecimal(OT_B_HOUR_FOR_CHARGE);
			value.AOTRateForCharge.OtCHour = dataReader.GetDecimal(OT_C_HOUR_FOR_CHARGE);
			value.OtReason = (string)dataReader[OT_REASON];
		}

		private bool fillEmployeeOvertimeHour(ref EmployeeOvertimeHour value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				while (dataReader.Read())
				{
					result = true;
					objOvertimeHour = new OvertimeHour();
					fillOvertimeHour(ref objOvertimeHour, dataReader);
					value.Add(objOvertimeHour);
				}
				objOvertimeHour = null;
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

		private bool fillOvertimeHour(ref OvertimeHour value, string sql)
		{
			bool result;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				if (dataReader.Read())
				{					
					fillOvertimeHour(ref value, dataReader);
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
		
		private void fillBenefitOTHour(BenefitOTHour value, SqlDataReader dataReader)
		{
			value.SetBenefitDate(dataReader.GetDateTime(OT_DATE));
			if (dataReader.IsDBNull(BEFORE_HOUR_FROM_TIME))
			{
				value.BeforeTime.From = NullConstant.DATETIME;
			}
			else
			{
				value.BeforeTime.From = dataReader.GetDateTime(BEFORE_HOUR_FROM_TIME);
			}
			if (dataReader.IsDBNull(BEFORE_HOUR_TO_TIME))
			{
				value.BeforeTime.To = NullConstant.DATETIME;
			}
			else
			{
				value.BeforeTime.To = dataReader.GetDateTime(BEFORE_HOUR_TO_TIME);
			}
			if (dataReader.IsDBNull(DURING_HOUR_FROM_TIME))
			{
				value.DuringTime1.From = NullConstant.DATETIME;
			}
			else
			{
				value.DuringTime1.From = dataReader.GetDateTime(DURING_HOUR_FROM_TIME);
			}
			value.DuringTime1.To = NullConstant.DATETIME;
			value.DuringTime2.From = NullConstant.DATETIME;
			if (dataReader.IsDBNull(DURING_HOUR_TO_TIME))
			{
				value.DuringTime2.To = NullConstant.DATETIME;
			}
			else
			{
				value.DuringTime2.To = dataReader.GetDateTime(DURING_HOUR_TO_TIME);
			}			
			if (dataReader.IsDBNull(BREAK_HOUR_FROM_TIME))
			{
				value.BreakTime.From = NullConstant.DATETIME;
			}
			else
			{
				value.BreakTime.From = dataReader.GetDateTime(BREAK_HOUR_FROM_TIME);
			}			
			if (dataReader.IsDBNull(BREAK_HOUR_TO_TIME))
			{
				value.BreakTime.To = NullConstant.DATETIME;
			}
			else
			{
				value.BreakTime.To = dataReader.GetDateTime(BREAK_HOUR_TO_TIME);
			}
			if (dataReader.IsDBNull(AFTER_HOUR_FROM_TIME))
			{
				value.AfterTime.From = NullConstant.DATETIME;
			}
			else
			{
				value.AfterTime.From = dataReader.GetDateTime(AFTER_HOUR_FROM_TIME);
			}			
			if (dataReader.IsDBNull(AFTER_HOUR_TO_TIME))
			{
				value.AfterTime.To = NullConstant.DATETIME;
			}
			else
			{
				value.AfterTime.To = dataReader.GetDateTime(AFTER_HOUR_TO_TIME);
			}			
			value.OTRate.OtAHour = dataReader.GetDecimal(OT_A_HOUR);
			value.OTRate.OtBHour = dataReader.GetDecimal(OT_B_HOUR);
			value.OTRate.OtCHour = dataReader.GetDecimal(OT_C_HOUR);
			value.OTRateForCharge.OtAHour = dataReader.GetDecimal(OT_A_HOUR_FOR_CHARGE);
			value.OTRateForCharge.OtBHour = dataReader.GetDecimal(OT_B_HOUR_FOR_CHARGE);
			value.OTRateForCharge.OtCHour = dataReader.GetDecimal(OT_C_HOUR_FOR_CHARGE);
			value.Reason = (string)dataReader[OT_REASON];
		}

		private bool fillBenefitOTHourList(BenefitOTHourList value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				BenefitOTHour benefitOTHour;
				while (dataReader.Read())
				{
					result = true;	
					benefitOTHour = new BenefitOTHour();
					fillBenefitOTHour(benefitOTHour, dataReader);
					value.Add(benefitOTHour);
				}
				benefitOTHour = null;
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
		#endregion

//		============================== Public Method ==============================
		public bool FillEmployeeOvertimeHour(ref EmployeeOvertimeHour value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Employee));
			stringBuilder.Append(getListCondition(value.AYearMonth));
			stringBuilder.Append(getOrderby());

			return fillEmployeeOvertimeHour(ref value, stringBuilder.ToString());
		}

		public bool FillBenefitOTHourList(BenefitOTHourList value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Employee));
			stringBuilder.Append(getListCondition(value.ForMonth));
			stringBuilder.Append(getOrderby());

			return fillBenefitOTHourList(value, stringBuilder.ToString());
		}
		
		public bool FillOvertimeHour(ref OvertimeHour value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(aEmployee));
			stringBuilder.Append(getKeyCondition(value));

			return fillOvertimeHour(ref value, stringBuilder.ToString());
		}

		public bool InsertEmployeeOvertimeHour(EmployeeOvertimeHour value)
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

		public bool UpdateEmployeeOvertimeHour(EmployeeOvertimeHour value)
		{
			StringBuilder stringBuilder = new StringBuilder("BEGIN ");

			stringBuilder.Append(getSQLDelete());
			stringBuilder.Append(getBaseCondition(value.Employee));
			stringBuilder.Append(getListCondition(value.AYearMonth));

			for(int i=0; i<value.Count; i++)
			{				
				stringBuilder.Append(getSQLInsert(value[i], value.Employee));
				stringBuilder.Append(";");
			}
			stringBuilder.Append(" END;");
	
			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0 || value.Count==0)
			{return true;}
			else
			{return false;}	
		}

		public bool DeleteEmployeeOvertimeHour(EmployeeOvertimeHour value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(value.Employee));
			stringBuilder.Append(getListCondition(value.AYearMonth));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}	
		}


//		================================= Process OTWorkSchedule =================================
		private string getSQLUpdate(WorkSchedule value)
		{
			StringBuilder stringBuilder = new StringBuilder("UPDATE Employee_Overtime_Hour SET ");
			
			stringBuilder.Append("During_Hour_From_Time = ");
			stringBuilder.Append(GetDB(value.AWorkingTime.From));
			stringBuilder.Append(", ");

			stringBuilder.Append("During_Hour_To_Time = ");
			stringBuilder.Append(GetDB(value.AWorkingTime.To));
		
			return stringBuilder.ToString();		
		}

        public bool ProcessOTWorkSchedule(ictus.Common.Entity.Company value)
		{			
			bool result = true;
			string employeeNo;
			DateTime otDate;

			EmployeeWorkScheduleDB dbEmployeeWorkSchedule = new EmployeeWorkScheduleDB();
			WorkSchedule objWorkSchedule;
			Employee objEmployee;

			StringBuilder stringBuilder = new StringBuilder();

			try
			{
				StringBuilder tmpStringBuilder = new StringBuilder(" SELECT Employee_No, OT_Date FROM Employee_Overtime_Hour ");
				tmpStringBuilder.Append(getBaseCondition(value));
				tmpStringBuilder.Append("AND During_Hour_From_Time IS NULL AND During_Hour_From_Time IS NULL");

				SqlDataReader dataReader = tableAccess.ExecuteDataReader(tmpStringBuilder.ToString());
				tmpStringBuilder = null;

				while (dataReader.Read())
				{
					employeeNo = (string)dataReader[0];
					otDate = dataReader.GetDateTime(1);

					objEmployee = new Employee(employeeNo, value);
					objWorkSchedule = new WorkSchedule();
					objWorkSchedule.WorkDate = otDate;

					if(dbEmployeeWorkSchedule.FillWorkSchedule(ref objWorkSchedule, objEmployee))
					{
						stringBuilder.Append(getSQLUpdate(objWorkSchedule));
						stringBuilder.Append(getBaseCondition(objEmployee));
						stringBuilder.Append(" AND (OT_Date = ");
						stringBuilder.Append(GetDB(objWorkSchedule.WorkDate));
						stringBuilder.Append(")");
					}
				}
			}
			catch(IndexOutOfRangeException ein)
			{
				throw ein;
			}
			finally
			{
				tableAccess.CloseDataReader();				
			}

			result &= (tableAccess.ExecuteSQL(stringBuilder.ToString())>0);
			return result;
		}
	}
}