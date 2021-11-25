using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using DataAccess.CommonDB;

using Entity.CommonEntity;

using SystemFramework.AppConfig;

namespace DataAccess.CommonDB
{
	public class ApplicationModuleDB : DataAccessBase
	{
		#region - Constant -
		private const int MODULE_NAME = 0;
		private const int MODULE_DESCRIPTION = 1;
		private const int SYSTEM_STATUS = 2;
		#endregion

		#region - Private -	
		private ApplicationModule objApplicationModule;
		private ApplicationFunctionDB dbApplicationFunction;
		#endregion

//		============================== Constructor ==============================
		public ApplicationModuleDB() : base()
		{
			dbApplicationFunction = new ApplicationFunctionDB();
		}

//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
			return "SELECT Module_Name, Module_Description, System_Status FROM Application_Module ";
		}

		private string getOrderby()
		{
			return " ORDER BY Module_Name "; 
		}
		#endregion

		#region - Fill -
		private void fillApplicationModule(ref ApplicationModule value, SqlDataReader dataReader)
		{
			value.Name = (string)dataReader[MODULE_NAME];
			value.Description = (string)dataReader[MODULE_DESCRIPTION];
			value.IsSystem = GetBool((string)dataReader[SYSTEM_STATUS]);
		}

		private bool fillApplicationModule(ref ApplicationModuleList value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				while (dataReader.Read())
				{
					result = true;
					objApplicationModule = new ApplicationModule();
					fillApplicationModule(ref objApplicationModule, dataReader);
					dbApplicationFunction.FillApplicationFunction(ref objApplicationModule);
					value.Add(objApplicationModule);
				}
			}
			catch(IndexOutOfRangeException ein)
			{throw ein;}
			finally
			{tableAccess.CloseDataReader();}
			return result;
		}	

		#endregion

//		============================== Public Method ==============================				
		public bool FillApplicationModule(ref ApplicationModuleList value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition());
			stringBuilder.Append(getOrderby());

			return fillApplicationModule(ref value, stringBuilder.ToString());		
		}
	}
}
