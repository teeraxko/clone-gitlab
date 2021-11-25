using System;

namespace SystemFramework.AppConfig
{
	public enum USER_ROLE
	{
		ADMIN,
		POWER_USER,
		USER
	}

	public class ApplicationUserProfile
	{
//		============================== Property ==============================
        public string UserID
        {
            set { ictus.Framework.ASC.AppConfig.UserProfile.UserID = value; }
            get { return ictus.Framework.ASC.AppConfig.UserProfile.UserID; }
        }
        
        private string userName = "";
		public string UserName
		{
			set{userName = value;}
			get{return userName;}
		}

		private string password = "";
		public string Password
		{
			set
			{password = value;}
			get{return password;}
		}

		private USER_ROLE userRole = USER_ROLE.USER;
		public USER_ROLE UserRole
		{
			set{userRole = value;}
			get{return userRole;}
		}

		public string UserRoleDB
		{
			get
			{
				switch(userRole)
				{
					case USER_ROLE.ADMIN :
					{
						return "9";
					}
					case USER_ROLE.POWER_USER :
					{
						return "5";
					}
					default :
					{
						return "1";
					}
				}
			}
			set
			{
				switch(value)
				{
					case "9" :
					{
						userRole = USER_ROLE.ADMIN;
						break;
					}
					case "5" :
					{
						userRole = USER_ROLE.POWER_USER;
						break;
					}
					default :
					{
						userRole = USER_ROLE.USER;
						break;
					}
				}
			}
		}

		public string UserRoleString
		{
			get
			{
				switch(userRole)
				{
					case USER_ROLE.ADMIN :
					{
						return "IT Admin";
					}
					case USER_ROLE.POWER_USER :
					{
						return "ผู้ดูแลระบบ";
					}
					default :
					{
						return "ผู้ใช้";
					}
				}
			}
		}

//		============================== Constructor ==============================
		public ApplicationUserProfile()
		{
		}
	}
}
