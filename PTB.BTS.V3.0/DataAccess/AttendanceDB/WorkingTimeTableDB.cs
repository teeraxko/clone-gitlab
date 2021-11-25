using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.General;

using Entity.CommonEntity;
using Entity.AttendanceEntities;

using DataAccess.CommonDB;

using SystemFramework.AppConfig;

using ictus.Common.Entity;

namespace DataAccess.AttendanceDB
{
	public class WorkingTimeTableDB : DataAccessBase
	{
		#region - Constant -
			private const int TABLE_ID = 0;
			private const int TABLE_DESCRIPTION = 1;
			private const int START_WORKING_TIME = 2;
			private const int END_WORKING_TIME = 3;
			private const int START_BREAKING_TIME = 4;
			private const int END_BREAKING_TIME = 5;
		#endregion

		#region - Private -
			private WorkingTimeTable objWorkingTimeTable;
			private bool disposed = false;
		#endregion

//		============================== Constructor ==============================
		public WorkingTimeTableDB()
		{
		}
		
//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
			return "SELECT Table_ID, Table_Description, Start_Working_Time, End_Working_Time, Start_Break_Time, End_Break_Time FROM Working_Time_Table ";
		}

		private string getSQLInsert(WorkingTimeTable value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder("INSERT INTO Working_Time_Table (Company_Code,Table_ID, Table_Description, Start_Working_Time, End_Working_Time, Start_Break_Time, End_Break_Time, Process_Date, Process_User) ");
			stringBuilder.Append("VALUES (");

			//Company_Code
			stringBuilder.Append(GetDB(aCompany.CompanyCode));
			stringBuilder.Append(", ");

			//Table_ID
			stringBuilder.Append(GetDB(value.TableID));
			stringBuilder.Append(", ");

			//Table_Description
			stringBuilder.Append(GetDB(value.Description));
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

		private string getSQLUpdate(WorkingTimeTable value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder("UPDATE Working_Time_Table SET ");

			stringBuilder.Append("Company_Code = ");
			stringBuilder.Append(GetDB(aCompany.CompanyCode));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Table_ID = ");
			stringBuilder.Append(GetDB(value.TableID));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Table_Description = ");
			stringBuilder.Append(GetDB(value.Description));
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
			return "DELETE FROM Working_Time_Table ";
		}

		private string getKeyCondition(WorkingTimeTable value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (IsNotNULL(value.TableID))
			{
				stringBuilder.Append(" AND (Table_ID = ");
				stringBuilder.Append(GetDB(value.TableID));
				stringBuilder.Append(")");
			}
			return stringBuilder.ToString();
		}

		private string getEntityCondition(WorkingTimeTable value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (IsNotNULL(value.Description))
			{
				stringBuilder.Append(" AND (Table_Description = ");
				stringBuilder.Append(GetDB(value.Description));
				stringBuilder.Append(")");
			}
			return stringBuilder.ToString();		
		}

		private string getOrderby()
		{
			return " ORDER BY Table_Description, Table_ID ";
		}
		#endregion

		#region - Fill -
		private void fillWorkingTimeTable(ref WorkingTimeTable value, SqlDataReader dataReader)
		{
			value.TableID = (string)dataReader[TABLE_ID];
			value.Description = (string)dataReader[TABLE_DESCRIPTION];
			value.AWorkingTime.From = dataReader.GetDateTime(START_WORKING_TIME);
			value.AWorkingTime.To = dataReader.GetDateTime(END_WORKING_TIME);
			value.ABreakTime.From = dataReader.GetDateTime(START_BREAKING_TIME);
			value.ABreakTime.To = dataReader.GetDateTime(END_BREAKING_TIME);		
		}

		private bool fillWorkingTimeTableList(ref WorkingTimeTableList value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				while (dataReader.Read())
				{
					result = true;
					objWorkingTimeTable = new WorkingTimeTable();
					fillWorkingTimeTable(ref objWorkingTimeTable, dataReader);
					value.Add(objWorkingTimeTable);
				}
				objWorkingTimeTable = null;
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

		private bool fillWorkingTimeTable(ref WorkingTimeTable value, string sql)
		{
			bool result;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				if (dataReader.Read())
				{
					fillWorkingTimeTable(ref value, dataReader);
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
		public WorkingTimeTable GetWorkingTimeTable(string workingTimeTableID, Company aCompany)
		{
			objWorkingTimeTable = new WorkingTimeTable();
			objWorkingTimeTable.TableID = workingTimeTableID;

			if(FillWorkingTimeTable(ref objWorkingTimeTable, aCompany))
			{
				return objWorkingTimeTable;
			}
			else
			{
				objWorkingTimeTable = null;
				return null;
			}
		}

		internal WorkingTimeTable GetDBWorkingTimeTable(string workingTimeTableID, Company aCompany)
		{
			objWorkingTimeTable = new WorkingTimeTable();
			objWorkingTimeTable.TableID = workingTimeTableID;
			if(FillWorkingTimeTable(ref objWorkingTimeTable, aCompany))
			{
				return objWorkingTimeTable;
			}
			else
			{
				objWorkingTimeTable.TableID = NullConstant.STRING;
				return objWorkingTimeTable;
			}
		}

		public WorkingTimeTable GetDupDescriptionWorkingTimeTable(string description, Company aCompany)
		{
			objWorkingTimeTable = new WorkingTimeTable();
			objWorkingTimeTable.Description = description;

			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getEntityCondition(objWorkingTimeTable));

			if(fillWorkingTimeTable(ref objWorkingTimeTable, stringBuilder.ToString()))
			{
				return objWorkingTimeTable;
			}
			else
			{
				objWorkingTimeTable = null;
				return null;
			}
		}

		public bool FillWorkingTimeTable(ref WorkingTimeTable value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(value));
			return fillWorkingTimeTable(ref value, stringBuilder.ToString());
		}

		public bool FillWorkingTimeTableList(ref WorkingTimeTableList value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Company));
			stringBuilder.Append(getOrderby());

			return fillWorkingTimeTableList(ref value, stringBuilder.ToString());
		}

		public bool FillWorkingTimeTableList(ref WorkingTimeTableList value, WorkingTimeTable aWorkingTimeTable)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Company));
			stringBuilder.Append(getKeyCondition(aWorkingTimeTable));
			stringBuilder.Append(getOrderby());

			return fillWorkingTimeTableList(ref value, stringBuilder.ToString());
		}
        
		public bool InsertWorkingTimeTable(WorkingTimeTable value, Company aCompany)
		{
			if (tableAccess.ExecuteSQL(getSQLInsert(value, aCompany))>0)
			{return true;}
			else
			{return false;}	
		}

		public bool UpdateWorkingTimeTable(WorkingTimeTable value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value, aCompany));
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool DeleteWorkingTimeTable(WorkingTimeTable value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition (aCompany));
			stringBuilder.Append(getKeyCondition(value));

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
						objWorkingTimeTable = null;
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