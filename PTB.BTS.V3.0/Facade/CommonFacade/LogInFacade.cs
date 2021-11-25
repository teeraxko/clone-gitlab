using System;

using SystemFramework.AppConfig;

using PTB.BTS.Common.Flow;

namespace Facade.CommonFacade
{
	public class LogInFacade
	{
		#region - Constant -
		#endregion

		#region - Private - 
			private LogInFlow logInFlow;
		#endregion

		//============================== Property ==============================
		private ApplicationUserProfile userProfile;
		public string UserName
		{
			set
			{
				clearUserProfile();
				userProfile.UserName = value;
			}
		}

		public string Password
		{
			set
			{
				userProfile.Password = value;
			}
		}

		//============================== Constructor ==============================
		public LogInFacade()
		{
			logInFlow = new LogInFlow();
			userProfile = new ApplicationUserProfile();
		}

		//============================== Private Method ==============================
		private void clearUserProfile()
		{
			userProfile.UserName = "";
			userProfile.Password = "";
			userProfile.UserRole = USER_ROLE.USER;
		}

		//============================== Public Method ==============================
		public ApplicationUserProfile GetUserProfile()
		{
			if(logInFlow.IsValidLogIn(userProfile))
			{
				return userProfile;
			}
			else
			{
				return null;
			}
		}

		public bool ChangePassword(string newPassword)
		{
			return logInFlow.ChangePassword(userProfile, newPassword);
		}

		public ApplicationUserPermission GetUserPermission(ApplicationUserProfile value)
		{
			PermissionFlow flowPermission = new PermissionFlow();
			ApplicationUserPermission userPermission = flowPermission.GetUserPermission(value);
			flowPermission = null;
			return userPermission;
		}
	}
}