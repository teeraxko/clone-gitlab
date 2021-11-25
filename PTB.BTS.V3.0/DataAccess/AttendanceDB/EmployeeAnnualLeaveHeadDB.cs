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
	public class EmployeeAnnualLeaveHeadDB : DataAccessBase
	{
		#region - Constant -
		private const int EMPLOYEE_NO = 0;
		private const int FOR_YEAR = 1;
		private const int TOTAL_DAYS = 2;
		private const int USE_DAYS = 3;	
		private const int SELL_DAYS = 4;
		#endregion

//		============================== Constructor ==============================
		public EmployeeAnnualLeaveHeadDB() : base()
		{
		}

//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
			return " SELECT Employee_No, For_Year, Total_Days, Use_Days, Sell_Days FROM Employee_Annual_Leave_Head ";
		}

		private string getSQLInsert(AnnualLeaveHead value)
		{
			StringBuilder stringBuilder = new StringBuilder(" INSERT INTO Employee_Annual_Leave_Head (Company_Code, Employee_No, For_Year, Total_Days, Use_Days, Sell_Days, Process_Date, Process_User) ");
			stringBuilder.Append("VALUES (");

			//Company_Code
			stringBuilder.Append(GetDB(value.Employee.Company.CompanyCode));
			stringBuilder.Append(", ");

			//Employee_No
			stringBuilder.Append(GetDB(value.Employee.EmployeeNo));
			stringBuilder.Append(", ");

			//For_Year
			stringBuilder.Append(GetDB(value.ForYear));
			stringBuilder.Append(", ");	

			//Total_Days
			stringBuilder.Append(GetDB(value.TotalDays));
			stringBuilder.Append(", ");		

			//Use_Days
			stringBuilder.Append(GetDB(value.UseDays));
			stringBuilder.Append(", ");

			//Sell_Days
			stringBuilder.Append(GetDB(value.SellDays));
			stringBuilder.Append(", ");

			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(") ");

			string sql = stringBuilder.ToString();
			stringBuilder = null;
			return sql;
		}

		private string getSQLUpdate(AnnualLeaveHead value)
		{
			StringBuilder stringBuilder = new StringBuilder("UPDATE Employee_Annual_Leave_Head SET ");

			stringBuilder.Append(" Company_Code = ");
			stringBuilder.Append(GetDB(value.Employee.Company.CompanyCode));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Employee_No = ");
			stringBuilder.Append(GetDB(value.Employee.EmployeeNo));
			stringBuilder.Append(", ");

			stringBuilder.Append(" For_Year = ");
			stringBuilder.Append(GetDB(value.ForYear));
			stringBuilder.Append(", ");	

			stringBuilder.Append(" Total_Days = ");
			stringBuilder.Append(GetDB(value.TotalDays));
			stringBuilder.Append(", ");		

			stringBuilder.Append(" Use_Days = ");
			stringBuilder.Append(GetDB(value.UseDays));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Sell_Days = ");
			stringBuilder.Append(GetDB(value.SellDays));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Process_Date = ");
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			stringBuilder.Append(" Process_User = ");
			stringBuilder.Append(GetDB(UserProfile.UserID));
			
			string sql = stringBuilder.ToString();
			stringBuilder = null;
			return sql;
		}	

		private string getSQLDelete()
		{
			return " DELETE FROM Employee_Annual_Leave_Head ";
		}

		private string getForYearCondition(int forYear)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(" AND (For_Year = ");
			stringBuilder.Append(GetDB(forYear));
			stringBuilder.Append(")");
			string sql = stringBuilder.ToString();
			stringBuilder = null;
			return sql;
		}

		private string getKeyCondition(AnnualLeaveHead value)
		{
			return getForYearCondition(value.ForYear);
		}

		private string getKeyCondition(AnnualLeaveHeadList value)
		{
			return getForYearCondition(value.ForYear);
		}

		private string getOrderby()
		{
			return " ORDER BY For_Year ";
		}
		#endregion

		#region - fill -
		private void fillAnnualLeaveHead(ref AnnualLeaveHead value, SqlDataReader dataReader)
		{
			value.TotalDays = dataReader.GetDecimal(TOTAL_DAYS);
			value.UseDays = dataReader.GetDecimal(USE_DAYS);
			value.SellDays = dataReader.GetDecimal(SELL_DAYS);
		}

		private bool fillAnnualLeaveHead(ref AnnualLeaveHead value, string sql)
		{
			bool result;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				if (dataReader.Read())
				{					
					fillAnnualLeaveHead(ref value, dataReader);
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
			{
				dataReader = null;
				tableAccess.CloseDataReader();
			}
			return result;
		}

		private bool fillAnnualLeaveHeadList(ref AnnualLeaveHeadList value, EmployeeList employeeList, string sql)
		{
			bool result = false;
			string employeeNo;
			AnnualLeaveHead annualLeaveHead;

			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				while(dataReader.Read())
				{
					result = true;
					employeeNo = (string)dataReader[EMPLOYEE_NO];
					
					if(employeeList.Contain(employeeNo))
					{
						annualLeaveHead = new AnnualLeaveHead(employeeList[employeeNo], value.ForYear);
						fillAnnualLeaveHead(ref annualLeaveHead, dataReader);
						value.Add(annualLeaveHead);
					}
				}
			}
			catch (IndexOutOfRangeException ein)
			{throw ein;}
			finally
			{
				employeeNo = null;
				dataReader = null;
				annualLeaveHead = null;
				tableAccess.CloseDataReader();
			}
			return result;
		}
		#endregion

