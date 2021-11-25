using System;

using SystemFramework.AppConfig;

using DataAccess.CommonDB;

namespace PTB.BTS.Common.Flow
{
	public class PermissionFlow
	{
		#region - Constant -
		#endregion

		#region - Private - 
		private ApplicationModulePermissionDB dbModulePermission;
		private ApplicationUserProfileDB dbApplicationUserProfile;

		private ApplicationModuleDB dbApplicationModule;
		private ApplicationModuleList applicationModuleList;
		#endregion

		//============================== Property ==============================

		//============================== Constructor ==============================
		public PermissionFlow()
		{
			dbModulePermission = new ApplicationModulePermissionDB();
			dbApplicationUserProfile = new ApplicationUserProfileDB();

			dbApplicationModule = new ApplicationModuleDB();
			applicationModuleList = new ApplicationModuleList();
			dbApplicationModule.FillApplicationModule(ref applicationModuleList);
		}

		//============================== Private Method ==============================
		#region - Private - 
			private MODULE_PERMISSION defaultModulePermission(Module value, ApplicationUserProfile userProfile)
			{
				switch(userProfile.UserRole)
				{
					case USER_ROLE.ADMIN :
					{
						return MODULE_PERMISSION.ACCESS;
					}
					case USER_ROLE.POWER_USER :
					{
						if(value.IsSystem)
						{
							return MODULE_PERMISSION.NO_ACCESS;
						}
						else
						{
							return MODULE_PERMISSION.ACCESS;
						}
					}
					default :
					{
						return MODULE_PERMISSION.NO_ACCESS;			
					}
				}
			}

			private FUNCTION_PERMISSION defaultFunctionPermission(Function function, ApplicationUserProfile userProfile)
			{
				switch(userProfile.UserRole)
				{
					case USER_ROLE.ADMIN :
					{
						return FUNCTION_PERMISSION.FULL_CONTROL;
					}
					case USER_ROLE.POWER_USER :
					{
						if(function.IsSystem)
						{
							return FUNCTION_PERMISSION.NO_ACCESS;
						}
						else
						{
							return FUNCTION_PERMISSION.FULL_CONTROL;
						}
					}
					default :
					{
						return FUNCTION_PERMISSION.NO_ACCESS;			
					}
				}
			}
		#endregion

		private ApplicationUserPermission getUserPermissionBlank(ApplicationUserProfile value)
		{
			ApplicationUserPermission userPermission = new ApplicationUserPermission(value);
			
			ApplicationModule applicationModule; 
			ModulePermission modulePermission;
			FunctionPermission functionPermission;

			for(int i=0; i<applicationModuleList.Count; i++)
			{
				applicationModule = applicationModuleList[i];
				modulePermission = new ModulePermission(applicationModule.Module);
				modulePermission.Permission = defaultModulePermission(applicationModule.Module, value);

				for(int j=0; j<applicationModule.Count; j++)
				{
					functionPermission = new FunctionPermission(applicationModule[j].Function);
					functionPermission.Permission = defaultFunctionPermission(functionPermission.Function, value);
					modulePermission.Add(functionPermission);
				}
				userPermission.Add(modulePermission);
			}

			dbModulePermission.InsertApplicationModulePermission(userPermission);
			return userPermission;
		}

		//============================== Public Method ==============================
		public ApplicationUserPermission GetUserPermission(ApplicationUserProfile value)
		{
			ApplicationUserPermission userPermission = new ApplicationUserPermission(value);
			if(dbModulePermission.FillApplicationModulePermission(ref userPermission))
			{
				return userPermission;
			}
			else
			{
				return getUserPermissionBlank(value);
			}
		}
		
		public bool FillUserPermissionList(ref ApplicationUserPermissionList value)
		{
			ApplicationUserPermissionList userPermissionList = new ApplicationUserPermissionList();
			dbModulePermission.FillApplicationModulePermissionList(ref userPermissionList);
			
			ApplicationUserProfileList userProfileList = new ApplicationUserProfileList();
			dbApplicationUserProfile.FillApplicationUserProfileList(ref userProfileList);
			
			ApplicationUserPermission userPermission;
			for(int i=0; i<userProfileList.Count; i++)
			{
				if(userPermissionList.Contain(userProfileList[i].UserName))
				{
					value.Add(userPermissionList[userProfileList[i].UserName]);
				}
				else
				{
					userPermission = getUserPermissionBlank(userProfileList[i]);
					value.Add(userPermission);
				}
			}

			return (value.Count>0);
		}

		public bool UpdateModulePermission(ModulePermission value, ApplicationUserProfile userProfile)
		{
			return dbModulePermission.UpdatePermissionOfModule(value, userProfile);
		}

		public bool UpdateFunctionPermission(ModulePermission value, ApplicationUserProfile userProfile)
		{
			ApplicationFunctionPermissionDB dbApplicationFunctionPermission = new ApplicationFunctionPermissionDB();
			return dbApplicationFunctionPermission.UpdateApplicationFunctionPermission(value, userProfile);
		}

		public bool DeleteUserPermission(ApplicationUserPermission value)
		{
			return dbModulePermission.DeleteApplicationModulePermission(value);
		}
	}
}
