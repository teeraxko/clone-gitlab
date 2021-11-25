using System;

namespace SystemFramework.AppConfig
{
	public class UserProfile
	{
		public static string UserID
		{
			get
			{
				return ictus.Framework.ASC.AppConfig.UserProfile.UserID;
			}
			set
			{
                ictus.Framework.ASC.AppConfig.UserProfile.UserID = value;
			}
		}

		private static USER_ROLE userROLE = USER_ROLE.USER;
		public static USER_ROLE UserROLE
		{
			get
			{
				return userROLE;
			}
			set
			{
				userROLE = value;
			}
		}

		private static ApplicationUserPermission appUserPermission;
		public static ApplicationUserPermission AppUserPermission
		{
			set
			{
				appUserPermission = value;
			}
		}

		public static bool IsReadOnly(string moduleName, string functionName)
		{
			if(appUserPermission.Contain(moduleName))
			{
				ModulePermission modulePermission = appUserPermission[moduleName];
				if(modulePermission.Contain(functionName))
				{
					if(modulePermission[functionName].Permission == FUNCTION_PERMISSION.FULL_CONTROL)
					{
						return false;
					}
				}
			}
			return true;
		}

        public static string GetFormName(string moduleName, string functionName)
        {
            if (appUserPermission.Contain(moduleName))
            {
                ModulePermission modulePermission = appUserPermission[moduleName];
                if (modulePermission.Contain(functionName))
                {
                    return modulePermission[functionName].Description;
                }
            }
            return "";
        }

        public static string GetFormID(string moduleName, string functionName)
        {
            if (appUserPermission.Contain(moduleName))
            {
                ModulePermission modulePermission = appUserPermission[moduleName];
                if (modulePermission.Contain(functionName))
                {
                    return modulePermission[functionName].ID;
                }
            }
            return "";
        }
	}
}