//		============================== Public Method ==============================
		public bool FillAnnualLeaveHead(ref AnnualLeaveHead value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Employee));
			stringBuilder.Append(getKeyCondition(value));

			bool result = fillAnnualLeaveHead(ref value, stringBuilder.ToString());
			stringBuilder = null;
			return result;
		}

		public bool FillAnnualLeaveHeadList(ref AnnualLeaveHeadList value, EmployeeList employeeList)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Company));
			stringBuilder.Append(getKeyCondition(value));

			bool result = fillAnnualLeaveHeadList(ref value, employeeList, stringBuilder.ToString());
			stringBuilder = null;
			return result;
		}

		public bool FillAnnualLeaveHeadList(ref AnnualLeaveHeadList value, EmployeeList employeeList, int forYear)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Company));
			stringBuilder.Append(getForYearCondition(forYear));

			bool result = fillAnnualLeaveHeadList(ref value, employeeList, stringBuilder.ToString());
			stringBuilder = null;
			return result;
		}

		public bool InsertAnnualLeaveHead(AnnualLeaveHead value)
		{
			if (tableAccess.ExecuteSQL(getSQLInsert(value))>0)
			{return true;}
			else
			{return false;}	
		}

		public bool InsertAnnualLeaveHeadList(AnnualLeaveHeadList value)
		{
			AnnualLeaveHead annualLeaveHead;
			StringBuilder stringBuilder = new StringBuilder();
			for(int i=0; i<value.Count; i++)
			{
				annualLeaveHead = value[i];
				stringBuilder.Append(getSQLDelete());
				stringBuilder.Append(getBaseCondition(annualLeaveHead.Employee));
				stringBuilder.Append(getKeyCondition(value));

				stringBuilder.Append(getSQLInsert(annualLeaveHead));
			}
			annualLeaveHead = null;
			
			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}	
		}

		public bool UpdateEmployeeAnnualLeaveHead(AnnualLeaveHead value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value));
			stringBuilder.Append(getBaseCondition(value.Employee));
			stringBuilder.Append(getKeyCondition(value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool UpdateEmployeeAnnualLeaveHeadList(AnnualLeaveHeadList value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for(int i=0; i<value.Count; i++)
			{
				stringBuilder.Append(getSQLUpdate(value[i]));
				stringBuilder.Append(getBaseCondition(value[i].Employee));
				stringBuilder.Append(getKeyCondition(value[i]));
//
//				stringBuilder.Append(getSQLInsert(value[i]));
			}

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool UpdateAnnualLeaveDualHeadList(AnnualLeaveDualHeadList value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for(int i=0; i<value.Count; i++)
			{
				stringBuilder.Append(getSQLDelete());
				stringBuilder.Append(getBaseCondition(value[i].Employee));
				stringBuilder.Append(getKeyCondition(value[i].Current));

				stringBuilder.Append(getSQLInsert(value[i].Current));
			}

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool DeleteEmployeeAnnualLeaveHead(AnnualLeaveHead value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(value.Employee));
			stringBuilder.Append(getKeyCondition(value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool DeleteEmployeeAnnualLeaveHead(Employee value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(value));

			return (tableAccess.ExecuteSQL(stringBuilder.ToString())>0);
		}

		public int CountEmployeeAnnualLeaveHead(Employee employee)
		{
			StringBuilder stringBuilder = new StringBuilder(" Select count(*) FROM Employee_Annual_Leave_Head ");
			stringBuilder.Append(getBaseCondition(employee));

			return (int)tableAccess.ExecuteScalar(stringBuilder.ToString());
		}
	}
}