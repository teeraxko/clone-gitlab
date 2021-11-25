using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using DataAccess.CommonDB;

using SystemFramework.AppConfig;

namespace DataAccess.CommonDB
{
	public class ApplicationModulePermissionDB : DataAccessBase
	{
		#region - Constant -
		private const int MODULE_NAME = 0;
		private const int USER_NAME = 1;
		private const int PERMISSION_LEVEL = 2;
		#endregion

		#region - Private -	
			private ApplicationModuleDB dbApplicationModule;
			private ApplicationModuleList applicationModuleList;

			private ApplicationFunctionPermissionDB dbApplicationFunctionPermission;

			private ApplicationUserProfileDB dbApplicationUserProfile;
		#endregion

//		============================== Constructor ==============================
		public ApplicationModulePermissionDB()
		{
			dbApplicationModule = new ApplicationModuleDB();
			applicationModuleList = new ApplicationModuleList();
			dbApplicationModule.FillApplicationModule(ref applicationModuleList);

			dbApplicationFunctionPermission = new ApplicationFunctionPermissionDB();

			dbApplicationUserProfile = new ApplicationUserProfileDB();
		}

//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
			return " SELECT Module_Name, User_Name, Permission_Level FROM Application_Module_Permission ";
		}

		private string getSQLInsert(ApplicationUserPermission aApplicationUserPermission, ModulePermission aModulePermission)
		{
			StringBuilder stringBuilder = new StringBuilder(" INSERT INTO Application_Module_Permission (Module_Name, User_Name, Permission_Level, Process_Date, Process_User) ");
			stringBuilder.Append(" VALUES ( ");
			//Module_Name
			stringBuilder.Append(GetDB(aModulePermission.Name));
			stringBuilder.Append(", ");

			//User_Name
			stringBuilder.Append(GetDB(aApplicationUserPermission.AUser.UserName));
			stringBuilder.Append(", ");

			//Permission_Level
			stringBuilder.Append(GetDB(aModulePermission.PermissionDB)); 
			stringBuilder.Append(", ");

			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(")");

			return stringBuilder.ToString();
		}

		private string getSQLUpdate(ModulePermission value, ApplicationUserProfile userProfile)
		{
			StringBuilder stringBuilder = new StringBuilder("UPDATE Application_Module_Permission SET ");
			stringBuilder.Append("Module_Name = ");
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
			return " DELETE FROM Application_Module_Permission ";
		}

		private string getKeyCondition(ModulePermission value)
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
			return " ORDER BY User_Name, Module_Name ";
		}

		#endregion

		#region - Fill -
		private void fillApplicationModulePermission(ref ApplicationUserPermission value, SqlDataReader dataReader)
		{
			string moduleName;
			ModulePermission modulePermission;

			moduleName = (string)dataReader[MODULE_NAME];
			modulePermission = new ModulePermission(applicationModuleList[moduleName].Module);
			dbApplicationFunctionPermission.FillApplicationFunctionPermission(ref modulePermission, applicationModuleList[moduleName], value.AUser);

			modulePermission.PermissionDB = (string)dataReader[PERMISSION_LEVEL];
			value.Add(modulePermission);		
		}

		private bool fillApplicationModulePermission(ref ApplicationUserPermission value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				while (dataReader.Read())
				{
					result = true;
					fillApplicationModulePermission(ref value, dataReader);
				}
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

		private bool fillApplicationModulePermission(ref ApplicationUserPermissionList value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				ApplicationUserProfile userProfile;				
				ApplicationUserPermission applicationUserPermission;

				while (dataReader.Read())
				{
					result = true;
					string UserName = (string)dataReader[USER_NAME];

					if(value.Contain(UserName))
					{
						applicationUserPermission = value[UserName];
						fillApplicationModulePermission(ref applicationUserPermission, dataReader);
					}
					else
					{
						userProfile = new ApplicationUserProfile();
						userProfile.UserName = (string)dataReader[USER_NAME];
						dbApplicationUserProfile.FillApplicationUserProfile(ref userProfile);
					
						applicationUserPermission = new ApplicationUserPermission(userProfile);
						fillApplicationModulePermission(ref applicationUserPermission, dataReader);

						value.Add(applicationUserPermission);
					}
				}
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
		public bool FillApplicationModulePermission(ref ApplicationUserPermission value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition());
			stringBuilder.Append(getKeyCondition(value.AUser));
			stringBuilder.Append(getOrderby());

			return fillApplicationModulePermission(ref value, stringBuilder.ToString());		
		}

		public bool FillApplicationModulePermission(ref ApplicationUserPermission value, ModulePermission aModulePermission)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition());
			stringBuilder.Append(getKeyCondition(value.AUser));
			stringBuilder.Append(getKeyCondition(aModulePermission));

			return fillApplicationModulePermission(ref value, stringBuilder.ToString());		
		}

		public bool FillApplicationModulePermissionList(ref ApplicationUserPermissionList value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition());
			stringBuilder.Append(getOrderby());

			return fillApplicationModulePermission(ref value, stringBuilder.ToString());
		}

		public bool InsertApplicationModulePermission(ApplicationUserPermission value)
		{
			if(value.Count>0)
			{
				StringBuilder stringBuilder = new StringBuilder();
				for(int i=0; i < value.Count; i++)
				{
					stringBuilder.Append(getSQLInsert(value, value[i]));
				}

				if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
				{
					dbApplicationFunctionPermission.InsertApplicationFunctionPermission(value);
					return true;
				}
				else
				{return false;}
			}
			else
			{return false;}	
		}

		// Update ModulePermission property
		public bool UpdatePermissionOfModule(ModulePermission value, ApplicationUserProfile userProfile)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value, userProfile));
			stringBuilder.Append(getBaseCondition());
			stringBuilder.Append(getKeyCondition(value));
			stringBuilder.Append(getKeyCondition(userProfile));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool DeleteApplicationModulePermission(ApplicationUserPermission value)
		{
			if(dbApplicationFunctionPermission.DeleteApplicationFunctionPermission(value))
			{
				StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
				stringBuilder.Append(getBaseCondition());
				stringBuilder.Append(getKeyCondition(value.AUser));

				return (tableAccess.ExecuteSQL(stringBuilder.ToString())>0);
			}
			return false;
		}
	}
}
