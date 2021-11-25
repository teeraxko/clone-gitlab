using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Entity.CommonEntity;
using ictus.PIS.PI.Entity;
using Entity.AttendanceEntities;

using DataAccess.CommonDB;
using DataAccess.PiDB;
using DataAccess.ContractDB;

using SystemFramework.AppConfig;

using ictus.Common.Entity;

namespace DataAccess.AttendanceDB
{
	public class WorkingTimeConditionSpecificDB : DataAccessBase
	{
		#region - Constant -
		private const int EMPLOYEE_NO = 0;
		private const int TABLE_ID = 1;
		#endregion

		#region - Private -
		private EmployeeDB dbEmployee;
		private WorkingTimeTableDB dbWorkingTimeTable;
		private WorkingTimeConditionSpecific objWorkingTimeConditionSpecific;
		private bool disposed  = false;
		#endregion

//		============================== Constructor ==============================
		public WorkingTimeConditionSpecificDB():base()
		{
			dbEmployee = new EmployeeDB();
			dbWorkingTimeTable = new WorkingTimeTableDB();
		}

//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
			return " SELECT Employee_No, Table_ID FROM Working_Time_Condition_Specific ";
		}

		private string getSQLInsert(WorkingTimeConditionSpecific value)
		{
			StringBuilder stringBuilder = new StringBuilder("INSERT INTO Working_Time_Condition_Specific (Company_Code, Employee_No, Table_ID, Process_Date, Process_User) ");
			stringBuilder.Append("VALUES (");

			//Company_Code
			stringBuilder.Append(GetDB(value.AEmployee.Company.CompanyCode));
			stringBuilder.Append(", ");

			//Employee_No
			stringBuilder.Append(GetDB(value.AEmployee.EmployeeNo));
			stringBuilder.Append(", ");

			//Table_ID
			stringBuilder.Append(GetDB(value.AWorkingTimeTable.TableID));
			stringBuilder.Append(", ");

			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(")");

			return stringBuilder.ToString();
		}

		private string getSQLUpdate(WorkingTimeConditionSpecific value)
		{
			StringBuilder stringBuilder = new StringBuilder("UPDATE Working_Time_Condition_Specific SET ");

			stringBuilder.Append(" Company_Code = ");
			stringBuilder.Append(GetDB(value.AEmployee.Company.CompanyCode));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Employee_No = ");
			stringBuilder.Append(GetDB(value.AEmployee.EmployeeNo));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Table_ID = ");
			stringBuilder.Append(GetDB(value.AWorkingTimeTable.TableID));
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
			return " DELETE FROM Working_Time_Condition_Specific ";
		}

		private string getOrderby()
		{
			return " ORDER BY Employee_No, Table_ID ";
		}
		#endregion

		#region - fill -
		private void fillWorkingTimeConditionSpecific(ref WorkingTimeConditionSpecific value, Company aCompany, SqlDataReader dataReader)
		{
			value.AEmployee = dbEmployee.GetFormerlyEmployee((string)dataReader[EMPLOYEE_NO], aCompany);
			value.AWorkingTimeTable = dbWorkingTimeTable.GetDBWorkingTimeTable((string)dataReader[TABLE_ID], aCompany);
		}

		private bool fillWorkingTimeConditionSpecificList(ref WorkingTimeConditionSpecificList value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			EmployeeList listEmployee = new EmployeeList(value.Company);
			dbEmployee.FillAvailableEmployeeList(ref listEmployee);
			WorkingTimeTableList listWorkingTimeTable = new WorkingTimeTableList(value.Company);
			dbWorkingTimeTable.FillWorkingTimeTableList(ref listWorkingTimeTable);

			try
			{
				while (dataReader.Read())
				{
					result = true;
					objWorkingTimeConditionSpecific = new WorkingTimeConditionSpecific();
					objWorkingTimeConditionSpecific.AEmployee = listEmployee[(string)dataReader[EMPLOYEE_NO]];
					objWorkingTimeConditionSpecific.AWorkingTimeTable = listWorkingTimeTable[(string)dataReader[TABLE_ID]];

					if(objWorkingTimeConditionSpecific.AEmployee != null && objWorkingTimeConditionSpecific.AEmployee.EmployeeNo != "")
					{
						value.Add(objWorkingTimeConditionSpecific);
					}
				}
				objWorkingTimeConditionSpecific = null;
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

		private bool fillWorkingTimeConditionSpecific(ref WorkingTimeConditionSpecific value, Company aCompany, string sql)
		{
			bool result;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				if (dataReader.Read())
				{					
					fillWorkingTimeConditionSpecific(ref value, aCompany, dataReader);
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
		public bool FillWorkingTimeConditionSpecificList(ref WorkingTimeConditionSpecificList value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Company));
			stringBuilder.Append(getOrderby());

			return fillWorkingTimeConditionSpecificList(ref value, stringBuilder.ToString());
		}

		public bool FillWorkingTimeConditionSpecific(ref WorkingTimeConditionSpecific value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.AEmployee));

			return fillWorkingTimeConditionSpecific(ref value, value.AEmployee.Company, stringBuilder.ToString());
		}

		public bool InsertWorkingTimeConditionSpecific(WorkingTimeConditionSpecific value)
		{
			if (tableAccess.ExecuteSQL(getSQLInsert(value))>0)
			{return true;}
			else
			{return false;}	
		}

		public bool UpdateWorkingTimeConditionSpecific(WorkingTimeConditionSpecific value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value));
			stringBuilder.Append(getBaseCondition(value.AEmployee));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool DeleteWorkingTimeConditionSpecific(WorkingTimeConditionSpecific value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(value.AEmployee));

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
