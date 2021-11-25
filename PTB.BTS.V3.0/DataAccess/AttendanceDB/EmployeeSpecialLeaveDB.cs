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
	public class EmployeeSpecialLeaveDB : DataAccessBase
	{
		#region - Constant -
		private const int EMPLOYEE_NO = 0;
		private const int LEAVE_DATE = 1;
		private const int PERIOD_STATUS = 2;	
		private const int SPECIAL_LEAVE_CODE = 3;
		#endregion

		#region - Private -
		private SpecialLeaveDB dbSpecialLeave; 
		private SpecialLeave objSpecialLeave;
		#endregion

//		============================== Constructor ==============================
		public EmployeeSpecialLeaveDB() : base()
		{
			dbSpecialLeave = new SpecialLeaveDB();
		}

//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
			return " SELECT Employee_No, Leave_Date, Period_Status, Special_Leave_Code FROM Employee_Special_Leave ";
		}

		private string getSQLInsert(SpecialLeave value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder("INSERT INTO Employee_Special_Leave (Company_Code, Employee_No, Leave_Date, Period_Status, Special_Leave_Code, Process_Date, Process_User) ");
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

			//Special_Leave_Code
			stringBuilder.Append(GetDB(value.AKindOfSpecialLeave.Code));
			stringBuilder.Append(", ");

			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(")");

			return stringBuilder.ToString();
		}

		private string getSQLUpdate(SpecialLeave value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder("UPDATE Employee_Special_Leave SET ");

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

			stringBuilder.Append(" Special_Leave_Code = ");
			stringBuilder.Append(GetDB(value.AKindOfSpecialLeave.Code));
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
			return " DELETE FROM Employee_Special_Leave ";
		}

		private string getKeyCondition(SpecialLeave value)
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

		private string getListYearCondition(YearMonth value)
		{
			return " AND " +  SqlFunction.GetYearCondition("Leave_Date", value);
		}

		private string getOrderby()
		{
			return " ORDER BY Employee_No, Leave_Date ";
		}
		#endregion

		#region - fill -
		private void fillSpecialLeave(ref SpecialLeave value, SqlDataReader dataReader)
		{
			value.LeaveDate = dataReader.GetDateTime(LEAVE_DATE);
			value.PeriodStatus = CTFunction.GetLeavePeriodType((string)dataReader[PERIOD_STATUS]);
			value.AKindOfSpecialLeave = (KindOfSpecialLeave)dbSpecialLeave.GetMTB((string)dataReader[SPECIAL_LEAVE_CODE]);
		}

		private bool fillEmployeeSpecialLeave(ref EmployeeSpecialLeave value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				while (dataReader.Read())
				{
					result = true;
					objSpecialLeave = new SpecialLeave();
					fillSpecialLeave(ref objSpecialLeave, dataReader);
					value.Add(objSpecialLeave);
				}
				objSpecialLeave = null;
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

		private bool fillSpecialLeave(ref SpecialLeave value, string sql)
		{
			bool result;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				if (dataReader.Read())
				{					
					fillSpecialLeave(ref value, dataReader);
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
		public SpecialLeave GetSpecialLeave(DateTime forDate, Employee aEmployee)
		{
			objSpecialLeave = new SpecialLeave();
			objSpecialLeave.LeaveDate = forDate;
			if(FillSpecialLeave(ref objSpecialLeave, aEmployee))
			{
				return objSpecialLeave;
			}
			else
			{
				objSpecialLeave = null;
				return null;
			}
		}

		public bool FillEmployeeSpecialLeave(ref EmployeeSpecialLeave value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Employee));
			stringBuilder.Append(getListCondition(value.AYearMonth));
			stringBuilder.Append(getOrderby());

			return fillEmployeeSpecialLeave(ref value, stringBuilder.ToString());
		}

		public bool FillEmployeeSpecialLeaveYear(ref EmployeeSpecialLeave value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Employee));
			stringBuilder.Append(getListYearCondition(value.AYearMonth));
			stringBuilder.Append(getOrderby());

			return fillEmployeeSpecialLeave(ref value, stringBuilder.ToString());
		}

        public bool FillAllEmployeeSpecialLeave(EmployeeSpecialLeave value)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(value.Employee));
            stringBuilder.Append(getOrderby());

            return fillEmployeeSpecialLeave(ref value, stringBuilder.ToString());
        }

		public bool FillSpecialLeave(ref SpecialLeave value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(aEmployee));
			stringBuilder.Append(getKeyCondition(value));

			return fillSpecialLeave(ref value, stringBuilder.ToString());
		}

		public bool InsertSpecialLeave(SpecialLeave value, Employee aEmployee)
		{
			if (tableAccess.ExecuteSQL(getSQLInsert(value, aEmployee))>0)
			{return true;}
			else
			{return false;}	
		}

		public bool UpdateSpecialLeave(SpecialLeave value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value, aEmployee));
			stringBuilder.Append(getBaseCondition(aEmployee));
			stringBuilder.Append(getKeyCondition(value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool DeleteSpecialLeave(SpecialLeave value, Employee aEmployee)
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
