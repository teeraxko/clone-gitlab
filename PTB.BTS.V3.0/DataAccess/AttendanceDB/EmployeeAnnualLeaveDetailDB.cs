using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Entity.CommonEntity;
using ictus.PIS.PI.Entity;
using Entity.AttendanceEntities;

using DataAccess.PiDB;
using DataAccess.CommonDB;

using SystemFramework.AppConfig;

namespace DataAccess.AttendanceDB
{
	public class EmployeeAnnualLeaveDetailDB : DataAccessBase
	{
		#region - Constant -
			private const int EMPLOYEE_NO = 0;
			private const int FOR_YEAR = 1;
			private const int LEAVE_DATE = 2;
			private const int PERIOD_STATUS = 3;
			private const int LEAVE_YEAR_STATUS = 4; 
			private const int LEAVE_REASON = 5;
		#endregion

		#region - Private -
		#endregion

		//============================== Constructor ==============================
		public EmployeeAnnualLeaveDetailDB() : base()
		{
		}

		//============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
			return " SELECT Employee_No, For_Year, Leave_Date, Period_Status, Leave_Year_Status, Leave_Reason FROM Employee_Annual_Leave_Detail ";
		}

		private string getSQLInsert(AnnualLeaveDay value, Employee employee)
		{
			StringBuilder stringBuilder = new StringBuilder("INSERT INTO Employee_Annual_Leave_Detail (Company_Code, Employee_No, For_Year, Leave_Date, Period_Status, Leave_Year_Status, Leave_Reason, Process_Date, Process_User) ");
			stringBuilder.Append("VALUES (");

			//Company_Code
			stringBuilder.Append(GetDB(employee.Company.CompanyCode));
			stringBuilder.Append(", ");

			//Employee_No
			stringBuilder.Append(GetDB(employee.EmployeeNo));
			stringBuilder.Append(", ");

			//For_Year
			stringBuilder.Append(GetDB(value.ForYear));
			stringBuilder.Append(", ");	

			//Leave_Date
			stringBuilder.Append(GetDB(value.LeaveDate));
			stringBuilder.Append(", ");		

			//Period_Status
			stringBuilder.Append(GetDB(value.PeriodStatus));
			stringBuilder.Append(", ");

			//Leave_Year_Status
			stringBuilder.Append(GetDB(value.LeaveYearStatus));
			stringBuilder.Append(", ");

			//Leave_Reason
			stringBuilder.Append(GetDB(value.Reason.Name));
			stringBuilder.Append(", ");

			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(")");

			return stringBuilder.ToString();
		}

		private string getSQLUpdate(AnnualLeaveDay value, Employee employee)
		{
			StringBuilder stringBuilder = new StringBuilder("UPDATE Employee_Annual_Leave_Detail SET ");

			stringBuilder.Append(" Company_Code = ");
			stringBuilder.Append(GetDB(employee.Company.CompanyCode));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Employee_No = ");
			stringBuilder.Append(GetDB(employee.EmployeeNo));
			stringBuilder.Append(", ");

			stringBuilder.Append(" For_Year = ");
			stringBuilder.Append(GetDB(value.ForYear));
			stringBuilder.Append(", ");	

			stringBuilder.Append(" Leave_Date = ");
			stringBuilder.Append(GetDB(value.LeaveDate));
			stringBuilder.Append(", ");		

			stringBuilder.Append(" Period_Status = ");
			stringBuilder.Append(GetDB(value.PeriodStatus));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Leave_Year_Status = ");
			stringBuilder.Append(GetDB(value.LeaveYearStatus));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Leave_Reason = ");
			stringBuilder.Append(GetDB(value.Reason.Name));
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
			return " DELETE FROM Employee_Annual_Leave_Detail ";
		}

		private string getKeyCondition(AnnualLeaveDay value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if(IsNotNULL(value.ForYear))
			{
				stringBuilder.Append(" AND (For_Year = ");
				stringBuilder.Append(GetDB(value.ForYear));
				stringBuilder.Append(")");
			}
			if(IsNotNULL(value.LeaveDate))
			{
				stringBuilder.Append(" AND (Leave_Date = ");
				stringBuilder.Append(GetDB(value.LeaveDate));
				stringBuilder.Append(")");
			}
			return stringBuilder.ToString();
		}

		private string getKeyCondition(AnnualLeaveYear value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if(IsNotNULL(value.ForYear))
			{
				stringBuilder.Append(" AND (For_Year = ");
				stringBuilder.Append(GetDB(value.ForYear));
				stringBuilder.Append(")");
			}
			return stringBuilder.ToString();
		}

		private string getOrderby()
		{
			return " ORDER BY For_Year, Leave_Date ";
		}
		#endregion

