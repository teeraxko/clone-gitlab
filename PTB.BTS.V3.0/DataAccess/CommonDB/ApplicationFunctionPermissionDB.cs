using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using DataAccess.CommonDB;

using SystemFramework.AppConfig;

namespace DataAccess.CommonDB
{
	public class ApplicationFunctionPermissionDB : DataAccessBase
	{
		#region - Constant -
		private const int MODULE_NAME = 0;
		private const int FUNCTION_NAME = 1;
		private const int USER_NAME = 2;
		private const int PERMISSION_LEVEL = 3;
		#endregion

		#region - Private -	
			private ApplicationFunctionDB dbApplicationFunction;
		#endregion

//		============================== Constructor ==============================
		public ApplicationFunctionPermissionDB() : base()
		{
			dbApplicationFunction = new ApplicationFunctionDB();
		}

//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
			return " SELECT Module_Name, Function_Name, User_Name, Permission_Level FROM Application_Function_Permission ";
		}

		private string getSQLInsert(ModulePermission aModulePermission, FunctionPermission aFunctionPermission, ApplicationUserProfile aApplicationUserProfile)
		{
			StringBuilder stringBuilder = new StringBuilder(" INSERT INTO Application_Function_Permission (Module_Name, Function_Name, User_Name, Permission_Level, Process_Date, Process_User) ");
			stringBuilder.Append(" VALUES ( ");
			//Module_Name
			stringBuilder.Append(GetDB(aModulePermission.Name));
			stringBuilder.Append(", ");

			//Function_Name
			stringBuilder.Append(GetDB(aFunctionPermission.Name));
			stringBuilder.Append(", ");

			//User_Name
			stringBuilder.Append(GetDB(aApplicationUserProfile.UserName));
			stringBuilder.Append(", ");

			//Permission_Level
			stringBuilder.Append(GetDB(aFunctionPermission.PermissionDB)); 
			stringBuilder.Append(", ");

			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(")");

			return stringBuilder.ToString();
		}

		private string getSQLUpdate(FunctionPermission value, Module module, ApplicationUserProfile userProfile)
		{
			StringBuilder stringBuilder = new StringBuilder(" UPDATE Application_Function_Permission SET ");
			stringBuilder.Append("Module_Name = ");
			stringBuilder.Append(GetDB(module.Name));
			stringBuilder.Append(", ");

			stringBuilder.Append("Function_Name = ");
			stringBuilder.Append(GetDB(value.Name));
			stringBuilder.Append(", ");

			stringBuilder.Append("User_Name = ");
			stringBuilder.Append(GetDB(userProfile.UserName));
			stringBuilder.Append(", ");

			stringBuilder.Append("Permission_Level = ");
			stringBuilder.Append(GetDB(value.PermissionDB)); 
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
			return " DELETE FROM Application_Function_Permission ";
		}

		private string getKeyCondition(Module value)
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

		private string getKeyCondition(FunctionPermission value)
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

		private string getKeyCondition(ApplicationUserProfile value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if(IsNotNULL(value.UserName))
			{
				stringBuilder.Append(" AND (User_Name = ");
				stringBuilder.Append(GetDB(value.UserName));
				stringBuilder.Append(")");
			}
			return stringBuilder.ToString();
		}

		private string getOrderby()
		{
			return " ORDER BY Function_Name ";
		}

		private string insertApplicationFunctionPermission(ModulePermission value, ApplicationUserProfile userProfile)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for(int i=0; i < value.Count; i++)
			{
				stringBuilder.Append(getSQLInsert(value, value[i], userProfile));
			}
			return stringBuilder.ToString();
		}

		public string updateApplicationFunctionPermission(FunctionPermission value, Module module, ApplicationUserProfile userProfile)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value, module, userProfile));
			stringBuilder.Append(getBaseCondition());
			stringBuilder.Append(getKeyCondition(module));
			stringBuilder.Append(getKeyCondition(value));
			stringBuilder.Append(getKeyCondition(userProfile));

			return stringBuilder.ToString();
		}
		#endregion

		#region - Fill -
		#endregion

//		============================== Public Method ==============================				
		public bool FillApplicationFunctionPermission(ref ModulePermission value, ApplicationModule applicationModule, ApplicationUserProfile user)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition());
			stringBuilder.Append(getKeyCondition(value.Module));
			stringBuilder.Append(getKeyCondition(user));
			stringBuilder.Append(getOrderby());

			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(stringBuilder.ToString());
			try
			{
				FunctionPermission functionPermission;
				string functionName;
				while (dataReader.Read())
				{
					result = true;
					functionName = (string)dataReader[FUNCTION_NAME];
					functionPermission = new FunctionPermission(applicationModule[functionName].Function);
					functionPermission.PermissionDB = (string)dataReader[PERMISSION_LEVEL];
					value.Add(functionPermission);
				}

                ModulePermission tempModulePermission = new ModulePermission();
                tempModulePermission.Module = applicationModule.Module;

                for (int i = 0; i < applicationModule.Count; i++)
                {
                    if (value.Contain(applicationModule[i].Function.Name))
                    {
                        tempModulePermission.Add(value[applicationModule[i].Function.Name]);
                    }
                }

                value = new ModulePermission();
                value.Module = applicationModule.Module;

                for (int i = 0; i < tempModulePermission.Count; i++)
                {
                    value.Add(tempModulePermission[i]);                    
                }
                tempModulePermission = null;
			}
			finally
			{
				tableAccess.CloseDataReader();
				stringBuilder = null;
			}
			return result;
		}

		public bool InsertApplicationFunctionPermission(ModulePermission value, ApplicationUserProfile userProfile)
		{
			if (tableAccess.ExecuteSQL(insertApplicationFunctionPermission(value, userProfile))>0)
			{return true;}
			else
			{return false;}
		}

		public bool InsertApplicationFunctionPermission(ApplicationUserPermission value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for(int i=0; i < value.Count; i++)
			{
				stringBuilder.Append(insertApplicationFunctionPermission(value[i], value.AUser));
			}

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool UpdateApplicationFunctionPermission(ModulePermission value, ApplicationUserProfile userProfile)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for(int i=0; i < value.Count; i++)
			{
				stringBuilder.Append(updateApplicationFunctionPermission(value[i], value.Module, userProfile));
			}

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool DeleteApplicationFunctionPermission(ApplicationUserPermission value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition());
			stringBuilder.Append(getKeyCondition(value.AUser));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}
	}
}
