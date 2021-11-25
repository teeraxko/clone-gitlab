using System;

using DataAccess.CommonDB;

using SystemFramework.AppConfig;
using SystemFramework.AppException;

namespace PTB.BTS.Common.Flow
{
	public class LogInFlow
	{
		#region - Constant -
		#endregion

		#region - Private - 
			ApplicationUserProfileDB dbApplicationUserProfile;
		#endregion

		//============================== Property ==============================

		//============================== Constructor ==============================
		public LogInFlow()
		{
			dbApplicationUserProfile = new ApplicationUserProfileDB();
		}

		//============================== Private Method ==============================


		//============================== Public Method ==============================
		public bool IsValidLogIn(ApplicationUserProfile value)
		{
			string encryptPassword = CommonFlow.Encrypt(value.Password);
			value.Password = "";

			if(dbApplicationUserProfile.FillApplicationUserProfile(ref value))
			{
				if(encryptPassword == value.Password)
				{
					return true;
				}
				else
				{
					throw new DataInvalidException("รหัสผ่าน", "LogInFlow");
				}				
			}
			else
			{
				throw new NotFoundException("ชื่อผู้ใช้ในระบบ", "LogInFlow");
			}
		}

		public bool ChangePassword(ApplicationUserProfile value, string newPassword)
		{
			if(IsValidLogIn(value))
			{
				value.Password = CommonFlow.Encrypt(newPassword);
//				value.Password = value.Password.Replace("'", "''");
//				value.Password = value.Password.Replace("\"", "\\\"");
				return dbApplicationUserProfile.UpdateApplicationUserProfile(value);
			}
			else
			{
				return false;
			}
		}

	}
}