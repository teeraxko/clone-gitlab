using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Entity.CommonEntity;
using Entity.AttendanceEntities;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.Time;

using DataAccess.CommonDB;
using DataAccess.PiDB;

using SystemFramework.AppConfig;

namespace DataAccess.AttendanceDB
{
	public class EmployeePrivateLeaveDB : DataAccessBase
	{
		#region - Constant -
		private const int EMPLOYEE_NO = 0;
		private const int LEAVE_DATE = 1;
		private const int PERIOD_STATUS = 2;	
		private const int LEAVE_REASON = 3;
		#endregion

		#region - Private -
		private LeaveReasonDB dbLeaveReason; 
		private PrivateLeave objPrivateLeave;
		#endregion

		//		============================== Constructor ==============================
		public EmployeePrivateLeaveDB() : base()
		{
			dbLeaveReason = new LeaveReasonDB();
		}

		//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
			return " SELECT Employee_No, Leave_Date, Period_Status, Leave_Reason FROM Employee_Private_Leave ";
		}

		private string getSQLInsert(PrivateLeave value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder("INSERT INTO Employee_Private_Leave (Company_Code, Employee_No, Leave_Date, Period_Status, Leave_Reason, Process_Date, Process_User) ");
			stringBuilder.Append("VALUES (");

			//Company_Code
			stringBuilder.Append(GetDB(aEmployee.Company.CompanyCode));
			stringBuilder.Append(", ");

			//Employee_No
			stringBuilder.Append(GetDB(aEmployee.EmployeeNo));
			stringBuilder.Append(", ");

			//Leave_Date
			stringBuilder.Append(GetDB(value.LeaveDate));
			stringBuilder.Append(", ");		

			//Period_Status
			stringBuilder.Append(GetDB(value.PeriodStatus));
			stringBuilder.Append(", ");

			//Leave_Reason
			stringBuilder.Append(GetDB(value.ALeaveReason.Name));
			stringBuilder.Append(", ");

			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(")");

			return stringBuilder.ToString();
		}

		private string getSQLUpdate(PrivateLeave value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder("UPDATE Employee_Private_Leave SET ");

			stringBuilder.Append(" Company_Code = ");
			stringBuilder.Append(GetDB(aEmployee.Company.CompanyCode));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Employee_No = ");
			stringBuilder.Append(GetDB(aEmployee.EmployeeNo));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Leave_Date = ");
			stringBuilder.Append(GetDB(value.LeaveDate));
			stringBuilder.Append(", ");		

			stringBuilder.Append(" Period_Status = ");
			stringBuilder.Append(GetDB(value.PeriodStatus));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Leave_Reason = ");
			stringBuilder.Append(GetDB(value.ALeaveReason.Name));
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
			return " DELETE FROM Employee_Private_Leave ";
		}

		private string getKeyCondition(PrivateLeave value)
		{
			StringBuilder stringBuilder = new StringBuilder();

			if(IsNotNULL(value.LeaveDate))
			{
				stringBuilder.Append(" AND (Leave_Date = ");
				stringBuilder.Append(GetDB(value.LeaveDate));
				stringBuilder.Append(")");
			}

			return stringBuilder.ToString();
		}
		
		private string getListCondition(YearMonth value)
		{
			return " AND " +  SqlFunction.GetYearMonthCondition("Leave_Date", value);
		}

		private string getListYearCondition(int value)
		{
            //if (value == 2007)
            //{
            //    return " AND (Leave_Date >=  " + GetDB(new DateTime(2006, 11, 1)) + ") AND (Leave_Date < " + GetDB(new DateTime(2008, 4, 1)) + ") ";
            //}
            //else
            //{
                return " AND (Leave_Date >=  " + GetDB(new DateTime(value, 4, 1)) + ") AND (Leave_Date < " + GetDB(new DateTime(value + 1, 4, 1)) + ") ";
            //}
        }

		private string getOrderby()
		{
			return " ORDER BY Employee_No, Leave_Date ";
		}
		#endregion

		#region - fill -
		private void fillPrivateLeave(ref PrivateLeave value, SqlDataReader dataReader)
		{
			value.LeaveDate = dataReader.GetDateTime(LEAVE_DATE);
			value.PeriodStatus = CTFunction.GetLeavePeriodType((string)dataReader[PERIOD_STATUS]);
			value.ALeaveReason.Name = (string)dataReader[LEAVE_REASON];
		}

		private bool fillEmployeePrivateLeave(ref EmployeePrivateLeave value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				while (dataReader.Read())
				{
					result = true;
					objPrivateLeave = new PrivateLeave();
					fillPrivateLeave(ref objPrivateLeave, dataReader);
					value.Add(objPrivateLeave);
				}
				objPrivateLeave = null;
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

		private bool fillPrivateLeave(ref PrivateLeave value, string sql)
		{
			bool result;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				if (dataReader.Read())
				{					
					fillPrivateLeave(ref value, dataReader);
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
		public PrivateLeave GetPrivateLeave(DateTime forDate, Employee aEmployee)
		{
			objPrivateLeave = new PrivateLeave();
			objPrivateLeave.LeaveDate = forDate;
			if(FillPrivateLeave(ref objPrivateLeave, aEmployee))
			{
				return objPrivateLeave;
			}
			else
			{
				objPrivateLeave = null;
				return objPrivateLeave;
			}		
		}

		public bool FillEmployeePrivateLeave(ref EmployeePrivateLeave value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Employee));
			stringBuilder.Append(getListCondition(value.AYearMonth));
			stringBuilder.Append(getOrderby());

			return fillEmployeePrivateLeave(ref value, stringBuilder.ToString());
		}

		public bool FillEmployeePrivateLeaveYear(ref EmployeePrivateLeave value, int year)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Employee));
			stringBuilder.Append(getListYearCondition(year));
			stringBuilder.Append(getOrderby());

			return fillEmployeePrivateLeave(ref value, stringBuilder.ToString());
		}

		public bool FillPrivateLeave(ref PrivateLeave value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(aEmployee));
			stringBuilder.Append(getKeyCondition(value));

			return fillPrivateLeave(ref value, stringBuilder.ToString());
		}

		public bool InsertPrivateLeave(PrivateLeave value, Employee aEmployee)
		{
			if (tableAccess.ExecuteSQL(getSQLInsert(value, aEmployee))>0)
			{return true;}
			else
			{return false;}	
		}

		public bool UpdatePrivateLeave(PrivateLeave value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value, aEmployee));
			stringBuilder.Append(getBaseCondition(aEmployee));
			stringBuilder.Append(getKeyCondition(value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool DeletePrivateLeave(PrivateLeave value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(aEmployee));
			stringBuilder.Append(getKeyCondition(value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}
	}
}