		#region - fill -
		private void fillAnnualLeaveDay(ref AnnualLeaveDay value, SqlDataReader dataReader)
		{
			value.ForYear = dataReader.GetInt16(FOR_YEAR);
			value.LeaveDate = dataReader.GetDateTime(LEAVE_DATE);
			value.PeriodStatus = CTFunction.GetLeavePeriodType((string)dataReader[PERIOD_STATUS]);
			value.LeaveYearStatus = CTFunction.GetLeaveYearStatusType((string)dataReader[LEAVE_YEAR_STATUS]);
			value.Reason.Name = (string)dataReader[LEAVE_REASON];
		}

		private bool fillEmployeeAnnualLeaveDetail(ref AnnualLeaveYear value, string sql)
		{
			bool result = false;

			AnnualLeaveDay annualLeaveDay;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				while (dataReader.Read())
				{
					result = true;
					annualLeaveDay = new AnnualLeaveDay(dataReader.GetDateTime(LEAVE_DATE));
					annualLeaveDay.ForYear = dataReader.GetInt16(FOR_YEAR);
					annualLeaveDay.PeriodStatus = CTFunction.GetLeavePeriodType((string)dataReader[PERIOD_STATUS]);
					annualLeaveDay.LeaveYearStatus = CTFunction.GetLeaveYearStatusType((string)dataReader[LEAVE_YEAR_STATUS]);
					annualLeaveDay.Reason = new LeaveReason();
					annualLeaveDay.Reason.Name = (string)dataReader[LEAVE_REASON];
					value.Add(annualLeaveDay);
				}
			}
			catch(IndexOutOfRangeException ein)
			{
				throw ein;
			}
			finally
			{
				dataReader = null;
				annualLeaveDay = null;
				tableAccess.CloseDataReader();				
			}
			return result;
		}

		private bool fillEmployeeAnnualLeaveDetail(ref AnnualLeaveDayList value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			AnnualLeaveDay annualLeaveDay;
			try
			{
				while (dataReader.Read())
				{
					result = true;
					annualLeaveDay = new AnnualLeaveDay(dataReader.GetDateTime(LEAVE_DATE));
					fillAnnualLeaveDay(ref annualLeaveDay, dataReader);
					value.Add(annualLeaveDay);
				}
				annualLeaveDay = null;
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

		//============================== Public Method ==============================
		public bool FillEmployeeAnnualLeaveDetail(ref AnnualLeaveYear value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Employee));
			stringBuilder.Append(getKeyCondition(value));
			stringBuilder.Append(getOrderby());

			bool result = fillEmployeeAnnualLeaveDetail(ref value, stringBuilder.ToString());
			stringBuilder = null;
			return result;
		}
		 
		public bool FillEmployeeAnnualLeaveDetail(ref AnnualLeaveDayList value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Employee));
			stringBuilder.Append(getOrderby());

			return fillEmployeeAnnualLeaveDetail(ref value, stringBuilder.ToString());
		}

		public bool InsertAnnualLeaveDay(AnnualLeaveDay value, Employee employee)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLInsert(value, employee));
			bool result = (tableAccess.ExecuteSQL(stringBuilder.ToString())>0);
			stringBuilder = null;
			return result;
		}

		public bool InsertAnnualLeave(AnnualLeaveDayList value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for(int i=0; i<value.Count; i++)
			{
				stringBuilder.Append(getSQLDelete());
				stringBuilder.Append(getBaseCondition(value.Employee));
				stringBuilder.Append(getKeyCondition(value[i]));

				stringBuilder.Append(getSQLInsert(value[i], value.Employee));
			}
			bool result = (tableAccess.ExecuteSQL(stringBuilder.ToString())>0);
			stringBuilder = null;
			return result;
		}

		public bool UpdateAnnualLeave(AnnualLeaveDay value, Employee employee)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value, employee));
			stringBuilder.Append(getBaseCondition(employee));
			stringBuilder.Append(getKeyCondition(value));

			bool result = (tableAccess.ExecuteSQL(stringBuilder.ToString())>0);
			stringBuilder = null;
			return result;
		}

		public bool UpdateAnnualLeave(AnnualLeaveDayList value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for(int i=0; i<value.Count; i++)
			{
				stringBuilder.Append(getSQLDelete());
				stringBuilder.Append(getBaseCondition(value.Employee));
				stringBuilder.Append(getKeyCondition(value[i]));

				stringBuilder.Append(getSQLInsert(value[i], value.Employee));
			}
			bool result = (tableAccess.ExecuteSQL(stringBuilder.ToString())>0);
			stringBuilder = null;
			return result;
		}

		public bool DeleteAnnualLeave(AnnualLeaveDay value, Employee employee)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(employee));
			stringBuilder.Append(getKeyCondition(value));

			bool result = (tableAccess.ExecuteSQL(stringBuilder.ToString())>0);
			stringBuilder = null;
			return result;
		}
	}
}