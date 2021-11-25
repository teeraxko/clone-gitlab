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
	public class EmployeeSickLeaveDB : DataAccessBase
	{
		#region - Constant -
		private const int EMPLOYEE_NO = 0;
		private const int LEAVE_DATE = 1;
		private const int PERIOD_STATUS = 2;	
		private const int DISEASE_NAME = 3;
		#endregion

		#region - Private -
		private DiseaseDB dbDisease; 
		private SickLeave objSickLeave;
		#endregion

		//		============================== Constructor ==============================
		public EmployeeSickLeaveDB() : base()
		{
			dbDisease = new DiseaseDB();
		}

		//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
			return " SELECT Employee_No, Leave_Date, Period_Status, Disease_Name FROM Employee_Sick_Leave ";
		}

		private string getSQLInsert(SickLeave value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder("INSERT INTO Employee_Sick_Leave (Company_Code, Employee_No, Leave_Date, Period_Status, Disease_Name, Process_Date, Process_User) ");
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

			//Disease_Name
			stringBuilder.Append(GetDB(value.ADisease.Name));
			stringBuilder.Append(", ");

			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(")");

			return stringBuilder.ToString();
		}

		private string getSQLUpdate(SickLeave value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder("UPDATE Employee_Sick_Leave SET ");

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

			stringBuilder.Append(" Disease_Name = ");
			stringBuilder.Append(GetDB(value.ADisease.Name));
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
			return " DELETE FROM Employee_Sick_Leave ";
		}

		private string getKeyCondition(SickLeave value)
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
		private void fillSickLeave(ref SickLeave value, SqlDataReader dataReader)
		{
			value.LeaveDate = dataReader.GetDateTime(LEAVE_DATE);
			value.PeriodStatus = CTFunction.GetLeavePeriodType((string)dataReader[PERIOD_STATUS]);
			value.ADisease.Name = (string)dataReader[DISEASE_NAME];
		}

		private bool fillEmployeeSickLeave(ref EmployeeSickLeave value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				while (dataReader.Read())
				{
					result = true;
					objSickLeave = new SickLeave();
					fillSickLeave(ref objSickLeave, dataReader);
					value.Add(objSickLeave);
				}
				objSickLeave = null;
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

		private bool fillSickLeave(ref SickLeave value, string sql)
		{
			bool result;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				if (dataReader.Read())
				{					
					fillSickLeave(ref value, dataReader);
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
		public SickLeave GetSickLeave(DateTime forDate, Employee aEmployee)
		{
			objSickLeave = new SickLeave();
			objSickLeave.LeaveDate = forDate;
			if(FillSickLeave(ref objSickLeave, aEmployee))
			{
				return objSickLeave;
			}
			else
			{
				objSickLeave = null;
				return null;
			}
		}

		public bool FillEmployeeSickLeave(ref EmployeeSickLeave value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Employee));
			stringBuilder.Append(getListCondition(value.AYearMonth));
			stringBuilder.Append(getOrderby());

			return fillEmployeeSickLeave(ref value, stringBuilder.ToString());
		}
			
		public bool FillEmployeeSickLeaveYear(ref EmployeeSickLeave value, int year)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Employee));
			stringBuilder.Append(getListYearCondition(year));
			stringBuilder.Append(getOrderby());

			return fillEmployeeSickLeave(ref value, stringBuilder.ToString());
		}

		public bool FillSickLeave(ref SickLeave value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(aEmployee));
			stringBuilder.Append(getKeyCondition(value));

			return fillSickLeave(ref value, stringBuilder.ToString());
		}

		public bool InsertSickLeave(SickLeave value, Employee aEmployee)
		{
			if (tableAccess.ExecuteSQL(getSQLInsert(value, aEmployee))>0)
			{return true;}
			else
			{return false;}	
		}

		public bool UpdateSickLeave(SickLeave value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value, aEmployee));
			stringBuilder.Append(getBaseCondition(aEmployee));
			stringBuilder.Append(getKeyCondition(value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool DeleteSickLeave(SickLeave value, Employee aEmployee)
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