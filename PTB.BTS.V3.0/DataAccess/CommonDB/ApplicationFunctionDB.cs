using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using DataAccess.CommonDB;

using SystemFramework.AppConfig;

namespace DataAccess.CommonDB
{
	public class ApplicationFunctionDB : DataAccessBase
	{
		#region - Constant -
		private const int MODULE_NAME = 0;
		private const int FUNCTION_NAME = 1;
		private const int FUNCTION_DESCRIPTION = 2;
        private const int FORM_ID = 3;
		private const int SYSTEM_STATUS = 4;
		#endregion

		#region - Private -	
		private ApplicationFunction objApplicationFunction;
		#endregion

//		============================== Constructor ==============================
		public ApplicationFunctionDB() : base()
		{
		}

//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
			return "SELECT Module_Name, Function_Name, Function_Description, Form_ID, System_Status FROM Application_Function ";
		}

		private string getKeyCondition(ApplicationModule value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if(IsNotNULL(value.Name))
			{
				stringBuilder.Append(" AND (Module_Name = ");
				stringBuilder.Append(GetDB(value.Name));
				stringBuilder.Append(")");
			}

			return stringBuilder.ToString();
		}

		private string getKeyCondition(ApplicationFunction value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if(IsNotNULL(value.Name))
			{
				stringBuilder.Append(" AND (Function_Name = ");
				stringBuilder.Append(GetDB(value.Name));
				stringBuilder.Append(")");
			}
			return stringBuilder.ToString();
		}

		private string getOrderby()
		{
            return " ORDER BY Function_Description "; 
		}
		#endregion

		#region - Fill -
		private void fillApplicationFunction(ref ApplicationFunction value, SqlDataReader dataReader)
		{
			value.Name = (string)dataReader[FUNCTION_NAME];
			value.Description = (string)dataReader[FUNCTION_DESCRIPTION];
            value.ID = (string)dataReader[FORM_ID];
			value.IsSystem = GetBool((string)dataReader[SYSTEM_STATUS]);
		}

		private bool fillApplicationFunction(ref ApplicationModule value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				while (dataReader.Read())
				{
					result = true;
					objApplicationFunction = new ApplicationFunction();
					fillApplicationFunction(ref objApplicationFunction, dataReader);
					value.Add(objApplicationFunction);
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
		public bool FillApplicationFunction(ref ApplicationModule value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition());
			stringBuilder.Append(getKeyCondition(value));
			stringBuilder.Append(getOrderby());

			return fillApplicationFunction(ref value, stringBuilder.ToString());		
		}
	}
}
