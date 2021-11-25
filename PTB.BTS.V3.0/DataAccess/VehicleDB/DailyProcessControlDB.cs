using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;
using Entity.VehicleEntities;

using DataAccess.CommonDB;

using SystemFramework.AppConfig;

using ictus.Common.Entity;

namespace DataAccess.VehicleDB
{
	public class DailyProcessControlDB : DataAccessBase
	{
		#region - Constant -
		private const int DAILY_DATE = 0;
		private const int PROCESS_STATUS = 1;
		#endregion

		#region - Private -
		private DailyProcessControl objDailyProcessControl;
		#endregion

//		============================== Constructor ==============================
		public DailyProcessControlDB() : base()
		{
		}

//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
			return " SELECT Daily_Date, Process_Status FROM Daily_Process_Control ";
		}

		private string getSQLInsert(DailyProcessControl value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder("INSERT INTO Daily_Process_Control (Company_Code, Daily_Date, Process_Status, Process_Date, Process_User) ");
			stringBuilder.Append("VALUES (");

			//Company_Code
			stringBuilder.Append(GetDB(aCompany.CompanyCode));
			stringBuilder.Append(", ");

			//Daily_Date
			stringBuilder.Append(GetDB(value.DailyDate.Date));
			stringBuilder.Append(", ");

			//Process_Status
			stringBuilder.Append(GetDB(value.ProcessStatus));
			stringBuilder.Append(", ");

			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(")");

			return stringBuilder.ToString();
		}

		private string getSQLUpdate(DailyProcessControl value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder("UPDATE Daily_Process_Control SET ");

			stringBuilder.Append(" Company_Code = ");
			stringBuilder.Append(GetDB(aCompany.CompanyCode));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Daily_Date = ");
			stringBuilder.Append(GetDB(value.DailyDate.Date));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Process_Status = ");
			stringBuilder.Append(GetDB(value.ProcessStatus));
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
			return " DELETE FROM Daily_Process_Control ";
		}

		private string getKeyCondition(DailyProcessControl value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if(IsNotNULL(value.DailyDate.Date))
			{
				stringBuilder.Append(" AND (Daily_Date = ");
				stringBuilder.Append(GetDB(value.DailyDate.Date));
				stringBuilder.Append(")");
			}
			return stringBuilder.ToString();
		}

		private string getOrderby()
		{
			return " ORDER BY Daily_Date ";
		}
		#endregion

		#region - fill -
		private void fillDailyProcessControl(ref DailyProcessControl value, SqlDataReader dataReader)
		{		
			value.DailyDate = dataReader.GetDateTime(DAILY_DATE);
			value.ProcessStatus = CTFunction.GetProcessStatusType((string)dataReader[PROCESS_STATUS]);
		}

		private bool fillDailyProcessControl(ref DailyProcessControl value, string sql)
		{
			bool result;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				if (dataReader.Read())
				{					
					fillDailyProcessControl(ref value, dataReader);
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

		private bool fillDailyProcessControlList(ref DailyProcessControlList value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				while (dataReader.Read())
				{
					result = true;
					objDailyProcessControl = new DailyProcessControl();
					fillDailyProcessControl(ref objDailyProcessControl, dataReader);
					value.Add(objDailyProcessControl);
				}
				objDailyProcessControl = null;
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
		public bool FillDailyProcessControl(ref DailyProcessControl value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(value));

			return fillDailyProcessControl(ref value, stringBuilder.ToString());
		}

		public bool FillDailyProcessControlList(ref DailyProcessControlList value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Company));

			return fillDailyProcessControlList(ref value, stringBuilder.ToString());
		}

		public bool InsertDailyProcessControl(DailyProcessControl value, Company aCompany)
		{
			return tableAccess.ExecuteSQL(getSQLInsert(value, aCompany)) > 0;
		}

		public bool UpdateDailyProcessControl(DailyProcessControl value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value, aCompany));
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(value));

			return tableAccess.ExecuteSQL(stringBuilder.ToString()) > 0;
		}

		public bool DeleteDailyProcessControl(DailyProcessControl value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(value));

			return tableAccess.ExecuteSQL(stringBuilder.ToString()) > 0;
		}
	}
}
